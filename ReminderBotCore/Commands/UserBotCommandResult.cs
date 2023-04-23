using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Commands
{
    public class UserBotCommandResult
    {
        public string ResponseText { get; private set; }
        public IEnumerable<ReminderUnit> Reminders { get; private set; }
        public ReminderStatus Status { get; private set; }

        public UserBotCommandResult(string? responseText = null, IEnumerable<ReminderUnit>? reminders = null, ReminderStatus? status = null)
        {
            ResponseText = responseText != null? responseText: string.Empty;
            Reminders = reminders != null? reminders: new List<ReminderUnit>();
            Status = status != null ? (ReminderStatus)status : ReminderStatus.Unchanged;
        }

        public UserBotCommandResult(string? responseText, ReminderUnit reminder, ReminderStatus? status)
        {
            ResponseText = responseText != null ? responseText : string.Empty;
            Reminders = new List<ReminderUnit>();
            Reminders.Append(reminder);
            Status = status != null ? (ReminderStatus)status : ReminderStatus.Unchanged;
        }
    }

    public enum ReminderStatus
    {
        Added = 0, Changed = 1, Deleted = 2, Unchanged = 3
    }
}
