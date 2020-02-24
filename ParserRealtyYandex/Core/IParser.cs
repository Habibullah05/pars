
using System.Collections.Generic;

namespace ParserRealtyYandex.Core
{
    public interface IParser<T> where T:class
    {
        IEnumerable<string> ParseLinks(int page);
        T Parse(string index);
        int ParseCountPages();

    }
}
