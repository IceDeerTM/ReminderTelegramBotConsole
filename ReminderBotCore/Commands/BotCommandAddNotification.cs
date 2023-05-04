using ReminderBotCore.Services;
using ReminderBotCore.Models;
using ReminderBotCore.CommandResults;

namespace ReminderBotCore.Commands
{
    public class BotCommandAddNotification : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandAddNotification(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService) 
        {
            this.reminderService = reminderService;
        }

        public override async Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /add message time
            // Пример: /add Встреча 12:00

            string[] args = RequestString.Split(' ');

            if (args.Length == 3 && chat != null)
            {
                ReminderUnit addingReminder = new ReminderUnit(DateTime.Parse(args[2]), args[1], chat);
                return new UserBotCommandResult("Напоминание успешно добавлено.", await reminderService.AddReminderUnit(addingReminder), ReminderStatus.Added);
            }
            else if (chat == null) return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
            else return new UserBotCommandResult("Некорректный запрос.");
        }
    }
}
