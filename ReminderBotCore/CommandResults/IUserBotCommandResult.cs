using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.CommandResults
{
    public interface IUserBotCommandResult: IBotCommandResult
    {
        public string Message { get; init; }
    }
}
