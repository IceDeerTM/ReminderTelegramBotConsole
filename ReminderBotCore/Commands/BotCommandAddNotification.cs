using ReminderBotCore.Services;
using ReminderBotCore.Models;
using ReminderBotCore.Commands;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandAddNotification : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandAddNotification(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService) 
        {
            this.reminderService = reminderService;
        }

        public override async Task<UserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /add message time
            // Пример: /add Встреча 12:00

            string[] args = RequestString.Split(' ');

            if (args.Length == 3 && chat != null)
            {
                ReminderUnit addingReminder = new ReminderUnit(DateTime.Parse(args[1]), args[2], chat);
                return new UserBotCommandResult("Напоминание успешно добавлено.", await reminderService.AddReminderUnit(addingReminder), ReminderStatus.Added);
            }
            else if (chat == null) return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
            else return new UserBotCommandResult("Некорректный запрос.");
        }
    }
}
