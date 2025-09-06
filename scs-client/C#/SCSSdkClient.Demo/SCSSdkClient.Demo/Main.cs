using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SCSSdkClient.Demo.SCSSdkClientDemo;

namespace SCSSdkClient.Demo
{
    public partial class Main : Form
    {
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

        public Main()
        {
            InitializeComponent();
            ReadConfigFile();
        }

        private void ReadConfigFile()
        {
            MessageBox.Show("ReadConfigFile running");
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
            //Telemetry.pause(); // that line make it possible, but not every application wants to ask the user to quit, need to see if i can change that, when not use the try catch and IGNORE it (nothing changed )
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                //Telemetry.resume();
                return;
            }

            //Telemetry.Dispose();
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
            MessageBox.Show("El formulario de configuración ha sido cerrado.");
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
            SCSSdkClientDemo formConfigBasica = new SCSSdkClientDemo();

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
        }
    }
}
