using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization; // добавили пространство имён

namespace Text_Editor_RTF_2
{
    [Serializable] // Указали атрибут класса
    public class Paths
    {
        [XmlAttribute]
        public string Path { get; set; }
        public Paths() { }
        public Paths(string path)
        {            
            this.Path = path;            
        }        
        static public void Serealize_it(List<Paths> objectGrath, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Paths>));
            using (Stream fStream = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(fStream, objectGrath);
            }           
        }
        static public void Deserealize_it(string filename, out List<Paths> lst)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Paths>));
            try
            {
                using (XmlReader reader = XmlReader.Create(filename))
                {
                    lst = (List<Paths>)xmlSerializer.Deserialize(reader);
                }
            }
            catch
            {
                lst = new List<Paths>();
            }
        }
    }
}
