using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public interface IParserWorker<T> where T : class
    {
        Task Start();
    }
}
