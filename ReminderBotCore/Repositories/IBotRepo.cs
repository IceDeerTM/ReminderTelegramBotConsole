using ReminderBotCore.Models;

namespace ReminderBotCore.Repositories
{
    public interface IBotRepo
    {
        public Task<List<ReminderUnit>> GetReminders(ReminderChat chat);
        public Task<int> GetCountReminders(ReminderChat chat);

        public Task<ReminderUnit> AddReminderUnit(ReminderUnit reminder);
        public Task<ReminderUnit> DeleteReminder(ReminderUnit reminder);

        public Task<ReminderChat> GetChat(long chatId);
        public Task<ReminderUnit> GetReminderByGuid(string id);
    }
}
