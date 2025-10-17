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
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.hgf = new System.Windows.Forms.TabControl();
            this.tabAbout = new SCSSdkClient.Demo.CustomTabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
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
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelJobStarted = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.jobstarted = new System.Windows.Forms.RichTextBox();
            this.panelFined = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.finedevent = new System.Windows.Forms.RichTextBox();
            this.panelJobDelivered = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.jobdelivered = new System.Windows.Forms.RichTextBox();
            this.panelJobCancelled = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.jobcanceled = new System.Windows.Forms.RichTextBox();
            this.panelTollgate = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tollgateevent = new System.Windows.Forms.RichTextBox();
            this.panelTrain = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.trainevent = new System.Windows.Forms.RichTextBox();
            this.panelFerry = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.ferryevent = new System.Windows.Forms.RichTextBox();
            this.panelRefuel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.refuelevent = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripTriggerActions.SuspendLayout();
            this.hgf.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelJobStarted.SuspendLayout();
            this.panelFined.SuspendLayout();
            this.panelJobDelivered.SuspendLayout();
            this.panelJobCancelled.SuspendLayout();
            this.panelTollgate.SuspendLayout();
            this.panelTrain.SuspendLayout();
            this.panelFerry.SuspendLayout();
            this.panelRefuel.SuspendLayout();
            this.SuspendLayout();
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
            this.contextMenuStripTriggerActions.Size = new System.Drawing.Size(145, 208);
            // 
            // toolStripRunAll
            // 
            this.toolStripRunAll.Name = "toolStripRunAll";
            this.toolStripRunAll.Size = new System.Drawing.Size(144, 22);
            this.toolStripRunAll.Text = "Run all";
            this.toolStripRunAll.Click += new System.EventHandler(this.toolStripRunAll_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripJobStarted
            // 
            this.toolStripJobStarted.Name = "toolStripJobStarted";
            this.toolStripJobStarted.Size = new System.Drawing.Size(144, 22);
            this.toolStripJobStarted.Text = "JobStarted";
            this.toolStripJobStarted.Click += new System.EventHandler(this.toolStripJobStarted_Click);
            // 
            // toolStripJobDelivered
            // 
            this.toolStripJobDelivered.Name = "toolStripJobDelivered";
            this.toolStripJobDelivered.Size = new System.Drawing.Size(144, 22);
            this.toolStripJobDelivered.Text = "JobDelivered";
            this.toolStripJobDelivered.Click += new System.EventHandler(this.toolStripJobDelivered_Click);
            // 
            // toolStripJobCancelled
            // 
            this.toolStripJobCancelled.Name = "toolStripJobCancelled";
            this.toolStripJobCancelled.Size = new System.Drawing.Size(144, 22);
            this.toolStripJobCancelled.Text = "JobCancelled";
            this.toolStripJobCancelled.Click += new System.EventHandler(this.toolStripJobCancelled_Click);
            // 
            // toolStripFinedEvent
            // 
            this.toolStripFinedEvent.Name = "toolStripFinedEvent";
            this.toolStripFinedEvent.Size = new System.Drawing.Size(144, 22);
            this.toolStripFinedEvent.Text = "FinedEvent";
            this.toolStripFinedEvent.Click += new System.EventHandler(this.toolStripFinedEvent_Click);
            // 
            // toolStripTollgateEvent
            // 
            this.toolStripTollgateEvent.Name = "toolStripTollgateEvent";
            this.toolStripTollgateEvent.Size = new System.Drawing.Size(144, 22);
            this.toolStripTollgateEvent.Text = "TollgateEvent";
            this.toolStripTollgateEvent.Click += new System.EventHandler(this.toolStripTollgateEvent_Click);
            // 
            // toolStripTrainEvent
            // 
            this.toolStripTrainEvent.Name = "toolStripTrainEvent";
            this.toolStripTrainEvent.Size = new System.Drawing.Size(144, 22);
            this.toolStripTrainEvent.Text = "TrainEvent";
            this.toolStripTrainEvent.Click += new System.EventHandler(this.toolStripTrainEvent_Click);
            // 
            // toolStripFerryEvent
            // 
            this.toolStripFerryEvent.Name = "toolStripFerryEvent";
            this.toolStripFerryEvent.Size = new System.Drawing.Size(144, 22);
            this.toolStripFerryEvent.Text = "FerryEvent";
            this.toolStripFerryEvent.Click += new System.EventHandler(this.toolStripFerryEvent_Click);
            // 
            // toolStripRefuelEvent
            // 
            this.toolStripRefuelEvent.Name = "toolStripRefuelEvent";
            this.toolStripRefuelEvent.Size = new System.Drawing.Size(144, 22);
            this.toolStripRefuelEvent.Text = "RefuelEvent";
            this.toolStripRefuelEvent.Click += new System.EventHandler(this.toolStripRefuelEvent_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDown = this.contextMenuStripTriggerActions;
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(118, 22);
            this.toolStripDropDownButton3.Text = "Trigger SB Actions!";
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
            this.hgf.Controls.Add(this.tabPage9);
            this.hgf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hgf.Location = new System.Drawing.Point(0, 0);
            this.hgf.Name = "hgf";
            this.hgf.SelectedIndex = 0;
            this.hgf.Size = new System.Drawing.Size(619, 697);
            this.hgf.TabIndex = 0;
            this.hgf.SelectedIndexChanged += new System.EventHandler(this.hgf_SelectedIndexChanged);
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
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(611, 671);
            this.tabAbout.TabIndex = 0;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            this.tabAbout.Click += new System.EventHandler(this.tabAbout_Click);
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
            this.toolStrip.Location = new System.Drawing.Point(305, 20);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.ShowItemToolTips = false;
            this.toolStrip.Size = new System.Drawing.Size(151, 25);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton.DropDown = this.contextMenuStripTriggerActions;
            this.toolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton.Image")));
            this.toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            this.toolStripDropDownButton.Size = new System.Drawing.Size(118, 22);
            this.toolStripDropDownButton.Text = "Trigger SB Actions!";
            this.toolStripDropDownButton.Click += new System.EventHandler(this.toolStripDropDownButton_Click);
            // 
            // buttonTriggerActions
            // 
            this.buttonTriggerActions.ContextMenuStrip = this.contextMenuStripTriggerActions;
            this.buttonTriggerActions.Location = new System.Drawing.Point(458, 18);
            this.buttonTriggerActions.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTriggerActions.Name = "buttonTriggerActions";
            this.buttonTriggerActions.Size = new System.Drawing.Size(120, 27);
            this.buttonTriggerActions.TabIndex = 5;
            this.buttonTriggerActions.Text = "Trigger SB Actions!";
            this.buttonTriggerActions.UseVisualStyleBackColor = true;
            this.buttonTriggerActions.Click += new System.EventHandler(this.buttonTriggerActions_Click);
            // 
            // rtb_fuel
            // 
            this.rtb_fuel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_fuel.Location = new System.Drawing.Point(20, 866);
            this.rtb_fuel.Name = "rtb_fuel";
            this.rtb_fuel.Size = new System.Drawing.Size(549, 36);
            this.rtb_fuel.TabIndex = 4;
            this.rtb_fuel.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.l_updateRate});
            this.statusStrip1.Location = new System.Drawing.Point(3, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel1.Text = "Current update rate:";
            // 
            // l_updateRate
            // 
            this.l_updateRate.Name = "l_updateRate";
            this.l_updateRate.Size = new System.Drawing.Size(0, 17);
            // 
            // lbGeneral
            // 
            this.lbGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGeneral.Location = new System.Drawing.Point(20, 210);
            this.lbGeneral.Name = "lbGeneral";
            this.lbGeneral.Size = new System.Drawing.Size(549, 649);
            this.lbGeneral.TabIndex = 2;
            this.lbGeneral.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(20, 61);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(549, 122);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // lblDemo
            // 
            this.lblDemo.AutoSize = true;
            this.lblDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemo.Location = new System.Drawing.Point(6, 20);
            this.lblDemo.Name = "lblDemo";
            this.lblDemo.Size = new System.Drawing.Size(454, 25);
            this.lblDemo.TabIndex = 0;
            this.lblDemo.Text = "ETS2 SDK Telemetry C# Demo Radiaktive";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.common);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(611, 671);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Common";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // common
            // 
            this.common.Dock = System.Windows.Forms.DockStyle.Fill;
            this.common.Location = new System.Drawing.Point(3, 3);
            this.common.Name = "common";
            this.common.Size = new System.Drawing.Size(605, 665);
            this.common.TabIndex = 3;
            this.common.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.truck);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(611, 671);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Truck";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // truck
            // 
            this.truck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.truck.Location = new System.Drawing.Point(3, 3);
            this.truck.Name = "truck";
            this.truck.Size = new System.Drawing.Size(605, 665);
            this.truck.TabIndex = 4;
            this.truck.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.trailer);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(611, 671);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Trailer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // trailer
            // 
            this.trailer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trailer.Location = new System.Drawing.Point(3, 3);
            this.trailer.Name = "trailer";
            this.trailer.Size = new System.Drawing.Size(605, 665);
            this.trailer.TabIndex = 4;
            this.trailer.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.job);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(611, 671);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Job";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // job
            // 
            this.job.Dock = System.Windows.Forms.DockStyle.Fill;
            this.job.Location = new System.Drawing.Point(3, 3);
            this.job.Name = "job";
            this.job.Size = new System.Drawing.Size(605, 665);
            this.job.TabIndex = 4;
            this.job.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.control);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(611, 671);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Control";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // control
            // 
            this.control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control.Location = new System.Drawing.Point(3, 3);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(605, 665);
            this.control.TabIndex = 4;
            this.control.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.navigation);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(611, 671);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Navigation";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // navigation
            // 
            this.navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigation.Location = new System.Drawing.Point(3, 3);
            this.navigation.Name = "navigation";
            this.navigation.Size = new System.Drawing.Size(605, 665);
            this.navigation.TabIndex = 4;
            this.navigation.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.substances);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(611, 671);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Substances";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // substances
            // 
            this.substances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.substances.Location = new System.Drawing.Point(3, 3);
            this.substances.Name = "substances";
            this.substances.Size = new System.Drawing.Size(605, 665);
            this.substances.TabIndex = 5;
            this.substances.Text = "";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.gameplayevent);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(611, 671);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "GameplayEvents";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // gameplayevent
            // 
            this.gameplayevent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameplayevent.Location = new System.Drawing.Point(3, 3);
            this.gameplayevent.Name = "gameplayevent";
            this.gameplayevent.Size = new System.Drawing.Size(605, 665);
            this.gameplayevent.TabIndex = 6;
            this.gameplayevent.Text = "";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.toolStrip1);
            this.tabPage9.Controls.Add(this.panelJobStarted);
            this.tabPage9.Controls.Add(this.panelFined);
            this.tabPage9.Controls.Add(this.panelJobDelivered);
            this.tabPage9.Controls.Add(this.panelJobCancelled);
            this.tabPage9.Controls.Add(this.panelTollgate);
            this.tabPage9.Controls.Add(this.panelTrain);
            this.tabPage9.Controls.Add(this.panelFerry);
            this.tabPage9.Controls.Add(this.panelRefuel);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage9.Size = new System.Drawing.Size(611, 671);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Text = "Events";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.ContextMenuStrip = this.contextMenuStripTriggerActions;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(362, 743);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(120, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panelJobStarted
            // 
            this.panelJobStarted.AutoSize = true;
            this.panelJobStarted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelJobStarted.Controls.Add(this.label14);
            this.panelJobStarted.Controls.Add(this.jobstarted);
            this.panelJobStarted.Location = new System.Drawing.Point(3, 3);
            this.panelJobStarted.Margin = new System.Windows.Forms.Padding(2);
            this.panelJobStarted.Name = "panelJobStarted";
            this.panelJobStarted.Padding = new System.Windows.Forms.Padding(8);
            this.panelJobStarted.Size = new System.Drawing.Size(301, 448);
            this.panelJobStarted.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 8);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "JobStarted";
            // 
            // jobstarted
            // 
            this.jobstarted.Location = new System.Drawing.Point(8, 25);
            this.jobstarted.Margin = new System.Windows.Forms.Padding(2);
            this.jobstarted.Name = "jobstarted";
            this.jobstarted.Size = new System.Drawing.Size(283, 413);
            this.jobstarted.TabIndex = 16;
            this.jobstarted.Text = "";
            // 
            // panelFined
            // 
            this.panelFined.AutoSize = true;
            this.panelFined.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFined.Controls.Add(this.label11);
            this.panelFined.Controls.Add(this.finedevent);
            this.panelFined.Location = new System.Drawing.Point(308, 551);
            this.panelFined.Margin = new System.Windows.Forms.Padding(2);
            this.panelFined.Name = "panelFined";
            this.panelFined.Padding = new System.Windows.Forms.Padding(8);
            this.panelFined.Size = new System.Drawing.Size(301, 95);
            this.panelFined.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "FinedEvent";
            // 
            // finedevent
            // 
            this.finedevent.Location = new System.Drawing.Point(8, 24);
            this.finedevent.Margin = new System.Windows.Forms.Padding(2);
            this.finedevent.Name = "finedevent";
            this.finedevent.Size = new System.Drawing.Size(283, 61);
            this.finedevent.TabIndex = 16;
            this.finedevent.Text = "";
            // 
            // panelJobDelivered
            // 
            this.panelJobDelivered.AutoSize = true;
            this.panelJobDelivered.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelJobDelivered.Controls.Add(this.label13);
            this.panelJobDelivered.Controls.Add(this.jobdelivered);
            this.panelJobDelivered.Location = new System.Drawing.Point(308, 3);
            this.panelJobDelivered.Margin = new System.Windows.Forms.Padding(2);
            this.panelJobDelivered.Name = "panelJobDelivered";
            this.panelJobDelivered.Padding = new System.Windows.Forms.Padding(8);
            this.panelJobDelivered.Size = new System.Drawing.Size(301, 357);
            this.panelJobDelivered.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 8);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "JobDelivered";
            // 
            // jobdelivered
            // 
            this.jobdelivered.Location = new System.Drawing.Point(8, 25);
            this.jobdelivered.Margin = new System.Windows.Forms.Padding(2);
            this.jobdelivered.Name = "jobdelivered";
            this.jobdelivered.Size = new System.Drawing.Size(283, 322);
            this.jobdelivered.TabIndex = 16;
            this.jobdelivered.Text = "";
            // 
            // panelJobCancelled
            // 
            this.panelJobCancelled.AutoSize = true;
            this.panelJobCancelled.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelJobCancelled.Controls.Add(this.label12);
            this.panelJobCancelled.Controls.Add(this.jobcanceled);
            this.panelJobCancelled.Location = new System.Drawing.Point(308, 361);
            this.panelJobCancelled.Margin = new System.Windows.Forms.Padding(2);
            this.panelJobCancelled.Name = "panelJobCancelled";
            this.panelJobCancelled.Padding = new System.Windows.Forms.Padding(8);
            this.panelJobCancelled.Size = new System.Drawing.Size(301, 188);
            this.panelJobCancelled.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "JobCancelled";
            // 
            // jobcanceled
            // 
            this.jobcanceled.Location = new System.Drawing.Point(8, 25);
            this.jobcanceled.Margin = new System.Windows.Forms.Padding(2);
            this.jobcanceled.Name = "jobcanceled";
            this.jobcanceled.Size = new System.Drawing.Size(283, 153);
            this.jobcanceled.TabIndex = 16;
            this.jobcanceled.Text = "";
            // 
            // panelTollgate
            // 
            this.panelTollgate.AutoSize = true;
            this.panelTollgate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTollgate.Controls.Add(this.label10);
            this.panelTollgate.Controls.Add(this.tollgateevent);
            this.panelTollgate.Location = new System.Drawing.Point(308, 647);
            this.panelTollgate.Margin = new System.Windows.Forms.Padding(2);
            this.panelTollgate.Name = "panelTollgate";
            this.panelTollgate.Padding = new System.Windows.Forms.Padding(8);
            this.panelTollgate.Size = new System.Drawing.Size(301, 81);
            this.panelTollgate.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "TollgateEvent";
            // 
            // tollgateevent
            // 
            this.tollgateevent.Location = new System.Drawing.Point(8, 23);
            this.tollgateevent.Margin = new System.Windows.Forms.Padding(2);
            this.tollgateevent.Name = "tollgateevent";
            this.tollgateevent.Size = new System.Drawing.Size(283, 48);
            this.tollgateevent.TabIndex = 16;
            this.tollgateevent.Text = "";
            // 
            // panelTrain
            // 
            this.panelTrain.AutoSize = true;
            this.panelTrain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTrain.Controls.Add(this.label8);
            this.panelTrain.Controls.Add(this.trainevent);
            this.panelTrain.Location = new System.Drawing.Point(3, 452);
            this.panelTrain.Margin = new System.Windows.Forms.Padding(2);
            this.panelTrain.Name = "panelTrain";
            this.panelTrain.Padding = new System.Windows.Forms.Padding(8);
            this.panelTrain.Size = new System.Drawing.Size(301, 133);
            this.panelTrain.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "TrainEvent";
            // 
            // trainevent
            // 
            this.trainevent.Location = new System.Drawing.Point(8, 23);
            this.trainevent.Margin = new System.Windows.Forms.Padding(2);
            this.trainevent.Name = "trainevent";
            this.trainevent.Size = new System.Drawing.Size(283, 100);
            this.trainevent.TabIndex = 16;
            this.trainevent.Text = "";
            // 
            // panelFerry
            // 
            this.panelFerry.AutoSize = true;
            this.panelFerry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFerry.Controls.Add(this.label9);
            this.panelFerry.Controls.Add(this.ferryevent);
            this.panelFerry.Location = new System.Drawing.Point(3, 586);
            this.panelFerry.Margin = new System.Windows.Forms.Padding(2);
            this.panelFerry.Name = "panelFerry";
            this.panelFerry.Padding = new System.Windows.Forms.Padding(8);
            this.panelFerry.Size = new System.Drawing.Size(301, 133);
            this.panelFerry.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "FerryEvent";
            // 
            // ferryevent
            // 
            this.ferryevent.Location = new System.Drawing.Point(8, 24);
            this.ferryevent.Margin = new System.Windows.Forms.Padding(2);
            this.ferryevent.Name = "ferryevent";
            this.ferryevent.Size = new System.Drawing.Size(283, 99);
            this.ferryevent.TabIndex = 16;
            this.ferryevent.Text = "";
            // 
            // panelRefuel
            // 
            this.panelRefuel.AutoSize = true;
            this.panelRefuel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRefuel.Controls.Add(this.label7);
            this.panelRefuel.Controls.Add(this.refuelevent);
            this.panelRefuel.Location = new System.Drawing.Point(3, 719);
            this.panelRefuel.Margin = new System.Windows.Forms.Padding(2);
            this.panelRefuel.Name = "panelRefuel";
            this.panelRefuel.Padding = new System.Windows.Forms.Padding(8);
            this.panelRefuel.Size = new System.Drawing.Size(301, 83);
            this.panelRefuel.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "RefuelEvent";
            // 
            // refuelevent
            // 
            this.refuelevent.Location = new System.Drawing.Point(8, 23);
            this.refuelevent.Margin = new System.Windows.Forms.Padding(2);
            this.refuelevent.Name = "refuelevent";
            this.refuelevent.Size = new System.Drawing.Size(283, 50);
            this.refuelevent.TabIndex = 16;
            this.refuelevent.Text = "";
            // 
            // SCSSdkClientDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 697);
            this.Controls.Add(this.hgf);
            this.Name = "SCSSdkClientDemo";
            this.Text = "SCSSDkClientDemo 0.9 Radiaktive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SCSSdkClientDemo_FormClosing);
            this.contextMenuStripTriggerActions.ResumeLayout(false);
            this.hgf.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelJobStarted.ResumeLayout(false);
            this.panelJobStarted.PerformLayout();
            this.panelFined.ResumeLayout(false);
            this.panelFined.PerformLayout();
            this.panelJobDelivered.ResumeLayout(false);
            this.panelJobDelivered.PerformLayout();
            this.panelJobCancelled.ResumeLayout(false);
            this.panelJobCancelled.PerformLayout();
            this.panelTollgate.ResumeLayout(false);
            this.panelTollgate.PerformLayout();
            this.panelTrain.ResumeLayout(false);
            this.panelTrain.PerformLayout();
            this.panelFerry.ResumeLayout(false);
            this.panelFerry.PerformLayout();
            this.panelRefuel.ResumeLayout(false);
            this.panelRefuel.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Panel panelRefuel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox refuelevent;
        private System.Windows.Forms.Panel panelJobStarted;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox jobstarted;
        private System.Windows.Forms.Panel panelJobDelivered;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox jobdelivered;
        private System.Windows.Forms.Panel panelJobCancelled;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox jobcanceled;
        private System.Windows.Forms.Panel panelFined;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox finedevent;
        private System.Windows.Forms.Panel panelTollgate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox tollgateevent;
        private System.Windows.Forms.Panel panelTrain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox trainevent;
        private System.Windows.Forms.Panel panelFerry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox ferryevent;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

