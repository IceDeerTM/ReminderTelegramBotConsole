using ReminderBotCore.CommandResults;
using ReminderBotCore.Commands;
using ReminderBotCore.Models;

namespace ReminderBotCore.Commands
{
    public class BotCommandNotExist : IBotCommand
    {
        public Task<IUserBotCommandResult> ExecuteCommand(ChatCredentials chatCredentials)
        {
            string responseText = "Такой команды не существует.";
            IUserBotCommandResult botCommandResult = new UserBotCommandResult(responseText);
            return Task.FromResult(botCommandResult);
        }
    }
}
