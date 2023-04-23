using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public interface IFactoryBotCommand
    {
        public IBotCommand CreateBotCommand(string requestString);
        public IBotCommand CreateBotCommandDeleteBot();
        public IBotCommand CreateBotCommandReminder();
    }
}
