using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Repositories;
using ReminderBotCore.Services;
using ReminderTelegramBotConsole.Repositories.EF;
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
                services.AddDbContext<BotDbContext>(options => options.UseMySql("connectionString", new MySqlServerVersion(Version.Parse("10.0.38"))));
                services.AddSingleton<IBotRepo, EFRepo>();
                services.AddSingleton<IReminderUnitService, ReminderUnitService>();
                services.AddSingleton<IReminderChatService, ReminderChatService>();
                services.AddSingleton<IFactoryBotCommand, FactoryBotCommand>();
                services.AddTransient<ILogger, FileLogger>();
                services.AddSingleton<TelegramBotService>();
                services.AddHostedService<TelegramBotHostedService>();
            });
            IHost app = builder.Build();
            Console.WriteLine("Приложение запущено.");

            app.Start();

            while (true)
            {
            }
        }
    }
}