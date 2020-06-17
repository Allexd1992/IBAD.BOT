using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAD.BOT.OPC
{
    public class UpdateMoikaOpcEventArgs
    {
        // Сообщение
        public short Step { get; }
        public bool Run { get; }
        public bool Complet { get; }
       

        public UpdateMoikaOpcEventArgs(short Step, bool Run, bool Complet)
        {
            this.Step = Step;
            this.Run = Run;
            this.Complet = Complet;
        }
    }
}
