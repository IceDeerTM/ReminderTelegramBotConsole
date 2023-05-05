using ReminderBotCore.CommandResults;
using ReminderBotCore.Models;
using ReminderBotCore.Services;
using System.Security;

namespace ReminderBotCore.Commands
{
    public class BotCommandReminder : IBotCommandReminder
    {
        public IReminderChatService ChatService { get; private set; }
        public IReminderUnitService ReminderService { get; private set; }
        public ISenderMessage? SenderMessage { get; private set; }

        private List<ReminderUnit> _reminders;
        private DateTime serverTime = DateTime.Now;
        private DateTime everyClock = DateTime.Now;

        public BotCommandReminder(IReminderChatService chatService, IReminderUnitService reminderService, ISenderMessage? senderMessage)
        {
            ChatService = chatService;
            ReminderService = reminderService;
            SenderMessage = senderMessage;
            _reminders = new List<ReminderUnit>();
            Update();
        }

        public async Task ExecuteCommand()
        {
            DateTime currentTime = DateTime.Now;
            if ((currentTime.Day > serverTime.Day) || ((currentTime.Day == 1) && (currentTime.Day < serverTime.Day))) // Наступил ли следующий день?
            {
                serverTime = DateTime.Now;
                await BigChangeIsReminder();
            }

            if (everyClock.Hour < currentTime.Hour)
            {
                everyClock = DateTime.Now;
                Update();
            }

            for (int i = 0; i < _reminders.Count; i++)
            {
                var reminder = _reminders[i];
                var difference = currentTime.Minute - reminder.TimeRemind.Minute;
                if (reminder.TimeRemind.Minute == currentTime.Minute || (difference == 1))
                {
                    if (SenderMessage != null) await SenderMessage.SendMessage(reminder.ReminderChat.ChatId, reminder.Message);

                    reminder.IsReminder = true;
                    await ReminderService.UpdateNotification(reminder);
                    _reminders.Remove(reminder);
                    i--;
                }
            }
        }

        private async Task BigChangeIsReminder()
        {
            List<ReminderChat> chats = await ChatService.GetChats();

            foreach (ReminderChat chat in chats)
            {
                List<ReminderUnit> reminderUnits = new List<ReminderUnit>();

                foreach (ReminderUnit unit in reminderUnits)
                {
                    unit.IsReminder = false;
                    _ = await ReminderService.UpdateNotification(unit);
                }
            }
            Update();
        }

        private async void Update()
        {
            _reminders = await ReminderService.GetRemindersForHour(everyClock);
            int x = 5;
        }

        public void Update(IBotCommandResult commandResult)
        {
            var dateTime = DateTime.Now;
            if (commandResult.Status == ReminderStatus.Added)
            {
                foreach(var reminder in commandResult.Reminders)
                {
                    if (reminder.TimeRemind.Hour == everyClock.Hour && dateTime.Minute <= reminder.TimeRemind.Minute) _reminders.Add(reminder);
                }
            }
            else if (commandResult.Status == ReminderStatus.Changed)
            {
                foreach (var reminder in commandResult.Reminders)
                {
                    var reminderInList = _reminders.Find((r) => reminder.UId == r.UId);

                    if (reminder.TimeRemind.Hour == everyClock.Hour && dateTime.Minute >= reminder.TimeRemind.Minute)
                    {
                        
                        if (!reminder.isActive && reminderInList != null) _reminders.Remove(reminderInList);
                        else if (reminder.isActive && reminderInList != null) _reminders[_reminders.IndexOf(reminderInList)] = reminder;
                        else _reminders.Add(reminder);
                    }
                }
            }
            else if (commandResult.Status == ReminderStatus.Deleted)
            {
                foreach (var reminder in commandResult.Reminders)
                {
                    var reminderInList = _reminders.Find((r) => reminder.UId == r.UId);

                    if (reminderInList != null)
                        _reminders.Remove(reminderInList);
                }
            }
        }
    }
}
