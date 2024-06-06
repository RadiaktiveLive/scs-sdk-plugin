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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCSSdkClientDemo));
            this.hgf = new System.Windows.Forms.TabControl();
            this.tabAbout = new SCSSdkClient.Demo.CustomTabPage();
            this.button1 = new System.Windows.Forms.Button();
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
            this.button2 = new System.Windows.Forms.Button();
            this.hgf.SuspendLayout();
            this.tabAbout.SuspendLayout();
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
            this.tabAbout.Controls.Add(this.button2);
            this.tabAbout.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(916, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Trigger SB Actions!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 70);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

