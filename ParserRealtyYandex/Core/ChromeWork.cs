using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public class ChromeWork : IChromeWork
    {
        readonly IWebDriver _crhomeDriver;
        readonly IAuthorization _authorization;
        public ChromeWork(IAuthorization authorization)
        {
            _authorization = authorization;

            _crhomeDriver = new ChromeDriver();
            Auth();


        }
        private void Auth()
        {

            SetUrl(_authorization.Url);
            SetInputValue(_authorization.LoginInputSelect, _authorization.Login);
            ClickBySelector(_authorization.ButtonLoginSelect);
            Thread.Sleep(1000);
            SetInputValue(_authorization.PasswordInputSelet, _authorization.Password);
            ClickBySelector(_authorization.ButtonPasswordSelect);
            _crhomeDriver.Navigate().GoToUrl(_authorization.Url);

        }

        public void ClickBySelector(string select)
        {
            FintElemetBySelector(select).Click();

        }

        public string GetTextBySelector(string select)
        {

            return FintElemetBySelector(select).Text;
        }

        public IEnumerable<string> GetTextsBySelector(string select)
        {
            return _crhomeDriver.FindElements(
                       By.CssSelector(select)
                       ).Select(e => e.Text);
        }

        public IEnumerable<string> GetSelectAttributeBySelector(string select, string attribute)
        {
            return _crhomeDriver.FindElements(
                        By.CssSelector(select)
                        ).Select(a => a.GetAttribute(attribute));
        }

        public void SetInputValue(string select, string value)
        {
            FintElemetBySelector(select).SendKeys(value);
        }

        public void SetUrl(string url)
        {
            _crhomeDriver.Navigate().GoToUrl(url);
        }
        public void AddNewTab(string url)
        {
            _crhomeDriver.Navigate().GoToUrl(url);
            SetUrl(url);
         
        }
      

        public IWebElement FintElemetBySelector(string select)
        {
            return _crhomeDriver.FindElement(By.CssSelector(select));
        }
        public ICollection<IWebElement> FintElemetsBySelector(string select)
        {
            return _crhomeDriver.FindElements(By.CssSelector(select));
        }
    }
}
