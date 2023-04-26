using ReminderBotCore.CommandResults;
using ReminderBotCore.Commands;
using ReminderBotCore.Models;

namespace ReminderBotCore.Commands
{
    public interface IFactoryBotCommand
    {
        public IBotCommand CreateBotCommand(string requestString);
        public ICommandDeleteBot CreateBotCommandDeleteBot();
        public IBotCommand CreateBotCommandReminder();
        public IBotCommand CreateBotCommandChangeIsReminder();
    }
}
