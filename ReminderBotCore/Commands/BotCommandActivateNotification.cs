using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandActivateNotification : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandActivateNotification(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /activate guid
            // Пример: /activate 215gsahczx214fghfhd!

            string[] args = RequestString.Split(' ');
            if (args.Length == 2 && chat != null)
            {
                var reminder = await reminderService.ChangeModeNotification(args[1], true);
                return new UserBotCommandResult($"Напоминание {reminder.Message} включено.", reminder, ReminderStatus.Changed);
            }
            else if (args.Length != 2)
            {
                return new UserBotCommandResult("Некорректный запрос. Попробуйте заново.");
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
