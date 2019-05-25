namespace BlackSniffer
{
    partial class MainForm
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
            this.lblTest = new System.Windows.Forms.Label();
            this.dataGridViewPackets = new System.Windows.Forms.DataGridView();
            this.PacketIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStartCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopCapture = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackets)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(622, 300);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(0, 12);
            this.lblTest.TabIndex = 3;
            // 
            // dataGridViewPackets
            // 
            this.dataGridViewPackets.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewPackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPackets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PacketIndex,
            this.DestinationAddress,
            this.SourceAddress,
            this.Time,
            this.Protocol,
            this.Length,
            this.Info});
            this.dataGridViewPackets.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridViewPackets.Location = new System.Drawing.Point(0, 172);
            this.dataGridViewPackets.Name = "dataGridViewPackets";
            this.dataGridViewPackets.RowTemplate.Height = 23;
            this.dataGridViewPackets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewPackets.Size = new System.Drawing.Size(802, 282);
            this.dataGridViewPackets.TabIndex = 4;
            this.dataGridViewPackets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPackets_CellClick);
            this.dataGridViewPackets.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewPackets_CellFormatting);
            this.dataGridViewPackets.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewPackets_RowsAdded);
            // 
            // PacketIndex
            // 
            this.PacketIndex.Frozen = true;
            this.PacketIndex.HeaderText = "PacketIndex";
            this.PacketIndex.Name = "PacketIndex";
            // 
            // DestinationAddress
            // 
            this.DestinationAddress.Frozen = true;
            this.DestinationAddress.HeaderText = "Dest";
            this.DestinationAddress.Name = "DestinationAddress";
            this.DestinationAddress.Width = 150;
            // 
            // SourceAddress
            // 
            this.SourceAddress.Frozen = true;
            this.SourceAddress.HeaderText = "Src";
            this.SourceAddress.Name = "SourceAddress";
            // 
            // Time
            // 
            this.Time.Frozen = true;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Protocol
            // 
            this.Protocol.Frozen = true;
            this.Protocol.HeaderText = "Protocol";
            this.Protocol.Name = "Protocol";
            // 
            // Length
            // 
            this.Length.Frozen = true;
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            // 
            // Info
            // 
            this.Info.Frozen = true;
            this.Info.HeaderText = "Info";
            this.Info.Name = "Info";
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStartCapture,
            this.toolStripButtonStopCapture});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(802, 39);
            this.toolStripMain.TabIndex = 5;
            // 
            // toolStripButtonStartCapture
            // 
            this.toolStripButtonStartCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartCapture.Image = global::BlackSniffer.Properties.Resources.Wizard2;
            this.toolStripButtonStartCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartCapture.Name = "toolStripButtonStartCapture";
            this.toolStripButtonStartCapture.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStartCapture.Text = "toolStripButton1";
            this.toolStripButtonStartCapture.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // toolStripButtonStopCapture
            // 
            this.toolStripButtonStopCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStopCapture.Image = global::BlackSniffer.Properties.Resources.Stop;
            this.toolStripButtonStopCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopCapture.Name = "toolStripButtonStopCapture";
            this.toolStripButtonStopCapture.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStopCapture.Text = "toolStripButton2";
            this.toolStripButtonStopCapture.Click += new System.EventHandler(this.ToolStripButtonStopCapture_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.dataGridViewPackets);
            this.Controls.Add(this.lblTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "BlackSniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackets)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.DataGridView dataGridViewPackets;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartCapture;
        private System.Windows.Forms.ToolStripButton toolStripButtonStopCapture;
    }
}
