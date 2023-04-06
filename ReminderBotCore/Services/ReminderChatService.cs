using ReminderBotCore.Models;
using ReminderBotCore.Repositories;

namespace ReminderBotCore.Services
{
    public class ReminderChatService
    {
        private IBotRepo dbRepo;
        public ReminderChatService(IBotRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public void AddReminderUnit(ReminderChat chat, string[] args)
        {
            DateTime dateTime = DateTime.Now;
            chat.reminders.Add(new ReminderUnit(args[0], dateTime, args[3]));
            // Вызов добавления в бд должен быть тут еще
        }
        public void AddDefaultReminders(ReminderChat chat)
        {
            chat.reminders.Add(new ReminderUnit("Hunt", new DateTime(2022, 04, 19, 5, 0, 0), "Охота"));
            chat.reminders.Add(new ReminderUnit("Tsar", new DateTime(2022, 04, 19, 13, 0, 0), "Царь"));
            chat.reminders.Add(new ReminderUnit("Cart", new DateTime(2022, 04, 19, 15, 0, 0), "Повозки"));
        }

    }
}
