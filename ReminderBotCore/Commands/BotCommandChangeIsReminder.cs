using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    internal class BotCommandChangeIsReminder : IBotCommand
    {
        public IReminderChatService ChatService { get; private set; }
        public IReminderUnitService ReminderService { get; private set; }
        public ISenderMessage SenderMessage { get; private set; }

        public BotCommandChangeIsReminder(IReminderChatService chatService, IReminderUnitService reminderService, ISenderMessage senderMessage)
        {
            ChatService = chatService;
            ReminderService = reminderService;
            SenderMessage = senderMessage;
        }

        public async Task<IUserBotCommandResult> ExecuteCommand(ChatCredentials chatCredentials)
        {
            List<ReminderChat> chats = await ChatService.GetChats();

            foreach(ReminderChat chat in chats)
            {
                List<ReminderUnit> reminderUnits= new List<ReminderUnit>();

                foreach(ReminderUnit unit in reminderUnits)
                {
                    unit.IsReminder = false;
                    _ = await ReminderService.UpdateNotification(unit);
                }
            }
            return new UserBotCommandResult("Выполнено.");
        }
    }

}
