using Microsoft.EntityFrameworkCore;
using ReminderBotCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderTelegramBotConsole.Utils
{
    public class BotDbContext: DbContext
    {
        public DbSet<ReminderChat> Chats { get; protected set; }
        public DbSet<ReminderUnit> Reminders { get; protected set; }

        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
