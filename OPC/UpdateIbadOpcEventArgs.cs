using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAD.BOT.OPC
{
    public class UpdateIbadOpcEventArgs 
    {
        // Сообщение
        
        public ushort Al2O3Ch1TmpEr { get; }
        public ushort Al2O3Ch2TmpEr { get; }
        public ushort Dc01Er { get; }
        public ushort Dc02Er { get; }
        public ushort HomoEplTmpEr { get; }
        public ushort HomoEplHeat01Er { get; }
        public ushort HomoEplHeat02Er { get; }
        public ushort HomoEplHeat03Er { get; }
        public ushort HomoEplHeat04Er { get; }
        public ushort HomoEplHeat05Er { get; }
        public ushort LmoTmpEr { get; }
        public ushort LmoHeat01Er { get; }
        public ushort LmoHeat02Er { get; }
        public ushort LmoHeat03Er { get; }
        public ushort LmoHeat04Er { get; }
        public ushort LmoHeat05Er { get; }
        public ushort IbadTmpAer { get; }
        public ushort IbadTmpBer { get; }
        public ushort IbadTmpCer { get; }
        public ushort IbadTmpDer { get; }
        public ushort Neck23TmpEr { get; }
        public ushort Neck34TmpEr { get; }
        public ushort Neck56TmpEr { get; }
        public ushort Rf01Er { get; }
        public ushort Rf02Er { get; }
        public ushort RheedTmpEr { get; }
        public ushort UnwindTmpEr { get; }
        public ushort WindTmpEr { get; }
        public ushort Y2O3TmpEr { get; }
        public bool eGun01Er { get; }
        public bool eGun02Er { get; }
        public ushort ReelOn { get; }
        public float Length { get; }
        public float Speed { get; }
        public float LengthSet { get; }
        public string CurTape { get; }
        public double TapePosition { get; }
        public short Step { get; }
        public bool Run { get; }
        public bool Complet { get; }

        public UpdateIbadOpcEventArgs(ushort Al2O3Ch1TmpEr,
                                            ushort Dc01Er,
                                            ushort Dc02Er,
                                            ushort HomoEplTmpEr,
                                            ushort HomoEplHeat01Er,
                                            ushort HomoEplHeat02Er,
                                            ushort HomoEplHeat03Er,
                                            ushort HomoEplHeat04Er,
                                            ushort HomoEplHeat05Er,
                                            ushort LmoTmpEr,
                                            ushort LmoHeat01Er,
                                            ushort LmoHeat02Er,
                                            ushort LmoHeat03Er,
                                            ushort LmoHeat04Er,
                                            ushort LmoHeat05Er,
                                            ushort IbadTmpAer,
                                            ushort IbadTmpBer,
                                            ushort IbadTmpCer,
                                            ushort IbadTmpDer,
                                            ushort Neck23TmpEr,
                                            ushort Neck34TmpEr,
                                            ushort Neck56TmpEr,
                                            ushort Rf01Er,
                                            ushort Rf02Er,
                                            ushort RheedTmpEr,
                                            ushort UnwindTmpEr,
                                            ushort WindTmpEr,
                                            ushort Y2O3TmpEr,
                                            bool eGun01Er,
                                            bool eGun02Er,
                                            float Length,
                                            float Speed,
                                            float LengthSet,
                                            string CurTape,
                                            double TapePosition,
                                            ushort ReelOn,
                                            ushort Al2O3Ch2TmpEr,
                                            short Step,
                                            bool Run,
                                            bool Complet)
        {
            this.Al2O3Ch1TmpEr = Al2O3Ch1TmpEr;
            this.Al2O3Ch2TmpEr = Al2O3Ch2TmpEr;
            this.Dc01Er = Dc01Er;
            this.Dc02Er = Dc02Er;
            this.HomoEplTmpEr = HomoEplTmpEr;
            this.HomoEplHeat01Er = HomoEplHeat01Er;
            this.HomoEplHeat02Er = HomoEplHeat02Er;
            this.HomoEplHeat03Er = HomoEplHeat03Er;
            this.HomoEplHeat04Er = HomoEplHeat04Er;
            this.HomoEplHeat05Er = HomoEplHeat05Er;
            this.LmoTmpEr = HomoEplTmpEr;
            this.LmoHeat01Er = LmoHeat01Er;
            this.LmoHeat02Er = LmoHeat02Er;
            this.LmoHeat03Er = LmoHeat03Er;
            this.LmoHeat04Er = LmoHeat04Er;
            this.LmoHeat05Er = LmoHeat05Er;
            this.IbadTmpAer = IbadTmpAer;
            this.IbadTmpBer = IbadTmpBer;
            this.IbadTmpCer = IbadTmpCer;
            this.IbadTmpDer = IbadTmpDer;
            this.Neck23TmpEr = Neck23TmpEr;
            this.Neck34TmpEr = Neck34TmpEr;
            this.Neck56TmpEr = Neck56TmpEr;
            this.Rf01Er = Rf01Er;
            this.Rf02Er = Rf02Er;
            this.RheedTmpEr = RheedTmpEr;
            this.UnwindTmpEr = UnwindTmpEr;
            this.WindTmpEr = WindTmpEr;
            this.Y2O3TmpEr = Y2O3TmpEr;
            this.eGun01Er = eGun01Er;
            this.eGun02Er = eGun02Er;
            this.Length = Length;
            this.Speed = Speed;
            this.LengthSet = LengthSet;
            this.CurTape = CurTape;
            this.TapePosition = TapePosition;
            this.ReelOn = ReelOn;
            this.Step = Step;
            this.Run = Run;
            this.Complet = Complet;
            GC.Collect();
        }

       

    }
}
