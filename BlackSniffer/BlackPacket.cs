using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;

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
﻿
