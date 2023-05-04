using ReminderBotCore.CommandResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Commands
{
    public interface IBotCommandReminder
    {
        public Task ExecuteCommand();

        public void Update(IBotCommandResult commandResult);
    }
}
