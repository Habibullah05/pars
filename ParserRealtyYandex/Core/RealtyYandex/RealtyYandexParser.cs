﻿using AngleSharp.Dom;
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
             var divs1 = document.QuerySelectorAll("SitesSerp__list > div > div:nth-child(2) > a");
            var divs = document.QuerySelectorAll("#root > div:nth-child(5) > div > div.SitesSerp__list > div:nth-child(1) > div:nth-child(2) > a");//.Where(item => item.Attributes["href"] != null);//.Select(x => x.TextContent);
            List<string> vs = new List<string>();
            List<string> vs1 = new List<string>();
            foreach (var item in divs)
            {
                vs.Add(item.TextContent);
            }
            foreach (var item in divs1)
            {
                vs1.Add(item.TextContent);
            }

            return vs.ToArray();
        }

        public string ParseCountPages(IHtmlDocument document)
        {

            ///var divs = document.QuerySelectorAll("SiteSnippetSearch.SitesSerp__snippet.Link.Link_js_inited.Link_size_m.Link_theme_islands").Where(item => item.Attributes["href"] != null).Select(x=>x.Attributes["href"]);
            var divs = document.QuerySelectorAll(" div:nth-child(5) > div > div.SitesSerp__footer > span > span > label:nth-child(9) > button > span > a");//.Select(x => x.TextContent);
            string page = divs.Last().TextContent;
            
            
            return page;
        }
    }
}