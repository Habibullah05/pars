using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        string PrefixSoloElement { get; set; }
        string PrefixPage { get; set; }
        int Pages { get; set; }
    }
}
