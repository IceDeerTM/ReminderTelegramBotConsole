using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandActivateAll : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandActivateAll(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /activate_all
            if (chat != null)
            {
                return new UserBotCommandResult("Все напоминания отключены.", await reminderService.ChangeModeAllNotification(chat, true), ReminderStatus.Changed);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
