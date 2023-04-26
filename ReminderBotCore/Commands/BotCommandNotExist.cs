using ReminderBotCore.CommandResults;
using ReminderBotCore.Core.Commands;

namespace ReminderBotCore.Commands
{
    public class BotCommandNotExist : IBotCommand
    {
        public Task<IUserBotCommandResult> ExecuteCommand(long chatId)
        {
            string responseText = "Такой команды не существует.";
            IUserBotCommandResult botCommandResult = new UserBotCommandResult(responseText);
            return Task.FromResult(botCommandResult);
        }
    }
}
