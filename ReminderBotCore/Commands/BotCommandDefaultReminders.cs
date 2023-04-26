﻿using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandDefaultReminders : BaseBotCommand
    {
        private ReminderUnitService reminderService;
        public BotCommandDefaultReminders(string requestString, ReminderChatService chatService, ReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public async override Task<IUserBotCommandResult> ExecuteSubCommand(long chatId, ReminderChat? chat)
        {
            // Строка requetstString формата: /default_settings

            if (chat != null)
            {
                return new UserBotCommandResult("Напоминания по умолчанию добавлены.", await reminderService.AddDefaultReminders(chat), ReminderStatus.Added);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
