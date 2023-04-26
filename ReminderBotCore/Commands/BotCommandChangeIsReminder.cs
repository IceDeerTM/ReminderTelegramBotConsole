using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    internal class BotCommandChangeIsReminder : IBotCommand
    {
        public ReminderChatService ChatService { get; private set; }
        public ReminderUnitService ReminderService { get; private set; }
        public BotCommandChangeIsReminder(ReminderChatService chatService, ReminderUnitService reminderService)
        {
            ChatService = chatService;
            ReminderService = reminderService;
        }

        public Task<IUserBotCommandResult> ExecuteCommand(long chatId)
        {
            throw new NotImplementedException();
        }
    }

}
