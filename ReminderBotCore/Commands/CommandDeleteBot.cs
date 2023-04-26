﻿using ReminderBotCore.CommandResults;
using ReminderBotCore.Core.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    internal class CommandDeleteBot : ICommandDeleteBot // Пока не продумал как реализовывать
    {
        public ReminderChatService ChatService { get; private set; }
        public ReminderUnitService ReminderService { get; private set; }

        public CommandDeleteBot(ReminderChatService chatService, ReminderUnitService reminderService) 
        {
            ChatService = chatService;
            ReminderService = reminderService;
        }

        public Task<IBotCommandResult> ExecuteCommandDelete(long chatId)
        {
            throw new NotImplementedException();
        }

    }
}
