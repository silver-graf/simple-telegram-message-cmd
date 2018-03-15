using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using telegramBot.mining_tool;

namespace telegramBot
{
    class Telegrammes
    {


        public static int offset = 0; // отступ по сообщениям
        static string chatId = ""; //имя канала
        static string key = ""; //имя канала
        static TelegramBotClient bot = new TelegramBotClient("");//инициализация;

        public static async void SendMes(string mes)
        {//my 47130610
            var msg = await bot.SendTextMessageAsync(chatId, mes); // тип парсинга сообщения Markdown        
        }

        public static void initTel()
        {
            offset = bot.MessageOffset;
            bot.SetWebhookAsync("");
        }
        static string cur = "";
        // static List<string> curr = new List<string>();

        public static async void getCurency()
        {

            // Обязательно! убираем старую привязку к вебхуку для бота           

            try
            {
                var updates = await bot.GetUpdatesAsync(offset); // получаем массив обновлений

                foreach (var update in updates) // Перебираем все обновления
                {
                    if (update != null && update.Message.Text != null)
                    {
                        if (update.Message.Text.ToString() == "/saycur")
                        {
                            Market m = KunaExplorer.GetTicker("btcuah").Result;
                            SendMes("btcuah: " + m.ticker.last + " ");
                        }
                        if (update.Message.Text.ToString() == "/nanopoolpr")
                        {
                            NanopoolPrice m = NanopoolExplorer.ETNNanopoolPrice("etnjzKFU6ogESSKRZZbdqraPdcKVxEC17Cm1Xvbyy76PARQMmgrgceH4krAH6xmjKwJ3HtSAKuyFm1BBWYqtchtq9tBap8Qr4M.3372294e90bbf9e0159556d0058c528b19d179906fdce413357dd4905caee9b7").Result;
                            SendMes("btc_etn: " + m.data.price_btc + "\r\n " + "btc_etn: " + m.data.price_usd);
                        }

                        if (update.Message.Text.ToString() == "/but")
                        {
                            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.KeyboardButton("Накатим!"),
                                                    new Telegram.Bot.Types.KeyboardButton("Рря!")
                                                },
                                            },
                                ResizeKeyboard = true
                            };

                            await bot.SendTextMessageAsync(chatId, "Давай накатим, товарищ, мой!", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                        }
                        if (update.Message.Text.ToString() == "/delkeyb")
                        {


                            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardRemove();
                            await bot.SendTextMessageAsync(chatId, "клавиатура отключена", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);


                        }

                    }


                    offset = update.Id + 1;
                }

            }

            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {

                //Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }

        }

    }
}
