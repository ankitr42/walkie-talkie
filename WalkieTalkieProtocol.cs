using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WalkieTalkie
{
    class WalkieTalkieProtocol
    {
        private List<MessageTypeHandler> handlers;
        private UdpClient udpSender, udpReceiver;

        public WalkieTalkieProtocol(IPAddress ip, int inPort, int outPort)
        {
            if (inPort == outPort)
                throw new ArgumentException("inPort and outPort cannot be same");

            handlers = new List<MessageTypeHandler>();
            udpSender = new UdpClient(new IPEndPoint(ip, outPort));
            udpReceiver = new UdpClient(new IPEndPoint(ip, inPort));
        }

        public void AddMessageTypeHandler(string messagePrefix, MessageTypeHandler.MessageProcessor handlerMethod)
        {
            handlers.Add(new MessageTypeHandler(messagePrefix, handlerMethod));
        }

        public void RemoveMessageTypeHandler(string messagePrefix)
        {
            foreach (MessageTypeHandler handler in handlers)
            {
                if (handler.MessagePrefix == messagePrefix)
                    handlers.Remove();
            }
        }
    }

    class MessageTypeHandler
    {
        public delegate void MessageProcessor(string message);

        private string messagePrefix;
        MessageProcessor messageProcessor;

        public MessageTypeHandler(string prefix, MessageProcessor processor)
        {
            messagePrefix = prefix;
            messageProcessor = processor;
        }

        public string MessagePrefix
        {
            get { return messagePrefix; }
            set { messagePrefix = value; }
        }

        public MessageProcessor Processor
        {
            get { return messageProcessor; }
            set { messageProcessor = value; }
        }
    }
}
