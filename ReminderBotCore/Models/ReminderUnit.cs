namespace ReminderBotCore.Models
{
    public class ReminderUnit
    {
        public Guid id { get; set; }
        public bool IsReminder { get; set; }
        public DateTime TimeRemind { get; set; }
        public string Message { get; set; }

        public int ReminderChatId { get; set; }
        public ReminderChat Chat { get; set; }

        public ReminderUnit(DateTime date, string message, ReminderChat chat) 
        {
            id = Guid.NewGuid();
            TimeRemind = date;
            Message = message;
            Chat = chat;

            if (DateTime.Now.Hour >= TimeRemind.Hour)
            {
                IsReminder = true;
            }
        }

        public bool isSendNotification(DateTime now)
        {
            if (!IsReminder)
            {
                if (now.Hour == TimeRemind.Hour)
                {
                    IsReminder = true;
                    return true;
                }
            }

            return false;
        }
    }
}
