using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core.RealtyYandex
{
    public class RealtyYandexSelecters
    {

        public string TypeContractSelect { get; set; }
        public string NumberBuildingsSelect { get; set; }
        public string CountApartamentsSelect { get; set; }
        public string FacingSelect { get; set; }
        public string QueuesSelect { get; set; }
        public string StoreysSelect { get; set; }
        public string TypeHouseSelect { get; set; }
        public string ParkingSpacesSelect { get; set; }
        //
        public string CountPagesSelect { get;  }

        public string LinksSelect { get; }
        public string DeveloperSelect { get; }
        public string AdressSelect { get; }
        public string PhoneSelect { get; }
        public string PhoneButtonSelect { get; }
        public string ResidentialСomplexNameSelect { get; }
        public string DeadlineSelect { get; }
        public string PhotosSelect { get; }
        public string DescriptionSelect { get; }
        public RealtyYandexSelecters()
        {

            TypeContractSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_agreement > div > div.CardFeatures__itemValue";
            NumberBuildingsSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_houses > div > div.CardFeatures__itemValue";
               
            CountApartamentsSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_flats > div > div.CardFeatures__itemValue";
              FacingSelect= "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_decoration > div > div.CardFeatures__itemValue";
            QueuesSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_phases > div > div.CardFeatures__itemValue";
            StoreysSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_floors > div > div.CardFeatures__itemValue";
        TypeHouseSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_walls > div > div.CardFeatures__itemValue";

          ParkingSpacesSelect = "#description > div.CardFeatures > div.CardFeatures__list > div.CardFeatures__item.CardFeatures__item_parking > div > div.CardFeatures__itemValue";
          //
            CountPagesSelect = "#root > div:nth-child(5) > div > div.SitesSerp__footer > span > span > label";
            LinksSelect = "div.SitesSerp__list > div > div > a";
            DeveloperSelect = "#about > div.SiteCardAbout__right > div > div.CardDevBadge.SiteCardInfo__developer > div.CardDevBadge__text > a";
            AdressSelect = "# root > div > div.PageContent__content > div.SitePage > div.SiteCard > div> div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_fixed > div.SiteCardHeader > div > div.SiteCardHeader__left > div > div";
            PhoneButtonSelect = "#about > div.SiteCardAbout__right > div > div.CardContacts > button ";
            PhoneSelect = "#about > div.SiteCardAbout__right > div > div.CardContacts > button > span";
            ResidentialСomplexNameSelect = "#root > div > div.PageContent__content > div.SitePage > div.SiteCard > div:nth-child(1) > div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_relative > div.SiteCardHeader > div > div.SiteCardHeader__left > h1";
            DeadlineSelect = "#about > div.SiteCardAbout__right > div > div.SiteCardInfo__features > div > span.SiteCardInfo__features-item-value";
            PhotosSelect = "#about > div.SiteCardAbout__left > div > div.GalleryThumbs.SiteCardAbout__thumbs > div > div > img";
            DescriptionSelect = "#description > div.SiteCardDescription__text";


        }

    }
}
