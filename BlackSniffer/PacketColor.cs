using System.Collections.Generic;
using System.Drawing;

namespace BlackSniffer
{
    public class PacketColor
    {
        public Color FontColor { get; set; }
        public Color BackgroundColor { get; set; }

    }

    public class PacketStyles
    {
        public static Dictionary<string, PacketColor> PacketColorStyles { get; private set; }

        public PacketStyles()
        {
            PacketColorStyles = new Dictionary<string, PacketColor>();

            PacketColorStyles.Add(Protocol.TCP.ToString(), new PacketColor()
            {
                FontColor = Color.LightCoral,
                BackgroundColor = Color.DimGray
            }
            );

            PacketColorStyles.Add(Protocol.TLS.ToString(), new PacketColor()
            {
                FontColor = Color.Brown,
                BackgroundColor = Color.Gray
            }
            );

            PacketColorStyles.Add(Protocol.UDP.ToString(), new PacketColor()
            {
                FontColor = Color.Purple,
                BackgroundColor = Color.Silver
            }
            );
            PacketColorStyles.Add(Protocol.ARP.ToString(), new PacketColor()
            {
                FontColor = Color.Gold,
                BackgroundColor = Color.DarkRed
            }
            );

            PacketColorStyles.Add(Protocol.ICMPv6.ToString(), new PacketColor()
            {
                FontColor = Color.Black,
                BackgroundColor = Color.LightCyan
            }
            );

            PacketColorStyles.Add(Protocol.HTTP.ToString(), new PacketColor()
            {
                FontColor = Color.Black,
                BackgroundColor = Color.LightBlue
            }
            );

            PacketColorStyles.Add(Protocol.SSDP.ToString(), new PacketColor()
            {
                FontColor = Color.Black,
                BackgroundColor = Color.SkyBlue
            }
            );

            PacketColorStyles.Add(Protocol.GQUIC.ToString(), new PacketColor()
            {
                FontColor = Color.Black,
                BackgroundColor = Color.SkyBlue
            }
            );

            PacketColorStyles.Add(Protocol.ETHERNET.ToString(), new PacketColor()
            {
                FontColor = Color.Red,
                BackgroundColor = Color.Black
            }
           );
        }

    }

    
}
