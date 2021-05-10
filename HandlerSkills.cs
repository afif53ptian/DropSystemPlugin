using Grimoire.Networking;

namespace ExamplePacketPlugin
{
    public class HandlerSkills : IJsonMessageHandler
    {
        public string[] HandledCommands { get; } = { "sAct" };

        public void Handle(JsonMessage message)
        {
            var actions = message.DataObject["actions"];

            var passive = actions?["passive"];

            if (passive != null)
            {
                foreach (var p in passive)
                    p["range"] = 20000;
            }

            var active = actions?["active"];

            if (active != null)
            {
                foreach (var a in active)
                    a["range"] = 20000;
            }
        }
    }
}
