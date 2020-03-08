using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParserRealtyYandex.Core.RealtyYandex
{

    public class Photos
    {
        public List<string> ListPhotos { get; set; }// = new List<string>();
    }

    [XmlRoot(ElementName = "Item")]
    public class Building
    {
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }


        [XmlElement(ElementName = "Developer")]
        public string Developer { get; set; }


        [XmlElement(ElementName = "Adress")]
        public string Adress { get; set; }


        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }


        [XmlElement(ElementName = "ResidentialСomplexName")]
        public string ResidentialСomplexName { get; set; }


        [XmlElement(ElementName = "Deadline")]
        public string Deadline { get; set; }


        [XmlElement(ElementName = "Photos")]
        public Photos Photos { get; set; } = new Photos();


        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

    }
}
