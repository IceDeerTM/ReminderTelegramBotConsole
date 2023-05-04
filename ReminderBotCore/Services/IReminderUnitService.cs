using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Services
{
    public interface IReminderUnitService
    {
        public Task<IEnumerable<ReminderUnit>> AddDefaultReminders(ReminderChat chat);

        public Task<ReminderUnit> AddReminderUnit(ReminderUnit addingReminder);

        public Task<ReminderUnit> ChangeModeNotification(string id, bool mode);

        public Task<ReminderUnit> UpdateNotification(ReminderUnit reminder);

        public Task<List<ReminderUnit>> GetRemindersForHour(DateTime dateTime);

        public Task<int> GetCountReminders(ReminderChat chat);

        public Task<List<ReminderUnit>> GetReminders(ReminderChat chat);

        public Task<IEnumerable<ReminderUnit>> ChangeModeAllNotification(ReminderChat chat, bool mode);

        public Task<IEnumerable<ReminderUnit>> DeleteAllReminders(ReminderChat chat);

        public Task<ReminderUnit> DeleteReminder(string id);

    }
}
