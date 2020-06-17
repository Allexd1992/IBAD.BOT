using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using IBAD.BOT.BufferBlocks;
using IBAD.BOT.BOT;
using Telegram.Bot.Types;

namespace IBAD.BOT.BL
{
    class Model
    {
        TelegramBot bot;
        BufferBlock buffer;
        private  bool Autorun_on_Old;
        private bool[] Flags;
        private bool Reel_on_Old;
        private bool lengthStatus;
        private short Autorun_Step_Old;
        private bool Autorun_Complete_Old;
        private bool ErrIbadFlag;
        private bool ErrScadaFlag;
        private bool ErrTermFlag;
        private bool ErrMoikaFlag;

        public Model()
        {
            Flags = new bool[31];
            buffer = new BufferBlock();
            bot = new TelegramBot();
            bot.IbadErrorsGet += Bot_IbadErrorsGet;
            bot.IbadStatusGet += Bot_IbadStatusGet;
            bot.MoikaStatusGet += Bot_MoikaStatusGet;
            var time = new Timer(10000);
            time.AutoReset = true;
            time.Enabled = true;
            time.Elapsed += Time_Elapsed;

        }

        private void Bot_MoikaStatusGet(object sender, EventArgs e)
        {
            try
            {
                var message = sender as Telegram.Bot.Types.Message;
                var msg = MoikaStatusGet();
                GC.Collect();
                bot.SendMessage(message.Chat.Id, "Статус Moika: \n" + msg);
            }
            catch
            { LogWriter.WriteLog("", "", "Error from MoikaStatusGet", 0); }
        }

        private void Bot_IbadStatusGet(object sender, EventArgs e)
        {
            try
            {
                var message = sender as Telegram.Bot.Types.Message;
                var msg = IBADStatusGet();
                GC.Collect();
                bot.SendMessage(message.Chat.Id, "Статус IBAD: \n" + msg);
            }
            catch
            { LogWriter.WriteLog("", "", "Error from IbadStatusGet", 0); }
        }

        private void Bot_IbadErrorsGet(object sender, EventArgs e)
        {
            try
            {
                var message = sender as Telegram.Bot.Types.Message;
                var msg = IBADErrorGet();
                bot.SendMessage(message.Chat.Id, "Ошибки IBAD: \n" + msg);
                GC.Collect();
            }
            catch { LogWriter.WriteLog("", "", "Error from Bot_IbadErrorsGet", 0); }
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            IBADErrorScan();
            IBADStatusScan();
            MoikaStatusScan();
        }
        private string IBADErrorGet()
        {
            string msg = "";
            int i = 0;

            var buff = buffer.Al2O3Ch1TmpEr; 
            //Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Al2O3 Chamber 01 TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Al2O3Ch2TmpEr;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Al2O3 Chamber 02 TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Dc01Er;
            //Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of DC 01. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Dc02Er;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of DC 02. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.HomoEplTmpEr;
            Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Homo Epl TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.HomoEplHeat01Er;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Homo Epl Heater 1. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.HomoEplHeat02Er;
            Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Homo Epl Heater 2. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.HomoEplHeat03Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Homo Epl Heater 3. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.HomoEplHeat04Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Homo Epl Heater 4. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.HomoEplHeat05Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Homo Epl Heater 5. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.LmoHeat01Er; 
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of LMO Heater 1. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.LmoHeat02Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of LMO Heater 2. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.LmoHeat03Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of LMO Heater 3. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.LmoHeat04Er;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of LMO Heater 4. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.LmoHeat05Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of LMO Heater 5. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.LmoTmpEr;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of LMO TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.IbadTmpAer;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of TMP A. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.IbadTmpBer;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of TMP B. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.IbadTmpCer;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of TMP C. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.IbadTmpDer;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of TMP D. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Neck23TmpEr;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of neck 2-3 TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Neck34TmpEr;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of neck 3-4 TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Neck56TmpEr;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of neck 5-6 TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff =  buffer.Rf01Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of RF 1. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Rf02Er;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of RF 2. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.RheedTmpEr;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of RHEED TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.UnwindTmpEr;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Unwind TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff =buffer.WindTmpEr;
           // Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Wind TMP. Error cod: " + buff + "\n";
                i++;
            }

            buff = buffer.Y2O3TmpEr;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                msg += "Error of Y2O3 TMP. Error cod: " + buff + "\n";
                i++;
            }

            bool buff2 = buffer.eGun01Er;
          //  Console.WriteLine(buff2);
            if (buff2)
            {
                msg += "Error of EGUN 01" + "\n";
                i++;
            }

            buff2 = buffer.eGun02Er;
          //  Console.WriteLine(buff2);
            if (buff2)
            {
                msg += "Error of EGUN 02" + "\n";
                i++;
            }

            if (msg == "")
            {
                msg += "Ошибок нет\n";
            }
            else
            {
                msg += "Errors:" + i;
            }

            return msg;
        }
        private string IBADStatusGet()
        {
            string msg = "";
           
            var Reel_on =  buffer.ReelOn;
        //    Console.WriteLine("Start procc: " + Reel_on);
            if (Reel_on)
            {
                msg += "Установка запущена\n";

                var length = buffer.Length;
                msg += "Текущая длинна: " + string.Format("{0:0.00}", length) + " м" + "\n";
                var speed = buffer.Speed;
                msg += "Текущая скорость: " + string.Format("{0:0.00}", speed) + " м/мин" + "\n";
                var lengthSp = buffer.LengthSet;
                msg += "Суммарная длина " + string.Format("{0:0.00}", lengthSp) + " м" + "\n";
                var tape = buffer.CurTape;
               // Console.WriteLine(tape);
                //msg += "Текущая лента: " + tape + "\n";
                //var pos = buffer.TapePosition;
                ////Console.WriteLine(pos);
                //msg += "Текущая координата: " + pos + "\n";
                if (!buffer.ErrTERM)
                {
                    msg += "Текущая лента: " + tape + "\n";
                    var pos = buffer.TapePosition;
                    msg += "Текущая координата: " + pos + "\n";
                }
                else
                {
                    msg += "Для получения текущей ленты запустите программу терминала " + "\n";
                }
                int min = Convert.ToInt32((lengthSp - length) / speed);
                int hour = min / 60;
                min %= 60;
                msg += "Процесс закончится через: " + hour + " часов " + min + " минут" + "\n";

            }
            else
            {
                msg = "Процесс остановлен \n";
            }


            return msg;
        }
        private  void IBADErrorScan()
        {

            if (buffer.ErrIBAD)
            {
                if (!ErrIbadFlag)
                {
                    try
                    {
                        bot.SendMessageChat("Error connect with IBAD PLC " + "\n");
                        ErrIbadFlag = true;

                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                    
                }
              
            }
            else
            {
                ErrIbadFlag = false;
            }

            if (buffer.ErrSCADA)
            {
                if (!ErrScadaFlag)
                {
                    try
                    {
                        bot.SendMessageChat("Error connect with IBAD SCADA"  + "\n");
                        ErrScadaFlag = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                    
                }
               
            }
            else
            {
                ErrScadaFlag = false;
            }

            if (buffer.ErrTERM)
            {
                if (!ErrTermFlag)
                {
                    try
                    {
                        bot.SendMessageChat("Error connect with IBAD Terminal" + "\n");
                        ErrTermFlag = true;

                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                    
                }
             
            }
            else
            {
                ErrTermFlag = false;
            }


            var buff = buffer.Al2O3Ch1TmpEr;
      //      Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[0])
                {
                    try
                    {
                        bot.SendMessageChat("Error of Al2O3 Chamber 01 TMP. Error cod: " + buff + "\n");
                  
                    }
                    catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                Flags[0] = true;
                }
            }
            else
            {
                Flags[0] = false;
            }


            buff = buffer.Al2O3Ch2TmpEr;
       //     Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[1])
                {
                    try { 
                    bot.SendMessageChat("Error of Al2O3 Chamber 02 TMP. Error cod: " + buff + "\n");

                    Flags[1] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[1] = false;

            }

            buff = buffer.Dc01Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[2])
                {
                    try { 
                    bot.SendMessageChat("Error of DC 01. Error cod: " + buff + "\n");
                    Flags[2] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[2] = false;

            }

            buff = buffer.Dc02Er;
        //    Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[3])
                {
                    try { 
                    bot.SendMessageChat("Error of DC 02. Error cod: " + buff + "\n");
                    Flags[3] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[3] = false;

            }

            buff = buffer.HomoEplTmpEr;
        //    Console.WriteLine(buff);
            if (buff != 0)

            {
                if (!Flags[4])
                {
                    try { 
                    bot.SendMessageChat("Error of Homo Epl TMP. Error cod: " + buff + "\n");
                    Flags[4] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[4] = false;

            }

            buff = buffer.HomoEplHeat01Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[5])
                {
                    try { 
                    bot.SendMessageChat("Error of Homo Epl Heater 1. Error cod: " + buff + "\n");
                    Flags[5] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[5] = false;

            }

            buff = buffer.HomoEplHeat02Er;
        //    Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[6])
                {
                    try { 
                    bot.SendMessageChat("Error of Homo Epl Heater 2. Error cod: " + buff + "\n");
                    Flags[6] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[6] = false;

            }

            buff = buffer.HomoEplHeat03Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[7])
                {
                    try { 
                    bot.SendMessageChat("Error of Homo Epl Heater 3. Error cod: " + buff + "\n");
                    Flags[7] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[7] = false;

            }

            buff = buffer.HomoEplHeat04Er;
       //     Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[8])
                {
                    try { 
                    bot.SendMessageChat("Error of Homo Epl Heater 4. Error cod: " + buff + "\n");
                    Flags[8] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[8] = false;

            }

            buff = buffer.HomoEplHeat05Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[9])
                {
                    try { 
                    bot.SendMessageChat("Error of Homo Epl Heater 5. Error cod: " + buff + "\n");
                    Flags[9] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[9] = false;

            }

            buff = buffer.LmoHeat01Er;
         //  Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[10])
                {
                    try { 
                    bot.SendMessageChat("Error of LMO Heater 1. Error cod: " + buff + "\n");
                    Flags[10] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[10] = false;

            }

            buff = buffer.LmoHeat02Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[11])
                {
                    try { 
                    bot.SendMessageChat("Error of LMO Heater 2. Error cod: " + buff + "\n");
                    Flags[11] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[11] = false;

            }

            buff = buffer.LmoHeat03Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[12])
                {
                    try { 
                    bot.SendMessageChat("Error of LMO Heater 3. Error cod: " + buff + "\n");
                    Flags[12] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[12] = false;


            }

            buff = buffer.LmoHeat04Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[13])
                {
                    try { 
                    bot.SendMessageChat("Error of LMO Heater 4. Error cod: " + buff + "\n");
                    Flags[13] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[13] = false;

            }

            buff = buffer.LmoHeat05Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[14])
                {
                    try
                    {
                        bot.SendMessageChat("Error of LMO Heater 5. Error cod: " + buff + "\n");
                        Flags[14] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[14] = false;

            }

            buff = buffer.LmoTmpEr;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[15])
                {
                    try { 
                    bot.SendMessageChat("Error of LMO TMP. Error cod: " + buff + "\n");
                    Flags[15] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[15] = false;
            }

            buff = buffer.IbadTmpAer;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[16])
                {
                    try { 
                    bot.SendMessageChat("Error of TMP A. Error cod: " + buff + "\n");
                    Flags[16] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[16] = false;
            }

            buff = buffer.IbadTmpBer;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[17])
                {
                    try { 
                    bot.SendMessageChat("Error of TMP B. Error cod: " + buff + "\n");
                    Flags[17] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[17] = false;
            }

            buff = buffer.IbadTmpCer;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[18])
                {
                    try { 
                    bot.SendMessageChat("Error of TMP C. Error cod: " + buff + "\n");
                    Flags[18] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[18] = false;
            }

            buff = buffer.IbadTmpDer;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[19])
                {
                    try { 
                    bot.SendMessageChat("Error of TMP D. Error cod: " + buff + "\n");
                    Flags[19] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[19] = false;
            }

            buff = buffer.Neck23TmpEr;
          //  Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[20])
                {
                    try { 
                    bot.SendMessageChat("Error of neck 2-3 TMP. Error cod: " + buff + "\n");
                    Flags[20] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[20] = false;
            }

            buff = buffer.Neck34TmpEr;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[21])
                {
                    try { 
                    bot.SendMessageChat("Error of neck 3-4 TMP. Error cod: " + buff + "\n");
                    Flags[21] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[21] = false;
            }

            buff = buffer.Neck56TmpEr;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[22])
                {
                    try { 
                    bot.SendMessageChat("Error of neck 5-6 TMP. Error cod: " + buff + "\n");
                    Flags[22] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[22] = false;
            }

            buff = buffer.Rf01Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[23])
                {
                    try { 
                    bot.SendMessageChat("Error of RF 1. Error cod: " + buff + "\n");
                    Flags[23] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[23] = false;
            }

            buff = buffer.Rf02Er;
         //   Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[24])
                {
                    try { 
                    bot.SendMessageChat("Error of RF 2. Error cod: " + buff + "\n");
                    Flags[24] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[24] = false;

            }

            buff = buffer.RheedTmpEr;
            //Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[25])
                {
                    try { 
                    bot.SendMessageChat("Error of RHEED TMP. Error cod: " + buff + "\n");
                    Flags[25] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[25] = false;
            }

            buff = buffer.UnwindTmpEr;
            // Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[26])
                {
                    try { 
                    bot.SendMessageChat("Error of Unwind TMP. Error cod: " + buff + "\n");
                    Flags[26] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[26] = false;
            }

            buff = buffer.WindTmpEr;
            // Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[27])
                {
                    try { 
                    bot.SendMessageChat("Error of Wind TMP. Error cod: " + buff + "\n");
                    Flags[27] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[27] = false;

            }

            buff = buffer.Y2O3TmpEr;
            //Console.WriteLine(buff);
            if (buff != 0)
            {
                if (!Flags[28])
                {
                    try { 
                    bot.SendMessageChat("Error of Y2O3 TMP. Error cod: " + buff + "\n");
                    Flags[28] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[28] = false;

            }

            bool buff2 = buffer.eGun01Er;
            //Console.WriteLine(buff2);
            if (buff2)
            {
                if (!Flags[29])
                {
                    try { 
                    bot.SendMessageChat("Error of EGUN 01" + "\n");
                    Flags[29] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[29] = false;

            }

            buff2 = buffer.eGun02Er;
            // Console.WriteLine(buff2);
            if (buff2)
            {
                if (!Flags[30])
                {
                    try { 
                    bot.SendMessageChat("Error of EGUN 02" + "\n");
                    Flags[30] = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }
            }
            else
            {
                Flags[30] = false;

            }

        }
        private  void IBADStatusScan()
        {
            var Reel_on = buffer.ReelOn;
            //  Console.WriteLine("Start procc: " + Reel_on);
            if (Reel_on && Reel_on_Old != Reel_on)
            {
                try { 
                bot.SendMessageChat("IBAD: процесс запущен \n");
                Reel_on_Old = Reel_on;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }

            }
            if (!Reel_on && Reel_on_Old != Reel_on)
            {
                try { 
                bot.SendMessageChat("IBAD: процесс остановлен \n");
                Reel_on_Old = Reel_on;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }

            }
            var length = buffer.Length;
            var lengthSp = buffer.LengthSet;
            var speed = buffer.Speed;
            int min = Convert.ToInt32((lengthSp - length) / speed);
            if (min <11)
            {
               
                if (!lengthStatus)
                {
                    try { 
                    bot.SendMessageChat("IBAD: процесс завершится через " + min + " минут" + "\n");
                    lengthStatus = true;
                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                }

            }
            else
            {
                lengthStatus = false;
            }
            GC.Collect();
        }
        private  string MoikaStatusGet()
        {
            string msg = "";
            var Autorun_on = buffer.Run;
            var Autorun_Step = buffer.Step;
            var Autorun_Complete = buffer.Complet;
            // Console.WriteLine(Autorun_on);
            if (Autorun_on)
            {
                msg += "Процесс запущен \n";


            }
            if (Autorun_Complete)
            {
                msg += "Процесс завершён \n";
            }
            if (Autorun_Step == 1)
            {
                msg += "Текущий процесс: процесс мойки 1  \n";

            }
            if (Autorun_Step == 3)
            {
                msg += "Текущий процесс: процесс протяжки 1  \n";

            }
            if (Autorun_Step == 5)
            {
                msg += "Текущий процесс: процесс мойки 2  \n";

            }
            if (Autorun_Step == 7)
            {
                msg += "Текущий процесс: процесс протяжки 2  \n";

            }
            if (Autorun_Step == 9)
            {
                msg += "Текущий процесс: процесс мойки 3  \n";

            }
            if (Autorun_Step == 11)
            {
                msg += "Текущий процесс: процесс протяжки 3  \n";

            }
            if (Autorun_Step == 13)
            {
                msg += "Текущий процесс: процесс мойки 4  \n";
            }
            if (Autorun_Step == 15)
            {
                msg += "Текущий процесс: процесс протяжки 4  \n";
            }
            if (Autorun_Step == 17)
            {
                msg += "Текущий процесс: процесс сушки  \n";

            }
            GC.Collect();
            return msg;

        }
        private  void MoikaStatusScan()
        {
            if (buffer.ErrMOIKA)
            {
                if (!ErrMoikaFlag)
                {
                    try
                    {
                        bot.SendMessageChat("Error connect with MOIKA PLC" + "\n");

                    }
                    catch
                    { LogWriter.WriteLog("", "", "Error from Send message", 0); }
                    ErrMoikaFlag = true;
                }
                else
                {
                    ErrMoikaFlag = false;
                }
            }
            var Autorun_on = buffer.Run;
            var Autorun_Step = buffer.Step;
            var Autorun_Complete = buffer.Complet;
            //   Console.WriteLine(Autorun_on);
            if (Autorun_on && Autorun_on_Old != Autorun_on)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс запущен \n");

                Autorun_on_Old = Autorun_on;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Complete && Autorun_Complete_Old != Autorun_Complete)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс завершён \n");
                Autorun_Complete_Old = Autorun_Complete;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 1 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс мойки 1  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 3 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс протяжки 1  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 5 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс мойки 2  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 7 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс протяжки 2  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 9 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс мойки 3  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 11 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс протяжки 3  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 13 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс мойки 4  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 15 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс протяжки 4  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            if (Autorun_Step == 17 && Autorun_Step_Old != Autorun_Step)
            {
                try { 
                bot.SendMessageChat("MOIKA: процесс сушки  \n");
                Autorun_Step_Old = Autorun_Step;
                }
                catch
                { LogWriter.WriteLog("", "", "Error from Send message", 0); }
            }
            GC.Collect();


        }
    }

    
}
