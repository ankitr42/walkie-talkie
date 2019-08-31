using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WalkieTalkie
{
    public partial class wndSettings : Form
    {
        public wndSettings()
        {
            InitializeComponent();
        }

        public new DialogResult ShowDialog()
        {
            RegistryKey key;
            DialogResult result;
            string startupCommand;

            txtUserName.Text = Configuration.UserName;
            txtIPAddress.Text = Configuration.LANIP.ToString();

            key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            startupCommand = (string)key.GetValue("WalkieTalkie", null);
            key.Close();
            if (startupCommand != null)
            {
                chkAutoStart.Checked = true;
                if (startupCommand.Contains("systray"))
                    chkStartMinimized.Checked = true;
            }
            chkShowGroupNotification.Checked = Configuration.GroupChatNotifications;

            result = base.ShowDialog();
            if (result == DialogResult.OK)
            {
                Configuration.SaveConfiguration();
                MessageBox.Show("The new settings will take effect after restarting the program.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RegistryKey key;
            string startupCommand;

            if (txtUserName.Text.Contains(" "))
            {
                MessageBox.Show("Username cannot have embedded spaces.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Configuration.UserName = txtUserName.Text;
                System.Net.IPAddress tIPAdd;

                if (!System.Net.IPAddress.TryParse(txtIPAddress.Text, out tIPAdd))
                {
                    MessageBox.Show("Invalid IP Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Configuration.LANIP = tIPAdd;

                if (chkAutoStart.Checked)
                {
                    key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                    startupCommand = Application.ExecutablePath;
                    if (chkStartMinimized.Checked)
                        startupCommand += " -systray";

                    key.SetValue("WalkieTalkie", startupCommand);
                    key.Close();
                }
                Configuration.GroupChatNotifications = chkShowGroupNotification.Checked;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }
    }
}