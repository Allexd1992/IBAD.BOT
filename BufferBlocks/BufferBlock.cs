using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBAD.BOT.OPC;
using TitaniumAS.Opc.Client.Da;

namespace IBAD.BOT.BufferBlocks
{
    public class BufferBlock
    {
        #region Tags
        public ushort Al2O3Ch1TmpEr { get; private set; }
        public ushort Al2O3Ch2TmpEr { get; private set; }
        public bool ReelOn { get; private set; }
        public ushort Dc01Er { get; private set; }
        public ushort Dc02Er { get; private set; }
        public ushort HomoEplTmpEr { get; private set; }
        public ushort HomoEplHeat01Er { get; private set; }
        public ushort HomoEplHeat02Er { get; private set; }
        public ushort HomoEplHeat03Er { get; private set; }
        public ushort HomoEplHeat04Er { get; private set; }
        public ushort HomoEplHeat05Er { get; private set; }
        public ushort LmoTmpEr { get; private set; }
        public ushort LmoHeat01Er { get; private set; }
        public ushort LmoHeat02Er { get; private set; }
        public ushort LmoHeat03Er { get; private set; }
        public ushort LmoHeat04Er { get; private set; }
        public ushort LmoHeat05Er { get; private set; }
        public ushort IbadTmpAer { get; private set; }
        public ushort IbadTmpBer { get; private set; }
        public ushort IbadTmpCer { get; private set; }
        public ushort IbadTmpDer { get; private set; }
        public ushort Neck23TmpEr { get; private set; }
        public ushort Neck34TmpEr { get; private set; }
        public ushort Neck56TmpEr { get; private set; }
        public ushort Rf01Er { get; private set; }
        public ushort Rf02Er { get; private set; }
        public ushort RheedTmpEr { get; private set; }
        public ushort UnwindTmpEr { get; private set; }
        public ushort WindTmpEr { get; private set; }
        public ushort Y2O3TmpEr { get; private set; }
        public bool eGun01Er { get; private set; }
        public bool eGun02Er { get; private set; }
        public float Length { get; private set; }
        public float Speed { get; private set; }
        public float LengthSet { get; private set; }
        public string CurTape { get; private set; }
        public double TapePosition { get; private set; }
        public short Step { get; private set; }
        public bool Run { get; private set; }
        public bool Complet { get; private set; }
        public bool ErrIBAD { get; private set; }
        public bool ErrSCADA { get; private set; }
        public bool ErrMOIKA { get; private set; }
        public bool ErrTERM{ get; private set; }
        #endregion
        ClientDaOPC ClientOPC;
        public BufferBlock()
        {
            ClientOPC = new ClientDaOPC();
            ClientOPC.UpdateOpcIBAD += ClientOPC_UpdateOpcIBAD;
            ClientOPC.UpdateOpcSCADA += ClientOPC_UpdateOpcSCADA;
            ClientOPC.UpdateOpcMOIKA += ClientOPC_UpdateOpcMOIKA;
            ClientOPC.UpdateOpcTERM += ClientOPC_UpdateOpcTERM;
            ClientOPC.ErrorOpcIBAD += ClientOPC_ErrorOpcIBAD;
            ClientOPC.ErrorOpcMOIKA += ClientOPC_ErrorOpcMOIKA;
            ClientOPC.ErrorOpcSCADA += ClientOPC_ErrorOpcSCADA;
            ClientOPC.ErrorOpcTERM += ClientOPC_ErrorOpcTERM;

            GC.Collect();

        }

        private void ClientOPC_ErrorOpcTERM()
        {
            ErrTERM = true;
        }

        private void ClientOPC_ErrorOpcSCADA()
        {
            ErrSCADA = true;
        }

        private void ClientOPC_ErrorOpcMOIKA()
        {
            ErrMOIKA = true;
        }

        private void ClientOPC_ErrorOpcIBAD()
        {
            ErrIBAD = true;
        }

        private void ClientOPC_UpdateOpcTERM(object sender, EventArgs e)
        {
            var Values = (OpcDaItemValue[])sender;
            CurTape = (string)Values[0].Value;
            TapePosition= (double)Values[1].Value;
            ErrTERM = false;
            //Console.WriteLine(CurTape);
            //Console.WriteLine(TapePosition);
        }

        private void ClientOPC_UpdateOpcMOIKA(object sender, EventArgs e)
        {
            var Values = (OpcDaItemValue[])sender;
            Step = (short)Values[0].Value;
            Run = (bool)Values[1].Value;
            Complet = (bool)Values[2].Value;
            ErrMOIKA = false;
        }

        private void ClientOPC_UpdateOpcSCADA(object sender, EventArgs e)
        {

            var Values = (OpcDaItemValue[])sender;
            eGun01Er = (bool)Values[0].Value;
            eGun02Er = (bool)Values[1].Value;
            ReelOn = Convert.ToBoolean((ushort)Values[2].Value);
            ErrSCADA = false;
     



        }

        private void ClientOPC_UpdateOpcIBAD(object sender, EventArgs e)
        {
            var Values = (OpcDaItemValue[])sender;

            Al2O3Ch1TmpEr = (ushort)Values[0].Value;
            Dc01Er = (ushort)Values[1].Value;
            Dc02Er = (ushort)Values[2].Value;
            HomoEplTmpEr = (ushort)Values[3].Value;
            HomoEplHeat01Er = (ushort)Values[4].Value;
            HomoEplHeat02Er = (ushort)Values[5].Value;
            HomoEplHeat03Er = (ushort)Values[6].Value;
            HomoEplHeat04Er = (ushort)Values[7].Value;
            HomoEplHeat05Er = (ushort)Values[8].Value;
            LmoTmpEr = (ushort)Values[14].Value;
            LmoHeat01Er = (ushort)Values[9].Value;
            LmoHeat02Er = (ushort)Values[10].Value;
            LmoHeat03Er = (ushort)Values[11].Value;
            LmoHeat04Er = (ushort)Values[12].Value;
            LmoHeat05Er = (ushort)Values[13].Value;
            IbadTmpAer = (ushort)Values[15].Value;
            IbadTmpBer = (ushort)Values[16].Value;
            IbadTmpCer = (ushort)Values[17].Value;
            IbadTmpDer = (ushort)Values[18].Value;
            Neck23TmpEr = (ushort)Values[19].Value;
            Neck34TmpEr = (ushort)Values[20].Value;
            Neck56TmpEr = (ushort)Values[21].Value;
            Rf01Er = (ushort)Values[22].Value;
            Rf02Er = (ushort)Values[23].Value;
            RheedTmpEr = (ushort)Values[24].Value;
            UnwindTmpEr = (ushort)Values[25].Value;
            WindTmpEr = (ushort)Values[26].Value;
            Y2O3TmpEr = (ushort)Values[27].Value;
            Length = (float)Values[28].Value;
            Speed = (float)Values[29].Value;
            LengthSet = (float)Values[30].Value;
            Al2O3Ch2TmpEr = (ushort)Values[31].Value;
            ErrIBAD = false;
        }

    
 
    }
}
