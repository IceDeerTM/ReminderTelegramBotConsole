using ReminderBotCore.Core.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Commands
{
    public class BotCommandReminder : IBotCommand // Пока не продумал как реализовывать
    {
        public BotCommandReminder()
        {
        }

        Task<UserBotCommandResult> IBotCommand.ExecuteCommand(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
