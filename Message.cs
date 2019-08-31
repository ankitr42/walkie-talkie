using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WalkieTalkie
{
    class Message
    {
        private IPEndPoint destEndPoint;
        private string message;

        public Message(IPEndPoint destEP, string content)
        {
            destEndPoint = destEP;
            message = content;
        }

        public IPEndPoint DestinationEndPoint
        {
            get { return destEndPoint; }
            set { destEndPoint = value; }
        }

        public string Content
        {
            get { return message; }
            set { message = value; }
        }
    }
}
