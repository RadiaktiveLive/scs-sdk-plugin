using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
using System.Windows.Forms;
using static SCSSdkClient.Demo.SCSSdkClientDemo;

namespace SCSSdkClient.Demo
{
    public partial class SBConfigForm : Form
    {
        private Main _mainForm;

        public StreamerBot StreamerBotConfig = new StreamerBot();

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
                    new LogWriter("INFO", "TcpClient Connection successful");



                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(testUrl.ToString());
                    //response.StatusCode == HttpStatusCode.NotFound
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(json);
                        new LogWriter("INFO", json);

                        if (json.Length > 0)
                        {

                            // Replace 'dynamic' with your object type if you have one
                            GetAction data = JsonConvert.DeserializeObject<GetAction>(json);

                            //MessageBox.Show(data["count"]);
                            new LogWriter("INFO", data.Count.ToString());

                            if (data.Count >= 0 && data.Actions.Count >= 0)
                            {
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
                        new LogWriter("ERROR", $"Error: {response.StatusCode}");
                        MessageBox.Show($"Error: {response.StatusCode}", messageBoxTitle);
                    }


                }
                catch (HttpRequestException ex)
                {
                    // Handle exception related to the HTTP request
                    //Console.WriteLine($"Request error: {ex.Message}");
                    new LogWriter("ERROR", $"Request error: {ex.Message}");
                    MessageBox.Show($"Request error: {ex.Message}", messageBoxTitle);
                }
                catch (JsonException ex)
                {
                    // Handle exception related to JSON deserialization
                    //Console.WriteLine($"Deserialization error: {ex.Message}");
                    new LogWriter("ERROR", $"Deserialization error: {ex.Message}");
                    MessageBox.Show($"Deserialization error: {ex.Message}", messageBoxTitle);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Connection failed: {ex.Message}");
                    new LogWriter("ERROR", $"Connection failed: {ex.Message}");
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

    }
}
