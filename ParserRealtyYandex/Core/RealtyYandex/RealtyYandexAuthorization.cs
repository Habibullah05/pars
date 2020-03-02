using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core.RealtyYandex
{
    public class RealtyYandexAuthorization : IAuthorization
    {
        public string Url {get;}

        public string Login {get;}

        public string Password {get;}

        public string LoginInputSelect {get;}

        public string PasswordInputSelet {get;}
        public string ButtonLoginSelect { get;  }
        public string ButtonPasswordSelect { get;}


        public RealtyYandexAuthorization()
        {
            Url = ParserRealtyYandex.Properties.Settings.Default.AuthorizationUrl;
            Login = ParserRealtyYandex.Properties.Settings.Default.Login;
            Password = ParserRealtyYandex.Properties.Settings.Default.Password;
            LoginInputSelect= "#passp-field-login";
            PasswordInputSelet="#passp-field-passwd";
            ButtonLoginSelect = "#root > div > div > div.passp-flex-wrapper > div > div > div.passp-auth-content > div:nth-child(2) > div > div > div.passp-login-form > form > div.passp-button.passp-sign-in-button > button.control.button2.button2_view_classic.button2_size_l.button2_theme_action.button2_width_max.button2_type_submit.passp-form-button";
            ButtonPasswordSelect = "#root > div > div > div.passp-flex-wrapper > div > div > div.passp-auth-content > div:nth-child(2) > div > div > form > div.passp-button.passp-sign-in-button > button.control.button2.button2_view_classic.button2_size_l.button2_theme_action.button2_width_max.button2_type_submit.passp-form-button";

        }
    }
}
