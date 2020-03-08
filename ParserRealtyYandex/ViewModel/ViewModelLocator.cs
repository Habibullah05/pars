using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using ParserRealtyYandex.Core;
using ParserRealtyYandex.Core.RealtyYandex;
using ParserRealtyYandex.RealtyYandex;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParserRealtyYandex.ViewModel
{
    
    public class ViewModelLocator
    {
        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IParser<BuildingInfo>, RealtyYandexParser>();
            SimpleIoc.Default.Register<IParserSettings, RealtyYandexSettings>();
            SimpleIoc.Default.Register<IAuthorization, RealtyYandexAuthorization>();
            SimpleIoc.Default.Register<IChromeWork, ChromeWork>();
                     
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
          
        }
    }
}