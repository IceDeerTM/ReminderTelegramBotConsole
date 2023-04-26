using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderTelegramBotConsole.Repositories
{
    public class EFRepo : IBotRepo
    {
        public Task<ReminderChat> AddReminderChat(ReminderChat chat)
        {
            throw new NotImplementedException();
        }

        public Task<ReminderUnit> AddReminderUnit(ReminderUnit reminderUnit)
        {
            throw new NotImplementedException();
        }

        public Task<ReminderUnit> DeleteReminder(ReminderUnit reminder)
        {
            throw new NotImplementedException();
        }

        public Task<ReminderChat> DeleteReminderChat(ReminderChat chat)
        {
            throw new NotImplementedException();
        }

        public Task<ReminderChat> GetChat(long chatId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountReminders(ReminderChat chat)
        {
            throw new NotImplementedException();
        }

        public Task<ReminderUnit> GetReminderByGuid(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReminderUnit>> GetReminders(ReminderChat chat)
        {
            throw new NotImplementedException();
        }

        public Task<ReminderUnit> UpdateNotification(ReminderUnit reminder)
        {
            throw new NotImplementedException();
        }
    }
}
