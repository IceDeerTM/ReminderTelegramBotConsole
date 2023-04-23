using ReminderBotCore.Commands;
using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public interface IBotCommand
    {
        public Task<UserBotCommandResult> ExecuteCommand(long chatId);
    }
}
