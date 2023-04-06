namespace ReminderBotCore.Models
{
    public class ReminderUnit
    {
        public string Name { get; set; }
        public Guid id { get; set; }
        public bool IsReminder { get; set; }
        public DateTime TimeRemind { get; set; }
        public string Message { get; set; }

        public ReminderUnit(string name, DateTime date, string message) 
        {
            id = Guid.NewGuid();
            Name = name;
            TimeRemind = date;
            Message = message;

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
