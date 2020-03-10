using System;
using Telegram.Bot;
using System.IO;

namespace SOKPO_NotificationsBot
{
    class Program
    {
        static void Main()
        {
            Config config = new Config();
            var botClient = new TelegramBotClient(config.token);

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
        }
    }
}
