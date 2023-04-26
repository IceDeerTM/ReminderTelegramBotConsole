using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.CommandResults
{
    public class BotCommandDeleteBotResult : BaseBotCommandResult
    {
        public BotCommandDeleteBotResult(IEnumerable<ReminderUnit>? reminders) : base(reminders, ReminderStatus.Deleted) { }
    }
}
