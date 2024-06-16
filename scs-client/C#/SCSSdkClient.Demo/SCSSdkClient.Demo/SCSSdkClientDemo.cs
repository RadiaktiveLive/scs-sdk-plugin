using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SCSSdkClient.Object;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using static SCSSdkClient.Object.SCSTelemetry;
using static SCSSdkClient.Demo.SCSSdkClientDemo;
using System.IO;
using System.Security.Policy;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace SCSSdkClient.Demo {

    /// <inheritdoc />
    public partial class SCSSdkClientDemo : Form {

        /// <summary>
        ///     The SCSSdkTelemetry object
        /// </summary>
        public SCSSdkTelemetry Telemetry;

        ///
        public string StreamerBotConfigFile = "StreamerBotSettings.json";
        ///
        public string StreamerbotUrl = "";
        ///
        public StreamerBot StreamerBotConfig = new StreamerBot();
        ///
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

        private static readonly HttpClient client = new HttpClient();

        private float fuel;
        private SCSTelemetry raw;

        /// <inheritdoc />
        public SCSSdkClientDemo() {
            
            InitializeComponent();
            readConfigFile();
            /*
            var myObject = new MyJsonObject
            {
                action = new ActionInfo
                {
                    id = TestActionId,
                    name = TestActionName
                },
                args = new Dictionary<string, string>
                    {
                        { "Amount", "140" },
                        { "Offence", "red_light" }
                    }
            };
            PostJsonDataAsync(myObject);
            */
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

            if (Telemetry.Error != null) {
                lbGeneral.Text =
                    "General info:\r\nFailed to open memory map " +
                    Telemetry.Map +
                    " - on some systems you need to run the client (this app) with elevated permissions, because e.g. you're running Steam/ETS2 with elevated permissions as well. .NET reported the following Exception:\r\n" +
                    Telemetry.Error.Message +
                    "\r\n\r\nStacktrace:\r\n" +
                    Telemetry.Error.StackTrace;
            }

            l_updateRate.Text = Telemetry.UpdateInterval + "ms";
        }

        private void SCSSdkClientDemo_FormClosing(object sender, FormClosingEventArgs e) {
            Telemetry.pause(); // that line make it possible, but not every application wants to ask the user to quit, need to see if i can change that, when not use the try catch and IGNORE it (nothing changed )
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) ==
                DialogResult.No) {
                e.Cancel = true;
                Telemetry.resume();
                return;
            }

            Telemetry.Dispose();
        }

        private void Telemetry_Data(SCSTelemetry data, bool updated) {
            if (!updated)
                return;
            try {
                if (InvokeRequired) {
                    Invoke(new TelemetryData(Telemetry_Data), data, updated);
                    return;
                }

                l_updateRate.Text = Telemetry.UpdateInterval + "ms";

                lbGeneral.Text = "General info:\n" +
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
                raw = data;

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
            } catch (Exception ex) {
                // ignored atm i found no proper way to shut the telemetry down and down call this anymore when this or another thing is already disposed
                Console.WriteLine("Telemetry was closed: " + ex);
            }
        }

        private void TelemetryFerry(object sender, EventArgs e) {
            //MessageBox.Show("Ferry");
            Ferry(gameplayevent.Text);
        }

        private void TelemetryFined(object sender, EventArgs e) {
            //MessageBox.Show("Fined");
            Fined(gameplayevent.Text);
        }

        private void TelemetryJobCancelled(object sender, EventArgs e) {
            //MessageBox.Show("Job Cancelled");
            Cancelled(gameplayevent.Text);
        }

        private void TelemetryJobDelivered(object sender, EventArgs e) {
            //MessageBox.Show("Job Delivered");
            Delivered(gameplayevent.Text);
        }

        private void TelemetryOnJobStarted(object sender, EventArgs e) {
            //MessageBox.Show("Just started job OR loaded game with active.");
            Started(job.Text);
        }

        private void TelemetryRefuel(object sender, EventArgs e) {
            rtb_fuel.Invoke((MethodInvoker)(() => rtb_fuel.BackColor = Color.Green));
        }

        private void TelemetryRefuelEnd(object sender, EventArgs e) {
            rtb_fuel.Invoke((MethodInvoker)(() => rtb_fuel.BackColor = Color.Red));
        }

        private void TelemetryRefuelPayed(object sender, EventArgs e) {
            //MessageBox.Show("Fuel Payed: " + fuel);
            Refuel(gameplayevent.Text);
        }

        private void TelemetryTollgate(object sender, EventArgs e) {
            //MessageBox.Show("Tollgate");
            Tollgate(gameplayevent.Text);
        }

        private void TelemetryTrain(object sender, EventArgs e) {
            //MessageBox.Show("Train");
            Train(gameplayevent.Text);
        }

        ///
        public class MyJsonObject
        {
            ///
            public ActionInfo action { get; set; }
            ///
            public Dictionary<string, string> args { get; set; }
        }
        
        ///
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
        }

        private void readConfigFile()
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

                string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "StreamerBotSettings.json");

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
                    textBoxJobStartedId.Text = JobStartedEventId;
                    textBoxJobStartedName.Text = JobStartedEventName;
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
                    textBoxJobDeliveredId.Text = JobDeliveredEventId;
                    textBoxJobDeliveredName.Text = JobDeliveredEventName;
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
                    textBoxJobCancelledId.Text = JobCancelledEventId;
                    textBoxJobCancelledName.Text = JobCancelledEventName;
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
                    textBoxFinedEventId.Text = FinedEventId;
                    textBoxFinedEventName.Text = FinedEventName;
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
                    textBoxTollgateEventId.Text = TollgateEventId;
                    textBoxTollgateEventName.Text = TollgateEventName;
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
                    textBoxTrainEventId.Text = TrainEventId;
                    textBoxTrainEventName.Text = TrainEventName;
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
                    textBoxFerryEventId.Text = FerryEventId;
                    textBoxFerryEventName.Text = FerryEventName;
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
                    textBoxRefuelEventId.Text = RefuelEventId;
                    textBoxRefuelEventName.Text = RefuelEventName;
                }
                //MessageBox.Show("RefuelEventSBAction: \n{\n id = \"" + RefuelEventSBAction.id + "\",\n name = \"" + RefuelEventSBAction.name + "\"\n}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBoxPort.Text, out value))
            {
                if (value < 0 || value > 65535) // Minimum value
                {
                    //textBoxPort.Text = "0";
                    MessageBox.Show("Please enter a number between 0 and 65535. Default port is 7474.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number between 0 and 65535. Default port is 7474.");
            }
        }

        private MyJsonObject createMyJsonObject(ActionInfo actionInfo, string title, string json)
        {
            var myObject = new MyJsonObject();
            var args = new Dictionary<string, string> { { "event", title }, { "json", json } };
            myObject = new MyJsonObject { action = actionInfo, args = args };
            return myObject;
        }

        private void Ferry(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.FerryEvent);
            //MessageBox.Show(json, "FerryEvent");
            var myObject = createMyJsonObject(FerryEventSBAction, "FerryEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelFerry);
        }
        private void Fined(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.FinedEvent);
            //MessageBox.Show(json, "FinedEvent");
            var myObject = createMyJsonObject(FinedEventSBAction, "FinedEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelFined);
        }
        private void Started(string events)
        {
            //var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            //var json = JsonConvert.SerializeObject(myObject1.JobDelivered);
            //MessageBox.Show(json, "JobDelivered");
            var myObject = createMyJsonObject(JobStartedEventSBAction, "Job", events);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelJobStarted);
        }
        private void Cancelled(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.JobCancelled);
            //MessageBox.Show(json, "JobCancelled");
            var myObject = createMyJsonObject(JobCancelledEventSBAction, "JobCancelled", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelJobCancelled);
        }
        private void Delivered(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.JobDelivered);
            //MessageBox.Show(json, "JobDelivered");
            var myObject = createMyJsonObject(JobDeliveredEventSBAction, "JobDelivered", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelJobDelivered);
        }
        private void Tollgate(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.TollgateEvent);
            //MessageBox.Show(json, "TollgateEvent");
            var myObject = createMyJsonObject(TollgateEventSBAction, "TollgateEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelTollgate);
        }
        private void Train(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.TrainEvent);
            //MessageBox.Show(json, "TrainEvent");
            var myObject = createMyJsonObject(TrainEventSBAction, "TrainEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            Task variableInutilPerEvitarWarnings2 = PanelColor(panelTrain);
        }
        private void Refuel(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.RefuelEvent);
            //MessageBox.Show(json, "RefuelEvent");
            var myObject = createMyJsonObject(RefuelEventSBAction, "RefuelEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);

            //panelRefuel.BackColor = Color.IndianRed;
            Task variableInutilPerEvitarWarnings2 = PanelColor(panelRefuel);
            //panelRefuel.BackColor = Color.Transparent;
        }

        static async Task PanelColor(Panel panel, string panelColorHighlight = "IndianRed", string panelColorRevert = "Transparent")
        {
            panel.BackColor = Color.FromName(panelColorHighlight);
            await Task.Delay(2000); // Non-blocking delay for 2 seconds
            panel.BackColor = Color.FromName(panelColorRevert);
        }

        private void buttonTriggerActions_Click(object sender, EventArgs e)
        {
            contextMenuStripTriggerActions.Show(buttonTriggerActions, new Point(0, buttonTriggerActions.Height)); // Shows the menu strip below the button
            /*
            var sleep = 1 * 1000;

            Started(job.Text);
            
            System.Threading.Thread.Sleep(sleep);

            Delivered(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Cancelled(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Fined(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Tollgate(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Train(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Ferry(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Refuel(gameplayevent.Text);
            */
        }
        /*
        private void contextMenuStripTriggerActions_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        */
        private async void toolStripRunAll_Click(object sender, EventArgs e)
        {
            var sleep = 2 * 1000;

            Started(job.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Delivered(gameplayevent.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Cancelled(gameplayevent.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Fined(gameplayevent.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Tollgate(gameplayevent.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Train(gameplayevent.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Ferry(gameplayevent.Text);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            Refuel(gameplayevent.Text);
        }

        private void toolStripJobStarted_Click(object sender, EventArgs e)
        {
            Started(job.Text);
        }

        private void toolStripJobDelivered_Click(object sender, EventArgs e)
        {
            Delivered(gameplayevent.Text);
        }

        private void toolStripJobCancelled_Click(object sender, EventArgs e)
        {
            Cancelled(gameplayevent.Text);
        }

        private void toolStripFinedEvent_Click(object sender, EventArgs e)
        {
            Fined(gameplayevent.Text);
        }

        private void toolStripTollgateEvent_Click(object sender, EventArgs e)
        {
            Tollgate(gameplayevent.Text);
        }

        private void toolStripTrainEvent_Click(object sender, EventArgs e)
        {
            Train(gameplayevent.Text);
        }

        private void toolStripFerryEvent_Click(object sender, EventArgs e)
        {
            Ferry(gameplayevent.Text);
        }

        private void toolStripRefuelEvent_Click(object sender, EventArgs e)
        {
            Refuel(gameplayevent.Text);
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save the settings?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            var data = new
            {
                Connection = new
                {
                    Protocol = "http",
                    Ip = textBoxIp.Text,
                    Port = textBoxPort.Text,
                    Endpoint = "DoAction"
                },
                Actions = new
                {
                    JobStartedEvent = new
                    {
                        Id = textBoxJobStartedId.Text,
                        Name = textBoxJobStartedName.Text
                    },
                    JobDeliveredEvent = new
                    {
                        Id = textBoxJobDeliveredId.Text,
                        Name = textBoxJobDeliveredName.Text
                    },
                    JobCancelledEvent = new
                    {
                        Id = textBoxJobCancelledId.Text,
                        Name = textBoxJobCancelledName.Text
                    },
                    FinedEvent = new
                    {
                        Id = textBoxFinedEventId.Text,
                        Name = textBoxFinedEventName.Text
                    },
                    TollgateEvent = new
                    {
                        Id = textBoxTollgateEventId.Text,
                        Name = textBoxTollgateEventName.Text
                    },
                    TrainEvent = new
                    {
                        Id = textBoxTrainEventId.Text,
                        Name = textBoxTrainEventName.Text
                    },
                    FerryEvent = new
                    {
                        Id = textBoxFerryEventId.Text,
                        Name = textBoxFerryEventName.Text
                    },
                    RefuelEvent = new
                    {
                        Id = textBoxRefuelEventId.Text,
                        Name = textBoxRefuelEventName.Text
                    }
                    // Add more actions as needed
                }
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            // Specify your own path and filename
            string path = @"savedSettings.json";

            File.WriteAllText(path, json);
        }

        private async void buttonTestConnection_Click(object sender, EventArgs e)
        {
            /*
            //var url = StreamerbotUrl;
            if (StreamerBotConfig.url.Equals(""))
            {
                return null;
            }
            */
            var testUrl = new UriBuilder(StreamerBotConfig.protocol, textBoxIp.Text, int.Parse(textBoxPort.Text), "GetActions");
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



            string server = textBoxIp.Text; // Replace with your server
            int port = int.Parse(textBoxPort.Text); // Replace with your port

            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(server, port);
                    //Console.WriteLine("Connection successful");
                    new LogWriter("TcpClient Connection successful");



                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(testUrl.ToString());
                    //response.StatusCode == HttpStatusCode.NotFound
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(json);
                        new LogWriter(json);

                        if (json.Length > 0)
                        {

                            // Replace 'dynamic' with your object type if you have one
                            GetAction data = JsonConvert.DeserializeObject<GetAction>(json);

                            //MessageBox.Show(data["count"]);
                            new LogWriter(data.Count.ToString());

                            if (data.Count >= 0 && data.Actions.Count >= 0)
                            {
                                new LogWriter("data.Count >= 0: " + data.Count.ToString());
                                new LogWriter("data.Actions.Count >= 0: " + data.Actions.Count.ToString());

                                foreach (Action element in data.Actions)
                                {
                                    new LogWriter(element.Name.ToString());
                                    new LogWriter(JsonConvert.SerializeObject(element, Formatting.Indented));
                                }

                                new LogWriter("Connection successful.");
                                MessageBox.Show("Connection successful.");
                            }
                            else
                            {
                                new LogWriter("Connection failed.");
                                MessageBox.Show("Connection failed.");
                            }




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
                            MessageBox.Show("Connection failed.");
                        }


                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        new LogWriter($"Error: {response.StatusCode}");
                        MessageBox.Show($"Error: {response.StatusCode}");
                    }


                }
                catch (HttpRequestException ex)
                {
                    // Handle exception related to the HTTP request
                    //Console.WriteLine($"Request error: {ex.Message}");
                    new LogWriter($"Request error: {ex.Message}");
                    MessageBox.Show($"Request error: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    // Handle exception related to JSON deserialization
                    //Console.WriteLine($"Deserialization error: {ex.Message}");
                    new LogWriter($"Deserialization error: {ex.Message}");
                    MessageBox.Show($"Deserialization error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Connection failed: {ex.Message}");
                    new LogWriter($"Connection failed: {ex.Message}");
                    MessageBox.Show($"Connection failed: {ex.Message}");
                }
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
            public LogWriter(string logMessage)
            {
                LogWrite(logMessage);
            }
            public void LogWrite(string logMessage)
            {
                m_exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                try
                {
                    using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
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
                    txtWriter.WriteLine("{0} {1} :", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
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
