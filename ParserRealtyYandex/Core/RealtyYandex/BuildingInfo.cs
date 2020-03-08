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
    public class Rooms
    {
        public string Id { get; set; }
        public List<Room> RoomList { get; set; }

    }


    public class DescriptionJK
    {
        public string Id { get; set; }
        public string TypeContract { get; set; }
        public string NumberBuildings { get; set; }
        public string CountApartaments { get; set; }
        public string Facing { get; set; }
        public string Queues { get; set; }
        public string Storeys { get; set; }
        public string TypeHouse { get; set; }
        public string ParkingSpaces { get; set; }

    }

    public class AdditionalBenefits
    {
//# description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_phases > div > div.CardFeatures__itemLabel
//# description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_houses > div > div.CardFeatures__itemValue
//# description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_floors > div > div.CardFeatures__itemValue
        public string Id { get; set; }
        public string ClosedTerritory { get; set; }
        public string Security{ get; set; }
        public string Concierge { get; set; }




    }
    public class BuildingInfo
    {
        public string Id
        {
            get { return this.Id; }
            set
            {
                //this.Id = value;
                this.Rooms.Id = value;
                this.Description.Id = value;
                this.Building.Id = value;
                this.AdditionalBenefits.Id = value;
            }
        }
        public AdditionalBenefits  AdditionalBenefits { get; set; }
        public Rooms Rooms { get; set; }
        public DescriptionJK Description { set; get; }
        public Building Building { get; set; }

    }
}
