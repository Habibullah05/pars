using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
   public interface IChromeWork
    {
        IEnumerable<string> GetSelectAttributeBySelector(string select, string attribute);
        IEnumerable<string> GetTextsBySelector(string select);
        void SetUrl(string url);
        void AddNewTab(string url);
        void SetInputValue(string select, string value);
        string GetTextBySelector(string select);
        void ClickBySelector(string select);
    }
}
