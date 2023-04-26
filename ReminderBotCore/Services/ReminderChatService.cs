using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    /// <summary>
    /// Слой сервиса для модели ReminderChat
    /// </summary>
    public class ReminderChatService
    {
        private IBotRepo dbRepo;
        public ReminderChatService(IBotRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public async Task<ReminderChat> GetChat(long chatId)
        {
            return await dbRepo.GetChat(chatId);
        }

        public async Task<ReminderChat> AddReminderChat(ReminderChat chat)
        {
            return await dbRepo.AddReminderChat(chat);
        }
        
        public async Task<ReminderChat> DeleteReminderChat(ReminderChat chat)
        {
            return await dbRepo.DeleteReminderChat(chat);
        }
    }
}
