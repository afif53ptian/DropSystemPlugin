using Grimoire.Networking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePacketPlugin
{
    public class HandlerDisableAnims : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = { "ct" };

        public void Handle(JsonMessage message)
        {
            if (message.DataObject["anims"] != null)
                message.DataObject["anims"] = new JArray();
            if (message.DataObject["a"] != null)
                message.DataObject["a"] = new JArray();
        }
    }
}