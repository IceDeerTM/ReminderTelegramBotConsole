using ReminderBotCore.CommandResults;
using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    internal class CommandDeleteBot : ICommandDeleteBot
    {
        public IReminderChatService ChatService { get; private set; }
        public IReminderUnitService ReminderService { get; private set; }

        public CommandDeleteBot(IReminderChatService chatService, IReminderUnitService reminderService) 
        {
            ChatService = chatService;
            ReminderService = reminderService;
        }

        public async Task<IBotCommandResult> ExecuteCommandDelete(ChatCredentials chatCredentials)
        {
            var chat = await ChatService.GetChat(chatCredentials.ChatId);

            var reminders = await ReminderService.DeleteAllReminders(chat);

            return new BotCommandDeleteBotResult(reminders);
        }

    }
}
