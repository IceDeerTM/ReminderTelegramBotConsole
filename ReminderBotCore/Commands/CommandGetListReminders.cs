using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class CommandGetListReminders : BaseBotCommand
    {
        public CommandGetListReminders(string requestString) : base(requestString)
        {

        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
