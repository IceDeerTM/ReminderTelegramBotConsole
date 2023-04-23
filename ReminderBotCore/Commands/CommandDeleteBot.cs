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
    internal class CommandDeleteBot : IBotCommand // Пока не продумал как реализовывать
    {

        Task<UserBotCommandResult> IBotCommand.ExecuteCommand(long chatId)
        {
            throw new NotImplementedException();
        }
    }
}
