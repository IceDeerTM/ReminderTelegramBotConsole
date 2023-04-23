using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Core.Commands
{
    public abstract class BaseBotCommand : IBotCommand
    {
        public string RequestString { get; private set; }
        private ReminderChatService chatService;
        public ReminderChatService ChatService { get { return chatService; } private set { if (value != null) chatService = value; } }

        public BaseBotCommand(string requestString, ReminderChatService chatService)
        {
            RequestString = requestString;
            ChatService = chatService;
        }

        public async Task<UserBotCommandResult> ExecuteCommand(long chatId)
        {
            ReminderChat? chat = await chatService.GetChat(chatId);
            return await ExecuteSubCommand(chatId, chat);
        }

        public abstract Task<UserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat);

    }
}
