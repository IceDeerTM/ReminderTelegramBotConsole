using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.CommandResults
{
    public class UserBotCommandResult : BaseBotCommandResult, IUserBotCommandResult
    {
        public string Message { get; init; }

        public UserBotCommandResult(string? message, IEnumerable<ReminderUnit>? reminders = null, ReminderStatus? status = null) : base(reminders, status)
        {
            Message = message != null ? message : string.Empty;
        }

        public UserBotCommandResult(string? message, ReminderUnit reminder, ReminderStatus? status) : base(new List<ReminderUnit>() { reminder }, status)
        {
            Message = message != null ? message : string.Empty;
        }
    }
}
