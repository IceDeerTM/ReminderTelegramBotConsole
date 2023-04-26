namespace ReminderBotCore.Models
{
    /// <summary>
    /// Модель чата
    /// </summary>
    public class ReminderChat
    {
        /// <summary>
        /// Идентификатор чата(в частности в ТГ это long)
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// Список напоминаний, привязанных к чату
        /// </summary>
        public List<ReminderUnit> Reminders { get; set; }

        public ReminderChat(long chatId)
        {
            Reminders= new List<ReminderUnit>();
            ChatId = chatId;
        }
    }
}
