using ParserRealtyYandex.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.RealtyYandex
{
   public class RealtyYandexSettings : IParserSettings
    {
        public string BaseUrl { get; set; } 
        public string PrefixSoloElement { get; set; }
        public string PrefixPage { get; set; }
        public int Pages { get; set; }
        public RealtyYandexSettings()
        {
            BaseUrl= ParserRealtyYandex.Properties.Settings.Default.BaseUrl;
            PrefixPage = ParserRealtyYandex.Properties.Settings.Default.PrefixPage;
        }
    }
}
