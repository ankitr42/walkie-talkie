using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;

namespace WalkieTalkie
{
    public static class PrivateChatManager
    {
        private const int inPort = 2014, outPort = 2015;
        private const int minUID = 1000, maxUID = 2000;
        private static BackgroundWorker bgDataSender, bgDataCollector;
        private static UdpClient udpSender, udpReceiver;
        private static List<wndPrivateChat> activeChatWindows;

        private static Random randomGenerator;

        static PrivateChatManager()
        {
            // BackgroundWorkers
            bgDataCollector = new BackgroundWorker();
            bgDataCollector.DoWork += new DoWorkEventHandler(bgDataCollector_DoWork);
            bgDataSender = new BackgroundWorker();
            bgDataSender.DoWork += new DoWorkEventHandler(bgDataSender_DoWork);
            
            bgDataSender = new BackgroundWorker();

            udpSender = new UdpClient(new IPEndPoint(new IPAddress(Configuration.LANIP.GetAddressBytes()), outPort));
            udpReceiver = new UdpClient(new IPEndPoint(new IPAddress(Configuration.LANIP.GetAddressBytes()), inPort));

            activeChatWindows = new List<wndPrivateChat>();

            randomGenerator = new Random();
        }

        static void bgDataSender_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        static void bgDataCollector_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        public static void StartPrivateChat(IPAddress destAddr, User remoteUser)
        {
            wndPrivateChat chatWindow = new wndPrivateChat(randomGenerator.Next(minUID, maxUID), new IPEndPoint(destAddr, inPort), remoteUser);
            chatWindow.Show();
            
            activeChatWindows.Add(chatWindow);
        }

        public static void Shutdown()
        {
        }
    }
}
