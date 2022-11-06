using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerilestirmeSerialization
{
    [Serializable]
    public class Urun
    {
        [XmlElement(ElementName = "UrunNo")]
        public Guid ID { get; set; }
        public string Isim { get; set; }
        public string Marka { get; set; }
        //[NonSerialized]
        [XmlIgnore]
        public double Fiyat { get; set; }
        public double BayiFiyat { get; set; }
    }
}
