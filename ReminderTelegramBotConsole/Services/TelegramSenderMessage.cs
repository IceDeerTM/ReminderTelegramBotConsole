using ReminderBotCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ReminderTelegramBotConsole.Services
{
    internal class TelegramSenderMessage : ISenderMessage
    {
        protected ITelegramBotClient TelegramBot { get; private set; }

        public TelegramSenderMessage(ITelegramBotClient telegramBot)
        {
            TelegramBot = telegramBot;
        }

        public async Task SendMessage(string chatId, string message)
        {
            await TelegramBot.SendTextMessageAsync(new ChatId(long.Parse(chatId)), message);
        }
    }
}
