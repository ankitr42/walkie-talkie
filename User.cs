using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace WalkieTalkie
{
    public class User
    {
        private string userName;
        private string statusMessage;
        private IPAddress ipAddress;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; }
        }

        public IPAddress IP
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public User(string name, string status, IPAddress ip)
        {
            userName = name;
            statusMessage = status;
            ipAddress = ip;
        }

        public override string ToString()
        {
            return userName + ((statusMessage.Length > 0) ? " - " + statusMessage : "");
        }

        public static User FindUserWithIP(List<User> userList, IPAddress ipToCompare)
        {
            foreach (User user in userList)
                if (user.IP.ToString() == ipToCompare.ToString())
                    return userList[userList.IndexOf(user)];

            return null;
        }
    }
}
