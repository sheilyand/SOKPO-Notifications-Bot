using System;
using Telegram.Bot;
using System.IO;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using Telegram.Bot.Args;

namespace SOKPO_NotificationsBot
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main()
        {
            Config config = new Config();
            botClient = new TelegramBotClient(config.token);

            //var me = botClient.GetMeAsync().Result;
            //Console.WriteLine(
            //  $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            //);

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat, // or a chat id: 123456789
                  text: "Trying *all the parameters* of `sendMessage` method",
                  parseMode: ParseMode.Markdown,
                  disableNotification: true,
                  replyToMessageId: e.Message.MessageId,
                  replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                    "Check sendMessage method",
                    "https://core.telegram.org/bots/api#sendmessage"
                  ))
                );

                
            }
        }
    }
}
