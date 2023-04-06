using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public abstract class BaseBotCommand : IBotCommand
    {
        private string requestString;

        public BaseBotCommand(string requestString)
        {
            this.requestString = requestString;
        }

        public abstract Task<string> Execute(ReminderChat chat);

    }
}
