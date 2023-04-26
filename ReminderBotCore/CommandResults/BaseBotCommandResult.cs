using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.CommandResults
{
    public abstract class BaseBotCommandResult: IBotCommandResult
    {
        public IEnumerable<ReminderUnit> Reminders { get; init; }
        public ReminderStatus Status { get; init; }

        public BaseBotCommandResult(IEnumerable<ReminderUnit>? reminders, ReminderStatus? status)
        {
            Reminders = reminders != null ? reminders : new List<ReminderUnit>();
            Status = status != null ? (ReminderStatus)status : ReminderStatus.Unchanged;
        }
    }
}
