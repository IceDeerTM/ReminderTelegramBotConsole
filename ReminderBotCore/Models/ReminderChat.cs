namespace ReminderBotCore.Models
{
    public class ReminderChat
    {
        public long ChatId { get; set; }
        public List<ReminderUnit> reminders { get; set; }

        public ReminderChat(long chatId)
        {
            reminders= new List<ReminderUnit>();
            ChatId = chatId;
        }
    }
}
