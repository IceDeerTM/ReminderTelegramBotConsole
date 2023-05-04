using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBotCore.Models
{
    public class ChatCredentials
    {
        public string? Name { get; init; }
        public string ChatId { get; init; }

        public ChatCredentials(string chatId, string? name)
        {
            Name = name;
            ChatId = chatId;
        }
    }
}
