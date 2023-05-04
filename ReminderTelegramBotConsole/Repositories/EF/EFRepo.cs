using Microsoft.EntityFrameworkCore;
using ReminderBotCore.Models;
using ReminderBotCore.Repositories;
using ReminderTelegramBotConsole.Utils;

namespace ReminderTelegramBotConsole.Repositories.EF
{
    public class EFRepo : IBotRepo
    {
        private BotDbContext db;

        public EFRepo(BotDbContext db)
        {
            this.db = db;
        }

        public async Task<ReminderChat> AddReminderChat(ReminderChat chat)
        {
            _ = await db.Chats.AddAsync(chat);
            _ = await db.SaveChangesAsync();
            return chat;
        }

        public async Task<ReminderUnit> AddReminderUnit(ReminderUnit reminderUnit)
        {
            _ = await db.Reminders.AddAsync(reminderUnit);
            _ = await db.SaveChangesAsync();
            return reminderUnit;
        }

        public async Task<ReminderUnit> DeleteReminder(ReminderUnit reminder)
        {
            _ = db.Reminders.Remove(reminder);
            _ = await db.SaveChangesAsync();
            return reminder;
        }

        public async Task<ReminderChat> DeleteReminderChat(ReminderChat chat)
        {
            _ = db.Chats.Remove(chat);
            _ = await db.SaveChangesAsync();
            return chat;
        }

        public async Task<ReminderChat> GetChat(string chatId)
        {
            return await db.Chats.Where(chat => chat.ChatId == chatId).FirstOrDefaultAsync();
        }

        public async Task<List<ReminderChat>> GetChats()
        {
            return await db.Chats.ToListAsync();
        }

        public async Task<int> GetCountReminders(ReminderChat chat)
        {
            return await db.Reminders.CountAsync();
        }

        public async Task<ReminderUnit> GetReminderByGuid(string id)
        {
            return await db.Reminders.Where(reminder => reminder.UId.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<List<ReminderUnit>> GetReminders(ReminderChat chat)
        {
            return await db.Reminders.Where(reminder => reminder.ReminderChatId == chat.Id).ToListAsync();
        }

        public async Task<List<ReminderUnit>> GetRemindersForHour(DateTime dateTime)
        {
            return await db.Reminders
                .Where(r => r.TimeRemind.Hour == dateTime.Hour && r.IsReminder == false && r.isActive == true)
                .ToListAsync();
        }

        public async Task<ReminderUnit> UpdateNotification(ReminderUnit reminder)
        {
            ReminderUnit rem = db.Reminders.Update(reminder).Entity;
            _ = await db.SaveChangesAsync();
            return rem;
        }
    }
}
