namespace ReminderBotCore.Models
{
    /// <summary>
    /// Модель напоминалки.
    /// </summary>
    public class ReminderUnit : BaseEntity
    {
        /// <summary>
        /// Уникальный идентификатор напоминания.
        /// </summary>
        public Guid UId { get; set; }

        /// <summary>
        /// Идентификатор выполнения напоминания, если true - то напоминание было выполнено.
        /// </summary>
        public bool IsReminder { get; set; }

        /// <summary>
        /// Идентификатор активно ли напоминание или отключено.
        /// </summary>
        public bool isActive { get; set; }

        /// <summary>
        /// Время когда напоминание должно быть исполнено.
        /// </summary>
        public DateTime TimeRemind { get; set; }

        /// <summary>
        /// Сообщение которое будет передано пользователю во время исполнения напоминания.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Идентификатор строки чата в бд
        /// </summary>
        public int ReminderChatId { get; set; }

        /// <summary>
        /// Чат, к которому привязано напоминание.
        /// </summary>
        public ReminderChat ReminderChat { get; set; }

        public ReminderUnit() // Без конструктора по умолчанию не создается бд
        {

        }

        public ReminderUnit(DateTime date, string message, ReminderChat chat) 
        {
            UId = Guid.NewGuid();
            TimeRemind = date;
            Message = message;
            ReminderChat = chat;
            isActive = true;
            
            if (DateTime.Now.Hour >= TimeRemind.Hour)
            {
                if (DateTime.Now.Minute >= TimeRemind.Minute) 
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
