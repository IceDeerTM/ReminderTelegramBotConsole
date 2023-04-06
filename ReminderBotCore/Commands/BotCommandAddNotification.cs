using ReminderBotCore.Services;
using ReminderBotCore.Models;

namespace ReminderBotCore.Core.Commands
{
    public class BotCommandAddNotification : BaseBotCommand
    {
        private ReminderChatService chatService;
        public BotCommandAddNotification(string requestString, ReminderChatService chatService) : base(requestString) 
        {
            this.chatService = chatService;
        }

        public override Task<string> Execute(ReminderChat chat)
        {
            throw new NotImplementedException();
        }
    }
}
