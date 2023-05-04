using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandActivateAll : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandActivateAll(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /activate_all
            if (chat != null)
            {
                return new UserBotCommandResult("Все напоминания отключены.", await reminderService.ChangeModeAllNotification(chat, true), ReminderStatus.Changed);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
