using ReminderBotCore.CommandResults;
using ReminderBotCore.Core.Commands;

namespace ReminderBotCore.Commands
{
    public class BotCommandReminder : IBotCommand // Пока не продумал как реализовывать
    {
        public BotCommandReminder()
        {
        }

        public Task<IUserBotCommandResult> ExecuteCommand(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
