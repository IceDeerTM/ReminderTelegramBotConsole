using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using System.Text.Json;
using Telegram.Bot.Types.Enums;
using ReminderBotCore.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ReminderBotCore.Commands;
using ReminderBotCore.CommandResults;
using ReminderBotCore.Services;

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

        private ITelegramBotClient bot;
        private ILogger? logger;
        private IFactoryBotCommand factoryBotCommand;
        private IBotCommandReminder commandReminder;
        private ISenderMessage senderMessage;

        public TelegramBotService(IConfiguration configuration, ILogger logger, IFactoryBotCommand factoryBotCommand)
        {
            this.factoryBotCommand = factoryBotCommand;
            
            this.logger = logger;
            string botToken = "";
            this.logger?.LogInformation(configuration.ToString());
            bot = new TelegramBotClient(botToken);
            senderMessage = new TelegramSenderMessage(bot);
            commandReminder = factoryBotCommand.CreateBotCommandReminder(senderMessage);
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update != null)
            {
                Console.WriteLine(JsonSerializer.Serialize(update));

                try
                {
                    if (update.Type == UpdateType.Message)
                    {
                        if (update.Message!= null) 
                        {
                            if (!string.IsNullOrEmpty(update.Message.Text))
                            {
                                var chatId = update.Message.Chat.Id;
                                var requestString = update.Message.Text.ToLower();

                                IBotCommand botCommand = factoryBotCommand.CreateBotCommand(requestString);
                                
                                if (botCommand is BotCommandNotExist)
                                {
                                    // Поскольку данной команды нету в пуле команд бота, то мы можем либо сообщить юзеру об этом
                                    // Либо же просто проигнорировать это и сделать return
                                    return;
                                }
                                else
                                {
                                    ChatCredentials chatCredentials = new ChatCredentials(update.Message.Chat.Id.ToString(), update.Message.Chat.Username);
                                    IUserBotCommandResult result = await botCommand.ExecuteCommand(chatCredentials);

                                    commandReminder.Update(result);

                                    await botClient.SendTextMessageAsync(chatId, result.Message);
                                }
                                
                            }
                        }
                    }
                    else if (update.Type == UpdateType.ChatMember)
                    {
                        // Проверка на удаление бота из чата
                        if (update.MyChatMember?.NewChatMember is ChatMemberBanned && update.MyChatMember?.NewChatMember.User.Id == bot.BotId)
                        {
                            ICommandDeleteBot botCommand = factoryBotCommand.CreateBotCommandDeleteBot();
                            ChatCredentials chatCredentials = new ChatCredentials(update.MyChatMember.Chat.Id.ToString(), update.MyChatMember.Chat.Username);
                            var commandResult = await botCommand.ExecuteCommandDelete(chatCredentials);
                            commandReminder.Update(commandResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            this.logger?.LogCritical(exception.Message);
            return Task.CompletedTask;
        }

        public async Task Close()
        {
            Console.ReadLine();
            await bot.CloseAsync();
        }

        public async Task ExecutePushNotification()
        {
            await commandReminder.ExecuteCommand();
        }

    }
}