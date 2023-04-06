using ReminderBotCore.Services;

namespace ReminderBotCore.Core.Commands
{
    public class FactoryBotCommand : IFactoryBotCommand
    {
        private ReminderChatService chatService;
        private ReminderUnitService reminderUnitService;

        public FactoryBotCommand(ReminderChatService chatService, ReminderUnitService reminderUnitService)
        {
            this.chatService = chatService;
            this.reminderUnitService = reminderUnitService;
        }

        public IBotCommand CreateBotCommand(string requestString)
        {
            // Тут должна быть реализация создания всех команд
            return new BotCommandAddNotification(requestString, chatService);
            throw new NotImplementedException();
        }
    }
}
