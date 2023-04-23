using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    public class ReminderUnitService
    {
        private IBotRepo dBRepo;

        public ReminderUnitService(IBotRepo dBRepo)
        {
            this.dBRepo = dBRepo;
        }

        public async Task<IEnumerable<ReminderUnit>> AddDefaultReminders(ReminderChat chat)
        {
            return null;
        }

        public async Task<ReminderUnit> AddReminderUnit(ReminderUnit addingReminder)
        {
            return await dBRepo.AddReminderUnit(addingReminder);
        }

        public async Task<ReminderUnit> DisableNotification(ReminderUnit reminder)
        {
            return reminder;
        }

        public async Task<ReminderUnit> DisableNotification(string id)
        {
            var reminder = await GetReminderByGuid(id);
            return await DisableNotification(reminder);
        }

        public async Task<int> GetCountReminders(ReminderChat chat)
        {
            int count = await dBRepo.GetCountReminders(chat);

            return count;
        }

        public async Task<List<ReminderUnit>> GetReminders(ReminderChat chat)
        {
            List<ReminderUnit> reminders = await dBRepo.GetReminders(chat);
            return reminders;
        }

        public async Task<IEnumerable<ReminderUnit>> DissableAllNotification(ReminderChat chat)
        {
            List<ReminderUnit> reminders = await GetReminders(chat);
            return await DissableAllNotification(reminders);
        }


        public async Task<IEnumerable<ReminderUnit>> DissableAllNotification(List<ReminderUnit> reminders)
        {
            foreach (var reminder in reminders) await DisableNotification(reminder);
            return reminders;
        }

        public async Task<IEnumerable<ReminderUnit>> DeleteAllReminders(ReminderChat chat)
        {
            List<ReminderUnit> reminders = await GetReminders(chat);
            foreach (var reminder in reminders) await DeleteReminder(reminder);
            return reminders;
        }

        public async Task<ReminderUnit> DeleteReminder(ReminderUnit reminder)
        {
            return null;
        }

        public async Task<ReminderUnit> DeleteReminder(string id)
        {
            var reminder = await GetReminderByGuid(id);
            return await DeleteReminder(reminder);
        }

        public async Task<ReminderUnit> GetReminderByGuid(string id)
        {
            return await dBRepo.GetReminderByGuid(id);
        }
    }
}
