using ParserRealtyYandex.Core.RealtyYandex;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public class ParserWorker<T> where T : class
    {
        private readonly IParser<T> _parser;
        private readonly IParserSettings _parserSettings;
      
        readonly ConcurrentBag<BuildingInfo>  buildingInfos; 





        #region Constructor
        public ParserWorker(IParser<T> parser) { 
        
            this._parser = parser;
            //buildings = new ConcurrentBag<Building>();
            buildingInfos = new ConcurrentBag<BuildingInfo>();
        }        
        
        
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser) => this._parserSettings = parserSettings;

        #endregion

        public async Task Start()
        {
          
             Worker();
        }

       
        private async Task Worker()
        {
           // _parserSettings.Pages = _parser.ParseCountPages();
            List<string> links = new List<string>();
            //for (int i = 0; i < _parserSettings.Pages; i++)
            //{
            //    links.AddRange(_parser.ParseLinks(i));

            //}
             links.Add("https://realty.yandex.ru/perm/kupit/novostrojka/kirovogradskaya-180-549967/");
             GetBuilding(links.ToArray());

        }

        private async Task GetBuilding(string[] links)
        {
           
            for (int i = 0; i < links.Count(); ++i)
            {

                buildingInfos.Add(_parser.Parse(links[i]) as BuildingInfo);

                
            }
               await BuildingSerealize(buildingInfos);

        }

        private async Task BuildingSerealize(ConcurrentBag<BuildingInfo> buildings)
        {
          await Helper<ConcurrentBag<BuildingInfo>>.SerializeT(buildings);
        }
    }
}
