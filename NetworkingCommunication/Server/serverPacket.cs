using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace mD_WPF_chSheet_01.NetworkingCommunication.Server
{
    [Serializable]
    class serverPacket
    {
        public int packetID { get; set; }

        public string name { get; set; }

        public string message { get; set; }

        public string packetType { get; set; }

        public serverPacket()
        {

        }
        public serverPacket(byte[] packetByte)
        {
            var serializer = new XmlSerializer(typeof(serverPacket));
            serverPacket sp;
            using (TextReader reader = new StringReader(Encoding.UTF8.GetString(packetByte)))
            {
                sp = (serverPacket)serializer.Deserialize(reader);
            }
            this.packetID = sp.packetID;
            this.packetType = sp.packetType;
            this.name = sp.name;
            this.message = sp.message;
        }

        public byte[] toBytes()
        {
            XmlSerializer xml = new XmlSerializer(typeof(serverPacket));
            string xmlstring = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xml.Serialize(writer, this);
                    xmlstring = sww.ToString();
                }
            }
            byte[] bytes = Encoding.UTF8.GetBytes(xmlstring);

            return bytes;
        }

    }
}
