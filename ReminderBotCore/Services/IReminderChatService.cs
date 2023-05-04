using ReminderBotCore.Models;
using ReminderBotCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Services
{
    public interface IReminderChatService
    {
        public Task<ReminderChat> GetChat(string chatId);

        public Task<List<ReminderChat>> GetChats();

        public Task<ReminderChat> AddReminderChat(ReminderChat chat);

        public Task<ReminderChat> DeleteReminderChat(ReminderChat chat);
    }
}
