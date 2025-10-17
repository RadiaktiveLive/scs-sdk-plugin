namespace SCSSdkClient.Demo
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SBConfig_btn = new System.Windows.Forms.Button();
            this.DebugTelemetry_btn = new System.Windows.Forms.Button();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.l_updateRate = new System.Windows.Forms.Label();
            this.lbGeneral = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SBConfig_btn
            // 
            this.SBConfig_btn.Location = new System.Drawing.Point(12, 12);
            this.SBConfig_btn.Name = "SBConfig_btn";
            this.SBConfig_btn.Size = new System.Drawing.Size(151, 82);
            this.SBConfig_btn.TabIndex = 0;
            this.SBConfig_btn.Text = "Streamer.Bot configuration";
            this.SBConfig_btn.UseVisualStyleBackColor = true;
            this.SBConfig_btn.Click += new System.EventHandler(this.SBConfig_btn_Click);
            // 
            // DebugTelemetry_btn
            // 
            this.DebugTelemetry_btn.Enabled = false;
            this.DebugTelemetry_btn.Location = new System.Drawing.Point(169, 12);
            this.DebugTelemetry_btn.Name = "DebugTelemetry_btn";
            this.DebugTelemetry_btn.Size = new System.Drawing.Size(151, 82);
            this.DebugTelemetry_btn.TabIndex = 1;
            this.DebugTelemetry_btn.Text = "Debug Telemetry";
            this.DebugTelemetry_btn.UseVisualStyleBackColor = true;
            this.DebugTelemetry_btn.Click += new System.EventHandler(this.DebugTelemetry_btn_Click);
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(12, 105);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(157, 20);
            this.textBoxIp.TabIndex = 2;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(12, 131);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(157, 20);
            this.textBoxPort.TabIndex = 3;
            // 
            // l_updateRate
            // 
            this.l_updateRate.AutoSize = true;
            this.l_updateRate.Location = new System.Drawing.Point(175, 138);
            this.l_updateRate.Name = "l_updateRate";
            this.l_updateRate.Size = new System.Drawing.Size(104, 13);
            this.l_updateRate.TabIndex = 4;
            this.l_updateRate.Text = "Current update rate: ";
            // 
            // lbGeneral
            // 
            this.lbGeneral.AutoSize = true;
            this.lbGeneral.Location = new System.Drawing.Point(175, 112);
            this.lbGeneral.Name = "lbGeneral";
            this.lbGeneral.Size = new System.Drawing.Size(95, 13);
            this.lbGeneral.TabIndex = 5;
            this.lbGeneral.Text = "Game connected: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 166);
            this.Controls.Add(this.lbGeneral);
            this.Controls.Add(this.l_updateRate);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.DebugTelemetry_btn);
            this.Controls.Add(this.SBConfig_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(349, 205);
            this.Name = "Main";
            this.Text = "Radiaktive - ETS/ATS Events to Streamer.Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SBConfig_btn;
        private System.Windows.Forms.Button DebugTelemetry_btn;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label l_updateRate;
        private System.Windows.Forms.Label lbGeneral;
    }
}