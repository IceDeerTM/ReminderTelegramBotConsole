using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public interface IBotCommand
    {
        public Task<string> Execute(ReminderChat chat);
    }
}
