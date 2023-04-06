using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandDeleteReminder : BaseBotCommand
    {
        public BotCommandDeleteReminder(string requestString) : base(requestString)
        {
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
