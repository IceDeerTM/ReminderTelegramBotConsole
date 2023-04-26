using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandDeleteReminder : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandDeleteReminder(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<IUserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /delete guid
            // Пример: /delete 215gsahczx214fghfhd!

            string[] args = RequestString.Split(' ');
            if (args.Length == 2 && chat != null)
            {
                var reminder = await reminderService.DeleteReminder(args[1]);
                return new UserBotCommandResult($"Напоминание {reminder.Message} удалено.", reminder, ReminderStatus.Deleted);
            }
            else if (args.Length != 2)
            {
                return new UserBotCommandResult("Некорректный запрос. Попробуйте заново.");
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
