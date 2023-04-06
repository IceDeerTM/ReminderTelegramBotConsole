using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class CommandDisableBot : BaseBotCommand
    {
        public CommandDisableBot(string requestString) : base(requestString)
        {

        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
