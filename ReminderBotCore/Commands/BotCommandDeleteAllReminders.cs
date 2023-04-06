using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandDeleteAllReminders : BaseBotCommand
    {
        public BotCommandDeleteAllReminders(string requestString) : base(requestString)
        {
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
