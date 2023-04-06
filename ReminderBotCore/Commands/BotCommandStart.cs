using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandStart : BaseBotCommand
    {
        public BotCommandStart(string requestString) : base(requestString)
        {
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
