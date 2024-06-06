using System;
//using System.Configuration;
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
using static SCSSdkClient.Demo.CustomSettingsSection;
using System.IO;

namespace SCSSdkClient.Demo {

    /// <inheritdoc />
    public partial class SCSSdkClientDemo : Form {

        /// <summary>
        ///     The SCSSdkTelemetry object
        /// </summary>
        public SCSSdkTelemetry Telemetry;

        ///
        //public const string StreamerbotUrl = "http://127.0.0.1:7474/DoAction";
        ///
        //public const string TestActionId = "034beca8-9461-4514-b00b-3d116bab78e4";
        ///
        //public const string TestActionName = "Test";
        /*
        ///
        public ActionInfo JobInfoSBAction = new ActionInfo { id = "2fb96e1d-c7db-424d-8082-4208c74b6868", name = "JobStarted" };
        ///
        public ActionInfo FerryEventSBAction = new ActionInfo { id = "5b647f19-a79a-40f3-8d7e-a68152cb7f9a", name = "FerryEvent" };
        ///
        public ActionInfo FinedEventSBAction = new ActionInfo { id = "4eca0dfc-3c19-40ae-b6e0-3c936fe71ef7", name = "FinedEvent" };
        ///
        public ActionInfo JobCancelledSBAction = new ActionInfo { id = "8eea589f-b513-4499-8602-40b914f8c749", name = "JobCancelled" };
        ///
        public ActionInfo JobDeliveredSBAction = new ActionInfo { id = "d9aee73d-c46c-4e7e-99a7-b9dda5c698cc", name = "JobDelivered" };
        ///
        public ActionInfo TollgateEventSBAction = new ActionInfo { id = "7196bf3f-b53d-4cc3-8242-6c9f98d02f8c", name = "TollgateEvent" };
        ///
        public ActionInfo TrainEventSBAction = new ActionInfo { id = "4f24d6ab-0712-482e-80c0-4ace8a693a4b", name = "TrainEvent" };
        ///
        public ActionInfo RefuelEventSBAction = new ActionInfo { id = "b63b68cd-5a3a-46f8-a08f-ef276c84e500", name = "RefuelEvent" };
        */
        public string StreamerbotUrl;

        public ActionInfo JobStartedSBAction;
        public ActionInfo FerryEventSBAction;
        public ActionInfo FinedEventSBAction;
        public ActionInfo JobCancelledSBAction;
        public ActionInfo JobDeliveredSBAction;
        public ActionInfo TollgateEventSBAction;
        public ActionInfo TrainEventSBAction;
        public ActionInfo RefuelEventSBAction;

        private static readonly HttpClient client = new HttpClient();

        private float fuel;
        private SCSTelemetry raw;

        /// <inheritdoc />
        public SCSSdkClientDemo() {
            readConfigFile();
            InitializeComponent();
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
        /*
        public class MyData
        {
            public string Action { get; set; }
                public int Id { get; set; }
                public string Name { get; set; }

        }
        */
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
        }

        ///
        public async Task<string> PostJsonDataAsync(MyJsonObject data)
        {
            var url = StreamerbotUrl;
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(data);
                //MessageBox.Show(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
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
            //MessageBox.Show("1");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //MessageBox.Show("2");
            IConfigurationRoot configuration = builder.Build();
            //MessageBox.Show("3");
            /*
            string name = configuration.GetSection("MySettings:Name").Value;
            string key1 = configuration.GetSection("MySettings:NestedSettings:Key1").Value;
            string key2 = configuration.GetSection("MySettings:NestedSettings:Key2").Value;
            string item1 = configuration.GetSection("MySettings:ArraySettings:0").Value;
            MessageBox.Show("4");
            MessageBox.Show("Name: " + name);
            MessageBox.Show("Key1: " + key1);
            MessageBox.Show("Key2: " + key2);
            MessageBox.Show("Item1: " + item1);
            */
            string Protocol = configuration.GetSection("Connection:Protocol").Value;
            string Ip = configuration.GetSection("Connection:Ip").Value;
            string Port = configuration.GetSection("Connection:Port").Value;
            string Endpoint = configuration.GetSection("Connection:Endpoint").Value;
            StreamerbotUrl = Protocol + "://" + Ip + ":" + Port + "/" + Endpoint;
            //MessageBox.Show("StreamerbotUrl: "+ StreamerbotUrl);

            string JobStartedId = configuration.GetSection("Actions:JobStarted:Id").Value;
            string JobStartedName = configuration.GetSection("Actions:JobStarted:Name").Value;
            JobStartedSBAction = new ActionInfo { id = JobStartedId, name = JobStartedName };
            //MessageBox.Show("JobStartedSBAction: "+ JobStartedSBAction);
            string JobDeliveredId = configuration.GetSection("Actions:JobDelivered:Id").Value;
            string JobDeliveredName = configuration.GetSection("Actions:JobDelivered:Name").Value;
            JobDeliveredSBAction = new ActionInfo { id = JobDeliveredId, name = JobDeliveredName };
            //MessageBox.Show("JobDeliveredSBAction: " + JobDeliveredSBAction);
            string JobCancelledId = configuration.GetSection("Actions:JobCancelled:Id").Value;
            string JobCancelledName = configuration.GetSection("Actions:JobCancelled:Name").Value;
            JobCancelledSBAction = new ActionInfo { id = JobCancelledId, name = JobCancelledName };
            //MessageBox.Show("JobCancelledSBAction: " + JobCancelledSBAction);
            string FinedEventId = configuration.GetSection("Actions:FinedEvent:Id").Value;
            string FinedEventName = configuration.GetSection("Actions:FinedEvent:Name").Value;
            FinedEventSBAction = new ActionInfo { id = FinedEventId, name = FinedEventName };
            //MessageBox.Show("FinedEventSBAction: " + FinedEventSBAction);
            string TollgateEventId = configuration.GetSection("Actions:TollgateEvent:Id").Value;
            string TollgateEventName = configuration.GetSection("Actions:TollgateEvent:Name").Value;
            TollgateEventSBAction = new ActionInfo { id = TollgateEventId, name = TollgateEventName };
            //MessageBox.Show("TollgateEventSBAction: " + TollgateEventSBAction);
            string TrainEventId = configuration.GetSection("Actions:TrainEvent:Id").Value;
            string TrainEventName = configuration.GetSection("Actions:TrainEvent:Name").Value;
            TrainEventSBAction = new ActionInfo { id = TrainEventId, name = TrainEventName };
            //MessageBox.Show("TrainEventSBAction: " + TrainEventSBAction);
            string FerryEventId = configuration.GetSection("Actions:FerryEvent:Id").Value;
            string FerryEventName = configuration.GetSection("Actions:FerryEvent:Name").Value;
            FerryEventSBAction = new ActionInfo { id = FerryEventId, name = FerryEventName };
            //MessageBox.Show("FerryEventSBAction: " + FerryEventSBAction);
            string RefuelEventId = configuration.GetSection("Actions:RefuelEvent:Id").Value;
            string RefuelEventName = configuration.GetSection("Actions:RefuelEvent:Name").Value;
            RefuelEventSBAction = new ActionInfo { id = RefuelEventId, name = RefuelEventName };
            //MessageBox.Show("RefuelEventSBAction: " + RefuelEventSBAction);
            /*
            try
            {
                var customSettings = ConfigurationManager.GetSection("MyCustomSettings") as CustomSettingsSection;

                if (customSettings != null)
                {
                    Console.WriteLine($"API Key: {customSettings.ApiKey}");
                    Console.WriteLine($"Service URL: {customSettings.ServiceUrl}");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Error reading configuration: {ex.Message}");
            }
            */
            //MessageBox.Show("1");
            /*
            try
            {
                var customSettings = ConfigurationManager.GetSection("JobInfoSBAction") as CustomSettingsSection;
                //MessageBox.Show("2");
                //MessageBox.Show(customSettings.ToString());
                //MessageBox.Show(customSettings.id.ToString());
                //MessageBox.Show(ConfigurationManager.GetSection("JobInfoSBAction").ToString());
                MessageBox.Show((customSettings != null).ToString());
                if (customSettings != null)
                {
                    MessageBox.Show("3");
                    JobInfoSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name};
                }
                
                customSettings = ConfigurationManager.GetSection("FerryEventSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    FerryEventSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                customSettings = ConfigurationManager.GetSection("FinedEventSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    FinedEventSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                customSettings = ConfigurationManager.GetSection("JobCancelledSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    JobCancelledSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                customSettings = ConfigurationManager.GetSection("JobDeliveredSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    JobDeliveredSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                customSettings = ConfigurationManager.GetSection("TollgateEventSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    TollgateEventSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                customSettings = ConfigurationManager.GetSection("TrainEventSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    TrainEventSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                customSettings = ConfigurationManager.GetSection("RefuelEventSBAction") as CustomSettingsSection;
                if (customSettings != null)
                {
                    RefuelEventSBAction = new ActionInfo { id = customSettings.id, name = customSettings.name };
                }

                /*
                var config = ConfigurationManager.OpenExeConfiguration("StreamerBot.config");
                var someKeyValue = config.JobInfoSBAction.Settings["someKey"].Value;
                * /

                /*
                // Specify the custom configuration file path
                var configFileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = "StreamerBot.config"
                };

                // Open the configuration file
                var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                // Read settings from the custom configuration file
                var someSetting = config.JobInfoSBAction.Settings["SomeKey"].Value;
                * /
                //JobInfoSBAction = new ActionInfo { id = "2fb96e1d-c7db-424d-8082-4208c74b6868", name = "Job" };
                /*
                FerryEventSBAction = new ActionInfo { id = "2fb96e1d-c7db-424d-8082-4208c74b6868", name = "Job" };
                FinedEventSBAction;
                JobCancelledSBAction;
                JobDeliveredSBAction;
                TollgateEventSBAction;
                TrainEventSBAction;
                RefuelEventSBAction;
                * /
            }
            catch (ConfigurationErrorsException ex)
            {
                //Console.WriteLine($"Error reading configuration: {ex.Message}");
            }
    */
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
        }
        private void Fined(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.FinedEvent);
            //MessageBox.Show(json, "FinedEvent");
            var myObject = createMyJsonObject(FinedEventSBAction, "FinedEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }
        private void Started(string events)
        {
            //var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            //var json = JsonConvert.SerializeObject(myObject1.JobDelivered);
            //MessageBox.Show(json, "JobDelivered");
            var myObject = createMyJsonObject(JobStartedSBAction, "Job", events);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }
        private void Cancelled(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.JobCancelled);
            //MessageBox.Show(json, "JobCancelled");
            var myObject = createMyJsonObject(JobCancelledSBAction, "JobCancelled", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }
        private void Delivered(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.JobDelivered);
            //MessageBox.Show(json, "JobDelivered");
            var myObject = createMyJsonObject(JobDeliveredSBAction, "JobDelivered", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }
        private void Tollgate(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.TollgateEvent);
            //MessageBox.Show(json, "TollgateEvent");
            var myObject = createMyJsonObject(TollgateEventSBAction, "TollgateEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }
        private void Train(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.TrainEvent);
            //MessageBox.Show(json, "TrainEvent");
            var myObject = createMyJsonObject(TrainEventSBAction, "TrainEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }
        private void Refuel(string events)
        {
            var myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(events);
            var json = JsonConvert.SerializeObject(myObject1.RefuelEvent);
            //MessageBox.Show(json, "RefuelEvent");
            var myObject = createMyJsonObject(RefuelEventSBAction, "RefuelEvent", json);
            Task variableInutilPerEvitarWarnings = PostJsonDataAsync(myObject);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sleep = 1 * 1000;
            //TelemetryFerry(null,e);
            //var jsdo = JsonConvert.DeserializeObject(gameplayevent.Text);
            //MessageBox.Show(jsdo.FerryEvent);
            /*
                        var myObject1 = JsonConvert.DeserializeObject<MyJsonObject2>(gameplayevent.Text);

                        // Access the PayAmount property
                        //decimal payAmount = myObject.FerryEvent.PayAmount;
                        var json = JsonConvert.SerializeObject(myObject1.FerryEvent);
                        MessageBox.Show(json, "Ferry");

                        //json = JsonConvert.SerializeObject(raw);

                        //Task.Delay(2000);
                        var myObject = new MyJsonObject
                        {
                            action = new ActionInfo
                            {
                                //id = TestActionId,
                                //name = TestActionName
                                id = JobActionId,
                                name = JobActionName
                            },
                            args = new Dictionary<string, string>
                                {
                                //{ "Amount", "140" },
                                //{ "Offence", "red_light" },
                                //{ "json", "{\"DeliveryTime\":{\"Value\":0,\"Date\":\"0001-01-01T00:00:00Z\"},\"RemainingDeliveryTime\":{\"Value\":0,\"Date\":\"0001-01-01T00:00:00Z\"},\"CargoLoaded\":false,\"SpecialJob\":false,\"Market\":0,\"PlannedDistanceKm\":0,\"CargoValues\":{\"Mass\":0,\"Id\":\"\",\"Name\":\"\",\"UnitCount\":0,\"UnitMass\":0,\"CargoDamage\":0},\"CityDestinationId\":\"\",\"CityDestination\":\"\",\"CompanyDestinationId\":\"\",\"CompanyDestination\":\"\",\"CitySourceId\":\"\",\"CitySource\":\"\",\"CompanySourceId\":\"\",\"CompanySource\":\"\",\"Income\":0}"}
                                  {"json", json }
                                }
                        };
                        PostJsonDataAsync(myObject);
             
            */

            Ferry(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Fined(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Cancelled(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Delivered(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Tollgate(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Train(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Refuel(gameplayevent.Text);
            System.Threading.Thread.Sleep(sleep);

            Started(job.Text);
            /*
            var myObject1 = new GamePlayEvents();/*
            myObject1 = JsonConvert.DeserializeObject<GamePlayEvents>(gameplayevent.Text);
            var json = "";
            json = JsonConvert.SerializeObject(myObject1.FerryEvent);
            MessageBox.Show(json, "FerryEvent");
            var myObject = new MyJsonObject();/*
            var myObject = createMyJsonObject(FerryEventSBAction, "FerryEvent", json);
            //var args = new Dictionary<string, string> { { "event", "FerryEvent" }, { "json", json } };
            //myObject = new MyJsonObject {action = FerryEventSBAction, args = args };
            PostJsonDataAsync(myObject);
            
            System.Threading.Thread.Sleep(sleep);
            //Task.Delay(10000);
            json = JsonConvert.SerializeObject(myObject1.FinedEvent);
            MessageBox.Show(json, "FinedEvent");
            myObject = createMyJsonObject(FinedEventSBAction, "FinedEvent", json);
            //args = new Dictionary<string, string> { { "event", "FinedEvent" }, { "json", json } };
            //myObject = new MyJsonObject { action = FinedEventSBAction, args = args };
            PostJsonDataAsync(myObject);

            System.Threading.Thread.Sleep(sleep);
            //Task.Delay(10000);
            json = JsonConvert.SerializeObject(myObject1.JobCancelled);
            MessageBox.Show(json, "JobCancelled");
            myObject = createMyJsonObject(JobCancelledSBAction, "JobCancelled", json);
            //args = new Dictionary<string, string> { { "event", "JobCancelled" }, { "json", json } };
            //myObject = new MyJsonObject { action = JobCancelledSBAction, args = args };
            PostJsonDataAsync(myObject);

            System.Threading.Thread.Sleep(sleep);
            //Task.Delay(10000);
            json = JsonConvert.SerializeObject(myObject1.JobDelivered);
            MessageBox.Show(json, "JobDelivered");
            myObject = createMyJsonObject(JobDeliveredSBAction, "JobDelivered", json);
            //args = new Dictionary<string, string> { { "event", "JobDelivered" }, { "json", json } };
            //myObject = new MyJsonObject { action = JobDeliveredSBAction, args = args };
            PostJsonDataAsync(myObject);

            System.Threading.Thread.Sleep(sleep);
            //Task.Delay(10000);
            json = JsonConvert.SerializeObject(myObject1.TollgateEvent);
            MessageBox.Show(json, "TollgateEvent");
            myObject = createMyJsonObject(TollgateEventSBAction, "TollgateEvent", json);
            //args = new Dictionary<string, string> { { "event", "TollgateEvent" }, { "json", json } };
            //myObject = new MyJsonObject { action = TollgateEventSBAction, args = args };
            PostJsonDataAsync(myObject);

            System.Threading.Thread.Sleep(sleep);
            //Task.Delay(10000);
            json = JsonConvert.SerializeObject(myObject1.TrainEvent);
            MessageBox.Show(json, "TrainEvent");
            myObject = createMyJsonObject(TrainEventSBAction, "TrainEvent", json);
            //args = new Dictionary<string, string> { { "event", "TrainEvent" }, { "json", json } };
            //myObject = new MyJsonObject { action = TrainEventSBAction, args = args };
            PostJsonDataAsync(myObject);

            System.Threading.Thread.Sleep(sleep);
            //Task.Delay(10000);
            json = JsonConvert.SerializeObject(myObject1.RefuelEvent);
            MessageBox.Show(json, "RefuelEvent");
            myObject = createMyJsonObject(RefuelEventSBAction, "RefuelEvent", json);
            //args = new Dictionary<string, string> { { "event", "RefuelEvent" }, { "json", json } };
            //myObject = new MyJsonObject { action = RefuelEventSBAction, args = args };
            PostJsonDataAsync(myObject);
            */







        }

        /*
        private async Task<String> PostToStreamerbot()
        {
            var values = new Dictionary<string, string>
              {
                  { "thing1", "hello" },
                  { "thing2", "world" }
              };
        / *
            var obj = new Dictionary<string, Dictionary<string, string>>
            {
                { "action": { "id": "034beca8-9461-4514-b00b-3d116bab78e4","name": "Test"},
                 "args": { "key", "value"}
            };
        * /
        var data = { "action": { "id": "034beca8-9461-4514-b00b-3d116bab78e4","name": "Test"},"args": { "key", "value"}};

        var json = JsonConvert.SerializeObject(data);

        var json = "{\"action\": {\"id\": \"034beca8-9461-4514-b00b-3d116bab78e4\",\"name\": \"Test\"}," +
                  "\"args\": {\"key\": \"value\",}};";


            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://127.0.0.1:7474/DoAction", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return "";
        }*/
    }
}
