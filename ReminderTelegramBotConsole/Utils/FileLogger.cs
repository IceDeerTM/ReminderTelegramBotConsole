using Microsoft.Extensions.Logging;

namespace ReminderTelegramBotConsole.Utils
{
    public class FileLogger : ILogger
    {
        string filePath = "log.txt";

        public FileLogger()
        {
            if (File.Exists(filePath)) { File.Delete(filePath); }
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
        }
    }
}
