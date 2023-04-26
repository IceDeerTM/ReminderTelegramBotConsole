using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReminderBotCore.Commands;
using ReminderBotCore.Repositories;
using ReminderBotCore.Services;
using ReminderTelegramBotConsole.Repositories;
using ReminderTelegramBotConsole.Services;
using ReminderTelegramBotConsole.Utils;

namespace ReminderTelegramBotConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {

                services.AddSingleton<IBotRepo, EFRepo>();
                services.AddSingleton<ReminderUnitService>();
                services.AddSingleton<ReminderChatService>();
                services.AddSingleton<IFactoryBotCommand, FactoryBotCommand>();
                services.AddTransient<ILogger, FileLogger>();
                services.AddSingleton<TelegramBotService>();
                services.AddHostedService<TelegramBotHostedService>();
            });
            IHost app = builder.Build();
            Console.WriteLine("Приложение запущено.");

            app.Start();

            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Приложение закрывается.");
                    break;
                }
            }
        }
    }
}