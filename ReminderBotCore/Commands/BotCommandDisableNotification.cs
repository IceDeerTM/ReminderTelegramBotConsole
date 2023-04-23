using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandDisableNotification : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandDisableNotification(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<UserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /disable guid
            // Пример: /disable 215gsahczx214fghfhd!

            string[] args = RequestString.Split(' ');
            if (args.Length == 2 && chat != null)
            {
                var reminder = await reminderService.DisableNotification(args[1]);
                return new UserBotCommandResult($"Напоминание {reminder.Message} отключено.", reminder, ReminderStatus.Changed);
            }
            else if (args.Length != 2)
            {
                return new UserBotCommandResult("Некорректный запрос. Попробуйте заново.");
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
