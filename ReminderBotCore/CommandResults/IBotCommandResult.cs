using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.CommandResults
{
    public interface IBotCommandResult
    {
        public IEnumerable<ReminderUnit> Reminders { get; init; }
        public ReminderStatus Status { get; init; }
    }
}
