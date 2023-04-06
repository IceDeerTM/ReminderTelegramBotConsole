namespace ReminderBotCore.Core.Commands
{
    public interface IFactoryBotCommand
    {
        public IBotCommand CreateBotCommand(string requestString);
    }
}
