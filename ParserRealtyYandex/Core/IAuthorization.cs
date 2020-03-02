using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public interface IAuthorization
    {
        string Url { get; }
        string Login { get;  }
        string Password { get;  }
        string LoginInputSelect { get;  }
        string PasswordInputSelet { get;  }
         string ButtonLoginSelect { get;  }
        string ButtonPasswordSelect { get;  }


    }
}
