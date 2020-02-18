using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ParserRealtyYandex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.RealtyYandex
{
   public class RealtyYandexParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            
             ///var divs = document.QuerySelectorAll("SiteSnippetSearch.SitesSerp__snippet.Link.Link_js_inited.Link_size_m.Link_theme_islands").Where(item => item.Attributes["href"] != null).Select(x=>x.Attributes["href"]);
            var divs = document.GetElementsByClassName("SitesSerp__items > div > a").Where(item => item.Attributes["href"] != null).Select(x => x.Attributes["href"].Value);
           
            return divs.ToArray();
        }

        public string ParseCountPages(IHtmlDocument document)
        {

            ///var divs = document.QuerySelectorAll("SiteSnippetSearch.SitesSerp__snippet.Link.Link_js_inited.Link_size_m.Link_theme_islands").Where(item => item.Attributes["href"] != null).Select(x=>x.Attributes["href"]);
            var divs = document.GetElementsByClassName("#root > div:nth-child(5) > div > div.SitesSerp__footer > span > span > label:nth-child(9) > button > span > a").Select(x => x.NodeValue);
            string page = divs.Last();
            return page;
        }
    }
}