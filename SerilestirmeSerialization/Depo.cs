using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerilestirmeSerialization
{
    public class Depo
    {
        [XmlAttribute]
        public string isim { get; set; }
        public List<Urun> Urunler;
    }
}
