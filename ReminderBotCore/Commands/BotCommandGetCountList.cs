﻿using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;

namespace ReminderBotCore.Commands
{
    public class BotCommandGetCountList : BaseBotCommand
    {
        private IReminderUnitService reminderService;
        public BotCommandGetCountList(string requestString, IReminderChatService chatService, IReminderUnitService reminderService) : base(requestString, chatService)
        {
            this.reminderService = reminderService;
        }

        public override async Task<IUserBotCommandResult> ExecuteSubCommand(ChatCredentials chatCredentials, ReminderChat? chat)
        {
            // Строка requetstString формата: /count

            if (chat != null)
            {
                var responseText = "Количество напоминаний - " + await reminderService.GetCountReminders(chat);
                return new UserBotCommandResult(responseText);
            }
            else return new UserBotCommandResult("Неизвестная ошибка.Попробуйте /start.");
        }
    }
}
