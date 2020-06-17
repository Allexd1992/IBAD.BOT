using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using MihaZupan;
using System.Timers;
using Telegram.Bot.Types;

namespace IBAD.BOT.BOT
{
    public class TelegramBot
    {

        public event EventHandler IbadStatusGet;
        public event EventHandler IbadErrorsGet;
        public event EventHandler MoikaStatusGet;
        public event EventHandler MoikaErrorsGet;
        private static HttpToSocks5Proxy proxy;
        private static ITelegramBotClient botClient;


        public TelegramBot()
        {
            proxy = new HttpToSocks5Proxy("80.211.202.168", 1080, "administrator", "Pld-2019");
            botClient = new TelegramBotClient("1153304260:AAExFeKzxfE6ozkeJkR-_SVj57YwGRYu2A0", proxy) { Timeout = TimeSpan.FromSeconds(10) };
            try
            {

                var me = botClient.GetMeAsync().Result;
                botClient.StartReceiving();
                Console.WriteLine($"ID { me.Id} ame: { me.FirstName}" + " Telegram instal");
                botClient.OnMessage += BotClient_OnMessage;
                botClient.OnCallbackQuery += BotClient_OnCallbackQuery;
                BotButton(-457313294);

            }
            catch (Exception ex)
            {
                // LogWriter.WriteLog("", "", "Telegram instal" + ex.Message, 0);
            }
        }
        public async void SendMessageChat(string Msg)
        { 
            try
            { 
            await botClient.SendTextMessageAsync(-1001421866430, Msg);
            }
            catch
            { LogWriter.WriteLog("", "", "Error from Send message : Telegram Bot", 0); }
        }
        public async void SendMessage(long ChatID,  string Msg)
        {
            try
            {
                await botClient.SendTextMessageAsync(ChatID, Msg);
            }
            catch
            { LogWriter.WriteLog("", "", "Error from Send message : Telegram Bot", 0); }
        }
        private async void BotClient_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            var message = e.CallbackQuery.Message;

            if (e.CallbackQuery.Data == "callback1")
            {
                await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "Проверяем статус установки");
                //await botClient.SendTextMessageAsync(message.Chat.Id, " Статус IBAD: \n");
                IbadStatusGet?.Invoke(message, null);
            }

            if (e.CallbackQuery.Data == "callback2")
            {
                await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "Проверяем  установку на ошибки");
               
                IbadErrorsGet?.Invoke(message, null);

                // await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
            }

            if (e.CallbackQuery.Data == "callback3")
            {
                await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "Проверяем статус установки");
                //await botClient.SendTextMessageAsync(message.Chat.Id, "В разработке");
                MoikaStatusGet?.Invoke(message, null);
                // await botClient.SendTextMessageAsync(message.Chat.Id, "IBAD status: \n" + MOIKAStatusGet()) ;
            }

            if (e.CallbackQuery.Data == "callback4")
            {
                await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "Проверяем  установку на ошибки");
                await botClient.SendTextMessageAsync(message.Chat.Id, "Ошибок нет");
                MoikaErrorsGet?.Invoke(message, null);
                // await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
            }


        }

        private static async void BotButton(long ID)
        {

            try
            {
                var keyboard = new ReplyKeyboardMarkup
                {
                    Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new KeyboardButton("/MOIKA"),
                                                    new KeyboardButton("/IBAD")
                                                },
                                            },
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(ID, "Выберите установку \n ", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
            }
            catch (Exception)
            {


            }

        }
        private static async void SysButtonIBAD(long ID)
        {
            var keyboard = new InlineKeyboardMarkup(
                                                    new InlineKeyboardButton[][]
                                                    {
                                                            // First row
                                                            new InlineKeyboardButton[] {
                                                                // First column
                                                                new InlineKeyboardButton(){Text="Статус", CallbackData ="callback1" },

                                                                // Second column
                                                                new InlineKeyboardButton(){Text="Ошибки", CallbackData ="callback2" },
                                                            },
                                                    }

                                                );


            await botClient.SendTextMessageAsync(ID, "IBAD: Выберете команду", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
        }
        private static async void SysButtonMOIKA(long ID)
        {
            var keyboard = new InlineKeyboardMarkup(
                                                    new InlineKeyboardButton[][]
                                                    {
                                                            // First row
                                                            new InlineKeyboardButton[] {
                                                                // First column
                                                                new InlineKeyboardButton(){Text="Статус", CallbackData ="callback3" },

                                                                // Second column
                                                                new InlineKeyboardButton(){Text="Ошибки", CallbackData ="callback4" },
                                                            },
                                                    }

                                                );


            await botClient.SendTextMessageAsync(ID, "MOIKA: Выберете команду", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
        }

        private static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            Console.WriteLine(e?.Message?.Text);
            if (text == null)
            {
                return;
            }
            Console.WriteLine(e.Message.Chat.Id);
            if (text == "/system")
            {
                BotButton(e.Message.Chat.Id);

            }
            if (text.ToUpper() == "/MOIKA")
            {

                SysButtonMOIKA(e.Message.Chat.Id);
            }
            if (text.ToUpper() == "/IBAD")
            {

                SysButtonIBAD(e.Message.Chat.Id);
            }

        }

    }
}
