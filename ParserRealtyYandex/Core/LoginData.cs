using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public class LoginData
    {
        public LoginData(Cookie uid, string csrf)
        {
            Uid = uid;
            CSRF = csrf;
        }

        public Cookie Uid { get; set; }
        public string CSRF { get; set; }
    }
}
