using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandDisableNotification : BaseBotCommand
    {
        public BotCommandDisableNotification(string requestString) : base(requestString)
        {
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
