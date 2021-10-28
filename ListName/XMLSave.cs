using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ListName
{
    public static class XMLSave
    {
        public static void Save(string filename, People peopleToSave)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(People));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, peopleToSave);
            writer.Close();
        }

        public static People Load(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(People));
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlReader r = XmlReader.Create(fs);
            People p;
            p = (People)serializer.Deserialize(r);
            return p;
        }
    }
}
