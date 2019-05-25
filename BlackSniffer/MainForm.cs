using SharpPcap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


namespace BlackSniffer
{
    //Pasha LOH
    public partial class MainForm : Form
    {
        Sniffer sniffer;
        Thread packetArrivalThread;
        public static Dictionary<string, PacketColor> PacketColorStyles;
        public MainForm()
        {
            PacketStyles temp = new PacketStyles();
            InitializeComponent();
            sniffer = new Sniffer();
            //Set Double buffering on the Grid using reflection and the bindingflags enum.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dataGridViewPackets, new object[] { true });
        }



        private void ButtonStart_Click(object sender, EventArgs e)
        {
            foreach (ICaptureDevice device in sniffer.CaptureDevices)
            {
                try
                {
                    device.OnPacketArrival += new PacketArrivalEventHandler(device_PacketArrival);
                    device.Open(DeviceMode.Promiscuous, sniffer.ReadTimeOut);
                    device.StartCapture();
                }
                catch (Exception exception)
                {

                }
            }
        }

        delegate void FillRow(int rowIndex, int collIndex, string value);

        private void device_PacketArrival(object sender, CaptureEventArgs e)
        {

            BlackPacket reseivedPacket = Sniffer.GetPacket(e.Packet);
            if (reseivedPacket != null)
            {
                int rowIndex = 0;
                try
                {
                    dataGridViewPackets.Invoke(new Action(() =>
                    {
                        rowIndex = dataGridViewPackets.Rows.Add();
                        dataGridViewPackets.Rows[rowIndex].Cells[0].Value = reseivedPacket.PacketIndex;
                        dataGridViewPackets.Rows[rowIndex].Cells[1].Value = reseivedPacket.DestAddress;
                        dataGridViewPackets.Rows[rowIndex].Cells[2].Value = reseivedPacket.SourceAddress;
                        dataGridViewPackets.Rows[rowIndex].Cells[3].Value = reseivedPacket.TimeValue.ToLongTimeString();
                        dataGridViewPackets.Rows[rowIndex].Cells[4].Value = reseivedPacket.Protocol.ToString();
                        dataGridViewPackets.Rows[rowIndex].Cells[5].Value = reseivedPacket.Length.ToString();
                        dataGridViewPackets.Rows[rowIndex].Cells[6].Value = "content";
                        try
                        {
                            ColorCell(reseivedPacket.Protocol, rowIndex);
                        }
                        catch (Exception exception)
                        {

                        }
                    }
                    ));
                }
                catch (Exception exception)
                {

                }

                sniffer.RefreshSavedPackets(reseivedPacket);
            }


        }

        private void ListboxPackets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sniffer.StopCapture();
        }

        private void DataGridViewPackets_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            (sender as DataGridView).FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void DataGridViewPackets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Protocol protocol = (Protocol)dataGridViewPackets.Rows[e.RowIndex].Cells[3].Value;
            //e.CellStyle.BackColor = BlackPacket.PacketsColors[protocol];
        }

        private void ColorCell(Protocol packetProtocol, int rowIndex)
        {
            dataGridViewPackets.Rows[rowIndex].DefaultCellStyle.BackColor = PacketStyles.PacketColorStyles[packetProtocol.ToString()].BackgroundColor;
            dataGridViewPackets.Rows[rowIndex].DefaultCellStyle.ForeColor = PacketStyles.PacketColorStyles[packetProtocol.ToString()].FontColor;
        }

        private void DataGridViewPackets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int packetIndex = e.RowIndex;
            PacketInnerInfo packetInnerInfo = new PacketInnerInfo();
            int index = (int)e.RowIndex % (sniffer.MaxSavedCount - 1);
            BlackPacket savedPacket = sniffer.SavedPackets[index];
            packetInnerInfo.LoadPacketInfo(savedPacket);
            packetInnerInfo.Show();
        }

        private void ToolStripButtonStopCapture_Click(object sender, EventArgs e)
        {
            sniffer.StopCapture();
        }
    }
}