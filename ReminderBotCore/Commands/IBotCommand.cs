using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;

namespace ReminderBotCore.Commands
{
    public interface IBotCommand
    {
        public Task<IUserBotCommandResult> ExecuteCommand(ChatCredentials chatCredentials);
    }
}
