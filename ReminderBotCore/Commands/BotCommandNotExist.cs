using ReminderBotCore.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Commands
{
    public class BotCommandNotExist : IBotCommand
    {
        public Task<UserBotCommandResult> ExecuteCommand(long chatId)
        {
            string responseText = "Такой команды не существует.";
            return Task.FromResult(new UserBotCommandResult(responseText));
        }
    }
}
