using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandGetListReminders : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandGetListReminders(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /list

            if (chat != null)
            {
                var reminders = await reminderService.GetReminders(chat);
                var responseText = "Список напоминаний: ";

                for (int i = 0; i < reminders.Count; i++)
                {
                    responseText += "\r\n";
                    responseText += $"\r\n {i + 1}) {reminders[i].Message} {reminders[i].TimeRemind} {reminders[i].UId}";
                }

                return new UserBotCommandResult(responseText);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
