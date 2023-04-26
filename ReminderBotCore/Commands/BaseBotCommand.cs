using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public abstract class BaseBotCommand : IBotCommand
    {
        public string RequestString { get; private set; }

        public ReminderChatService ChatService { get; private set; }

        public BaseBotCommand(string requestString, ReminderChatService chatService)
        {
            RequestString = requestString;
            ChatService = chatService;
        }

        public async Task<IUserBotCommandResult> ExecuteCommand(long chatId)
        {
            ReminderChat? chat = await ChatService.GetChat(chatId);
            return await ExecuteSubCommand(chatId, chat);
        }

        public abstract Task<IUserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat);
    }
}
