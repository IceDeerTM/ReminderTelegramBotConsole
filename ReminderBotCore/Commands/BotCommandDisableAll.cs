using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandDisableAll : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandDisableAll(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public async override Task<UserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /disable_all
            if (chat != null)
            {
                return new UserBotCommandResult("Все напоминания отключены.", await reminderService.DissableAllNotification(chat), ReminderStatus.Changed);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
