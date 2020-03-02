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

namespace ParserRealtyYandex.RealtyYandex
{
    public class RealtyYandexParser : IParser<Building>
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

        public Building Parse(string url)
        {
           // ChromeWork work = _chromeWork.
            _chromeWork.AddNewTab(url);
            var building = new Building();

            building.Adress = _chromeWork.GetTextBySelector(_selecters.AdressSelect);
            
            try
            {


                building.Description = _chromeWork.GetTextBySelector(_selecters.DescriptionSelect);
            }
            catch (Exception)
            {

                building.Description = null;
            }



            building.Deadline = _chromeWork.GetTextBySelector(_selecters.DeadlineSelect);

            building.ResidentialСomplexName = _chromeWork.GetTextBySelector(_selecters.ResidentialСomplexNameSelect);


            try { building.Developer = _chromeWork.GetTextBySelector(_selecters.DeveloperSelect); }
            catch { building.Developer = building.ResidentialСomplexName; }

            _chromeWork.ClickBySelector(_selecters.PhoneButtonSelect);
            building.Phone = _chromeWork.GetTextBySelector(_selecters.PhoneSelect);
            try
            {
                building.Photos.photo = _chromeWork.GetSelectAttributeBySelector(_selecters.PhoneSelect, "src").ToList();

            }
            catch (Exception)
            {
                building.Photos.photo = null;


            }


            var tmp = url.Split('/', '-', '=');
            building.Id = tmp.Last() == "" ? tmp[tmp.Count() - 2] : tmp.Last();

            return building;
        }


    }
}