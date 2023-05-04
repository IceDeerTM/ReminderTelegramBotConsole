using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandDefaultReminders : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandDefaultReminders(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /default_reminders

            if (chat != null)
            {
                return new UserBotCommandResult("Напоминания по умолчанию добавлены.", await reminderService.AddDefaultReminders(chat), ReminderStatus.Added);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
