using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandGetCountList : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandGetCountList(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<UserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /count

            if (chat != null)
            {
                var responseText = "Количество напоминаний - " + await reminderService.GetCountReminders(chat);
                return new UserBotCommandResult(responseText);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
