using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public interface IFactoryBotCommand
    {
        public IBotCommand CreateBotCommand(string requestString);
        public ICommandDeleteBot CreateBotCommandDeleteBot();
        public IBotCommandReminder CreateBotCommandReminder(ISenderMessage senderMessage);
    }
}
