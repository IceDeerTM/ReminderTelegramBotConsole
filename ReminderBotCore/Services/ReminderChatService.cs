using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    /// <summary>
    /// Слой сервиса для модели ReminderChat
    /// </summary>
    public class ReminderChatService : IReminderChatService
    {
        public IBotRepo dbRepo { get; private set; }
        public ReminderChatService(IBotRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public async Task<ReminderChat> GetChat(string chatId)
        {
            return await dbRepo.GetChat(chatId);
        }

        public async Task<List<ReminderChat>> GetChats()
        {
            return await dbRepo.GetChats();
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
