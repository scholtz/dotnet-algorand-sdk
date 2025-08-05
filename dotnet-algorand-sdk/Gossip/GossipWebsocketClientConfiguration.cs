using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Gossip
{
    public class GossipWebsocketClientConfiguration
    {
        /// <summary>
        /// Hostname or IP address including port of the avm gossip server.
        /// </summary>
        public string Host { get; set; }
    }
}
