namespace ReminderBotCore.Models
{
    public class ReminderChat
    {
        public long ChatId { get; set; }
        public bool isActive { get; set; }
        public List<ReminderUnit> reminders { get; set; }

        public ReminderChat(long chatId)
        {
            isActive = true;
            reminders= new List<ReminderUnit>();
            ChatId = chatId;
        }
    }
}
