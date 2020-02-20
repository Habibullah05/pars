using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
   public class ClassAutorization
    {

        public async Task<LoginData> GetLoginData(string url = "/")
        {
            string data;
            var baseAddress = new Uri("https://passport.yandex.ru");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var result = await client.GetAsync(url);
                data = await result.Content.ReadAsStringAsync();
            }
            var uidCookie = cookieContainer.GetCookies(baseAddress).Cast<Cookie>().FirstOrDefault(x => x.Name == "yandexuid");
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(data);
            var csrf = htmlDoc.DocumentNode.SelectSingleNode("//body").GetAttributeValue("data-csrf", null);
            var tmp = new LoginData(uidCookie, csrf);
            return  tmp;
        }
        public async Task<string> SendPost(  Cookie cookie = null, string url = "https://passport.yandex.ru/auth", FormUrlEncodedContent content = null)
        {
            string data;
            var baseAddress = new Uri("https://passport.yandex.ru");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                if (cookie != null) cookieContainer.Add(cookie);
                var result = await client.PostAsync(url, content);
                data = await result.Content.ReadAsStringAsync();
            }

            return data;
        }
    }
}
