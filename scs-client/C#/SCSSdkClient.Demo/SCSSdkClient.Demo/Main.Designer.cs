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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SBConfig_btn = new System.Windows.Forms.Button();
            this.DebugTelemetry_btn = new System.Windows.Forms.Button();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.l_updateRate = new System.Windows.Forms.Label();
            this.lbGeneral = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSBConnected = new System.Windows.Forms.Label();
            this.ButtonTestConnection = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxEnableMessageBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Radiaktive - ETS/ATS Events to Streamer.Bot";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(124, 48);
            this.contextMenuStrip.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // maximizarToolStripMenuItem
            // 
            this.maximizarToolStripMenuItem.Name = "maximizarToolStripMenuItem";
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.maximizarToolStripMenuItem.Text = "Restaurar";
            this.maximizarToolStripMenuItem.Click += new System.EventHandler(this.restaurarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // lblSBConnected
            // 
            this.lblSBConnected.AutoSize = true;
            this.lblSBConnected.Location = new System.Drawing.Point(175, 160);
            this.lblSBConnected.Name = "lblSBConnected";
            this.lblSBConnected.Size = new System.Drawing.Size(96, 13);
            this.lblSBConnected.TabIndex = 6;
            this.lblSBConnected.Text = "SB Connection: ➖";
            // 
            // ButtonTestConnection
            // 
            this.ButtonTestConnection.Location = new System.Drawing.Point(12, 158);
            this.ButtonTestConnection.Name = "ButtonTestConnection";
            this.ButtonTestConnection.Size = new System.Drawing.Size(157, 23);
            this.ButtonTestConnection.TabIndex = 7;
            this.ButtonTestConnection.Text = "Test SB Connection";
            this.ButtonTestConnection.UseVisualStyleBackColor = true;
            this.ButtonTestConnection.Click += new System.EventHandler(this.ButtonTestConnection_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.linkStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 190);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(333, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(102, 17);
            this.statusLabel.Text = "© Radiaktive 2025";
            // 
            // linkStatusLabel
            // 
            this.linkStatusLabel.IsLink = true;
            this.linkStatusLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkStatusLabel.Name = "linkStatusLabel";
            this.linkStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.linkStatusLabel.Text = "toolStripStatusLabel1";
            this.linkStatusLabel.Visible = false;
            this.linkStatusLabel.Click += new System.EventHandler(this.linkStatusLabel_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBoxEnableMessageBox
            // 
            this.checkBoxEnableMessageBox.AutoSize = true;
            this.checkBoxEnableMessageBox.Location = new System.Drawing.Point(176, 177);
            this.checkBoxEnableMessageBox.Name = "checkBoxEnableMessageBox";
            this.checkBoxEnableMessageBox.Size = new System.Drawing.Size(129, 17);
            this.checkBoxEnableMessageBox.TabIndex = 10;
            this.checkBoxEnableMessageBox.Text = "Enable MessageBox?";
            this.checkBoxEnableMessageBox.UseVisualStyleBackColor = true;
            this.checkBoxEnableMessageBox.CheckedChanged += new System.EventHandler(this.checkBoxEnableMessageBox_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 212);
            this.Controls.Add(this.checkBoxEnableMessageBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonTestConnection);
            this.Controls.Add(this.lblSBConnected);
            this.Controls.Add(this.lbGeneral);
            this.Controls.Add(this.l_updateRate);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.DebugTelemetry_btn);
            this.Controls.Add(this.SBConfig_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(349, 251);
            this.Name = "Main";
            this.Text = "Radiaktive - ETS/ATS Events to Streamer.Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem maximizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label lblSBConnected;
        private System.Windows.Forms.Button ButtonTestConnection;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel linkStatusLabel;
        private System.Windows.Forms.CheckBox checkBoxEnableMessageBox;
    }
}