using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using System.Text.Json;
using Telegram.Bot.Types.Enums;
using ReminderBotCore.Models;
using ReminderBotCore.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ReminderTelegramBotConsole.Services
{
    public class TelegramBotService : IUpdateHandler
    {
        public ITelegramBotClient Bot
        {
            get => bot;
            private set
            {
                if (value != null) bot = value;
            }
        }

        private List<ReminderChat> chats = new List<ReminderChat>();
        private ITelegramBotClient bot;
        private DateTime serverTime = DateTime.Now;
        private ReminderChatService chatService;
        private ReminderUnitService unitService;
        private ILogger? logger;
        

        public TelegramBotService(IConfiguration configuration, ILogger logger, ReminderChatService chatService, ReminderUnitService unitService)
        {
            this.logger = logger;
            string botToken = "botToken";
            this.logger?.LogInformation(configuration.ToString());
            bot = new TelegramBotClient(botToken);
            this.chatService = chatService;
            this.unitService = unitService;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonSerializer.Serialize(update));


            if (update?.Type == UpdateType.Message)
            {
                var message = update.Message;
                
                if (message != null)
                {
                    var messageText = message.Text?.ToLower();
                    var chat = chats.Where(item => item.ChatId == message.Chat.Id).FirstOrDefault();
                    if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/start"))
                    {
                        if (chat == null)
                        {
                            chats.Add(new ReminderChat(message.Chat.Id));
                            await botClient.SendTextMessageAsync(message.Chat, "Чат добавлен в бота.");
                        }
                        else
                        {
                            if (chat.isActive == false)
                            {
                                chat.isActive = true;
                                await botClient.SendTextMessageAsync(message.Chat, "Чат активирован.");
                            }
                            else await botClient.SendTextMessageAsync(message.Chat, "Уже активно.");

                        }
                        return;
                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/defautl_settings"))
                    {
                        if (chat != null)
                        {
                            chatService.AddDefaultReminders(chat);
                            await botClient.SendTextMessageAsync(message.Chat, "Дефолтные настройки отправки напоминаний для хана применены.");
                        }
                        else await botClient.SendTextMessageAsync(message.Chat, "Неизвестная ошибка. Попробуйте инициализировать бота в чате командой '/start'.");

                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/disable"))
                    {
                        if (chat != null)
                        {
                            chat.isActive = false;
                            await botClient.SendTextMessageAsync(message.Chat, "Напоминания отключены. Для активации use '/start'.");
                        }
                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/add"))
                    {
                        if (chat != null)
                        {
                            string[] requestString = messageText.Split(" ");
                            await botClient.SendTextMessageAsync(message.Chat, "Функция в разработке.");
                        }
                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/list"))
                    {
                        if (chat != null)
                        {
                            string responseMessage = "Список напоминаний:";
                            foreach (var reminder in chat.reminders)
                                responseMessage += "\r\n" + $"Message: {reminder.Message}" + $"\r\n Id: {reminder.id}" + $"\r\n Время:{reminder.TimeRemind.Hour}:00" + ">>>>>>";

                            await botClient.SendTextMessageAsync(message.Chat, responseMessage);
                        }
                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/delete_all"))
                    {
                        if (chat != null)
                        {
                            chat.reminders.Clear();
                            await botClient.SendTextMessageAsync(message.Chat, "Напоминания удалены.");
                        }
                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/count"))
                    {
                        if (chat != null)
                        {
                            await botClient.SendTextMessageAsync(message.Chat, $"Количество напоминаний: {chat.reminders.Count}");
                        }
                    }
                    else if (!string.IsNullOrEmpty(messageText) && messageText.Contains("/delete"))
                    {
                        if (chat != null)
                        {
                            string[] requestString = messageText.Split(" ");
                            if (requestString.Length > 1)
                            {
                                var reminder = chat.reminders.Where(rem => rem.id == new Guid(requestString[1])).FirstOrDefault();
                                if (chat.reminders.Remove(reminder))
                                    await botClient.SendTextMessageAsync(message.Chat, "Успешно удалено.");
                                else await botClient.SendTextMessageAsync(message.Chat, "Нет такого напоминания.");

                            }
                            else await botClient.SendTextMessageAsync(message.Chat, "Ошибка запроса.");
                        }
                    }
                }
            }
        }


        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            this.logger?.LogCritical(exception.Message);
            return Task.CompletedTask;
        }

        public async Task Close()
        {
            Console.ReadLine();
            await bot.CloseAsync();
        }

        public async Task CheckTime()
        {
            var currentDay = DateTime.Now.Day;
            if ((currentDay > serverTime.Day) || ((currentDay == 1) && (currentDay < serverTime.Day))) // Наступил ли следующий день?
            {
                serverTime = DateTime.Now;
                foreach (var chat in chats) 
                {
                    if (chat.isActive)
                    {
                        foreach (var reminder in chat.reminders) reminder.IsReminder = false;
                    }
                }
            }

            foreach(var chat in chats)
            {
                if (chat.isActive)
                {
                    foreach (var reminder in chat.reminders)
                    {
                        DateTime now = DateTime.Now;
                        if (reminder.isSendNotification(now))
                        {
                            await bot.SendTextMessageAsync(new ChatId(chat.ChatId), reminder.Message);
                        }
                    }
                }
            }

        }

    }
}