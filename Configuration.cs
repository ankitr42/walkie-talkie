using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WalkieTalkie
{
    public static class Configuration
    {
        private static string userName;
        private static System.Drawing.Size windowSize;
        private static IPAddress lanIP;
        private static bool groupChatNotifications;
        private static XmlDocument settingsDoc;

        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public static System.Drawing.Size WindowSize
        {
            get { return windowSize; }
            set { windowSize = value; }
        }

        public static IPAddress LANIP
        {
            get { return lanIP; }
            set { lanIP = value; }
        }

        public static bool GroupChatNotifications
        {
            get { return groupChatNotifications; }
            set { groupChatNotifications = value; }
        }

        static Configuration()
        {
            try
            {
                string defaultConfig = "<?xml version=\"1.0\" encoding=\"utf-8\"?><WalkieTalkie><Settings>" +
                                       "<UserName /><WindowSize>799,498</WindowSize><LanIP /><GroupChatNotifications>yes</GroupChatNotifications></Settings></WalkieTalkie>";
                string[] tempStrings;
                byte[] addressBytes = new byte[4];

                settingsDoc = new XmlDocument();
                if (!File.Exists("walkietalkie.xml"))
                    settingsDoc.LoadXml(defaultConfig);
                else
                    settingsDoc.Load("walkietalkie.xml");

                userName = settingsDoc.GetElementsByTagName("UserName")[0].InnerText;

                tempStrings = settingsDoc.GetElementsByTagName("WindowSize")[0].InnerText.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                windowSize = new Size(Convert.ToInt32(tempStrings[0]), Convert.ToInt32(tempStrings[1]));

                lanIP = null;
                tempStrings = settingsDoc.GetElementsByTagName("LanIP")[0].InnerText.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (tempStrings.Length == 4)
                {
                    addressBytes[0] = Convert.ToByte(tempStrings[0]);
                    addressBytes[1] = Convert.ToByte(tempStrings[1]);
                    addressBytes[2] = Convert.ToByte(tempStrings[2]);
                    addressBytes[3] = Convert.ToByte(tempStrings[3]);

                    lanIP = new IPAddress(addressBytes);
                }

                groupChatNotifications = (settingsDoc.GetElementsByTagName("GroupChatNotifications")[0].InnerText == "yes") ? true : false;
            }
            catch (Exception) { }
        }

        public static void SaveConfiguration()
        {
            try
            {
                settingsDoc.GetElementsByTagName("UserName")[0].InnerText = userName;
                settingsDoc.GetElementsByTagName("WindowSize")[0].InnerText = windowSize.Width.ToString() + "," + windowSize.Height.ToString();
                settingsDoc.GetElementsByTagName("LanIP")[0].InnerText = LANIP.ToString();
                settingsDoc.GetElementsByTagName("GroupChatNotifications")[0].InnerText = (groupChatNotifications ? "yes" : "no");

                settingsDoc.Save("walkietalkie.xml");
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't save configuration data. Please inform the developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
