using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IBAD.BOT.BL;

namespace IBAD.BOT
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void  Main(string[] args)
        {
            //var model = new Model();
            //{
            //    var handle = GetConsoleWindow();


            //    ShowWindow(handle, SW_HIDE);
                
            //    Console.ReadKey();


            //}
            // var client = new  IBAD.BOT.OPC.ClientDaOPC();


            var model = new Model();
            Console.ReadKey();

        }





        
    }
}
  