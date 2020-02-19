using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ParserRealtyYandex.Core
{
    public class HtmlLoader
    {
        readonly HttpClient _client;
        readonly IParserSettings _settings;
        public HtmlLoader(IParserSettings settings)
        {
            _client = new HttpClient();
            _settings = settings;


        }

        public async Task<string> GetSourceByPage(int page)
        {
            string url = _settings.BaseUrl +_settings.Prefix+ (page>0? _settings.PrefixPage.Replace("{CurrentId}", page.ToString()):"" );
            string data = null;

            using (WebClient client = new WebClient())
            {
               
                data =await client.DownloadStringTaskAsync(url);
                client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            }


            return data;

        }

        public async Task<string> GetSourceById(string Id)
        {
            string url = _settings.BaseUrl + Id;
            var response = await _client.GetAsync(url);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK) source = await response.Content.ReadAsStringAsync();

            return source;
        }

        public async  Task<string> GetSoursePages()
        {
            string data = null;
            string url = _settings.BaseUrl + _settings.Prefix;
            // cefSharp
            // WebBrowser web = new WebBrowser();
            //CefSharp
            using (WebClient client = new WebClient())
            {
                data = await client.DownloadStringTaskAsync(url);
            }
            ////string url = _settings.BaseUrl;
            //var response = await _client.GetAsync(url);
            //string source = null;
            //if (response != null && response.StatusCode == HttpStatusCode.OK) source = await response.Content.ReadAsStringAsync();
            return data;

            }
        }
    }
