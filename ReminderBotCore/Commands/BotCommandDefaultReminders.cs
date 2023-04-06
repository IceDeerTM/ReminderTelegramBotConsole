using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandDefaultReminders : BaseBotCommand
    {
        public BotCommandDefaultReminders(string requestString) : base(requestString)
        {
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
