using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerilestirmeSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Depo d = new Depo();
            d.isim = "Veksis Store";
            List<Urun> urunler = new List<Urun>();
            Urun urn = new Urun()
            {
                ID = Guid.NewGuid(),
                Isim = "Kurşun Kalem",
                Marka = "Faber Castel",
                Fiyat = 15.99,
                BayiFiyat = 12.45,
            };
            urunler.Add(urn);
            urunler.Add(new Urun() { ID = Guid.NewGuid(), Isim = "Silgi", Marka = "Pelikan", Fiyat = 52, BayiFiyat = 45 });

            d.Urunler = urunler;

            #region BinarySerialization 1

            //byte[] buffer = BinarySerialize("Selam Dostum Nassın");
            //string serializedData = "";
            //foreach (byte b in buffer)
            //{
            //    serializedData += b;
            //}
            //Console.WriteLine(serializedData);


            //string veri = (string)BinaryDeSerialize(buffer);
            //Console.WriteLine(veri);

            #endregion

            #region BinarySerialization 2

            //byte[] buffer = BinarySerialize(urn);
            //string serializedData = "";
            //foreach (byte b in buffer)
            //{
            //    serializedData += b;
            //}
            //Console.WriteLine(serializedData);

            //Urun urn2 = (Urun)BinaryDeSerialize(buffer);
            //Console.WriteLine(urn2.ID);
            //Console.WriteLine(urn2.Isim);
            //Console.WriteLine(urn2.Marka);
            //Console.WriteLine(urn2.Fiyat);
            //Console.WriteLine(urn2.BayiFiyat);

            #endregion

            #region JsonSerialization

            //string serilestirilmis = JsonSerialize(urn);
            //Console.WriteLine(serilestirilmis);

            //Urun urn2 = (Urun)JsonDeSerialize(serilestirilmis);
            //Console.WriteLine(urn2.ID);
            //Console.WriteLine(urn2.Isim);
            //Console.WriteLine(urn2.Marka);
            //Console.WriteLine(urn2.Fiyat);
            //Console.WriteLine(urn2.BayiFiyat);

            #endregion

            #region XML Serialization

            //string serilestirilmis = XmlSerialize(urn);
            //Console.WriteLine(serilestirilmis);

            //Urun urn2 = XmlDeSerialize(serilestirilmis);
            //Console.WriteLine("ID= " + urn2.ID);
            //Console.WriteLine("Isim= " + urn2.Isim);
            //Console.WriteLine("Marka= " + urn2.Marka);
            //Console.WriteLine("Fiyat= " + urn2.Fiyat);
            //Console.WriteLine("Bayi Fiyat= " + urn2.BayiFiyat);

            #endregion

            #region XML Serialization

            string serilestirilmis = XmlSerializeList(d);
            Console.WriteLine(serilestirilmis);

            Depo d2 = XmlDeSerializeList(serilestirilmis);
            Console.WriteLine("*-*-*-*-*-*-De Serialization-*-*-*-*-*--*");
            foreach (Urun item in d2.Urunler)
            {
                Console.WriteLine(item.ID);
                Console.WriteLine(item.Isim);
                Console.WriteLine(item.Marka);
                Console.WriteLine(item.BayiFiyat);
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-");
            }
           
            #endregion
        }

        public static byte[] BinarySerialize(object data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
            return stream.ToArray();
        }
        public static object BinaryDeSerialize(byte[] buffer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
        public static string JsonSerialize(object data)
        {
            return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects});
        }
        public static object JsonDeSerialize(string data)
        {
            return JsonConvert.DeserializeObject(data, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        }
        public static string XmlSerialize(Urun data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Urun));
            TextWriter yazici = new StringWriter();
            serializer.Serialize(yazici, data);
            return yazici.ToString();
        }
        public static Urun XmlDeSerialize(string data)
        {
            Urun urn = new Urun();
            XmlSerializer serializer = new XmlSerializer(typeof(Urun));
            StringReader okuyucu = new StringReader(data);
            XmlReader xmlokuyucu = new XmlTextReader(okuyucu);
            if (serializer.CanDeserialize(xmlokuyucu))
            {
                urn = (Urun)serializer.Deserialize(xmlokuyucu);
            }
            return urn;
        }

        public static string XmlSerializeList(Depo urunler)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Depo));
            TextWriter yazici = new StringWriter();
            serializer.Serialize(yazici, urunler);
            return yazici.ToString();
        }
        public static Depo XmlDeSerializeList(string data)
        {
            Depo urunler = new Depo();
            XmlSerializer serializer = new XmlSerializer(typeof(Depo));
            StringReader okuyucu = new StringReader(data);
            XmlReader xmlokuyucu = new XmlTextReader(okuyucu);
            urunler = (Depo)serializer.Deserialize(xmlokuyucu);
            return urunler;
        }
    }
}
