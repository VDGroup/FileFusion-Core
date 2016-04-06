namespace VideoPlayer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.VPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.Position = new XComponent.SliderBar.MACTrackBar();
            this.Volume = new XComponent.SliderBar.MACTrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.VPlayer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.Volume);
            this.splitContainer1.Panel2.Controls.Add(this.Position);
            this.splitContainer1.Size = new System.Drawing.Size(978, 590);
            this.splitContainer1.SplitterDistance = 524;
            this.splitContainer1.TabIndex = 0;
            // 
            // VPlayer
            // 
            this.VPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VPlayer.Enabled = true;
            this.VPlayer.Location = new System.Drawing.Point(0, 0);
            this.VPlayer.Name = "VPlayer";
            this.VPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VPlayer.OcxState")));
            this.VPlayer.Size = new System.Drawing.Size(978, 524);
            this.VPlayer.TabIndex = 0;
            // 
            // Position
            // 
            this.Position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Position.BackColor = System.Drawing.Color.Transparent;
            this.Position.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.Position.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Position.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.Position.IndentHeight = 6;
            this.Position.Location = new System.Drawing.Point(12, 22);
            this.Position.Maximum = 10;
            this.Position.Minimum = 0;
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(675, 28);
            this.Position.TabIndex = 0;
            this.Position.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.Position.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.Position.TickHeight = 4;
            this.Position.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Position.TrackerColor = System.Drawing.Color.Green;
            this.Position.TrackerSize = new System.Drawing.Size(16, 16);
            this.Position.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.Position.TrackLineHeight = 3;
            this.Position.Value = 0;
            // 
            // Volume
            // 
            this.Volume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Volume.BackColor = System.Drawing.Color.Transparent;
            this.Volume.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.Volume.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.Volume.IndentHeight = 6;
            this.Volume.Location = new System.Drawing.Point(693, 22);
            this.Volume.Maximum = 10;
            this.Volume.Minimum = 0;
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(273, 28);
            this.Volume.TabIndex = 1;
            this.Volume.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.Volume.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.Volume.TickHeight = 4;
            this.Volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Volume.TrackerColor = System.Drawing.Color.Green;
            this.Volume.TrackerSize = new System.Drawing.Size(16, 16);
            this.Volume.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.Volume.TrackLineHeight = 3;
            this.Volume.Value = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 590);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private AxWMPLib.AxWindowsMediaPlayer VPlayer;
        private XComponent.SliderBar.MACTrackBar Volume;
        private XComponent.SliderBar.MACTrackBar Position;
        private System.Windows.Forms.Timer timer1;
    }
}

