using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core.RealtyYandex
{
    public class Room
    {
        public string CountRoom { get; set; }
        public string Square { get; set; }
        public string Price { get; set; }
        public string Floor { get; set; }
        public string CountApartaments { get; set; }

    }

    public class DescriptionJK {
        public string TypeContract { get; set; }
        public string NumberBuildings { get; set; }
        public string CountApartaments { get; set; }
        public string Facing { get; set; }
        public string Queues { get; set; }
        public string Storeys { get; set; }
        public string TypeHouse { get; set; }
        public string ParkingSpaces { get; set; }




    }
    public class BuildingInfo
    {
        public List<Room> Rooms { get; set; }
        public DescriptionJK Description { set; get; }
        public BuildingInfo()
        {
            Rooms = new List<Room>();
            Description = new DescriptionJK();
        }

    }
}
