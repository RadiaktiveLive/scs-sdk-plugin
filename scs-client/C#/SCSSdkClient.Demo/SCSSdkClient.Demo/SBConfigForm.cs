using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCSSdkClient.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static SCSSdkClient.Demo.Main;
using static SCSSdkClient.Demo.SCSSdkClientDemo;
using static SCSSdkClient.Object.SCSTelemetry;

namespace SCSSdkClient.Demo
{
    public partial class SBConfigForm : Form
    {
        private Main _mainForm;

        public Main.StreamerBot StreamerBotConfig = new Main.StreamerBot();

        public string StreamerBotConfigFile = "StreamerBotSettings.json";

        public string StreamerbotUrl = "";

        public SBConfigForm(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void SBConfigForm_Load(object sender, EventArgs e)
        {
            // SB connection settings
            textBoxIp.Text = _mainForm.StreamerBotConfig.ip;
            textBoxPort.Text = _mainForm.StreamerBotConfig.port;

            // JobStartedEventSBAction
            textBoxJobStartedId.Text = _mainForm.JobStartedEventSBAction.id;
            textBoxJobStartedName.Text = _mainForm.JobStartedEventSBAction.name;

            // JobDeliveredEventSBAction
            textBoxJobDeliveredId.Text = _mainForm.JobDeliveredEventSBAction.id;
            textBoxJobDeliveredName.Text = _mainForm.JobDeliveredEventSBAction.name;

            // JobCancelledEventSBAction
            textBoxJobCancelledId.Text = _mainForm.JobCancelledEventSBAction.id;
            textBoxJobCancelledName.Text = _mainForm.JobCancelledEventSBAction.name;

            // FinedEventSBAction
            textBoxFinedEventId.Text = _mainForm.FinedEventSBAction.id;
            textBoxFinedEventName.Text = _mainForm.FinedEventSBAction.name;

            // TollgateEventSBAction
            textBoxTollgateEventId.Text = _mainForm.TollgateEventSBAction.id;
            textBoxTollgateEventName.Text = _mainForm.TollgateEventSBAction.name;

            // TrainEventSBAction
            textBoxTrainEventId.Text = _mainForm.TrainEventSBAction.id;
            textBoxTrainEventName.Text = _mainForm.TrainEventSBAction.name;

            // FerryEventSBAction
            textBoxFerryEventId.Text = _mainForm.FerryEventSBAction.id;
            textBoxFerryEventName.Text = _mainForm.FerryEventSBAction.name;

            // RefuelEventSBAction
            textBoxRefuelEventId.Text = _mainForm.RefuelEventSBAction.id;
            textBoxRefuelEventName.Text = _mainForm.RefuelEventSBAction.name;
        }

        private async void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            /*
            //var url = StreamerbotUrl;
            if (StreamerBotConfig.url.Equals(""))
            {
                return null;
            }
            */
            string messageBoxTitle = "StreamerBot Test Connection";
            var testUrl = new UriBuilder("http", textBoxIp.Text, int.Parse(textBoxPort.Text), "GetActions");
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
                    //new LogWriter("INFO", "TcpClient Connection successful");
                    //new LogWriter("INFO", testUrl.ToString() + "\rTcpClient Connection successful");
                    new Main.LogWriter("TEST CONNECTION", "Streamer.bot IP: " + server + ":" + port + "\rResult: TcpClient Connection successful");
                    MessageBox.Show($"Connection successful", messageBoxTitle);
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
                        }


                    }
                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode}");
                        new Main.LogWriter("ERROR", $"Error: {response.StatusCode}");
                        MessageBox.Show($"Error: {response.StatusCode}", messageBoxTitle);
                    }
                    

                }
                catch (HttpRequestException ex)
                {
                    // Handle exception related to the HTTP request
                    //Console.WriteLine($"Request error: {ex.Message}");
                    new Main.LogWriter("ERROR", $"Request error: {ex.Message}");
                    MessageBox.Show($"Request error: {ex.Message}", messageBoxTitle);
                }
                catch (JsonException ex)
                {
                    // Handle exception related to JSON deserialization
                    //Console.WriteLine($"Deserialization error: {ex.Message}");
                    new Main.LogWriter("ERROR", $"Deserialization error: {ex.Message}");
                    MessageBox.Show($"Deserialization error: {ex.Message}", messageBoxTitle);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Connection failed: {ex.Message}");
                    new Main.LogWriter("ERROR", $"Connection failed: {ex.Message}");
                    //new LogWriter("ERROR", $"Connection failed: {ex}");
                    MessageBox.Show($"Connection failed: {ex.Message}", messageBoxTitle);
                }
            }
        }

        private void ButtonSaveSettings_Click(object sender, EventArgs e)
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
            string path = StreamerBotConfigFile;

            // Replace Windows-style line endings with Unix-style line endings
            json = json.Replace("\r\n", "\n");

            File.WriteAllText(path, json, Encoding.UTF8);
            /* 
            //Per a passar les dades al formulari principal
            _mainForm.StreamerBotConfig.ip = data.Connection.Ip;
            _mainForm.StreamerBotConfig.port = data.Connection.Port;
            _mainForm.StreamerBotConfig.protocol = data.Connection.Protocol;
            _mainForm.StreamerBotConfig.endpoint = data.Connection.Endpoint;
            */
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

        private void SBConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void testJobStartedEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string jobStartedDemoData = "{\"JobValues\":{\"CargoLoaded\":false,\"CargoValues\":{\"CargoDamage\":0.0,\"Id\":\"\",\"Mass\":0.0,\"Name\":\"\",\"UnitCount\":0,\"UnitMass\":0.0},\"CityDestination\":\"\",\"CityDestinationId\":\"\",\"CitySource\":\"\",\"CitySourceId\":\"\",\"CompanyDestination\":\"\",\"CompanyDestinationId\":\"\",\"CompanySource\":\"\",\"CompanySourceId\":\"\",\"DeliveryTime\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0},\"Income\":0,\"Market\":0,\"PlannedDistanceKm\":0,\"RemainingDeliveryTime\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0},\"SpecialJob\":false}}";
                string jobStartedDemoData = @"
                    {
                      ""JobValues"": {
                        ""DeliveryTime"": {
                          ""Value"": 0,
                          ""Date"": ""0001-01-01T00:00:00Z""
                        },
                        ""RemainingDeliveryTime"": {
                          ""Value"": 0,
                          ""Date"": ""0001-01-01T00:00:00Z""
                        },
                        ""CargoLoaded"": false,
                        ""SpecialJob"": false,
                        ""Market"": 1,
                        ""PlannedDistanceKm"": 0,
                        ""CargoValues"": {
                          ""Mass"": 0.0,
                          ""Id"": """",
                          ""Name"": """",
                          ""UnitCount"": 0,
                          ""UnitMass"": 0.0,
                          ""CargoDamage"": 0.0
                        },
                        ""CityDestinationId"": """",
                        ""CityDestination"": """",
                        ""CompanyDestinationId"": """",
                        ""CompanyDestination"": """",
                        ""CitySourceId"": """",
                        ""CitySource"": """",
                        ""CompanySourceId"": """",
                        ""CompanySource"": """",
                        ""Income"": 123
                      }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(jobStartedDemoData);
                Main.GamePlayEvents jobStarted = json;
                _mainForm.Started(JsonConvert.SerializeObject(jobStarted, Formatting.Indented), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testJobStartedEventCurrentValue_Click(object sender, EventArgs e)
        {
            _mainForm.Started(JsonConvert.SerializeObject(_mainForm.raw.JobValues, Formatting.Indented));
        }

        private void testJobDeliveredEventDemoData_Click(object sender, EventArgs e)
        {
            try 
            {
                //string jobDeliveredDemoData = "{\"JobDelivered\":{\"AutoLoaded\":false,\"AutoParked\":false,\"CargoDamage\":0.0,\"DeliveryTime\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0},\"DistanceKm\":0.0,\"EarnedXp\":0,\"Finished\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0},\"Revenue\":0,\"Started\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0},\"StartedBackup\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0}}}";
                string jobDeliveredDemoData = @"
                    {
                        ""JobDelivered"": {
                          ""AutoLoaded"": false,
                          ""AutoParked"": false,
                          ""CargoDamage"": 0.0,
                          ""DeliveryTime"": {
                            ""Value"": 0,
                            ""Date"": ""0001-01-01T00:00:00Z""
                          },
                          ""DistanceKm"": 0.0,
                          ""EarnedXp"": 0,
                          ""Revenue"": 0,
                          ""Finished"": {
                            ""Value"": 0,
                            ""Date"": ""0001-01-01T00:00:00Z""
                          },
                          ""Started"": {
                            ""Value"": 0,
                            ""Date"": ""0001-01-01T00:00:00Z""
                          },
                          ""StartedBackup"": {
                            ""Value"": 0,
                            ""Date"": ""0001-01-01T00:00:00Z""
                          }
                        }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(jobDeliveredDemoData);
                Main.GamePlayEvents jobDelivered = json;
                _mainForm.Delivered(JsonConvert.SerializeObject(jobDelivered, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testJobDeliveredEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Delivered(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.JobDelivered, Formatting.Indented));
            _mainForm.Delivered(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void testJobCancelledEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string jobCancelledDemoData = "{\"JobCancelled\":{\"Finished\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0},\"Penalty\":0,\"Started\":{\"Date\":\"0001-01-01T00:00:00Z\",\"Value\":0}}}";
                string jobCancelledDemoData = @"
                    {
                        ""JobCancelled"": {
                          ""Penalty"": 0,
                          ""Finished"": {
                            ""Value"": 0,
                            ""Date"": ""0001-01-01T00:00:00Z""
                          },
                          ""Started"": {
                            ""Value"": 0,
                            ""Date"": ""0001-01-01T00:00:00Z""
                          }
                        }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(jobCancelledDemoData);
                Main.GamePlayEvents jobCancelledEvents = json;
                /*
                Main.JobCancelled testJobCancelledEvent = new Main.JobCancelled();
                Main.GamePlayEvents testGamePlayEventsJobCancelled = new Main.GamePlayEvents();
                testGamePlayEventsJobCancelled.JobCancelled = testJobCancelledEvent;
                */
                _mainForm.Cancelled(JsonConvert.SerializeObject(jobCancelledEvents, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testJobCancelledEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Cancelled(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.JobCancelled, Formatting.Indented));
            _mainForm.Cancelled(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void testRefuelPayedEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string refuelPayedDemoData = "{\"RefuelEvent\":{\"Amount\":0.0}}";
                string refuelPayedDemoData = @"
                    {
                        ""RefuelEvent"": {
                            ""Amount"": 4.41064453
                        }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(refuelPayedDemoData);
                Main.GamePlayEvents refuelPayedEvents = json;
                /*
                //string refuelPayedDemoData = "";
                Main.RefuelEvent testRefuelPayedEvent = new Main.RefuelEvent();
                Main.GamePlayEvents testGamePlayEventsRefuelPayed = new Main.GamePlayEvents();
                testGamePlayEventsRefuelPayed.RefuelEvent = testRefuelPayedEvent;
                //_mainForm.Refuel(JsonConvert.SerializeObject(refuelPayedDemoData, Formatting.Indented));
                */
                _mainForm.Refuel(JsonConvert.SerializeObject(refuelPayedEvents, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testRefuelPayedEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Refuel(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.RefuelEvent, Formatting.Indented));
            _mainForm.Refuel(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void testFinedEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string finedDemoData = "{\"FinedEvent\":{\"Amount\":123.0,\"Offence\":1}}";
                string finedDemoData = @"
                    {
	                    ""FinedEvent"": {
		                    ""Amount"": 360,
		                    ""Offence"": 6
	                    }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(finedDemoData);
                //Main.TrainEvent trainEvent = new Main.TrainEvent { trainDemoData };
                //Main.GamePlayEvents trainEvents = new Main.GamePlayEvents();
                Main.GamePlayEvents finedEvents = json;
                //trainEvents.TrainEvent = trainEvent;
                _mainForm.Fined(JsonConvert.SerializeObject(finedEvents, Formatting.Indented));
                /*
                //string finedDemoData = "{\"Amount\":0,\"Offence\":0}";
                //Main.GamePlayEvents gpeFined = new FinedEvent(finedDemoData);
                //FinedEvent fe = new Main.FinedEvent();
                //FinedEvent feDd = new Main.FinedEvent((decimal)0.0, 0);
                Main.FinedEvent testFinedEvent = new Main.FinedEvent((decimal)123.0,1);
                Main.GamePlayEvents testGamePlayEventsFined = new Main.GamePlayEvents();
                testGamePlayEventsFined.FinedEvent = testFinedEvent;
                /*{
                    Amount = 0,
                    Offence = 0
                };* /
                //var myObject1 = JsonConvert.DeserializeObject<Main.GamePlayEvents>(JsonConvert.SerializeObject(finedEventObject));
                //_mainForm.Fined(JsonConvert.SerializeObject(finedEventObject, Formatting.Indented));
                _mainForm.Fined(JsonConvert.SerializeObject(testGamePlayEventsFined, Formatting.Indented));
                */
                /*
                string finedDemoData = "{\"GamePlay\":{\"FinedEvent\":{\"Amount\":0,\"Offence\":0}}}";
                var json = JsonConvert.SerializeObject(finedDemoData, Formatting.Indented);
                //Main.GamePlayEvents gpeFined = new FinedEvent(finedDemoData);
                //FinedEvent fe = new Main.FinedEvent();
                //FinedEvent feDd = new Main.FinedEvent((decimal)0.0, 0);
                //Main.FinedEvent testFinedEvent = new Main.FinedEvent((decimal)123.0,1);
                //var myObject1 = JsonConvert.DeserializeObject<Main.GamePlayEvents>(finedDemoData);
                var myObject1 = JsonConvert.DeserializeObject<Main.GamePlayEvents>(json);
                //Main.GamePlayEvents testGamePlayEventsFined = new Main.GamePlayEvents();
                //testGamePlayEventsFined.FinedEvent = testFinedEvent;
                /*{
                    Amount = 0,
                    Offence = 0
                };* /
                //var myObject1 = JsonConvert.DeserializeObject<Main.GamePlayEvents>(JsonConvert.SerializeObject(finedEventObject));
                //_mainForm.Fined(JsonConvert.SerializeObject(finedEventObject, Formatting.Indented));
                //_mainForm.Fined(JsonConvert.SerializeObject(testGamePlayEventsFined, Formatting.Indented));
                _mainForm.Fined(JsonConvert.SerializeObject(myObject1, Formatting.Indented));
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testFinedEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Fined(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.FinedEvent, Formatting.Indented));
            _mainForm.Fined(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void testTollgateEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string tollgateDemoData = "{\"TollgateEvent\":{\"PayAmount\":0}}";
                string tollgateDemoData = @"
                    {
                        ""TollgateEvent"": {
                              ""PayAmount"": 0
                        }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(tollgateDemoData);
                Main.GamePlayEvents tollgateEvents = json;
                _mainForm.Tollgate(JsonConvert.SerializeObject(tollgateEvents, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testTollgateEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Tollgate(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.TollgateEvent, Formatting.Indented));
            _mainForm.Tollgate(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void testTrainEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string trainDemoData = "{\"TrainEvent\":{\"PayAmount\":0,\"SourceId\":\"\",\"SourceName\":\"\",\"TargetId\":\"\",\"TargetName\":\"\"}}";
                string trainDemoData = @"
                    {
                        ""TrainEvent"": {
                              ""PayAmount"": 0,
                              ""SourceId"": """",
                              ""SourceName"": """",
                              ""TargetId"": """",
                              ""TargetName"": """"
                        }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(trainDemoData);
                //Main.TrainEvent trainEvent = new Main.TrainEvent { trainDemoData };
                //Main.GamePlayEvents trainEvents = new Main.GamePlayEvents();
                Main.GamePlayEvents trainEvents = json;
                //trainEvents.TrainEvent = trainEvent;
                _mainForm.Train(JsonConvert.SerializeObject(trainEvents, Formatting.Indented));
                    //MessageBox.Show(JsonConvert.SerializeObject(trainEvents, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testTrainEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Train(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.TrainEvent, Formatting.Indented));
            _mainForm.Train(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void testFerryEventDemoData_Click(object sender, EventArgs e)
        {
            try
            {
                //string ferryDemoData = "{\"FerryEvent\":{\"PayAmount\":0,\"SourceId\":\"\",\"SourceName\":\"\",\"TargetId\":\"\",\"TargetName\":\"\"}}";
                string ferryDemoData = @"
                    {
                        ""FerryEvent"": {
                              ""PayAmount"": 0,
                              ""SourceId"": """",
                              ""SourceName"": """",
                              ""TargetId"": """",
                              ""TargetName"": """"
                        }
                    }
                ";
                var json = JsonConvert.DeserializeObject<Main.GamePlayEvents>(ferryDemoData);
                Main.GamePlayEvents ferryEvents = json;
                _mainForm.Ferry(JsonConvert.SerializeObject(ferryEvents, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void testFerryEventCurrentValue_Click(object sender, EventArgs e)
        {
            //_mainForm.Ferry(JsonConvert.SerializeObject(_mainForm.raw.GamePlay.FerryEvent, Formatting.Indented));
            _mainForm.Ferry(JsonConvert.SerializeObject(_mainForm.raw.GamePlay, Formatting.Indented));
        }

        private void buttonTriggerActions_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(buttonTriggerActions, new Point(0, buttonTriggerActions.Height)); // Shows the menu strip below the button
        }

        private async void toolStripMenuItemRunAll_Click(object sender, EventArgs e)
        {
            var sleep = 2 * 1000;

            //_mainForm.TelemetryOnJobStarted(_mainForm.raw.JobValues, e);
            testJobStartedEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryJobDelivered(_mainForm.raw.GamePlay, e);
            testJobDeliveredEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryJobCancelled(_mainForm.raw.GamePlay, e);
            testJobCancelledEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryFined(_mainForm.raw.GamePlay, e);
            testFinedEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryTollgate(_mainForm.raw.GamePlay, e);
            testTollgateEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryTrain(_mainForm.raw.GamePlay, e);
            testTrainEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryFerry(_mainForm.raw.GamePlay, e);
            testFerryEventDemoData_Click(sender, e);
            await Task.Delay(sleep);
            //System.Threading.Thread.Sleep(sleep);

            //_mainForm.TelemetryRefuelPayed(_mainForm.raw.GamePlay, e);
            testRefuelPayedEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemJobStarted_Click(object sender, EventArgs e)
        {
            testJobStartedEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemJobDelivered_Click(object sender, EventArgs e)
        {
            testJobDeliveredEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemJobCancelled_Click(object sender, EventArgs e)
        {
            testJobCancelledEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemFinedEvent_Click(object sender, EventArgs e)
        {
            testFinedEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemTollgateEvent_Click(object sender, EventArgs e)
        {
            testTollgateEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemTrainEvent_Click(object sender, EventArgs e)
        {
            testTrainEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemFerryEvent_Click(object sender, EventArgs e)
        {
            testFerryEventDemoData_Click(sender, e);
        }

        private void toolStripMenuItemRefuelEvent_Click(object sender, EventArgs e)
        {
            testRefuelPayedEventDemoData_Click(sender, e);
        }
    }
}
