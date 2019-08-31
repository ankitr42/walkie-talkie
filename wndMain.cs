using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Web;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WalkieTalkie
{
    public partial class wndMain : Form
    {
        private const int inPort = 2009;
        private const int outPort = 2012;
        private const int errorPort = 2013;
        private const bool loggingEnabled = false;

        private string userName = null;
        private string tempString;
        private bool statusSet;
        private IPAddress myAddress;
        private List<User> usersOnline;
        private List<wndPrivateChat> activePvtChatWindows;
        private List<Message> inBox, outBox;
        private UdpClient udpSender, udpReceiver;

        public wndMain()
        {
            InitializeComponent();

            statusSet = false;
            userName = Configuration.UserName;
            if (userName.Length == 0)
            {
                userName = Environment.UserName;
                Configuration.UserName = userName;
            }

            lblUserName.Text = userName;

            inBox = new List<Message>();
            outBox = new List<Message>();
            usersOnline = new List<User>();
            activePvtChatWindows = new List<wndPrivateChat>();
            tempString = Dns.GetHostName();

            try
            {
                if (Configuration.LANIP == null)
                {
                    IPHostEntry heserver = Dns.GetHostEntry(tempString);
                    foreach (IPAddress currAdd in heserver.AddressList)
                    {
                        if (currAdd.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                        {
                            myAddress = currAdd;
                            Configuration.LANIP = myAddress;
                            break;
                        }
                    }
                }
                else
                    myAddress = Configuration.LANIP;

                udpSender = new UdpClient(new IPEndPoint(new IPAddress(myAddress.GetAddressBytes()), outPort));
                udpReceiver = new UdpClient(new IPEndPoint(new IPAddress(myAddress.GetAddressBytes()), inPort));
            }
            catch (Exception)
            {
                MessageBox.Show("LAN Not Connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void wndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall && e.CloseReason != CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                this.Visible = false;
                sysTrayNotifier.ShowBalloonTip(7000, "WalkieTalkie Minimized", "WalkieTalkie has been minimized to the system tray. You can restore the program by double clicking the tray icon.", ToolTipIcon.Info);
            }
            else
                SayBye();
        }

        private void bgWUserFinder_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] ipAddressBytes = new byte[4];
            // byte[] dataBytes;
            byte myLastByte;
            IPAddress ipAddress;

            lblScanning.Text = "Scanning for users...";
            ipAddressBytes = myAddress.GetAddressBytes();
            myLastByte = ipAddressBytes[3];

            try
            {
                // dataBytes = Encoding.Unicode.GetBytes("CMD HELLO " + userName);
                for (int i = 1; i <= 100; i++)
                {
                    if (i != myLastByte)
                    {
                        ipAddressBytes[3] = (byte)i;
                        ipAddress = new IPAddress(ipAddressBytes);

                        if (User.FindUserWithIP(usersOnline, ipAddress) == null)
                            outBox.Add(new Message(new IPEndPoint(ipAddress, inPort), "CMD HELLO " + userName));
                            // udpSender.Send(dataBytes, dataBytes.Length, new IPEndPoint(ipAddress, inPort));
                    }
                }
            }
            catch (SocketException ex)
            {
                tempString = "A SocketException occured in bgWUserFinder_DoWork()" + Environment.NewLine;
                tempString += "Source machine: " + myAddress.ToString() + Environment.NewLine;
                tempString += "Socket error code: " + ex.SocketErrorCode.ToString() + Environment.NewLine;

                //udpSender.Send(Encoding.ASCII.GetBytes(tempString), tempString.Length, "192.168.12.84", errorPort);
                outBox.Add(new Message(new IPEndPoint(IPAddress.Parse("192.168.12.84"), errorPort), tempString));
                MessageBox.Show("An exception occured in bgWUserFinder_DoWork", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblScanning.Text = "  ";
        }

        private void bgWDataCollector_DoWork(object sender, DoWorkEventArgs e)
        {
            string data = "", tempString;
            string[] dataComponents;
            byte[] dataBytes;
            IPEndPoint senderEP = new IPEndPoint(0, 0);
            User user;

            while (!e.Cancel)
            {
                try
                {
                    dataBytes = udpReceiver.Receive(ref senderEP);
                    if (true)
                        File.AppendAllText("walkietalkie.receive.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);
                    data = Encoding.Unicode.GetString(dataBytes);

                    if (data.StartsWith("CMD"))
                    {
                        dataComponents = data.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (dataComponents[1] == "HELLO")
                        {
                            // rTxtChatRoomText.Text += "Hello from " + senderEP.Address.ToString() + Environment.NewLine;
                            if (User.FindUserWithIP(usersOnline, senderEP.Address) == null)
                            {
                                user = new User(dataComponents[2], "", senderEP.Address);
                                lstUsersOnline.Items.Add(user);
                                usersOnline.Add(user);

                                sysTrayNotifier.ShowBalloonTip(3000, "User online", user.UserName + " is now online.", ToolTipIcon.Info);
                            }

                            outBox.Add(new Message(new IPEndPoint(new IPEndPoint(senderEP.Address, inPort), "CMD IAM " + userName)));
                            //dataBytes = Encoding.Unicode.GetBytes("CMD IAM " + userName);
                            //udpSender.Send(dataBytes, dataBytes.Length, new IPEndPoint(senderEP.Address, inPort));
                            if (loggingEnabled)
                                File.AppendAllText("walkietalkie.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);

                            if (statusSet)
                            {
                                outBox.Add(new Message(new IPEndPoint(new IPEndPoint(senderEP.Address, inPort), "STATUS " + txtStatusMessage.Text)));
                                //dataBytes = Encoding.Unicode.GetBytes("STATUS " + txtStatusMessage.Text);
                                //udpSender.Send(dataBytes, dataBytes.Length, new IPEndPoint(senderEP.Address, inPort));
                                if (loggingEnabled)
                                    File.AppendAllText("walkietalkie.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);
                            }
                        }
                        else if (dataComponents[1] == "IAM")
                        {
                            // rTxtChatRoomText.Text += "IAM from " + senderEP.Address.ToString() + Environment.NewLine;
                            if (User.FindUserWithIP(usersOnline, senderEP.Address) == null)
                            {
                                user = new User(dataComponents[2], "", senderEP.Address);
                                usersOnline.Add(user);
                                lstUsersOnline.Items.Add(user);
                            }
                        }
                        else if (dataComponents[1] == "BYE")
                        {
                            // rTxtChatRoomText.Text += "BYE from " + senderEP.Address.ToString() + Environment.NewLine;
                            user = User.FindUserWithIP(usersOnline, senderEP.Address);

                            if (user != null)
                            {
                                lstUsersOnline.Items.Remove(user);
                                usersOnline.Remove(user);

                                sysTrayNotifier.ShowBalloonTip(3000, "User offline", user.UserName + " is now offline.", ToolTipIcon.Info);
                            }
                        }
                    }
                    else if (data.StartsWith("STATUS"))
                    {
                        // rTxtChatRoomText.Text += data + " from " + senderEP.Address.ToString() + Environment.NewLine;
                        user = User.FindUserWithIP(usersOnline, senderEP.Address);
                        if (user != null)
                            user.StatusMessage = data.Substring(data.IndexOf(" ") + 1);

                        lstUsersOnline.Items.Clear();
                        foreach (User tUser in usersOnline)
                            lstUsersOnline.Items.Add(tUser);
                    }
                    else if (data.StartsWith("NOSTATUS"))
                    {
                        // rTxtChatRoomText.Text += "NOSTATUS from " + senderEP.Address.ToString() + Environment.NewLine;
                        user = User.FindUserWithIP(usersOnline, senderEP.Address);
                        if (user != null)
                            user.StatusMessage = String.Empty;

                        lstUsersOnline.Items.Clear();
                        foreach (User tUser in usersOnline)
                            lstUsersOnline.Items.Add(tUser);
                    }
                    else if (data.StartsWith("MSG"))
                    {
                        rTxtChatRoomText.AppendText(DateTime.Now.ToLongTimeString() + ": " + data.Substring(data.IndexOf(" ") + 1) + Environment.NewLine);
                        if (!this.Visible)
                            sysTrayNotifier.ShowBalloonTip(5000, "New Message", "There are new messages in the chatroom.", ToolTipIcon.Info);
                    }
                    else if (data.StartsWith("PMSG"))
                    {

                    }
                }
                catch (SocketException ex)
                {
                    tempString = "A SocketException occured in bgWDataCollector_DoWork()" + Environment.NewLine;
                    tempString += "Source machine: " + senderEP.Address.ToString() + Environment.NewLine;
                    tempString += "Destination machine: " + myAddress.ToString() + Environment.NewLine;
                    tempString += "Socket error code: " + ex.SocketErrorCode.ToString() + Environment.NewLine;
                    tempString += "Data: " + (string)data;

                    outBox.Add(new Message(new IPEndPoint(IPAddress.Parse("192.168.12.84"), errorPort), tempString));
                    //udpSender.Send(Encoding.ASCII.GetBytes(tempString), tempString.Length, "192.168.12.84", errorPort);
                    MessageBox.Show("An error occured while trying to retrieve a message. The developer has been informed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bgWDataSender_DoWork(object sender, DoWorkEventArgs e)
        {
            //byte[] dataBytes = Encoding.Unicode.GetBytes("MSG " + (string)e.Argument);
            string tempString;

            if (dataBytes.Length > 0)
            {
                foreach (User user in usersOnline)
                {
                    try
                    {
                        outBox.Add(new Message(new IPEndPoint(user.IP, inPort), "MSG " + (string)e.Argument));
                        //udpSender.Send(dataBytes, dataBytes.Length, new IPEndPoint(user.IP, inPort));
                        //if (loggingEnabled)
                            //File.AppendAllText("walkietalkie.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);
                    }
                    catch (SocketException ex)
                    {
                        tempString = "A SocketException occured in bgWDataSender_DoWork()" + Environment.NewLine;
                        tempString += "Source machine: " + myAddress.ToString() + Environment.NewLine;
                        tempString += "Destination machine: " + user.IP.ToString() + Environment.NewLine;
                        tempString += "Socket error code: " + ex.SocketErrorCode.ToString() + Environment.NewLine;
                        tempString += "Data: " + (string)e.Argument;

                        outBox.Add(new Message(new IPEndPoint(IPAddress.Parse("192.168.12.84"), errorPort), tempString));
                        //udpSender.Send(Encoding.ASCII.GetBytes(tempString), tempString.Length, "192.168.12.84", errorPort);
                        //if (loggingEnabled)
                        //    File.AppendAllText("walkietalkie.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);
                        MessageBox.Show("An error occured while sending message to " + user.UserName + Environment.NewLine + "The developer has been informed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            dlgFontSelector.Font = rTxtUserText.Font;
            if (dlgFontSelector.ShowDialog(this) == DialogResult.OK)
            {
                rTxtUserText.Font = dlgFontSelector.Font;
                btnFont.Text = rTxtUserText.Font.Name + " " + rTxtUserText.Font.Size.ToString() + "pt";
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (dlgColorPicker.ShowDialog(this) == DialogResult.OK)
            {
                rTxtUserText.ForeColor = dlgColorPicker.Color;
                btnColor.ForeColor = dlgColorPicker.Color;
            }
        }

        private void rTxtUserText_TextChanged(object sender, EventArgs e)
        {
            if (rTxtUserText.Text.Length == 0)
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }

        private void rTxtUserText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Modifiers != Keys.Control)
                {
                    btnSend_Click(rTxtUserText, null);
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void rTxtChatRoomText_TextChanged(object sender, EventArgs e)
        {
            rTxtChatRoomText.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (btnSend.Enabled)
            {
                rTxtUserText.Text = userName + ": " + rTxtUserText.Text;
                rTxtChatRoomText.AppendText(DateTime.Now.ToLongTimeString() + ": " +  rTxtUserText.Text + Environment.NewLine);

                while (bgWDataSender.IsBusy)
                    ;
                
                bgWDataSender.RunWorkerAsync(rTxtUserText.Text);

                rTxtUserText.Text = "";
                rTxtUserText.Focus();
            }
        }

        private void bgWUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] addressBytes = myAddress.GetAddressBytes();
            string versionString, downloadlink;

            try
            {
                addressBytes[3] = 84;
                XmlReader updateChecker = XmlReader.Create("http://" + (new IPAddress(addressBytes)).ToString() + "/updates.xml");

                updateChecker.Read();
                updateChecker.ReadStartElement("programs");
                updateChecker.ReadStartElement("walkietalkie");
                
                updateChecker.ReadStartElement("version");
                versionString = updateChecker.ReadString();
                updateChecker.ReadEndElement();
                
                updateChecker.ReadStartElement("downloadlink");
                downloadlink = updateChecker.ReadString();
                updateChecker.ReadEndElement();
                
                updateChecker.ReadEndElement();
                updateChecker.ReadEndElement();

                updateChecker.Close();

                if (Application.ProductVersion != versionString)
                    if (MessageBox.Show("A new version of the application is available. Do you want to download it?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        MessageBox.Show("Please note that due to version differences, you may not be able to see and communicate with people using " +
                                        "the newer version of the application. Updating to the latest version is thus strongly recommended.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        Process.Start(downloadlink);
            }
            catch (Exception) {  }
        }

        private void mnuBtnAbout_Click(object sender, EventArgs e)
        {
            string aboutString;

            aboutString = Application.ProductName + Environment.NewLine;
            aboutString += "Version: " + Application.ProductVersion + Environment.NewLine;
            aboutString += Environment.NewLine;
            aboutString += "Developed by:" + Environment.NewLine;
            aboutString += "Ankit Rajpoot (ankitr.42@gmail.com)" + Environment.NewLine;
            aboutString += "MCA Batch of 2012" + Environment.NewLine;
            aboutString += "National Institute of Technology, Trichy" + Environment.NewLine;
            aboutString += Environment.NewLine;
            aboutString += "Developed specifically for: " + Environment.NewLine;
            aboutString += "MCA Batch of 2012 (2009 - 2012)"  + Environment.NewLine;
            aboutString += "National Institute of Technology, Trichy";


            MessageBox.Show(aboutString, "About WalkieTalkie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuBtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you close WalkieTalkie, you will not be able to send or receive IM messages. Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SayBye();
                Application.Exit();
            }
        }

        private void sysTrayNotifier_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void sysTrayMnuBtnExit_Click(object sender, EventArgs e)
        {
            mnuBtnExit_Click(sysTrayMnuBtnExit, e);
        }

        private void mnuBtnSettings_Click(object sender, EventArgs e)
        {
            wndSettings settings = new wndSettings();

            settings.ShowDialog();
        }

        private void wndMain_Shown(object sender, EventArgs e)
        {
            bgWUserFinder.RunWorkerAsync();
            bgWDataCollector.RunWorkerAsync();
            bgWUpdater.RunWorkerAsync();

            btnFont.Text = rTxtUserText.Font.Name + " " + rTxtUserText.Font.SizeInPoints.ToString() + "pt";

            if (Environment.CommandLine.Contains("systray"))
                this.Visible = false;
        }

        private void btnRefreshUserList_Click(object sender, EventArgs e)
        {
            if (!bgWUserFinder.IsBusy)
            {
                lstUsersOnline.Items.Clear();
                
                usersOnline.Clear();
                bgWUserFinder.RunWorkerAsync();
            }
        }

        private void rTxtChatRoomText_Enter(object sender, EventArgs e)
        {
            rTxtUserText.Focus();
        }

        private void btnSaveChat_Click(object sender, EventArgs e)
        {
            if (dlgSaveRtf.ShowDialog() == DialogResult.OK)
                rTxtChatRoomText.SaveFile(dlgSaveRtf.FileName);
        }

        private void txtStatusMessage_Enter(object sender, EventArgs e)
        {
            txtStatusMessage.BackColor = Color.White;
            txtStatusMessage.SelectAll();
            if (!statusSet)
                txtStatusMessage.Text = "";
        }

        private void txtStatusMessage_Leave(object sender, EventArgs e)
        {
            txtStatusMessage.BackColor = SystemColors.Control;
            if (txtStatusMessage.Text.Length > 0)
            {
                statusSet = true;
                UpdateMyStatus(txtStatusMessage.Text);
            }
            else
            {
                statusSet = false;
                txtStatusMessage.Text = "Type here to set your status...";
                UpdateMyStatus("");
            }
        }

        private void txtStatusMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                rTxtUserText.Focus();
            }
        }

        private void UpdateMyStatus(string status)
        {
            string data;

            lblUserName.Text = userName + " - " + status;

            if (status.Length > 0)
                data = Encoding.Unicode.GetBytes("STATUS " + status);
            else
                data = Encoding.Unicode.GetBytes("NOSTATUS");

            foreach (User user in usersOnline)
            {
                try
                {
                    outBox.Add(new Message(new IPEndPoint(user.IP, inPort), data));
                    //udpSender.Send(dataBytes, dataBytes.Length, new IPEndPoint(user.IP, inPort));
                    //if (loggingEnabled)
                    //    File.AppendAllText("walkietalkie.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);
                }
                catch (SocketException) { }
            }
        }

        private void SayBye()
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes("CMD BYE");

            try
            {
                foreach (User user in usersOnline)
                {
                    outBox.Add(new Message(new IPEndPoint(user.IP, inPort), "CMD BYE"));
                    //udpSender.Send(dataBytes, dataBytes.Length, new IPEndPoint(user.IP, inPort));
                    //if (loggingEnabled)
                    //    File.AppendAllText("walkietalkie.log", Encoding.Unicode.GetString(dataBytes) + Environment.NewLine);
                }
            }
            catch (Exception) { }
        }

        private void txtStatusMessage_Click(object sender, EventArgs e)
        {
            txtStatusMessage_Enter(sender, e);
        }

        private void lstUsersOnline_DoubleClick(object sender, EventArgs e)
        {
            if (lstUsersOnline.SelectedItem != null)
                PrivateChatManager.StartPrivateChat(IPAddress.Parse("192.168.12.84"), (User)lstUsersOnline.SelectedItem);
        }
    }
}