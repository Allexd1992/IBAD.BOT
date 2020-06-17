
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot.Types;
using TitaniumAS.Opc.Client;
using TitaniumAS.Opc.Client.Common;
using TitaniumAS.Opc.Client.Da;
using TitaniumAS.Opc.Client.Da.Browsing;
namespace IBAD.BOT.OPC
{

    class ClientDaOPC
    {
    
        public event EventHandler UpdateOpcIBAD;
        public event EventHandler UpdateOpcMOIKA;
        public event EventHandler UpdateOpcSCADA;
        public event EventHandler UpdateOpcTERM;
        public event Action ErrorOpcIBAD;
        public event Action ErrorOpcMOIKA;
        public event Action ErrorOpcSCADA;
        public event Action ErrorOpcTERM;


        OpcDaServer server;
        OpcDaGroup groupIBAD, groupMOIKA, groupSCADA, groupTERM;
        private bool errorWriteIBAD, errorWriteMOIKA, errorWriteSCADA, errorWriteTERM;

        public ClientDaOPC()
        {
            Uri url = UrlBuilder.Build("Kepware.KEPServerEX.V6", "10.177.3.61");
            server = new OpcDaServer(url);
            server.Connect();
            Console.WriteLine("OPC is connect");
           
            var tagsIBAD= new OpcDaItemDefinition[] {
            //ibad
            //error
            //int
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.Al2O3_CH1_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.DC_01",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.DC_02",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.Homo_Epl_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.HomoEpl_Heat_1",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.HomoEpl_Heat_2",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.HomoEpl_Heat_3",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.HomoEpl_Heat_4",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.HomoEpl_Heat_5",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.LMO_Heat_1",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.LMO_Heat_2",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.LMO_Heat_3",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.LMO_Heat_4",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.LMO_Heat_5",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.LMO_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.IBAD_TMP_A",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.IBAD_TMP_B",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.IBAD_TMP_C",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.IBAD_TMP_D",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.NECK_2_3_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.NECK_3_4_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.NECK_5_6_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.RF_01",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.RF_02",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.RHEED_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.Unwind_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.Wind_TMP",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.Y2O3_TMP",
                IsActive = true
            },
            //bool
           //status
            //float
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.System.Length",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.System.Linear_Speed",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.System.Set_Length",
                IsActive = true
            },
            
           

            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_PLC_01.ALARM.Al2O3_CH1_TMP",
                IsActive = true
            },
        };
            var tagsMOIKA = new OpcDaItemDefinition[] {
             new OpcDaItemDefinition()
            {
                ItemId = "BackhoffADS.MOIKA_PLC01.CHAMBER_ALL_PROCESS_STEP",
                IsActive = true
            },
            new OpcDaItemDefinition()
                //bool
            {
                ItemId = "BackhoffADS.MOIKA_PLC01.CHAMBER_ALL_PROCESS_RUN",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "BackhoffADS.MOIKA_PLC01.CHAMBER_ALL_PROCESS_COMPLETE",
                IsActive = true
            },
            };
            var tagsSCADA = new OpcDaItemDefinition[] {
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_SCADA.ALARM.EGUN_01",
                IsActive = true
            },
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_SCADA.ALARM.EGUN_01",
                IsActive = true
            },
             new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_SCADA.System.Start_Procces",
                IsActive = true
            },
            };
            var tagsTerm = new OpcDaItemDefinition[] {
         //string
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_TERM.Unwind_Load_cell.CurrentTape_01",
                IsActive = true
            },
            //float
            new OpcDaItemDefinition()
            {
                ItemId = "ModbusTCP.IBAD_TERM.Unwind_Load_cell.Position_01",
                IsActive = true
            }
            };

            groupIBAD = server.AddGroup("IBAD");
            groupIBAD.IsActive = true;
            groupMOIKA = server.AddGroup("MOIKA");
            groupMOIKA.IsActive = true;
            groupSCADA = server.AddGroup("SCADA");
            groupSCADA.IsActive = true;
            groupTERM = server.AddGroup("TERM");
            groupTERM.IsActive = true;
            OpcDaItemDefinition[] definitions1 = tagsIBAD;
            OpcDaItemDefinition[] definitions2 = tagsMOIKA;
            OpcDaItemDefinition[] definitions3 = tagsSCADA;
            OpcDaItemDefinition[] definitions4 = tagsTerm;
            OpcDaItemResult[] results = groupIBAD.AddItems(definitions1);
            OpcDaItemResult[] results2 = groupMOIKA.AddItems(definitions2);
            OpcDaItemResult[] results3 = groupSCADA.AddItems(definitions3);
            OpcDaItemResult[] results4= groupTERM.AddItems(definitions4);
            Console.WriteLine("Group IBAD is Add");
        
            var time = new Timer(1000);
            time.AutoReset = true;
            time.Enabled = true;
            time.Elapsed += Time_Elapsed;
            
        }

       
        private async void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    var Values = groupIBAD.Read(groupIBAD.Items, OpcDaDataSource.Device);
                    UpdateOpcIBAD?.Invoke(Values, null);
                    errorWriteIBAD = false;
                }
                catch
                {
                    if (!errorWriteIBAD)
                    {
                        Console.WriteLine( DateTime.Now + " Error from OPC read PLC");
                        ErrorOpcIBAD?.Invoke();
                        LogWriter.WriteLog("", "", "Error from OPC read IBAD", 0);
                        errorWriteIBAD = true;
                    }
                }
                try
                {

                    var Values1 = groupMOIKA.Read(groupMOIKA.Items, OpcDaDataSource.Device);
                    UpdateOpcMOIKA?.Invoke(Values1, null);
                    errorWriteMOIKA = false;
                }
                catch
                {
                    if (!errorWriteMOIKA)
                    {
                        Console.WriteLine(DateTime.Now + " Error from OPC read MOIKA");
                        ErrorOpcMOIKA?.Invoke();
                        LogWriter.WriteLog("", "", "Error from OPC read MOIKA", 0);
                        errorWriteMOIKA = true;
                    }

                    }
                try
                {
                    var Values2 = groupSCADA.Read(groupSCADA.Items, OpcDaDataSource.Device);
                    UpdateOpcSCADA?.Invoke(Values2, null);
                    errorWriteSCADA = false;
                }
                catch
                {
                    if (!errorWriteSCADA)
                    {
                        Console.WriteLine(DateTime.Now + " Error from OPC read SCADA");
                        ErrorOpcSCADA?.Invoke();
                        LogWriter.WriteLog("", "", "Error from OPC read SCADA", 0);
                        errorWriteSCADA = true;
                    }
                }
                try
                {
                    var Values3 = groupTERM.Read(groupTERM.Items, OpcDaDataSource.Device);
                    UpdateOpcTERM?.Invoke(Values3, null);
                    errorWriteTERM = false;
                }
                catch
                {
                    if (!errorWriteTERM)
                    {
                        Console.WriteLine(DateTime.Now + " Error from OPC read TERM");
                        ErrorOpcTERM?.Invoke();
                        LogWriter.WriteLog("", "", "Error from OPC read TERM", 0);
                        errorWriteTERM = true;
                    }
                }
            });
           
            GC.Collect();
    

        }

        
    }
}
