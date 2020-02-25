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
        IWebDriver crhomeDriver;
        string login = "aslanov.gabil@yandex.ru";
        string password = "6475207Aslanov";
        public RealtyYandexParser(IParserSettings settings)
        {
            crhomeDriver = new ChromeDriver();

            _settings = settings;
            Aute();

        }


        private void Aute()
        {
            string url = "https://passport.yandex.ru/profile";

            crhomeDriver.Navigate().GoToUrl(url);
            crhomeDriver.FindElement(By.CssSelector("#passp-field-login")).SendKeys(login);
            crhomeDriver.FindElement(By.CssSelector("#root > div > div > div.passp-flex-wrapper > div > div > div.passp-auth-content > div:nth-child(2) > div > div > div.passp-login-form > form > div.passp-button.passp-sign-in-button > button.control.button2.button2_view_classic.button2_size_l.button2_theme_action.button2_width_max.button2_type_submit.passp-form-button")).Click();
            Thread.Sleep(1000);
            crhomeDriver.FindElement(By.CssSelector("#passp-field-passwd")).SendKeys(password);
            crhomeDriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div[2]/div/div/div[3]/div[2]/div/div/form/div[2]/button[1]")).Click();
        }


        public IEnumerable<string> ParseLinks(int page)
        {

            string url = _settings.BaseUrl + _settings.Prefix + (page > 0 ? "?" + _settings.PrefixPage.Replace("{CurrentId}", page.ToString()) : "");
            //# root > div:nth-child(5) > div > div.SitesSerp__list > div:nth-child(1) > div:nth-child(3) > a
            // # root > div:nth-child(5) > div > div.SitesSerp__list > div > div > a
            crhomeDriver.Navigate().GoToUrl(url);
            var data = crhomeDriver.FindElements(
                       By.CssSelector(" div.SitesSerp__list > div > div > a")
                       ).Select(a => a.GetAttribute("href"));



            return data;
        }

        public int ParseCountPages()
        {
            string url = _settings.BaseUrl + _settings.Prefix;
            crhomeDriver.Navigate().GoToUrl(url);
            var data = crhomeDriver.FindElements(
                       By.CssSelector("#root > div:nth-child(5) > div > div.SitesSerp__footer > span > span > label")
                       ).LastOrDefault().Text;

            return Int32.Parse(data);
        }

        public Building Parse(string url)
        {
            crhomeDriver.Navigate().GoToUrl(url);
            Building building = new Building();

            building.Adress = crhomeDriver.FindElement(
                       By.CssSelector("#root > div > div.PageContent__content > div.SitePage > div.SiteCard > div:nth-child(1) > div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_relative > div.SiteCardHeader > div > div.SiteCardHeader__left > div:nth-child(3) > div")
                       ).Text;     

            string dicr = null;
            dicr= crhomeDriver.FindElement(
                      By.CssSelector("#description > div.SiteCardDescription__text")
                      ).Text;
            if (dicr != null)
            {
                building.Description = dicr;
            }

            building.Deadline = crhomeDriver.FindElement(
                      By.CssSelector("#about > div.SiteCardAbout__right > div > div.SiteCardInfo__features > div:nth-child(4) > span.SiteCardInfo__features-item-value")
                      ).Text;

            building.ResidentialСomplexName = crhomeDriver.FindElement(
                      By.CssSelector("#root > div > div.PageContent__content > div.SitePage > div.SiteCard > div:nth-child(1) > div.SiteCardHeader__wrapper.SiteCardHeader__wrapper_position_relative > div.SiteCardHeader > div > div.SiteCardHeader__left > h1")
                      ).Text;
            

            try
            {
                building.Developer = crhomeDriver.FindElement(
                          By.CssSelector("#about > div.SiteCardAbout__right > div > div.CardDevBadge.SiteCardInfo__developer > div.CardDevBadge__text > a")
                          ).Text;
            }
            catch (Exception)
            {

                building.Developer = building.ResidentialСomplexName;
              
            }
           
           
            

            crhomeDriver.FindElement(

                      By.CssSelector("#about > div.SiteCardAbout__right > div > div.CardContacts > button ")
                      ).Click();
            building.Phone = crhomeDriver.FindElement(

                      By.CssSelector("#about > div.SiteCardAbout__right > div > div.CardContacts > button > span")
                      ).Text;

            try
            {
                building.Photos.photo = crhomeDriver.FindElements(
                               By.CssSelector("#about > div.SiteCardAbout__left > div > div.GalleryThumbs.SiteCardAbout__thumbs > div > div > img")
                               ).Select(a => a.GetAttribute("src")).ToList();
            }
            catch (Exception)
            {
                building.Photos.photo = null;


            }

            
            var tmp = url.Split('/', '-', '=');
             building.Id = tmp.Last()==""? tmp[tmp.Count()-2]: tmp.Last();

            return building;
        }


    }
}