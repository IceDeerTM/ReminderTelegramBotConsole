namespace ReminderBotCore.Models
{
    /// <summary>
    /// Модель чата
    /// </summary>
    public class ReminderChat : BaseEntity
    {
        /// <summary>
        /// Идентификатор чата
        /// </summary>
        public string ChatId { get; set; }

        /// <summary>
        /// Название чата
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список напоминаний, привязанных к чату
        /// </summary>
        public List<ReminderUnit> Reminders { get; set; } = new List<ReminderUnit>();

        public ReminderChat(string chatId, string? name)
        {
            ChatId = chatId;
            Name = name != null? name: "";
        }
    }
}
