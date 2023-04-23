using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    public class ReminderChatService
    {
        private IBotRepo dbRepo;
        public ReminderChatService(IBotRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public async Task<ReminderChat> GetChat(long chatId)
        {
            return null;
        }

        public async Task<ReminderChat> AddReminderChat(ReminderChat chat)
        {
            return null;
        }

        public async Task UpdateReminderChat(ReminderChat chat)
        {

        }

    }
}
