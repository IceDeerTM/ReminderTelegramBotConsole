using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;

namespace ReminderBotCore.Commands
{
    public interface ICommandDeleteBot
    {
        public Task<IBotCommandResult> ExecuteCommandDelete(long chatId);
    }
}
