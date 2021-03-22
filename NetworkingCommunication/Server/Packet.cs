using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace mD_WPF_chSheet_01.NetworkingCommunication.Server
{
    [Serializable]
    public class Packet
    {
        public int packetID { get; set; }

        public string name { get; set; }

        public string message { get; set; }

        public string packetType { get; set; }

        public Packet()
        {

        }

        public Packet(byte[] packetByte)
        {
            var serializer = new XmlSerializer(typeof(Packet));
            Packet p;
            using (TextReader reader = new StringReader(Encoding.ASCII.GetString(packetByte)))
            {
                p = (Packet)serializer.Deserialize(reader);
            }
            this.packetID = p.packetID;
            this.packetType = p.packetType;
            this.name = p.name;
            this.message = p.message;
        }

        public byte[] toBytes()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Packet));
            string xmlString = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xml.Serialize(writer, this);
                    xmlString = sww.ToString();
                }
            }
            byte[] bytes = Encoding.ASCII.GetBytes(xmlString);

            return bytes;
        }
    }
}
