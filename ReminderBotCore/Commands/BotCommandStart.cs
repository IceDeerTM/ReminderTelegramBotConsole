using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandStart : BaseBotCommand
    {
        public BotCommandStart(string requestString, ReminderChatService chatService) : base(requestString, chatService)
        {
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /start

            if (chat == null)
            {
                var resultChat = await ChatService.AddReminderChat(new ReminderChat(chatId));
                return new UserBotCommandResult("Бот активирован.");
            }
            else return new UserBotCommandResult("Уже активно.");
            
        }
    }
}
