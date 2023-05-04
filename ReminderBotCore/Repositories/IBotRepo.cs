using ReminderBotCore.Models;
using System.Collections.Generic;

namespace ReminderBotCore.Repositories
{
    /// <summary>
    /// Репозиторий для работы сервисов ReminderChatService и ReminderUnitService
    /// </summary>
    public interface IBotRepo
    {
        public Task<List<ReminderUnit>> GetReminders(ReminderChat chat);

        public Task<List<ReminderUnit>> GetRemindersForHour(DateTime dateTime);

        public Task<int> GetCountReminders(ReminderChat chat);

        public Task<ReminderUnit> AddReminderUnit(ReminderUnit reminder);
        public Task<ReminderUnit> DeleteReminder(ReminderUnit reminder);

        public Task<ReminderChat> GetChat(string chatId);
        public Task<List<ReminderChat>> GetChats();
        public Task<ReminderChat> AddReminderChat(ReminderChat chat);
        public Task<ReminderChat> DeleteReminderChat(ReminderChat chat);
        public Task<ReminderUnit> GetReminderByGuid(string id);
        public Task<ReminderUnit> UpdateNotification(ReminderUnit reminder);
    }
}
