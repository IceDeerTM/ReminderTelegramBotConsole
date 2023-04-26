using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    /// <summary>
    /// Слой сервиса для модели ReminderUnit
    /// </summary>
    public class ReminderUnitService
    {
        private IBotRepo dbRepo;

        public ReminderUnitService(IBotRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public async Task<IEnumerable<ReminderUnit>> AddDefaultReminders(ReminderChat chat)
        {
            List<ReminderUnit> defaultReminders = new List<ReminderUnit>() {
                new ReminderUnit(new DateTime(2023, 04, 30, 12, 00, 00), "Охота", chat),
                new ReminderUnit(new DateTime(2023, 04, 30, 20, 00, 00), "Царь", chat),
                new ReminderUnit(new DateTime(2023, 04, 30, 22, 00, 00), "Повозки", chat)
            };

            defaultReminders = await GetUpdatedListFromRepo(AddReminderUnit, defaultReminders);

            return defaultReminders;
        }

        public async Task<ReminderUnit> AddReminderUnit(ReminderUnit addingReminder)
        {
            return await dbRepo.AddReminderUnit(addingReminder);
        }

        public async Task<ReminderUnit> ChangeModeNotification(ReminderUnit reminder, bool mode)
        {
            reminder.isActive = mode;
            return await dbRepo.UpdateNotification(reminder);
        }

        public async Task<ReminderUnit> ChangeModeNotification(string id, bool mode)
        {
            var reminder = await GetReminderByGuid(id);
            return await ChangeModeNotification(reminder, mode);
        }

        public async Task<int> GetCountReminders(ReminderChat chat)
        {
            int count = await dbRepo.GetCountReminders(chat);

            return count;
        }

        public async Task<List<ReminderUnit>> GetReminders(ReminderChat chat)
        {
            List<ReminderUnit> reminders = await dbRepo.GetReminders(chat);
            return reminders;
        }

        public async Task<IEnumerable<ReminderUnit>> ChangeModeAllNotification(ReminderChat chat, bool mode)
        {
            List<ReminderUnit> reminders = await GetReminders(chat);
            return await ChangeModeAllNotification(reminders, mode);
        }


        public async Task<IEnumerable<ReminderUnit>> ChangeModeAllNotification(List<ReminderUnit> reminders, bool mode)
        {
            reminders = await GetUpdatedListFromRepo(ChangeModeNotification, reminders, mode);
            return reminders;
        }

        public async Task<IEnumerable<ReminderUnit>> DeleteAllReminders(ReminderChat chat)
        {
            List<ReminderUnit> reminders = await GetReminders(chat);
            reminders = await GetUpdatedListFromRepo(DeleteReminder, reminders);

            return reminders;
        }

        public async Task<ReminderUnit> DeleteReminder(ReminderUnit reminder)
        {
            return await dbRepo.DeleteReminder(reminder);
        }

        public async Task<ReminderUnit> DeleteReminder(string id)
        {
            var reminder = await GetReminderByGuid(id);
            return await DeleteReminder(reminder);
        }

        public async Task<ReminderUnit> GetReminderByGuid(string id)
        {
            return await dbRepo.GetReminderByGuid(id);
        }

        public async Task<List<ReminderUnit>> GetUpdatedListFromRepo(Func<ReminderUnit, Task<ReminderUnit>> func, IEnumerable<ReminderUnit> collection)
        {
            List<ReminderUnit> resultCollection = new List<ReminderUnit>();
            foreach (var item in collection)
            {
                resultCollection.Add(await func(item));
            }
            return resultCollection;
        }
        public async Task<List<ReminderUnit>> GetUpdatedListFromRepo(Func<ReminderUnit, bool, Task<ReminderUnit>> func, IEnumerable<ReminderUnit> collection, bool mode)
        {
            List<ReminderUnit> resultCollection = new List<ReminderUnit>();
            foreach (var item in collection)
            {
                resultCollection.Add(await func(item, mode));
            }
            return resultCollection;
        }
    }
}
