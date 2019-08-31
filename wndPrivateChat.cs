using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Media;

namespace WalkieTalkie
{
    public partial class wndPrivateChat : Form
    {
        private int uniqueID;
        private User remoteUser;

        public wndPrivateChat(int uID, IPEndPoint eP, User rUser)
        {
            uniqueID = uID;
            remoteUser = rUser;

            InitializeComponent();

            this.Text = remoteUser.ToString() + " Private Chat";
        }
        public int UniqueID
        {
            get { return uniqueID; }
        }
        public User RemoteUser
        {
            get { return remoteUser; }
        }

        public wndPrivateChat FindActiveChatSession(List<wndPrivateChat> activeSessions, IPAddress destAddress)
        {
            foreach (wndPrivateChat window in activeSessions)
                if (destAddress == window.remoteUser.IP)
                    return window;
            return null;
        }
    }
}
