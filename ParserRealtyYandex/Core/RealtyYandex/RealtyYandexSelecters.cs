using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core.RealtyYandex
{
    public class RealtyYandexSelecters
    {
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
            CountPagesSelect = "#root > div:nth-child(5) > div > div.SitesSerp__footer > span > span > label";
            LinksSelect = "div.SitesSerp__list > div > div > a";
            DeveloperSelect = "#about > div.SiteCardAbout__right > div > div.CardDevBadge.SiteCardInfo__developer > div.CardDevBadge__text > a";
            AdressSelect = "# root > div > div.PageContent__content > div.SitePage > div.SiteCard > div> div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_fixed > div.SiteCardHeader > div > div.SiteCardHeader__left > div > div";
//# root > div > div.PageContent__content > div.SitePage > div.SiteCard > div> div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_fixed > div.SiteCardHeader > div > div.SiteCardHeader__left > div > div
            PhoneButtonSelect = "#about > div.SiteCardAbout__right > div > div.CardContacts > button ";
            PhoneSelect = "#about > div.SiteCardAbout__right > div > div.CardContacts > button > span";
            ResidentialСomplexNameSelect = "#root > div > div.PageContent__content > div.SitePage > div.SiteCard > div:nth-child(1) > div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_relative > div.SiteCardHeader > div > div.SiteCardHeader__left > h1";
            DeadlineSelect = "#about > div.SiteCardAbout__right > div > div.SiteCardInfo__features > div > span.SiteCardInfo__features-item-value";
            PhotosSelect = "#about > div.SiteCardAbout__left > div > div.GalleryThumbs.SiteCardAbout__thumbs > div > div > img";
            DescriptionSelect = "#description > div.SiteCardDescription__text";


        }

    }
}
