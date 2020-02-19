using AngleSharp.Html.Dom;

namespace ParserRealtyYandex.Core
{
    public interface IParser<T> where T:class
    {
        T Parse(IHtmlDocument document);
        string ParseCountPages(IHtmlDocument document);

    }
}
