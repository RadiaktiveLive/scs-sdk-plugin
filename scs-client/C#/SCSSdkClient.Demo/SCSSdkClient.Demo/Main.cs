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
using System.Diagnostics;
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

        public bool StreamerBotConnected = false;

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

        // --- Variables de Clase ---
        private (string Texto, string URL)[] mensajes = new (string, string)[] {
            //("Estado: Aplicación lista.", ""), // Mensaje normal
            ("© Radiaktive 2025", ""),
            ("Visita mi web: radiaktive.stream", "https://www.radiaktive.stream"), // Mensaje de enlace
            ("Visita mi Twitch: twitch.tv/radiaktive", "https://www.twitch.tv/radiaktive"), // Mensaje de enlace
            ("Visita mi YouTube: youtube.com/@RadiaktiveTV", "https://www.youtube.com/@RadiaktiveTV") // Mensaje de enlace
        };

        private int indiceMensaje = 0;

        // La URL actual, guardada para el evento Click
        private string urlActual = "";

        private bool messageBoxShow = false;
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
            //TestSbConnection();
            timer2_Tick(timer2, EventArgs.Empty);
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
                    //builder.AddJsonFile(jsonFilePath, optional: true, reloadOnChange: false);
                    builder.AddJsonFile(jsonFilePath, optional: true, reloadOnChange: true);
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

                //lbGeneral.Text = lbGeneralString;
                lbGeneral.Text = "Game connected: " + $"{data.Game}";
                l_updateRate.Text = "Current update rate: " + lbUpdateRateString;
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

        public class Time
        {
            public Time(uint i) => Value = i;

            public Time() { }

            /// <summary>
            ///     Represented in number of in-game minutes
            /// </summary>
            public uint Value { get; set; }

            /// <summary>
            ///     Represented in data of in-game minutes
            /// </summary>
            public DateTime Date => MinutesToDate(Value);

            public static implicit operator Time(uint i) => new Time(i);

            public static Time operator -(Time a, Time b) => new Time(a.Value - b.Value);
        }

        public class Frequency
        {
            public Frequency(int i) => Value = i;

            public Frequency() { }

            /// <summary>
            ///     Represented in number of in-game minutes
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            ///     Represented in data of in-game minutes
            /// </summary>
            public DateTime Date => MinutesToDate(Value);

            public static implicit operator Frequency(int i) => new Frequency(i);
        }

        /// <summary>
        ///     Converts uint minutes in a DateTime object
        /// </summary>
        /// <param name="minutes">In-Game Minutes</param>
        /// <returns>
        ///     DateTime object of the in-game time
        /// </returns>
        internal static DateTime MinutesToDate(uint minutes) =>
            new DateTime((long)minutes * 10000000 * 60, DateTimeKind.Utc);

        /// <summary>
        ///     Converts int minutes in a DateTime object
        /// </summary>
        /// <param name="minutes">In-Game Minutes</param>
        /// <returns>
        ///     DateTime object of the in-game time
        /// </returns>
        internal static DateTime MinutesToDate(int minutes) =>
            new DateTime((long)Math.Abs(minutes) * 10000000 * 60, DateTimeKind.Utc);

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

        public class Cargo
        {
            /// <summary>
            ///     Mass in kilograms
            /// </summary>
            public float Mass { get; set; }

            /// <summary>
            ///     Name for internal use by code.
            ///     Limited to C-identifier characters and dots.
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            ///     Name for display purposes.
            ///     Localized using the current in-game language.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///     How many units of the cargo the job consist of.
            /// </summary>
            public uint UnitCount { get; set; }

            /// <summary>
            ///     Mass of the single unit of the cargo in kilograms.
            /// </summary>
            public float UnitMass { get; set; }

            public float CargoDamage { get; set; }
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
            try
            {
                ShowMessageBox(events, "Ferry");
                //MessageBox.Show(events, "Ferry");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION FERRY", ex.Message);
            }
        }

        public void Fined(string events)
        {
            try
            {
                ShowMessageBox(events, "Fined");
                //MessageBox.Show(events, "Fined");
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
            try
            {
                if (demoData)
                {
                    ShowMessageBox(events, "Started demoData");
                    //MessageBox.Show(events, "Started demoData");
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
                    ShowMessageBox(events, "Started currentData");
                    //MessageBox.Show(events, "Started currentData");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION STARTED", ex.Message);
            }
        }

        public void Cancelled(string events)
        {
            try
            {
                ShowMessageBox(events, "Cancelled");
                //MessageBox.Show(events, "Cancelled");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION CANCELLED", ex.Message);
            }
        }

        public void Delivered(string events)
        {
            try
            {
                ShowMessageBox(events, "Delivered");
                //MessageBox.Show(events, "Delivered");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION DELIVERED", ex.Message);
            }
        }

        public void Tollgate(string events)
        {
            try
            {
                ShowMessageBox(events, "Tollgate");
                //MessageBox.Show(events, "Tollgate");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION TOLLGATE", ex.Message);
            }
        }

        public void Train(string events)
        {
            try
            {
                ShowMessageBox(events, "Train");
                //MessageBox.Show(events, "Train");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION TRAIN", ex.Message);
            }
        }

        public void Refuel(string events)
        {
            try
            {
                ShowMessageBox(events, "Refuel");
                //MessageBox.Show(events, "Refuel");
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
            catch (Exception ex)
            {
                new LogWriter("EXCEPTION REFUEL", ex.Message);
            }
        }

        static async Task PanelColor(Panel panel, string panelColorHighlight = "IndianRed", string panelColorRevert = "Transparent")
        {
            panel.BackColor = Color.FromName(panelColorHighlight);
            await Task.Delay(2000); // Non-blocking delay for 2 seconds
            panel.BackColor = Color.FromName(panelColorRevert);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            MinimizeToSysTray(sender, e);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreFromSysTray(sender, e);
        }

        private void MinimizeToSysTray(object sender, EventArgs e)
        {
            // Verifica si la ventana se está minimizando
            if (this.WindowState == FormWindowState.Minimized)
            {
                // 1. Oculta el formulario de la barra de tareas
                this.ShowInTaskbar = false;

                // 2. Hace visible el icono en la bandeja de sistema
                //notifyIcon.Visible = true;

                // Opcional: Muestra una notificación temporal
                notifyIcon.ShowBalloonTip(3000, "Mi Aplicación", "La aplicación se está ejecutando en segundo plano.", ToolTipIcon.Info);
            }
            // Si la ventana se está restaurando (Maximizado o Normal)
            else
            {
                // Oculta el icono de la bandeja cuando la aplicación está visible
                //notifyIcon.Visible = false;

                // Muestra el formulario en la barra de tareas
                this.ShowInTaskbar = true;
            }
        }

        private void RestoreFromSysTray(object sender, EventArgs e)
        {
            // 1. Muestra el formulario nuevamente
            this.WindowState = FormWindowState.Normal;

            // 2. Asegúrate de que se muestre en la barra de tareas y el icono de la bandeja se oculte
            this.ShowInTaskbar = true;
            //notifyIcon.Visible = false;
        }

        private void contextMenuStrip_Click(object sender, EventArgs e)
        {

        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oculta el icono de la bandeja antes de cerrar
            notifyIcon.Visible = false;

            // Cierra completamente la aplicación
            Application.Exit();
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Muestra el formulario
            this.WindowState = FormWindowState.Normal;

            // Lo trae al frente
            this.Activate();

            // Oculta el icono de la bandeja
            //notifyIcon.Visible = false;

            // Muestra la aplicación en la barra de tareas
            this.ShowInTaskbar = true;
        }

        private void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            //TestSbConnection(sender, e);
            TestSbConnection();
        }

        private void ButtonTestConnection_Click_1(object sender, EventArgs e)
        {
            //TestSbConnection(sender, e);
            TestSbConnection();
        }

        //private async void TestSbConnection(object sender, EventArgs e)
        private async void TestSbConnection()
        {
            /*
             //var url = StreamerbotUrl;
             if (StreamerBotConfig.url.Equals(""))
             {
                 return null;
             }
             */
            string messageBoxTitle = "StreamerBot Test Connection";
            var testUrl = new UriBuilder("http", StreamerBotConfig.ip, int.Parse(StreamerBotConfig.port), "GetActions");
            /*
            using (var client = new HttpClient())
            {
                //var json = JsonConvert.SerializeObject(data);
                //MessageBox.Show(json);
                //var content = new StringContent("", Encoding.UTF8, "application/json");
                //var response = await client.PostAsync(url, content);

                var response = await client.GetAsync(testUrl.ToString());
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(await response.Content.ReadAsStringAsync());
                    dynamic jsonObj = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    MessageBox.Show(jsonObj.count);
                    //return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the error
                    //return null;
                }

            }*/


            string server = StreamerBotConfig.ip; // Replace with your server
            int port = int.Parse(StreamerBotConfig.port); // Replace with your port

            StreamerBotConnected = false;

            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(server, port);
                    //Console.WriteLine("Connection successful");
                    //new LogWriter("INFO", "TcpClient Connection successful");
                    //new LogWriter("INFO", testUrl.ToString() + "\rTcpClient Connection successful");
                    new Main.LogWriter("TEST CONNECTION", "Streamer.bot IP: " + server + ":" + port + "\rResult: TcpClient Connection successful");
//                    MessageBox.Show($"Connection successful", messageBoxTitle);
                    //lblSBConnected.Text = "SB Connection try: ✔";
                    StreamerBotConnected = true;
                    tcpClient.Close();

                    HttpClient client = new HttpClient();
                    new Main.LogWriter("INFO", testUrl.ToString());
                    //new LogWriter("INFO2", testUrl.Uri.ToString());

                    HttpResponseMessage response = await client.GetAsync(testUrl.Uri.ToString());
                    //HttpResponseMessage response = await client.PostAsync(testUrl.ToString(), content);
                    //response.StatusCode == HttpStatusCode.NotFound
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(json);
                        //new LogWriter("INFO", json);

                        if (json.Length > 0)
                        {

                            // Replace 'dynamic' with your object type if you have one
                            Main.GetAction data = JsonConvert.DeserializeObject<Main.GetAction>(json);

                            //MessageBox.Show(data["count"]);
                            //new LogWriter("INFO", data.Count.ToString());
                            //new LogWriter("INFO", "data.Count ACTIONS: " + data.Count.ToString());
                            new Main.LogWriter("INFO", "Streamer.bot Total Actions: " + data.Count.ToString());
                            /*
                            if (data.Count >= 0 && data.Actions.Count >= 0)
                            {
                                new LogWriter("INFO", "data.Count ACTIONS: " + data.Count.ToString());
                                new LogWriter("INFO", "data.Count >= 0: " + data.Count.ToString());
                                new LogWriter("INFO", "data.Actions.Count >= 0: " + data.Actions.Count.ToString());

                                foreach (SCSSdkClientDemo.Action element in data.Actions)
                                {
                                    new LogWriter("INFO", element.Name.ToString());
                                    new LogWriter("INFO", JsonConvert.SerializeObject(element, Formatting.Indented));
                                }

                                new LogWriter("INFO", "Connection successful.");
                                MessageBox.Show("Connection successful.", messageBoxTitle);
                            }
                            else
                            {
                                new LogWriter("ERROR", "Connection failed.");
                                MessageBox.Show("Connection failed.", messageBoxTitle);
                            }
                            */



                            /*
                            if (data.Count >= 0) {

                                new LogWriter("data.Count >= 0: " + (data.Count >= 0).ToString());

                            }

                            //new LogWriter(data.Actions.ToString());
                            
                            foreach (Action element in data.Actions)
                            {
                                new LogWriter(element.Name.ToString());
                                new LogWriter(JsonConvert.SerializeObject(element, Formatting.Indented));
                            }

                            if (data.Actions.Count >= 0)
                            {
                                new LogWriter("data.Actions.Count >= 0: " + (data.Actions.Count >= 0).ToString());
                            }
                            */
                        }
                        else
                        {
                            MessageBox.Show("Connection failed.", messageBoxTitle);
                            //lblSBConnected.Text = "SB Connection else 1: ❌";
                        }


                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        new Main.LogWriter("ERROR", $"Error: {response.StatusCode}");
                        MessageBox.Show($"Error: {response.StatusCode}", messageBoxTitle);
                        //lblSBConnected.Text = "SB Connection else 2: ❌";
                    }


                }
                catch (HttpRequestException ex)
                {
                    // Handle exception related to the HTTP request
                    //Console.WriteLine($"Request error: {ex.Message}");
                    new Main.LogWriter("ERROR", $"Request error: {ex.Message}");
                    MessageBox.Show($"Request error: {ex.Message}", messageBoxTitle);
                    //lblSBConnected.Text = "SB Connection HttpRequestException: ❌";
                }
                catch (JsonException ex)
                {
                    // Handle exception related to JSON deserialization
                    //Console.WriteLine($"Deserialization error: {ex.Message}");
                    new Main.LogWriter("ERROR", $"Deserialization error: {ex.Message}");
                    MessageBox.Show($"Deserialization error: {ex.Message}", messageBoxTitle);
                    //lblSBConnected.Text = "SB Connection JsonException: ❌";
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Connection failed: {ex.Message}");
                    new Main.LogWriter("ERROR", $"Connection failed: {ex.Message}");
                    //new LogWriter("ERROR", $"Connection failed: {ex}");
//                    MessageBox.Show($"Connection failed: {ex.Message}", messageBoxTitle);
                    //lblSBConnected.Text = "SB Connection Exception: ❌";
                }
                lblSBConnected.Text = "SB Connection: " + (StreamerBotConnected ? "✔" : "❌");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //TestSbConnection();

            // 1. Iniciar el temporizador
            timer1.Start();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            //TestSbConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // LLAMA AQUÍ A LA FUNCIÓN QUE QUIERES EJECUTAR
            TestSbConnection();

            // Opcional: Mostrar la hora actual para comprobar que funciona
            label1.Text = "Última ejecución: " + DateTime.Now.ToLongTimeString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var mensajeActual = mensajes[indiceMensaje];

            // 1. Mostrar/Ocultar y Actualizar los StatusLabels
            if (string.IsNullOrEmpty(mensajeActual.URL))
            {
                // Es un mensaje normal
                statusLabel.Text = mensajeActual.Texto;
                statusLabel.Visible = true;
                linkStatusLabel.Visible = false;
                urlActual = "";
            }
            else
            {
                // Es un mensaje de enlace
                linkStatusLabel.Text = mensajeActual.Texto;
                linkStatusLabel.Visible = true;
                statusLabel.Visible = false;
                urlActual = mensajeActual.URL; // Guarda la URL para usarla en el evento Click
            }

            // 2. Avanzar y resetear el índice
            indiceMensaje++;
            if (indiceMensaje >= mensajes.Length)
            {
                indiceMensaje = 0;
            }
        }

        // --- Manejar el Clic en el Enlace ---
        // Debes crear este método haciendo doble clic en 'linkStatusLabel' en el diseñador
        private void linkStatusLabel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(urlActual))
            {
                try
                {
                    // Abre la URL en el navegador predeterminado
                    Process.Start(new ProcessStartInfo(urlActual) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el enlace: " + ex.Message);
                }
            }
        }

        public void ShowMessageBox(string eventData, string title)
        {
            if (messageBoxShow)
            {
                MessageBox.Show(eventData, title);
            }
            else
            {
                notifyIcon.ShowBalloonTip(3000, "Mi Aplicación", title + " Event Fired", ToolTipIcon.Info);
            }
        }

        private void checkBoxEnableMessageBox_CheckedChanged(object sender, EventArgs e)
        {
            messageBoxShow = checkBoxEnableMessageBox.Checked;
            //MessageBox.Show("MessageBox Status: " + messageBoxShow);
        }
    }
}
