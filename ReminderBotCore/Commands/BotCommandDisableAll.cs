using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandDisableAll : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandDisableAll(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /disable_all
            if (chat != null)
            {
                return new UserBotCommandResult("Все напоминания отключены.", await reminderService.ChangeModeAllNotification(chat, false), ReminderStatus.Changed);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
