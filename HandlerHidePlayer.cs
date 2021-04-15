using Grimoire.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePacketPlugin
{
    public class HandlerHidePlayer : IXtMessageHandler
    {
        public string[] HandledCommands { get; } = { "retrieveUserData", "retrieveUserDatas" };

        public static void DestroyPlayers() => Grimoire.Tools.Flash.Call("DestroyPlayers");

        public void Handle(XtMessage message)
        {
            message.Send = false;
            DestroyPlayers();
        }
    }
}