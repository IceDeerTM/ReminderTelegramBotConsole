using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public abstract class BaseBotCommand : IBotCommand
    {
        public string RequestString { get; private set; }

        public IReminderChatService ChatService { get; private set; }

        public BaseBotCommand(string requestString, IReminderChatService chatService)
        {
            RequestString = requestString;
            ChatService = chatService;
        }

        public async Task<IUserBotCommandResult> ExecuteCommand(ChatCredentials chatCredentials)
        {
            ReminderChat? chat = await ChatService.GetChat(chatCredentials.ChatId);
            return await ExecuteSubCommand(chatCredentials, chat);
        }

        public abstract Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat);
    }
}
