using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandStart : BaseBotCommand
    {
        public BotCommandStart(string requestString, IReminderChatService chatService) : base(requestString, chatService)
        {
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /start

            if (chat == null)
            {
                var resultChat = await ChatService.AddReminderChat(new ReminderChat(chatCredentials.ChatId, chatCredentials.Name));
                return new UserBotCommandResult("Бот активирован.");
            }
            else return new UserBotCommandResult("Уже активно.");
            
        }
    }
}
