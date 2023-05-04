using ReminderBotCore.CommandResults;
using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Services;
using System;

namespace ReminderBotCore.Commands
{
    public class FactoryBotCommand : IFactoryBotCommand
    {
        private IReminderChatService chatService;
        private IReminderUnitService reminderUnitService;

        public FactoryBotCommand(IReminderChatService chatService, IReminderUnitService reminderService)
        {
            this.chatService = chatService;
            this.reminderUnitService = reminderService;
        }

        public IBotCommand CreateBotCommand(string requestString)
        {
            if (requestString.Contains("/start"))
            {
                return new BotCommandStart(requestString, chatService);
            }
            else if (requestString.Contains("/default_reminders"))
            {
                return new BotCommandDefaultReminders(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/disable_all"))
            {
                return new BotCommandDisableAll(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/disable"))
            {
                return new BotCommandDisableNotification(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/add"))
            {
                return new BotCommandAddNotification(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/list"))
            {
                return new BotCommandGetListReminders(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/delete_all"))
            {
                return new BotCommandDeleteAllReminders(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/delete"))
            {
                return new BotCommandDeleteReminder(requestString, chatService, reminderUnitService);
            }
            else if (requestString.Contains("/count"))
            {
                return new BotCommandGetCountList(requestString, chatService, reminderUnitService);
            }
            else return new BotCommandNotExist();
        }

        public ICommandDeleteBot CreateBotCommandDeleteBot()
        {
            return new CommandDeleteBot(chatService, reminderUnitService);
        }

        public IBotCommandReminder CreateBotCommandReminder(ISenderMessage senderMessage)
        {
            return new BotCommandReminder(chatService, reminderUnitService, senderMessage);
        }
    }
}
