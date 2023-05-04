using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandDeleteAllReminders : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandDeleteAllReminders(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /delete_all
            if (chat != null)
            {
                return new UserBotCommandResult("Все напоминания удалены.", await reminderService.DeleteAllReminders(chat), ReminderStatus.Deleted);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
