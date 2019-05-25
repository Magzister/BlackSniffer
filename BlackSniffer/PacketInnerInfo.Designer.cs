namespace BlackSniffer
{
    partial class PacketInnerInfo
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
            this.treeViewPacketProtocolInfo = new System.Windows.Forms.TreeView();
            this.dataGridViewBytes = new System.Windows.Forms.DataGridView();
            this.Byte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBytes)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewPacketProtocolInfo
            // 
            this.treeViewPacketProtocolInfo.Location = new System.Drawing.Point(1, 1);
            this.treeViewPacketProtocolInfo.Name = "treeViewPacketProtocolInfo";
            this.treeViewPacketProtocolInfo.Size = new System.Drawing.Size(442, 169);
            this.treeViewPacketProtocolInfo.TabIndex = 2;
            // 
            // dataGridViewBytes
            // 
            this.dataGridViewBytes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBytes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Byte1,
            this.Byte2,
            this.Byte3,
            this.Byte4});
            this.dataGridViewBytes.Location = new System.Drawing.Point(1, 167);
            this.dataGridViewBytes.Name = "dataGridViewBytes";
            this.dataGridViewBytes.RowTemplate.Height = 23;
            this.dataGridViewBytes.Size = new System.Drawing.Size(442, 202);
            this.dataGridViewBytes.TabIndex = 4;
            // 
            // Byte1
            // 
            this.Byte1.Frozen = true;
            this.Byte1.HeaderText = "";
            this.Byte1.Name = "Byte1";
            // 
            // Byte2
            // 
            this.Byte2.Frozen = true;
            this.Byte2.HeaderText = "";
            this.Byte2.Name = "Byte2";
            // 
            // Byte3
            // 
            this.Byte3.Frozen = true;
            this.Byte3.HeaderText = "";
            this.Byte3.Name = "Byte3";
            // 
            // Byte4
            // 
            this.Byte4.Frozen = true;
            this.Byte4.HeaderText = "";
            this.Byte4.Name = "Byte4";
            // 
            // PacketInnerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 371);
            this.Controls.Add(this.dataGridViewBytes);
            this.Controls.Add(this.treeViewPacketProtocolInfo);
            this.Name = "PacketInnerInfo";
            this.Text = "PacketInnerInfo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBytes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewPacketProtocolInfo;
        private System.Windows.Forms.DataGridView dataGridViewBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte4;
    }
}