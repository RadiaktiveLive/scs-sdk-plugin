using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCSSdkClient.Object;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static SCSSdkClient.Demo.SCSSdkClientDemo;
using static SCSSdkClient.Object.SCSTelemetry;
using static SCSSdkClient.Object.SCSTelemetry.Job;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace SCSSdkClient.Demo
{
    public partial class Main : Form
    {
        #region StreamerBot Definitions
        public StreamerBot StreamerBotConfig = new StreamerBot();

        public string StreamerBotConfigFile = "StreamerBotSettings.json";

        public string StreamerbotUrl = "";

        public ActionInfo JobStartedEventSBAction = new ActionInfo();
        ///
        public ActionInfo FerryEventSBAction = new ActionInfo();
        ///
        public ActionInfo FinedEventSBAction = new ActionInfo();
        ///
        public ActionInfo JobCancelledEventSBAction = new ActionInfo();
        ///
        public ActionInfo JobDeliveredEventSBAction = new ActionInfo();
        ///
        public ActionInfo TollgateEventSBAction = new ActionInfo();
        ///
        public ActionInfo TrainEventSBAction = new ActionInfo();
        ///
        public ActionInfo RefuelEventSBAction = new ActionInfo();
        #endregion

        public string lbGeneralString;
        public string lbUpdateRateString;

        #region SCSTelemetry Definitions
        /// <summary>
        ///     The SCSSdkTelemetry object
        /// </summary>
        public SCSSdkTelemetry Telemetry;
        private float fuel;
        //private SCSTelemetry raw;
        public SCSTelemetry raw;
        #endregion

        public Main()
        {
            InitializeComponent();
            ReadConfigFile();
            TelemetryRun();
        }

        #region Test
        // Define el delegado que especifica el tipo de método que puede suscribirse.
        // En este caso, un método que toma un string como parámetro.
        public delegate void ActualizarDatosSdkTelemetryHandler(SCSSdkTelemetry nuevoValor);
        public delegate void ActualizarDatosTelemetryHandler(SCSTelemetry nuevoValor);

        // Declara el evento. Los otros formularios se suscribirán a este evento.
        public event ActualizarDatosSdkTelemetryHandler DatosActualizadosSdkTelemetry;
        public event ActualizarDatosTelemetryHandler DatosActualizadosTelemetry;
        #endregion

        #region StreamerBot Methods
        private void ReadConfigFile()
        {
            //MessageBox.Show("ReadConfigFile running");
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

                string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), StreamerBotConfigFile);

                if (File.Exists(jsonFilePath))
                {
                    builder.AddJsonFile(jsonFilePath, optional: true, reloadOnChange: false);
                }
                else
                {
                    MessageBox.Show("The file StreamerBotSettings.json does not exist in the current directory.");
                    return;
                }

                IConfigurationRoot configuration = builder.Build();

                string Protocol = configuration.GetSection("Connection:Protocol").Value;
                string Ip = configuration.GetSection("Connection:Ip").Value;
                string Port = configuration.GetSection("Connection:Port").Value;
                string Endpoint = configuration.GetSection("Connection:Endpoint").Value;
                if (Protocol == null || Ip == null || Port == null || Endpoint == null)
                {
                    MessageBox.Show("One or more Connection values are missing.");
                    //return;
                }
                else
                {
                    var uriBuilder = new UriBuilder(Protocol, Ip, int.Parse(Port), Endpoint);
                    StreamerBotConfig.protocol = Protocol;
                    StreamerBotConfig.ip = Ip;
                    StreamerBotConfig.port = Port;
                    StreamerBotConfig.endpoint = Endpoint;
                    StreamerBotConfig.url = uriBuilder.ToString();
                    /*
                    var uriBuilder = new UriBuilder(Protocol, Ip, int.Parse(Port), Endpoint);
                    StreamerbotUrl = uriBuilder.ToString();
                    */
                    textBoxIp.Text = Ip;
                    textBoxPort.Text = Port;
                }
                //MessageBox.Show("StreamerbotUrl: " + StreamerbotUrl);

                string JobStartedEventId = configuration.GetSection("Actions:JobStartedEvent:Id").Value;
                string JobStartedEventName = configuration.GetSection("Actions:JobStartedEvent:Name").Value;
                if (JobStartedEventId == null || JobStartedEventName == null)
                {
                    MessageBox.Show("JobStartedEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //JobStartedSBAction = new ActionInfo { id = JobStartedId, name = JobStartedName };
                    JobStartedEventSBAction.id = JobStartedEventId;
                    JobStartedEventSBAction.name = JobStartedEventName;
                    //textBoxJobStartedId.Text = JobStartedEventId;
                    //textBoxJobStartedName.Text = JobStartedEventName;
                }
                //MessageBox.Show("JobStartedSBAction: \n{\n id = \"" + JobStartedSBAction.id + "\",\n name = \"" + JobStartedSBAction.name + "\"\n}");

                string JobDeliveredEventId = configuration.GetSection("Actions:JobDeliveredEvent:Id").Value;
                string JobDeliveredEventName = configuration.GetSection("Actions:JobDeliveredEvent:Name").Value;
                if (JobDeliveredEventId == null || JobDeliveredEventName == null)
                {
                    MessageBox.Show("JobDeliveredEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //JobDeliveredSBAction = new ActionInfo { id = JobDeliveredId, name = JobDeliveredName };
                    JobDeliveredEventSBAction.id = JobDeliveredEventId;
                    JobDeliveredEventSBAction.name = JobDeliveredEventName;
                    //textBoxJobDeliveredId.Text = JobDeliveredEventId;
                    //textBoxJobDeliveredName.Text = JobDeliveredEventName;
                }
                //MessageBox.Show("JobDeliveredSBAction: \n{\n id = \"" + JobDeliveredSBAction.id + "\",\n name = \"" + JobDeliveredSBAction.name + "\"\n}");

                string JobCancelledEventId = configuration.GetSection("Actions:JobCancelledEvent:Id").Value;
                string JobCancelledEventName = configuration.GetSection("Actions:JobCancelledEvent:Name").Value;
                if (JobCancelledEventId == null || JobCancelledEventName == null)
                {
                    MessageBox.Show("JobCancelledEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //JobCancelledSBAction = new ActionInfo { id = JobCancelledId, name = JobCancelledName };
                    JobCancelledEventSBAction.id = JobCancelledEventId;
                    JobCancelledEventSBAction.name = JobCancelledEventName;
                    //textBoxJobCancelledId.Text = JobCancelledEventId;
                    //textBoxJobCancelledName.Text = JobCancelledEventName;
                }
                //MessageBox.Show("JobCancelledSBAction: \n{\n id = \"" + JobCancelledSBAction.id + "\",\n name = \"" + JobCancelledSBAction.name + "\"\n}");

                string FinedEventId = configuration.GetSection("Actions:FinedEvent:Id").Value;
                string FinedEventName = configuration.GetSection("Actions:FinedEvent:Name").Value;
                if (FinedEventId == null || FinedEventName == null)
                {
                    MessageBox.Show("FinedEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //FinedEventSBAction = new ActionInfo { id = FinedEventId, name = FinedEventName };
                    FinedEventSBAction.id = FinedEventId;
                    FinedEventSBAction.name = FinedEventName;
                    //textBoxFinedEventId.Text = FinedEventId;
                    //textBoxFinedEventName.Text = FinedEventName;
                }
                //MessageBox.Show("FinedEventSBAction: \n{\n id = \"" + FinedEventSBAction.id + "\",\n name = \"" + FinedEventSBAction.name + "\"\n}");

                string TollgateEventId = configuration.GetSection("Actions:TollgateEvent:Id").Value;
                string TollgateEventName = configuration.GetSection("Actions:TollgateEvent:Name").Value;
                if (TollgateEventId == null || TollgateEventName == null)
                {
                    MessageBox.Show("TollgateEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //TollgateEventSBAction = new ActionInfo { id = TollgateEventId, name = TollgateEventName };
                    TollgateEventSBAction.id = TollgateEventId;
                    TollgateEventSBAction.name = TollgateEventName;
                    //textBoxTollgateEventId.Text = TollgateEventId;
                    //textBoxTollgateEventName.Text = TollgateEventName;
                }
                //MessageBox.Show("TollgateEventSBAction: \n{\n id = \"" + TollgateEventSBAction.id + "\",\n name = \"" + TollgateEventSBAction.name + "\"\n}");

                string TrainEventId = configuration.GetSection("Actions:TrainEvent:Id").Value;
                string TrainEventName = configuration.GetSection("Actions:TrainEvent:Name").Value;
                if (TrainEventId == null || TrainEventName == null)
                {
                    MessageBox.Show("TrainEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //TrainEventSBAction = new ActionInfo { id = TrainEventId, name = TrainEventName };
                    TrainEventSBAction.id = TrainEventId;
                    TrainEventSBAction.name = TrainEventName;
                    //textBoxTrainEventId.Text = TrainEventId;
                    //textBoxTrainEventName.Text = TrainEventName;
                }
                //MessageBox.Show("TrainEventSBAction: \n{\n id = \"" + TrainEventSBAction.id + "\",\n name = \"" + TrainEventSBAction.name + "\"\n}");

                string FerryEventId = configuration.GetSection("Actions:FerryEvent:Id").Value;
                string FerryEventName = configuration.GetSection("Actions:FerryEvent:Name").Value;
                if (FerryEventId == null || FerryEventName == null)
                {
                    MessageBox.Show("FerryEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //FerryEventSBAction = new ActionInfo { id = FerryEventId, name = FerryEventName };
                    FerryEventSBAction.id = FerryEventId;
                    FerryEventSBAction.name = FerryEventName;
                    //textBoxFerryEventId.Text = FerryEventId;
                    //textBoxFerryEventName.Text = FerryEventName;
                }
                //MessageBox.Show("FerryEventSBAction: \n{\n id = \"" + FerryEventSBAction.id + "\",\n name = \"" + FerryEventSBAction.name + "\"\n}");

                string RefuelEventId = configuration.GetSection("Actions:RefuelEvent:Id").Value;
                string RefuelEventName = configuration.GetSection("Actions:RefuelEvent:Name").Value;
                if (RefuelEventId == null || RefuelEventName == null)
                {
                    MessageBox.Show("RefuelEvent configuration values are missing.");
                    //return;
                }
                else
                {
                    //RefuelEventSBAction = new ActionInfo { id = RefuelEventId, name = RefuelEventName };
                    RefuelEventSBAction.id = RefuelEventId;
                    RefuelEventSBAction.name = RefuelEventName;
                    //textBoxRefuelEventId.Text = RefuelEventId;
                    //textBoxRefuelEventName.Text = RefuelEventName;
                }

                //MessageBox.Show("RefuelEventSBAction: \n{\n id = \"" + RefuelEventSBAction.id + "\",\n name = \"" + RefuelEventSBAction.name + "\"\n}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            //Telemetry.pause(); // that line make it possible, but not every application wants to ask the user to quit, need to see if i can change that, when not use the try catch and IGNORE it (nothing changed )
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                //Telemetry.resume();
                return;
            }

            //Telemetry.Dispose();
            */
        }

        private void SBConfig_btn_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario de configuración básica
            SBConfigForm formSBConfig = new SBConfigForm(this);

            // Suscribe el método 'FormConfig_FormClosed' al evento FormClosed del formulario de configuración.
            formSBConfig.FormClosed += SBConfigForm_FormClosed;

            // Muestra el formulario de manera no modal
            // Esto permite al usuario interactuar con la ventana principal mientras la de configuración está abierta
            formSBConfig.Show();

            // Si necesitas que la subventana se cierre antes de interactuar con la principal, usa ShowDialog():
            // formConfigBasica.ShowDialog();
        }

        // Este método se ejecutará automáticamente cuando el formulario de configuración se cierre.
        private void SBConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Aquí puedes colocar el código que deseas ejecutar.
            // Por ejemplo, actualizar datos, recargar la interfaz, etc.
            ReadConfigFile();
            //ActualizarDatosPrincipales();
            //MessageBox.Show("El formulario de configuración ha sido cerrado.");
        }

        // Un método de ejemplo que podría ser llamado.
        private void ActualizarDatosPrincipales()
        {
            // Lógica para recargar o actualizar datos en la ventana principal.
            // Por ejemplo: miTextBoxEnVentanaPrincipal.Text = "Datos actualizados";

            ReadConfigFile();
        }

        private void DebugTelemetry_btn_Click(object sender, EventArgs e)
        {
            // Crea una nueva instancia del formulario de configuración básica
            SCSSdkClientDemo formConfigBasica = new SCSSdkClientDemo(this);

            DatosActualizadosSdkTelemetry?.Invoke(Telemetry);
            DatosActualizadosTelemetry?.Invoke(raw);

            // Muestra el formulario de manera no modal
            // Esto permite al usuario interactuar con la ventana principal mientras la de configuración está abierta
            formConfigBasica.Show();

            // Si necesitas que la subventana se cierre antes de interactuar con la principal, usa ShowDialog():
            // formConfigBasica.ShowDialog();
        }

        public class StreamerBot
        {
            ///
            public string protocol { get; set; }
            ///
            public string ip { get; set; }
            ///
            public string port { get; set; }
            ///
            public string endpoint { get; set; }
            ///
            public string url { get; set; }

            /// Constructor
            public StreamerBot()
            {
                this.protocol = "";
                this.ip = "";
                this.port = "";
                this.endpoint = "";
                this.url = "";
            }

            /// Constructor
            public StreamerBot(string protocol, string ip, string port, string endpoint, string url)
            {
                this.protocol = protocol;
                this.ip = ip;
                this.port = port;
                this.endpoint = endpoint;
                this.url = url;
            }
        }

        public class GetAction
        {
            public int Count { get; set; }
            public List<Action> Actions { get; set; }
            public string Status { get; set; }
            public string Id { get; set; }
        }

        public class Action
        {
            public bool Enabled { get; set; }
            public string Group { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public int SubactionCount { get; set; }
        }

        public class LogWriter
        {
            private string m_exePath = string.Empty;
            private string todayDate = DateTime.Now.ToString("yyyyMMdd");
            private string now = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            public LogWriter(string logType, string logMessage)
            {
                LogWrite(logType, logMessage);
            }
            public void LogWrite(string logType, string logMessage)
            {
                m_exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                try
                {
                    if (!Directory.Exists(m_exePath + "\\" + "Logs"))
                    {
                        Directory.CreateDirectory(m_exePath + "\\" + "Logs");
                    }
                    using (StreamWriter w = File.AppendText(m_exePath + "\\" + "Logs\\" + todayDate + ".txt"))
                    {
                        Log(logType, logMessage, w);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            public void Log(string logType, string logMessage, TextWriter txtWriter)
            {
                try
                {
                    //txtWriter.Write("\r\nLog Entry : ");
                    //txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToShortDateString());
                    txtWriter.WriteLine("{0} {1} {2} :", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToLongTimeString(), logType);
                    //DateTime.Now.ToLongDateString());
                    //txtWriter.WriteLine("  :");
                    //txtWriter.WriteLine("  :{0}", logMessage);
                    txtWriter.WriteLine("{0}", logMessage);
                    txtWriter.WriteLine("-------------------------------");
                }
                catch (Exception ex)
                {
                }
            }




            public LogWriter(string logType, string logMessage, string eventName)
            {
                LogWrite(logType, logMessage, eventName);
            }
            public void LogWrite(string logType, string logMessage, string eventName)
            {
                m_exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                try
                {
                    if (!Directory.Exists(m_exePath + "\\" + "Logs"))
                    {
                        Directory.CreateDirectory(m_exePath + "\\" + "Logs");
                    }
                    using (StreamWriter w = File.AppendText(m_exePath + "\\" + "Logs\\" + now + "_" + eventName + ".txt"))
                    {
                        Log(logMessage, w);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            public void Log(string logMessage, TextWriter txtWriter)
            {
                try
                {
                    //txtWriter.Write("\r\nLog Entry : ");
                    //txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToShortDateString());
                    //txtWriter.WriteLine("{0} {1} {2} :", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToLongTimeString(), logType);
                    //DateTime.Now.ToLongDateString());
                    //txtWriter.WriteLine("  :");
                    //txtWriter.WriteLine("  :{0}", logMessage);
                    txtWriter.WriteLine("{0}", logMessage);
                    //txtWriter.WriteLine("-------------------------------");
                }
                catch (Exception ex)
                {
                }
            }
        }
        #endregion

        #region SCSTelemetry
        private void TelemetryRun()
        {
            Telemetry = new SCSSdkTelemetry();
            Telemetry.Data += Telemetry_Data;
            Telemetry.JobStarted += TelemetryOnJobStarted;

            Telemetry.JobCancelled += TelemetryJobCancelled;
            Telemetry.JobDelivered += TelemetryJobDelivered;
            Telemetry.Fined += TelemetryFined;
            Telemetry.Tollgate += TelemetryTollgate;
            Telemetry.Ferry += TelemetryFerry;
            Telemetry.Train += TelemetryTrain;
            Telemetry.RefuelStart += TelemetryRefuel;
            Telemetry.RefuelEnd += TelemetryRefuelEnd;
            Telemetry.RefuelPayed += TelemetryRefuelPayed;

            if (Telemetry.Error != null)
            {
                lbGeneralString =
                    "General info:\r\nFailed to open memory map " +
                    Telemetry.Map +
                    " - on some systems you need to run the client (this app) with elevated permissions, because e.g. you're running Steam/ETS2 with elevated permissions as well. .NET reported the following Exception:\r\n" +
                    Telemetry.Error.Message +
                    "\r\n\r\nStacktrace:\r\n" +
                    Telemetry.Error.StackTrace;
            }

            lbUpdateRateString = Telemetry.UpdateInterval + "ms";
            //MessageBox.Show("Telemetry updated start");
            //DatosActualizadosSdkTelemetry?.Invoke(Telemetry);
        }

        private void SCSSdkClientDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Telemetry.pause(); // that line make it possible, but not every application wants to ask the user to quit, need to see if i can change that, when not use the try catch and IGNORE it (nothing changed )
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) ==
                DialogResult.No)
            {
                e.Cancel = true;
                Telemetry.resume();
                return;
            }

            Telemetry.Dispose();
        }

        private void Telemetry_Data(SCSTelemetry data, bool updated)
        {
            //MessageBox.Show("Telemetry Data updated: " + updated);
            if (!updated)
                return;
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new TelemetryData(Telemetry_Data), data, updated);
                    return;
                }

                lbUpdateRateString = Telemetry.UpdateInterval + "ms";

                lbGeneralString = "General info:\n" +
                                     "\tSDK Running:" +
                                        $"\t\t{data.SdkActive}\n" +
                                     "\tSDK Version:" +
                                        $"\t\t{data.DllVersion}\n" +
                                     "\tGame:" +
                                        $"\t\t\t{data.Game}\n" +
                                     "\tGame Version:" +
                                        $"\t\t{data.GameVersion}\n" +
                                     "\tTelemetry Version:" +
                                        $"\t\t{data.TelemetryVersion}\n" +
                                     "\tTimeStamp:" +
                                        $"\t\t{data.Timestamp}\n" +
                                     "\tSimulation TimeStamp:" +
                                        $"\t{data.SimulationTimestamp}\n" +
                                     "\tRender TimeStamp:" +
                                        $"\t\t{data.RenderTimestamp}\n" +
                                     "\tMultiplayer Time Offset:" +
                                        $"\t{data.MultiplayerTimeOffset}\n" +
                                     "\tGame Paused:" +
                                        $"\t\t{data.Paused}\n" +
                                     "\tOn Job:" +
                                        $"\t\t\t{data.SpecialEventsValues.OnJob}\n" +
                                     "\tJob Finished:" +
                                        $"\t\t{data.SpecialEventsValues.JobFinished}\n" +
                                     "\tJob Delivered:" +
                                        $"\t\t{data.SpecialEventsValues.JobDelivered}\n" +
                                     "\tJob Cancelled:" +
                                        $"\t\t{data.SpecialEventsValues.JobCancelled}\n" +
                                     "\tFined:" +
                                        $"\t\t\t{data.SpecialEventsValues.Fined}\n" +
                                     "\tTollgate:" +
                                        $"\t\t\t{data.SpecialEventsValues.Tollgate}\n" +
                                     "\tFerry:" +
                                        $"\t\t\t{data.SpecialEventsValues.Ferry}\n" +
                                     "\tTrain:" +
                                        $"\t\t\t{data.SpecialEventsValues.Train}\n" +
                                     "\tRefuel Payed:" +
                                        $"\t\t{data.SpecialEventsValues.RefuelPayed}\n";

                lbGeneral.Text = lbGeneralString;
                l_updateRate.Text = lbUpdateRateString;
                //MessageBox.Show("Telemetry updated start");
                DatosActualizadosSdkTelemetry?.Invoke(Telemetry);
                DatosActualizadosTelemetry?.Invoke(data);
                /*
                common.Text = JsonConvert.SerializeObject(data.CommonValues, Formatting.Indented);
                truck.Text = JsonConvert.SerializeObject(data.TruckValues, Formatting.Indented);
                trailer.Text =
                    JsonConvert.SerializeObject(data.TrailerValues[0],
                                                Formatting
                                                    .Indented); //TODO: UNTIL I WORK ON A BETTER DEMO SHOW ONLY TRAILER 0
                job.Text = JsonConvert.SerializeObject(data.JobValues, Formatting.Indented);
                control.Text = JsonConvert.SerializeObject(data.ControlValues, Formatting.Indented);
                navigation.Text = JsonConvert.SerializeObject(data.NavigationValues, Formatting.Indented);
                substances.Text = JsonConvert.SerializeObject(data.Substances, Formatting.Indented);
                gameplayevent.Text = JsonConvert.SerializeObject(data.GamePlay, Formatting.Indented);
                rtb_fuel.Text = data.TruckValues.CurrentValues.DashboardValues.FuelValue.Amount + " " + data.SpecialEventsValues.Refuel;
                fuel = data.GamePlay.RefuelEvent.Amount;
                */
                raw = data;
                /*
                //
                jobstarted.Text = JsonConvert.SerializeObject(data.JobValues, Formatting.Indented);
                jobdelivered.Text = JsonConvert.SerializeObject(data.GamePlay.JobDelivered, Formatting.Indented);
                jobcanceled.Text = JsonConvert.SerializeObject(data.GamePlay.JobCancelled, Formatting.Indented);
                finedevent.Text = JsonConvert.SerializeObject(data.GamePlay.FinedEvent, Formatting.Indented);
                trainevent.Text = JsonConvert.SerializeObject(data.GamePlay.TrainEvent, Formatting.Indented);
                tollgateevent.Text = JsonConvert.SerializeObject(data.GamePlay.TollgateEvent, Formatting.Indented);
                refuelevent.Text = JsonConvert.SerializeObject(data.GamePlay.RefuelEvent, Formatting.Indented);
                ferryevent.Text = JsonConvert.SerializeObject(data.GamePlay.FerryEvent, Formatting.Indented);
                //
                */
                //MessageBox.Show("Telemetry loaded");
                DebugTelemetry_btn.Enabled = true;
            }
            catch (Exception ex)
            {
                // ignored atm i found no proper way to shut the telemetry down and down call this anymore when this or another thing is already disposed
                Console.WriteLine("Telemetry was closed: " + ex);
            }
        }

        public void TelemetryFerry(object sender, EventArgs e)
        {
            //MessageBox.Show("Ferry");
            //Ferry(JsonConvert.SerializeObject(raw.GamePlay.FerryEvent, Formatting.Indented));
            Ferry(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }

        public void TelemetryFined(object sender, EventArgs e)
        {
            //MessageBox.Show("Fined");
            //Fined(JsonConvert.SerializeObject(raw.GamePlay.FinedEvent, Formatting.Indented));
            Fined(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }

        public void TelemetryJobCancelled(object sender, EventArgs e)
        {
            //MessageBox.Show("Job Cancelled");
            //Cancelled(JsonConvert.SerializeObject(raw.GamePlay.JobCancelled, Formatting.Indented));
            Cancelled(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }

        public void TelemetryJobDelivered(object sender, EventArgs e)
        {
            //MessageBox.Show("Job Delivered");
            //Delivered(JsonConvert.SerializeObject(raw.GamePlay.JobDelivered, Formatting.Indented));
            Delivered(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }

        public void TelemetryOnJobStarted(object sender, EventArgs e)
        {
            //MessageBox.Show("Just started job OR loaded game with active.");
            Started(JsonConvert.SerializeObject(raw.JobValues, Formatting.Indented));
        }

        public void TelemetryRefuel(object sender, EventArgs e)
        {
            //rtb_fuel.Invoke((MethodInvoker)(() => rtb_fuel.BackColor = Color.Green));
        }

        public void TelemetryRefuelEnd(object sender, EventArgs e)
        {
            //rtb_fuel.Invoke((MethodInvoker)(() => rtb_fuel.BackColor = Color.Red));
        }

        public void TelemetryRefuelPayed(object sender, EventArgs e)
        {
            //MessageBox.Show("Fuel Payed: " + fuel);
            //Refuel(JsonConvert.SerializeObject(raw.GamePlay.RefuelEvent, Formatting.Indented));
            Refuel(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }

        public void TelemetryTollgate(object sender, EventArgs e)
        {
            //MessageBox.Show("Tollgate");
            //Tollgate(JsonConvert.SerializeObject(raw.GamePlay.TollgateEvent, Formatting.Indented));
            Tollgate(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }

        public void TelemetryTrain(object sender, EventArgs e)
        {
            //MessageBox.Show("Train");
            //Train(JsonConvert.SerializeObject(raw.GamePlay.TrainEvent, Formatting.Indented));
            Train(JsonConvert.SerializeObject(raw.GamePlay, Formatting.Indented));
        }
        #endregion

        #region classes
        ///
        public class MyJsonObject
        {
            ///
            public ActionInfo action { get; set; }
            ///
            public Dictionary<string, string> args { get; set; }
        }


        ///
        public class ActionInfo
        {
            ///
            public string id { get; set; }
            ///
            public string name { get; set; }

            /// Constructor
            public ActionInfo()
            {
                this.id = "";
                this.name = "";
            }

            /// Constructor
            public ActionInfo(string id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }

        ///
        public async Task<string> PostJsonDataAsync(MyJsonObject data)
        {
            //var url = StreamerbotUrl;
            if (StreamerBotConfig.url.Equals(""))
            {
                return null;
            }
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(data);
                //MessageBox.Show(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //var response = await client.PostAsync(url, content);
                var response = await client.PostAsync(StreamerBotConfig.url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the error
                    return null;
                }
            }
        }

        ///
        public class FerryEvent
        {
            ///
            public decimal PayAmount { get; set; }
            ///
            public string SourceId { get; set; }
            ///
            public string SourceName { get; set; }
            ///
            public string TargetId { get; set; }
            ///
            public string TargetName { get; set; }
        }

        ///
        public class FinedEvent
        {
            ///
            public FinedEvent(decimal amount, int offence)
            {
                Amount = amount;
                Offence = offence;
            }

            ///
            public decimal Amount { get; set; }
            ///
            public int Offence { get; set; }
        }

        ///
        public class JobCancelled
        {
            ///
            public decimal Penalty { get; set; }
            ///
            public EventInfo Finished { get; set; }
            ///
            public EventInfo Started { get; set; }
        }

        ///
        public class JobDelivered
        {
            ///
            public bool AutoLoaded { get; set; }
            ///
            public bool AutoParked { get; set; }
            ///
            public double CargoDamage { get; set; }
            ///
            public EventInfo DeliveryTime { get; set; }
            ///
            public double DistanceKm { get; set; }
            ///
            public int EarnedXp { get; set; }
            ///
            public decimal Revenue { get; set; }
            ///
            public EventInfo Finished { get; set; }
            ///
            public EventInfo Started { get; set; }
            ///
            public EventInfo StartedBackup { get; set; }
        }

        ///
        public class TollgateEvent
        {
            ///
            public decimal PayAmount { get; set; }
        }

        ///
        public class TrainEvent
        {
            ///
            public TrainEvent()
            {
            }

            ///
            public decimal PayAmount { get; set; }
            ///
            public string SourceId { get; set; }
            ///
            public string SourceName { get; set; }
            ///
            public string TargetId { get; set; }
            ///
            public string TargetName { get; set; }
        }

        ///
        public class RefuelEvent
        {
            ///
            public double Amount { get; set; }
        }

        ///
        public class EventInfo
        {
            ///
            public int Value { get; set; }
            ///
            public DateTime Date { get; set; }
        }

        ///
        public class GamePlayEvents
        {
            ///
            public FerryEvent FerryEvent { get; set; }
            ///
            public FinedEvent FinedEvent { get; set; }
            ///
            public JobCancelled JobCancelled { get; set; }
            ///
            public JobDelivered JobDelivered { get; set; }
            ///
            public TollgateEvent TollgateEvent { get; set; }
            ///
            public TrainEvent TrainEvent { get; set; }
            ///
            public RefuelEvent RefuelEvent { get; set; }

            public Job JobValues { get; set; }
        }

        public class Job
        {
            ///
            public Time DeliveryTime { get; set; }
            public Frequency RemainingDeliveryTime { get; set; }

            public bool CargoLoaded { get; set; }
            public bool SpecialJob { get; set; }
            public JobMarket Market { get; set; }

            public uint PlannedDistanceKm { get; set; }

            public Cargo CargoValues { get; set; }

            public string CityDestinationId { get; set; }

            public string CityDestination { get; set; }

            public string CompanyDestinationId { get; set; }

            public string CompanyDestination { get; set; }

            public string CitySourceId { get; set; }

            public string CitySource { get; set; }

            public string CompanySourceId { get; set; }

            public string CompanySource { get; set; }

            public ulong Income { get; set; }
        }
        #endregion


        private MyJsonObject createMyJsonObject(ActionInfo actionInfo, string title, string json)
        {
            var myObject = new MyJsonObject();
            var args = new Dictionary<string, string> { { "event", title }, { "json", json } };
            myObject = new MyJsonObject { action = actionInfo, args = args };
            return myObject;
        }

        public void Ferry(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.FerryEvent);
            //MessageBox.Show(json, "FerryEvent");
            var myObject = createMyJsonObject(FerryEventSBAction, "FerryEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
            //new LogWriter("INFO FERRY", JsonConvert.SerializeObject(raw.GamePlay.FerryEvent, Formatting.Indented), "FERRY");
            new LogWriter("INFO FERRY", JsonConvert.SerializeObject(json, Formatting.Indented));
            new LogWriter("INFO FERRY", JsonConvert.SerializeObject(raw, Formatting.Indented), "FERRY");
            //Task variableInutilPerEvitarWarnings2 = PanelColor(panelFerry);
        }
        public void Fined(string events)
        {
            try
            {
                //MessageBox.Show(events, "FinedEvent");
                var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
                var json = JsonConvert.SerializeObject(myObject1.FinedEvent);
                //MessageBox.Show(json, "FinedEvent");
                //MessageBox.Show(json, "FinedEvent");
                var myObject = createMyJsonObject(FinedEventSBAction, "FinedEvent", json);
                Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
                //new LogWriter("INFO FINED", JsonConvert.SerializeObject(raw.GamePlay.FinedEvent, Formatting.Indented), "FINED");
                //new LogWriter("INFO FINED", JsonConvert.SerializeObject(json, Formatting.Indented));
                new LogWriter("INFO FINED", json);
                new LogWriter("INFO FINED", JsonConvert.SerializeObject(raw, Formatting.Indented), "FINED");
                //Task variableInutilPerEvitarWarnings2 = PanelColor(panelFined);
            }
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION FINED", ex.Message);
            }
        }
        public void Started(string events, bool demoData = false)
        {
            if (demoData)
            {
                //MessageBox.Show(events, "Started");
                var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
                var json = JsonConvert.SerializeObject(myObject1.JobValues);
                //MessageBox.Show(json, "Started");
                //MessageBox.Show(json, "FinedEvent");
                var myObject = createMyJsonObject(JobStartedEventSBAction, "Job", json);
                Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
                //new LogWriter("INFO FINED", JsonConvert.SerializeObject(raw.GamePlay.FinedEvent, Formatting.Indented), "FINED");
                //new LogWriter("INFO FINED", JsonConvert.SerializeObject(json, Formatting.Indented));
                new LogWriter("INFO Started", json);
                new LogWriter("INFO Started", JsonConvert.SerializeObject(raw, Formatting.Indented), "Started");
                //Task variableInutilPerEvitarWarnings2 = PanelColor(panelFined);
            }
            else
            {
                //var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
                //var json = JsonConvert.SerializeObject(myObject1.JobDelivered);
                //MessageBox.Show(json, "JobDelivered");
                var myObject = createMyJsonObject(JobStartedEventSBAction, "Job", events);
                Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
                //new LogWriter("INFO STARTED", JsonConvert.SerializeObject(raw.JobValues, Formatting.Indented), "JOB_STARTED");
                new LogWriter("INFO STARTED", JsonConvert.SerializeObject(events, Formatting.Indented));
                new LogWriter("INFO STARTED", JsonConvert.SerializeObject(raw, Formatting.Indented), "JOB_STARTED");
                //Task variableInutilPerEvitarWarnings2 = PanelColor(panelJobStarted);
            }
            

            
        }
        public void Cancelled(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.JobCancelled);
            //MessageBox.Show(json, "JobCancelled");
            var myObject = createMyJsonObject(JobCancelledEventSBAction, "JobCancelled", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
            //new LogWriter("INFO CANCELLED", JsonConvert.SerializeObject(raw.GamePlay.JobCancelled, Formatting.Indented), "JOB_CANCELLED");
            new LogWriter("INFO CANCELLED", JsonConvert.SerializeObject(json, Formatting.Indented));
            new LogWriter("INFO CANCELLED", JsonConvert.SerializeObject(raw, Formatting.Indented), "JOB_CANCELLED");
            //Task variableInutilPerEvitarWarnings2 = PanelColor(panelJobCancelled);
        }
        public void Delivered(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.JobDelivered);
            //MessageBox.Show(json, "JobDelivered");
            var myObject = createMyJsonObject(JobDeliveredEventSBAction, "JobDelivered", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
            //new LogWriter("INFO DELIVERED", JsonConvert.SerializeObject(raw.GamePlay.JobDelivered, Formatting.Indented), "JOB_DELIVERED");
            new LogWriter("INFO DELIVERED", JsonConvert.SerializeObject(json, Formatting.Indented));
            new LogWriter("INFO DELIVERED", JsonConvert.SerializeObject(raw, Formatting.Indented), "JOB_DELIVERED");
            //Task variableInutilPerEvitarWarnings2 = PanelColor(panelJobDelivered);
        }
        public void Tollgate(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.TollgateEvent);
            //MessageBox.Show(json, "TollgateEvent");
            var myObject = createMyJsonObject(TollgateEventSBAction, "TollgateEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
            //new LogWriter("INFO TOLLGATE", JsonConvert.SerializeObject(raw.GamePlay.TollgateEvent, Formatting.Indented), "TOLLGATE");
            new LogWriter("INFO TOLLGATE", JsonConvert.SerializeObject(json, Formatting.Indented));
            new LogWriter("INFO TOLLGATE", JsonConvert.SerializeObject(raw, Formatting.Indented), "TOLLGATE");
            //Task variableInutilPerEvitarWarnings2 = PanelColor(panelTollgate);
        }
        public void Train(string events)
        {
            //MessageBox.Show(events, "TrainEvent");
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.TrainEvent);
            //MessageBox.Show(json, "TrainEvent");
            //MessageBox.Show(json, "TrainEvent");
            var myObject = createMyJsonObject(TrainEventSBAction, "TrainEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
            //new LogWriter("INFO TRAIN", JsonConvert.SerializeObject(raw.GamePlay.TrainEvent, Formatting.Indented), "TRAIN");
            new LogWriter("INFO TRAIN", JsonConvert.SerializeObject(json, Formatting.Indented));
            new LogWriter("INFO TRAIN", JsonConvert.SerializeObject(raw, Formatting.Indented), "TRAIN");
            //Task variableInutilPerEvitarWarnings2 = PanelColor(panelTrain);
        }
        public void Refuel(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.RefuelEvent);
            //MessageBox.Show(json, "RefuelEvent");
            var myObject = createMyJsonObject(RefuelEventSBAction, "RefuelEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
            //new LogWriter("INFO REFUEL", JsonConvert.SerializeObject(raw.GamePlay.RefuelEvent, Formatting.Indented), "REFUEL_PAYED");
            new LogWriter("INFO REFUEL", JsonConvert.SerializeObject(json, Formatting.Indented));
            new LogWriter("INFO REFUEL", JsonConvert.SerializeObject(raw, Formatting.Indented), "REFUEL_PAYED");
            //panelRefuel.BackColor = Color.IndianRed;
            //Task variableInutilPerEvitarWarnings2 = PanelColor(panelRefuel);
            //panelRefuel.BackColor = Color.Transparent;
        }


        static async Task PanelColor(Panel panel, string panelColorHighlight = "IndianRed", string panelColorRevert = "Transparent")
        {
            panel.BackColor = Color.FromName(panelColorHighlight);
            await Task.Delay(2000); // Non-blocking delay for 2 seconds
            panel.BackColor = Color.FromName(panelColorRevert);
        }

    }
}
