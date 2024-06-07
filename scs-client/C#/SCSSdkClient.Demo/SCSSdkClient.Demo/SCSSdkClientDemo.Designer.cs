using System.Drawing;

namespace SCSSdkClient.Demo
{
   partial class SCSSdkClientDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCSSdkClientDemo));
            this.hgf = new System.Windows.Forms.TabControl();
            this.tabAbout = new SCSSdkClient.Demo.CustomTabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.contextMenuStripTriggerActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripRunAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripJobStarted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripJobDelivered = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripJobCancelled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFinedEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTollgateEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTrainEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFerryEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripRefuelEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonTriggerActions = new System.Windows.Forms.Button();
            this.rtb_fuel = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.l_updateRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbGeneral = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblDemo = new System.Windows.Forms.Label();
            this.tabPage1 = new SCSSdkClient.Demo.CustomTabPage();
            this.common = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.truck = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.trailer = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.job = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.control = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.navigation = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.substances = new System.Windows.Forms.RichTextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.gameplayevent = new System.Windows.Forms.RichTextBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.hgf.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenuStripTriggerActions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // hgf
            // 
            this.hgf.Controls.Add(this.tabAbout);
            this.hgf.Controls.Add(this.tabPage1);
            this.hgf.Controls.Add(this.tabPage2);
            this.hgf.Controls.Add(this.tabPage3);
            this.hgf.Controls.Add(this.tabPage4);
            this.hgf.Controls.Add(this.tabPage5);
            this.hgf.Controls.Add(this.tabPage6);
            this.hgf.Controls.Add(this.tabPage7);
            this.hgf.Controls.Add(this.tabPage8);
            this.hgf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hgf.Location = new System.Drawing.Point(0, 0);
            this.hgf.Margin = new System.Windows.Forms.Padding(6);
            this.hgf.Name = "hgf";
            this.hgf.SelectedIndex = 0;
            this.hgf.Size = new System.Drawing.Size(1190, 1194);
            this.hgf.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.toolStrip);
            this.tabAbout.Controls.Add(this.buttonTriggerActions);
            this.tabAbout.Controls.Add(this.rtb_fuel);
            this.tabAbout.Controls.Add(this.statusStrip1);
            this.tabAbout.Controls.Add(this.lbGeneral);
            this.tabAbout.Controls.Add(this.richTextBox1);
            this.tabAbout.Controls.Add(this.lblDemo);
            this.tabAbout.Location = new System.Drawing.Point(8, 39);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(6);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(6);
            this.tabAbout.Size = new System.Drawing.Size(1174, 1147);
            this.tabAbout.TabIndex = 0;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.ContextMenuStrip = this.contextMenuStripTriggerActions;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton});
            this.toolStrip.Location = new System.Drawing.Point(611, 38);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(302, 42);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // contextMenuStripTriggerActions
            // 
            this.contextMenuStripTriggerActions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripTriggerActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRunAll,
            this.toolStripSeparator,
            this.toolStripJobStarted,
            this.toolStripJobDelivered,
            this.toolStripJobCancelled,
            this.toolStripFinedEvent,
            this.toolStripTollgateEvent,
            this.toolStripTrainEvent,
            this.toolStripFerryEvent,
            this.toolStripRefuelEvent});
            this.contextMenuStripTriggerActions.Name = "contextMenuStripTriggerActions";
            this.contextMenuStripTriggerActions.OwnerItem = this.toolStripDropDownButton1;
            this.contextMenuStripTriggerActions.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.contextMenuStripTriggerActions.Size = new System.Drawing.Size(232, 352);
            // 
            // toolStripRunAll
            // 
            this.toolStripRunAll.Name = "toolStripRunAll";
            this.toolStripRunAll.Size = new System.Drawing.Size(231, 38);
            this.toolStripRunAll.Text = "Run all";
            this.toolStripRunAll.Click += new System.EventHandler(this.toolStripRunAll_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(228, 6);
            // 
            // toolStripJobStarted
            // 
            this.toolStripJobStarted.Name = "toolStripJobStarted";
            this.toolStripJobStarted.Size = new System.Drawing.Size(231, 38);
            this.toolStripJobStarted.Text = "JobStarted";
            this.toolStripJobStarted.Click += new System.EventHandler(this.toolStripJobStarted_Click);
            // 
            // toolStripJobDelivered
            // 
            this.toolStripJobDelivered.Name = "toolStripJobDelivered";
            this.toolStripJobDelivered.Size = new System.Drawing.Size(231, 38);
            this.toolStripJobDelivered.Text = "JobDelivered";
            this.toolStripJobDelivered.Click += new System.EventHandler(this.toolStripJobDelivered_Click);
            // 
            // toolStripJobCancelled
            // 
            this.toolStripJobCancelled.Name = "toolStripJobCancelled";
            this.toolStripJobCancelled.Size = new System.Drawing.Size(231, 38);
            this.toolStripJobCancelled.Text = "JobCancelled";
            this.toolStripJobCancelled.Click += new System.EventHandler(this.toolStripJobCancelled_Click);
            // 
            // toolStripFinedEvent
            // 
            this.toolStripFinedEvent.Name = "toolStripFinedEvent";
            this.toolStripFinedEvent.Size = new System.Drawing.Size(231, 38);
            this.toolStripFinedEvent.Text = "FinedEvent";
            this.toolStripFinedEvent.Click += new System.EventHandler(this.toolStripFinedEvent_Click);
            // 
            // toolStripTollgateEvent
            // 
            this.toolStripTollgateEvent.Name = "toolStripTollgateEvent";
            this.toolStripTollgateEvent.Size = new System.Drawing.Size(231, 38);
            this.toolStripTollgateEvent.Text = "TollgateEvent";
            this.toolStripTollgateEvent.Click += new System.EventHandler(this.toolStripTollgateEvent_Click);
            // 
            // toolStripTrainEvent
            // 
            this.toolStripTrainEvent.Name = "toolStripTrainEvent";
            this.toolStripTrainEvent.Size = new System.Drawing.Size(231, 38);
            this.toolStripTrainEvent.Text = "TrainEvent";
            this.toolStripTrainEvent.Click += new System.EventHandler(this.toolStripTrainEvent_Click);
            // 
            // toolStripFerryEvent
            // 
            this.toolStripFerryEvent.Name = "toolStripFerryEvent";
            this.toolStripFerryEvent.Size = new System.Drawing.Size(231, 38);
            this.toolStripFerryEvent.Text = "FerryEvent";
            this.toolStripFerryEvent.Click += new System.EventHandler(this.toolStripFerryEvent_Click);
            // 
            // toolStripRefuelEvent
            // 
            this.toolStripRefuelEvent.Name = "toolStripRefuelEvent";
            this.toolStripRefuelEvent.Size = new System.Drawing.Size(231, 38);
            this.toolStripRefuelEvent.Text = "RefuelEvent";
            this.toolStripRefuelEvent.Click += new System.EventHandler(this.toolStripRefuelEvent_Click);
            // 
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton.DropDown = this.contextMenuStripTriggerActions;
            this.toolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton.Image")));
            this.toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            this.toolStripDropDownButton.Size = new System.Drawing.Size(236, 36);
            this.toolStripDropDownButton.Text = "Trigger SB Actions!";
            // 
            // buttonTriggerActions
            // 
            this.buttonTriggerActions.ContextMenuStrip = this.contextMenuStripTriggerActions;
            this.buttonTriggerActions.Location = new System.Drawing.Point(916, 34);
            this.buttonTriggerActions.Name = "buttonTriggerActions";
            this.buttonTriggerActions.Size = new System.Drawing.Size(240, 52);
            this.buttonTriggerActions.TabIndex = 5;
            this.buttonTriggerActions.Text = "Trigger SB Actions!";
            this.buttonTriggerActions.UseVisualStyleBackColor = true;
            this.buttonTriggerActions.Click += new System.EventHandler(this.buttonTriggerActions_Click);
            // 
            // rtb_fuel
            // 
            this.rtb_fuel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_fuel.Location = new System.Drawing.Point(40, 985);
            this.rtb_fuel.Margin = new System.Windows.Forms.Padding(6);
            this.rtb_fuel.Name = "rtb_fuel";
            this.rtb_fuel.Size = new System.Drawing.Size(1094, 66);
            this.rtb_fuel.TabIndex = 4;
            this.rtb_fuel.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.l_updateRate});
            this.statusStrip1.Location = new System.Drawing.Point(6, 1099);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1162, 42);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(229, 32);
            this.toolStripStatusLabel1.Text = "Current update rate:";
            // 
            // l_updateRate
            // 
            this.l_updateRate.Name = "l_updateRate";
            this.l_updateRate.Size = new System.Drawing.Size(0, 32);
            // 
            // lbGeneral
            // 
            this.lbGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGeneral.Location = new System.Drawing.Point(40, 404);
            this.lbGeneral.Margin = new System.Windows.Forms.Padding(6);
            this.lbGeneral.Name = "lbGeneral";
            this.lbGeneral.Size = new System.Drawing.Size(1094, 564);
            this.lbGeneral.TabIndex = 2;
            this.lbGeneral.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(40, 117);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1094, 231);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // lblDemo
            // 
            this.lblDemo.AutoSize = true;
            this.lblDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemo.Location = new System.Drawing.Point(12, 38);
            this.lblDemo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDemo.Name = "lblDemo";
            this.lblDemo.Size = new System.Drawing.Size(850, 48);
            this.lblDemo.TabIndex = 0;
            this.lblDemo.Text = "ETS2 SDK Telemetry C# Demo Radiaktive";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.common);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Common";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // common
            // 
            this.common.Dock = System.Windows.Forms.DockStyle.Fill;
            this.common.Location = new System.Drawing.Point(6, 6);
            this.common.Margin = new System.Windows.Forms.Padding(6);
            this.common.Name = "common";
            this.common.Size = new System.Drawing.Size(1162, 1135);
            this.common.TabIndex = 3;
            this.common.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.truck);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage2.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Truck";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // truck
            // 
            this.truck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.truck.Location = new System.Drawing.Point(6, 6);
            this.truck.Margin = new System.Windows.Forms.Padding(6);
            this.truck.Name = "truck";
            this.truck.Size = new System.Drawing.Size(1162, 1135);
            this.truck.TabIndex = 4;
            this.truck.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.trailer);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage3.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Trailer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // trailer
            // 
            this.trailer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trailer.Location = new System.Drawing.Point(6, 6);
            this.trailer.Margin = new System.Windows.Forms.Padding(6);
            this.trailer.Name = "trailer";
            this.trailer.Size = new System.Drawing.Size(1162, 1135);
            this.trailer.TabIndex = 4;
            this.trailer.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.job);
            this.tabPage4.Location = new System.Drawing.Point(8, 39);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage4.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Job";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // job
            // 
            this.job.Dock = System.Windows.Forms.DockStyle.Fill;
            this.job.Location = new System.Drawing.Point(6, 6);
            this.job.Margin = new System.Windows.Forms.Padding(6);
            this.job.Name = "job";
            this.job.Size = new System.Drawing.Size(1162, 1135);
            this.job.TabIndex = 4;
            this.job.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.control);
            this.tabPage5.Location = new System.Drawing.Point(8, 39);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage5.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Control";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // control
            // 
            this.control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control.Location = new System.Drawing.Point(6, 6);
            this.control.Margin = new System.Windows.Forms.Padding(6);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(1162, 1135);
            this.control.TabIndex = 4;
            this.control.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.navigation);
            this.tabPage6.Location = new System.Drawing.Point(8, 39);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage6.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Navigation";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // navigation
            // 
            this.navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigation.Location = new System.Drawing.Point(6, 6);
            this.navigation.Margin = new System.Windows.Forms.Padding(6);
            this.navigation.Name = "navigation";
            this.navigation.Size = new System.Drawing.Size(1162, 1135);
            this.navigation.TabIndex = 4;
            this.navigation.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.substances);
            this.tabPage7.Location = new System.Drawing.Point(8, 39);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage7.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Substances";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // substances
            // 
            this.substances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.substances.Location = new System.Drawing.Point(6, 6);
            this.substances.Margin = new System.Windows.Forms.Padding(6);
            this.substances.Name = "substances";
            this.substances.Size = new System.Drawing.Size(1162, 1135);
            this.substances.TabIndex = 5;
            this.substances.Text = "";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.gameplayevent);
            this.tabPage8.Location = new System.Drawing.Point(8, 39);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage8.Size = new System.Drawing.Size(1174, 1147);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "GameplayEvents";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // gameplayevent
            // 
            this.gameplayevent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameplayevent.Location = new System.Drawing.Point(6, 6);
            this.gameplayevent.Margin = new System.Windows.Forms.Padding(6);
            this.gameplayevent.Name = "gameplayevent";
            this.gameplayevent.Size = new System.Drawing.Size(1162, 1135);
            this.gameplayevent.TabIndex = 6;
            this.gameplayevent.Text = "";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDown = this.contextMenuStripTriggerActions;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(236, 36);
            this.toolStripDropDownButton1.Text = "Trigger SB Actions!";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(23, 23);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton8.Text = "toolStripButton8";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton9.Text = "toolStripButton9";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton10.Text = "toolStripButton10";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 23);
            this.toolStripButton11.Text = "toolStripButton11";
            // 
            // SCSSdkClientDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 1194);
            this.Controls.Add(this.hgf);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SCSSdkClientDemo";
            this.Text = "SCSSDkClientDemo 0.9 Radiaktive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SCSSdkClientDemo_FormClosing);
            this.hgf.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStripTriggerActions.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabPage tabAbout;
        private System.Windows.Forms.RichTextBox lbGeneral;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblDemo;
        private System.Windows.Forms.TabControl hgf;
        private CustomTabPage tabPage1;
        private System.Windows.Forms.RichTextBox common;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox truck;
        private System.Windows.Forms.RichTextBox trailer;
        private System.Windows.Forms.RichTextBox job;
        private System.Windows.Forms.RichTextBox control;
        private System.Windows.Forms.RichTextBox navigation;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.RichTextBox substances;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.RichTextBox gameplayevent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel l_updateRate;
        private System.Windows.Forms.RichTextBox rtb_fuel;
        private System.Windows.Forms.Button buttonTriggerActions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTriggerActions;
        private System.Windows.Forms.ToolStripMenuItem toolStripRunAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripJobStarted;
        private System.Windows.Forms.ToolStripMenuItem toolStripJobCancelled;
        private System.Windows.Forms.ToolStripMenuItem toolStripFinedEvent;
        private System.Windows.Forms.ToolStripMenuItem toolStripTollgateEvent;
        private System.Windows.Forms.ToolStripMenuItem toolStripTrainEvent;
        private System.Windows.Forms.ToolStripMenuItem toolStripFerryEvent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripRefuelEvent;
        private System.Windows.Forms.ToolStripMenuItem toolStripJobDelivered;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton;
    }
}

