using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using ParserRealtyYandex.Core;
using ParserRealtyYandex.Core.RealtyYandex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParserRealtyYandex.RealtyYandex
{
    public class RealtyYandexParser : IParser<BuildingInfo>
    {
        readonly IParserSettings _settings;
        readonly IChromeWork _chromeWork;

        readonly RealtyYandexSelecters _selecters;

        public RealtyYandexParser(IParserSettings settings, IChromeWork chromeWork)
        {

            _chromeWork = chromeWork;
            _settings = settings;
            _selecters = new RealtyYandexSelecters();


        }





        public IEnumerable<string> ParseLinks(int page)
        {
            string url = _settings.BaseUrl + _settings.Prefix + (page > 0 ? "?" + _settings.PrefixPage.Replace("{CurrentId}", page.ToString()) : "");
            _chromeWork.SetUrl(url);
            return _chromeWork.GetSelectAttributeBySelector(_selecters.LinksSelect, "href");

        }

        public int ParseCountPages()
        {
            string url = _settings.BaseUrl + _settings.Prefix;
            _chromeWork.SetUrl(url);
            var data = _chromeWork.GetTextsBySelector(_selecters.CountPagesSelect).LastOrDefault();

            return Int32.Parse(data);
        }
        private Building ParseBuilding()
        {
            var building = new Building();

            building.Adress = _chromeWork.GetTextBySelector(_selecters.AdressSelect);
            try { building.Description = _chromeWork.GetTextBySelector(_selecters.DescriptionSelect); }
            catch { building.Description = null; }
            building.Deadline = _chromeWork.GetTextBySelector(_selecters.DeadlineSelect);
            building.ResidentialСomplexName = _chromeWork.GetTextBySelector(_selecters.ResidentialСomplexNameSelect);
            try { building.Developer = _chromeWork.GetTextBySelector(_selecters.DeveloperSelect); }
            catch { building.Developer = building.ResidentialСomplexName; }
            _chromeWork.ClickBySelector(_selecters.PhoneButtonSelect);
            building.Phone = _chromeWork.GetTextBySelector(_selecters.PhoneSelect);
            try { building.Photos.ListPhotos = _chromeWork.GetSelectAttributeBySelector(_selecters.PhoneSelect, "src").ToList(); }
            catch { building.Photos.ListPhotos = null; }

            return building;

        }
        private DescriptionJK ParseDesc()
        {
            var desc = new DescriptionJK();

            desc.NumberBuildings = _chromeWork.GetTextBySelector(_selecters.NumberBuildingsSelect);
            desc.CountApartaments = _chromeWork.GetTextBySelector(_selecters.CountApartamentsSelect);
            desc.Facing = _chromeWork.GetTextBySelector(_selecters.FacingSelect);
            desc.ParkingSpaces = _chromeWork.GetTextBySelector(_selecters.ParkingSpacesSelect);
            desc.Storeys = _chromeWork.GetTextBySelector(_selecters.StoreysSelect);
            desc.TypeHouse = _chromeWork.GetTextBySelector(_selecters.TypeHouseSelect);
            desc.Queues = _chromeWork.GetTextBySelector(_selecters.QueuesSelect);
            desc.TypeContract = _chromeWork.GetTextBySelector(_selecters.TypeContractSelect);




            return desc;

        }

        public BuildingInfo Parse(string url)
        {
            BuildingInfo info = new BuildingInfo();
            string[] tmp = url.Split('/');
            _chromeWork.SetUrl(url);


           // info.Id = tmp.Last() == "" ? tmp[tmp.Count() - 2] : tmp.Last();
            info.Building =  ParseBuilding();
            info.Description =  ParseDesc();
            //# flats > div > table > tbody > tr:nth-child(1) > td:nth-child(5) > span
            //# flats > div > table > tbody > tr:nth-child(2) > td:nth-child(5) > span
            return null;

        }


    }
}