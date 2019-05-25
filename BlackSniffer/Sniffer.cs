using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BlackSniffer
{
    public class Sniffer
    {
        public static ulong PacketsReseived { get; set; }
        public List<BlackPacket> ReseivedPackets { get; set; }
        public CaptureDeviceList CaptureDevices { get; private set; }
        public int ReadTimeOut { get; private set; }
        public string LogFilePath { get; private set; }
        public List<BlackPacket> SavedPackets { get; set; }
        public int MaxSavedCount { get; set; }


        public Sniffer()
        {
            LogFilePath = Directory.GetCurrentDirectory() + @"\log.txt";
            ReadTimeOut = 1000;
            MaxSavedCount = 100;
            SavedPackets = new List<BlackPacket>(MaxSavedCount);
            CaptureDevices = GetDevices();
        }

        public Sniffer(string logFilePath) : this()
        {
            LogFilePath = logFilePath;
        }
        public Sniffer(ushort readTimeOut) : this()
        {
            ReadTimeOut = readTimeOut;
        }


        public static CaptureDeviceList GetDevices() => CaptureDeviceList.Instance;

        public void StopCapture()
        {
            foreach (ICaptureDevice device in CaptureDevices)
            {
                Thread stopCaptureThread = new Thread(() => {
                    try
                    {
                        device.StopCapture();
                    }
                    catch (PcapException pcapException)
                    {
                        MessageBox.Show("Error" + pcapException.Message);
                    }

                    Thread.CurrentThread.Abort();
                });

                stopCaptureThread.Start();
            }
        }

        public static BlackPacket GetPacket(RawCapture rawPacket)
        {
            BlackPacket resultPacket = new BlackPacket();
            if (!resultPacket.Parse(rawPacket))
                return null;
            PacketsReseived++;
            return resultPacket;
        }

        public void RefreshSavedPackets(BlackPacket newPacket)
        {
            if (SavedPackets.Count < MaxSavedCount) { 
                SavedPackets.Add(newPacket);
                return;
            }

            int index = (int)newPacket.PacketIndex % (MaxSavedCount - 1);
            SavedPackets[index] = newPacket;
        }
    }

    
}