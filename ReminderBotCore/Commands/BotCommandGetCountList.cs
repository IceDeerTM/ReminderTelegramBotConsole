using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandGetCountList : BaseBotCommand
    {
        public BotCommandGetCountList(string requestString) : base(requestString)
        {
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
