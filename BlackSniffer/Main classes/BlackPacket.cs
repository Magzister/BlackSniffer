<<<<<<< HEAD
﻿using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;

namespace BlackSniffer
{ 
    public enum Protocol
    {
        HTTP,
        TLS,
        SSDP,
        TCP,
        UDP,
        ARP,
        ETHERNET,
        ICMPv6,
        ICMPv4,
        GQUIC,
        NONE
    }

    public sealed class BlackPacket
    {
        public readonly uint PORT_NONE = 0;
        public readonly uint PORT_ANY  = 1;
        public ulong PacketIndex { get; private set; }
        public static Dictionary<uint ,Protocol> ProtocolsPorts { get; set; }
        public string DestAddress { get; private set; }
        public string SourceAddress { get; private set; }
        public DateTime TimeValue { get; private set; }
        public Protocol Protocol { get; protected set; }
        public uint Length { get; private set; }
        public byte[] Header { get; private set; }
        public byte[] Content { get; private set; }
        public uint? DestinationPort { get; private set; }
        public uint? SourcePort { get; private set; }

        public BlackPacket()
        {
            
        }

        public BlackPacket(ulong packetIndex)
        {
            PacketIndex = packetIndex;
        }

        public Protocol DetermineProtocol(Protocol protocol, uint? destPort, uint? srcPort)
        {
            if (destPort == null || srcPort == null)
                return protocol;

            switch (protocol)
            {
                case Protocol.TCP :
                    if ((uint)destPort == 80 || (uint)srcPort == 80)
                        return Protocol.HTTP;
                    break;
                case Protocol.UDP :
                    if ((uint)destPort == 1900 || (uint)srcPort == 1900)
                        return Protocol.SSDP;
                    if ((uint)destPort == 443 || (uint)srcPort == 443)
                        return Protocol.GQUIC;
                    break;
            }

            return protocol;
        }

        public bool Parse(RawCapture rawPacket)
        {
            Packet packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            if (packet == null) return false;

            SourcePort = null;
            DestinationPort = null;
            Length = (uint)packet.Bytes.Length;
            TimeValue = rawPacket.Timeval.Date;
            PacketIndex = Sniffer.PacketsReseived;
            Protocol = Protocol.NONE;
            Content = rawPacket.Data;
            
            TcpPacket transportPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));
            if (transportPacket != null)
            {
                SourcePort = transportPacket.SourcePort;
                DestinationPort = transportPacket.DestinationPort;
                IPPacket ipPacket = (IPPacket)transportPacket.ParentPacket;
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Header = ipPacket.HeaderData;
                Protocol = Protocol.TCP;
                Protocol = DetermineProtocol(Protocol, DestinationPort, SourcePort);
                return true;
            }

            ICMPv6Packet icmpV6Packet = (ICMPv6Packet)packet.Extract(typeof(ICMPv6Packet));
            if (icmpV6Packet != null)
            {
                IPv6Packet ipPacket = (IPv6Packet)packet.Extract(typeof(IPv6Packet));
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.ICMPv6;
                Header = ipPacket.HeaderData;
                return true;
            }

            ICMPv4Packet icmpV4Packet = (ICMPv4Packet)packet.Extract(typeof(ICMPv4Packet));
            if(icmpV4Packet != null)
            {
                IPv4Packet ipPacket = (IPv4Packet)packet.Extract(typeof(IPv4Packet));
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.ICMPv4;

                Header = ipPacket.HeaderData;
                return true;
            }

            UdpPacket udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));
            if (udpPacket != null)
            {
                SourcePort = udpPacket.SourcePort;
                DestinationPort = udpPacket.DestinationPort;
                IPPacket ipPacket = (IPPacket)packet.Extract(typeof(IPPacket));
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.UDP;
                Header = ipPacket.HeaderData;
                Protocol = DetermineProtocol(Protocol, DestinationPort, SourcePort);
                return true;
            }

            ARPPacket arpPacket = (ARPPacket)packet.Extract(typeof(ARPPacket));
            if (arpPacket != null)
            {
                Header = arpPacket.HeaderData;
                SourceAddress = arpPacket.SenderHardwareAddress.ToString();
                DestAddress = arpPacket.TargetHardwareAddress.ToString();
                Protocol = Protocol.ARP;

                return true;
            }

            EthernetPacket ethernetPacket = (EthernetPacket)packet.Extract(typeof(EthernetPacket));
            if (ethernetPacket != null)
            {
                SourceAddress = ethernetPacket.SourceHwAddress.ToString();
                DestAddress = ethernetPacket.DestinationHwAddress.ToString();
                Protocol = Protocol.ETHERNET;
                Header = ethernetPacket.HeaderData;

                return true;
            }

            return false;
        }

    }    
}
=======
﻿using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;

namespace BlackSniffer
{ 
    public enum Protocol
    {
        HTTP = 80,
        SSDP = 1900,
        TCP  = 0,
        UDP,
        ARP,
        ETHERNET,
        ICMPv6,
        ICMPv4
    }
    public sealed class BlackPacket
    {
        public static Dictionary<Protocol, Color> PacketsColors { get; set; }
        public string DestAddress { get; private set; }
        public string SourceAddress { get; private set; }
        public DateTime TimeValue { get; private set; }
        public Protocol Protocol { get; private set; }
        public uint Length { get; private set; }
        public byte[] Header { get; private set; }
        public byte[] Content { get; private set; }
        public uint? DestinationPort { get; private set; }
        public uint? SourcePort { get; private set; }
        public Color PacketColor { get; private set; }

        public BlackPacket()
        {
            PacketsColors = new Dictionary<Protocol, Color>();
            PacketsColors.Add(Protocol.HTTP, Color.DarkBlue);
            PacketsColors.Add(Protocol.SSDP, Color.DarkGreen);
            PacketsColors.Add(Protocol.TCP, Color.Honeydew);
            PacketsColors.Add(Protocol.UDP, Color.Lavender);
            PacketsColors.Add(Protocol.ARP, Color.MediumSeaGreen);
            PacketsColors.Add(Protocol.ETHERNET, Color.MediumTurquoise);
        }

        public Protocol GetProtocolByPort(uint port) => (Protocol)port;

        public bool Parse(RawCapture rawPacket)
        {
            Packet packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            if (packet == null) return false;

            SourcePort = null;
            DestinationPort = null;
            Length = (uint)packet.Bytes.Length;
            TimeValue = rawPacket.Timeval.Date;

            ApplicationPacket applicationPacket = (ApplicationPacket)packet.Extract(typeof(ApplicationPacket));
            if (applicationPacket != null) 
            {
                TcpPacket transportLayerPacket = (TcpPacket)packet.ParentPacket;
                SourcePort = transportLayerPacket.SourcePort;
                DestinationPort = transportLayerPacket.DestinationPort;
                Protocol = GetProtocolByPort((uint)DestinationPort);
                IPPacket ipPacket = applicationPacket.ParentPacket.ParentPacket as IPPacket;
                DestAddress = ipPacket.DestinationAddress.ToString();
                SourceAddress = ipPacket.SourceAddress.ToString();
                Content = ipPacket.PayloadData;
                Header = ipPacket.HeaderData;
                return true;
            }
            if (packet is IPPacket)
            {
                IPPacket ipPacket = (IPPacket)packet.Extract(typeof(IPPacket));
                if (packet is TcpPacket)
                {
                    TcpPacket temp = (TcpPacket)packet.Extract(typeof(TcpPacket));
                    SourcePort = temp.SourcePort;
                    DestinationPort = temp.DestinationPort;
                    Protocol = Protocol.TCP;
                }
                else if (packet is UdpPacket)
                {
                    UdpPacket temp = (UdpPacket)packet.Extract(typeof(UdpPacket));
                    SourcePort = temp.SourcePort;
                    DestinationPort = temp.DestinationPort;
                    Protocol = Protocol.UDP;
                }
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Header = ipPacket.HeaderData;
                Content = ipPacket.PayloadData;
                return true;
            }

            TcpPacket transportPacket = (TcpPacket)packet.Extract(typeof(TcpPacket));
            if (transportPacket != null)
            {
                SourcePort = transportPacket.SourcePort;
                DestinationPort = transportPacket.DestinationPort;
                IPPacket ipPacket = (IPPacket)transportPacket.ParentPacket;
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.TCP;
                Header = ipPacket.HeaderData;
                Content = ipPacket.PayloadData;
                return true;
            }

            ICMPv6Packet icmpV6Packet = (ICMPv6Packet)packet.Extract(typeof(ICMPv6Packet));
            if (icmpV6Packet != null)
            {
                IPv6Packet ipPacket = (IPv6Packet)packet.Extract(typeof(IPv6Packet));
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.ICMPv6;
                Header = ipPacket.HeaderData;
                Content = ipPacket.PayloadData;
            }

            ICMPv4Packet icmpV4Packet = (ICMPv4Packet)packet.Extract(typeof(ICMPv4Packet));
            if(icmpV4Packet != null)
            {
                IPv4Packet ipPacket = (IPv4Packet)packet.Extract(typeof(IPv4Packet));
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.ICMPv4;
                Header = ipPacket.HeaderData;
                Content = ipPacket.PayloadData;
            }
            UdpPacket udpPacket = (UdpPacket)packet.Extract(typeof(UdpPacket));
            if (udpPacket != null)
            {
                SourcePort = udpPacket.SourcePort;
                DestinationPort = udpPacket.DestinationPort;
                IPPacket ipPacket = (IPPacket)packet.Extract(typeof(IPPacket));
                SourceAddress = ipPacket.SourceAddress.ToString();
                DestAddress = ipPacket.DestinationAddress.ToString();
                Protocol = Protocol.UDP;
                Header = ipPacket.HeaderData;
                Content = ipPacket.PayloadData;
                return true;
            }

            ARPPacket arpPacket = (ARPPacket)packet.Extract(typeof(ARPPacket));
            if (arpPacket != null)
            {
                Content = arpPacket.PayloadData;
                Header = arpPacket.HeaderData;
                SourceAddress = arpPacket.SenderHardwareAddress.ToString();
                DestAddress = arpPacket.TargetHardwareAddress.ToString();
                Protocol = Protocol.ARP;
                return true;
            }

            EthernetPacket ethernetPacket = (EthernetPacket)packet.Extract(typeof(EthernetPacket));
            if (ethernetPacket != null)
            {
                SourceAddress = ethernetPacket.SourceHwAddress.ToString();
                DestAddress = ethernetPacket.DestinationHwAddress.ToString();
                Protocol = Protocol.ETHERNET;
                Header = ethernetPacket.HeaderData;
                Content = ethernetPacket.PayloadData;
            }

            return false;
        }

    }    
}
>>>>>>> 77f5772c19e0efaf6b8069eaf7deb0f1952efcce
