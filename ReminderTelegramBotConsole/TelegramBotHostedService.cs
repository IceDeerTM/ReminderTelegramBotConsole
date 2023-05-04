using Microsoft.Extensions.Hosting;
using ReminderTelegramBotConsole.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace ReminderTelegramBotConsole
{
    public class TelegramBotHostedService : BackgroundService
    {
        private readonly TelegramBotService telegramBotService;
        private readonly IHostApplicationLifetime lifetime;

        public TelegramBotHostedService(TelegramBotService deerTelegramBotService, IHostApplicationLifetime lifetime)
        {
            this.telegramBotService = deerTelegramBotService;
            this.lifetime = lifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!await WaitForAppStartup(lifetime, stoppingToken))
                return;

            var receiverOptions = new ReceiverOptions();

            telegramBotService.Bot.StartReceiving(telegramBotService,
                receiverOptions,
                stoppingToken
            );
            Console.WriteLine("Запуск прослушивания сообщений ботом.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(60000);
                await telegramBotService.ExecutePushNotification();
            }

            await telegramBotService.Close();
        }
        static async Task<bool> WaitForAppStartup(IHostApplicationLifetime lifetime, CancellationToken stoppingToken)
        {
            // 👇 Создаём TaskCompletionSource для ApplicationStarted
            var startedSource = new TaskCompletionSource();
            using var reg1 = lifetime.ApplicationStarted.Register(() => startedSource.SetResult());

            // 👇 Создаём TaskCompletionSource для stoppingToken
            var cancelledSource = new TaskCompletionSource();
            using var reg2 = stoppingToken.Register(() => cancelledSource.SetResult());

            // Ожидаем любое из событий запуска или запроса на остановку
            Task completedTask = await Task.WhenAny(startedSource.Task, cancelledSource.Task).ConfigureAwait(false);

            // Если завершилась задача ApplicationStarted, возвращаем true, иначе false
            return completedTask == startedSource.Task;
        }
    }
}
