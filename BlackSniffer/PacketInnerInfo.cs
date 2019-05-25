using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackSniffer
{
    public partial class PacketInnerInfo : Form
    {
        public PacketInnerInfo()
        {
            InitializeComponent();
        }

        public void LoadPacketInfo(BlackPacket packet)
        {
            TreeNode protocolNode = treeViewPacketProtocolInfo.Nodes.Add("Protocol: " + packet.Protocol.ToString());
            if (packet.Protocol != Protocol.ETHERNET && packet.Protocol != Protocol.ARP)
            {
                protocolNode.Nodes.Add("Source port:" + packet.SourcePort);
                protocolNode.Nodes.Add("Destination port:" + packet.DestinationPort);
            }

            protocolNode.Nodes.Add("Source address: " + packet.SourceAddress);
            protocolNode.Nodes.Add("Destination address: " + packet.DestAddress);
            int rowIndex = dataGridViewBytes.Rows.Add();
            int j = 0;
            foreach (byte _byte in packet.Content)
            {

                dataGridViewBytes.Rows[rowIndex].Cells[j++].Value = _byte;
                if (j == 4)
                {
                    rowIndex = dataGridViewBytes.Rows.Add();
                    j = 0;
                }
            }
        }
    }
}
