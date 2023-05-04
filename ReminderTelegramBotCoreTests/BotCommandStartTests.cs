using Moq;
using ReminderBotCore.Commands;
using ReminderBotCore.Models;
using ReminderBotCore.Repositories;
using ReminderBotCore.Services;

namespace ReminderTelegramBotCoreTests
{
    public class BotCommandStartTests
    {
        private Mock<IReminderChatService> chatService = new Mock<IReminderChatService>();
        private string requestString = "/start";
        private static List<ReminderChat> chats = GetChats();

        [Fact]
        public void ExecuteSubCommand_Test()
        {
            ChatCredentials chat = new ChatCredentials("214214", null);

            // Arrange
            var botCommand = GetBotCommand();

            // Act
            var botResult = botCommand.ExecuteCommand(chat).Result;

            // Assert
            Assert.Equal("Бот активирован.", botResult.Message);
        }

        [Fact]
        public void ExecuteSubCommand_Test2()
        {
            ChatCredentials chat = new ChatCredentials("12345", null);

            // Arrange
            var botCommand = GetBotCommand();

            // Act
            var botResult = botCommand.ExecuteCommand(chat).Result;

            // Assert
            Assert.Equal("Уже активно.", botResult.Message);
            chatService.Verify();
        }

        private IBotCommand GetBotCommand() 
        {
            var mockRepo = new Mock<IBotRepo>();
            mockRepo.Setup(m => m.AddReminderChat(It.IsAny<ReminderChat>())).Returns((ReminderChat x) => {
                if (!chats.Contains(x))
                {
                    x.Id = chats.Count;
                    chats.Add(x);
                }
                Console.WriteLine(chats.Count);
                return Task.FromResult(x);
            });

            mockRepo.Setup(m => m.GetChat(It.IsAny<string>())).Returns((string l) => Task.FromResult(chats.Where(chat => chat.ChatId == l).FirstOrDefault()));

            chatService.Setup(m => m.GetChat(It.IsAny<string>())).Returns((string l) => mockRepo.Object.GetChat(l)).Verifiable();
            chatService.Setup(m => m.AddReminderChat(It.IsAny<ReminderChat>())).Returns((ReminderChat x) => mockRepo.Object.AddReminderChat(x));

            var botCommand = new BotCommandStart(requestString, chatService.Object);

            return botCommand;
        }
        private static List<ReminderChat> GetChats()
        {
            ReminderChat chat1 = new ReminderChat("12345L", null); chat1.Id = 0;
            ReminderChat chat2 = new ReminderChat("23456L", null); chat1.Id = 1;
            return new List<ReminderChat> { chat1, chat2 };
        }
    }
}