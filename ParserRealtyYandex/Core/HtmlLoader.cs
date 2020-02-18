using System;
using System.Collections.Generic;
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
           string url = _settings.BaseUrl + _settings.PrefixPage.Replace("{CurrentId}", page.ToString());
            var response = await _client.GetAsync(url);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK) source = await response.Content.ReadAsStringAsync();


                return source;

        }

        public async Task<string> GetSourceById(string Id)
        {
            string url = _settings.BaseUrl + Id;
            var response = await _client.GetAsync(url);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK) source = await response.Content.ReadAsStringAsync();
            
            return source;
        }

        public async Task<string> GetSoursePages()
        {
            string url = _settings.BaseUrl;
            var response = await _client.GetAsync(url);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK) source = await response.Content.ReadAsStringAsync();

            return source;
        }
    }
}
