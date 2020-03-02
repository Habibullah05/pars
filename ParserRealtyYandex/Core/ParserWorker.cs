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
        readonly ConcurrentBag<Building> buildings; 
        readonly ConcurrentBag<BuildingInfo>  buildingInfos; 





        #region Constructor
        public ParserWorker(IParser<T> parser) { 
        
            this._parser = parser;
            buildings = new ConcurrentBag<Building>();
            buildingInfos = new ConcurrentBag<BuildingInfo>();
        }        
        
        
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser) => this._parserSettings = parserSettings;

        #endregion

        public async Task Start()
        {
          
            await Worker();
        }

       
        private async Task Worker()
        {
            _parserSettings.Pages = _parser.ParseCountPages();
            List<string> links = new List<string>();
            for (int i = 0; i < _parserSettings.Pages; i++)
            {
               // links.AddRange();
            await  GetBuilding(_parser.ParseLinks(i).ToList());

            }
            //links.Add("https://realty.yandex.ru/perm/kupit/novostrojka/motovilihinsky-553773/");

        }

        private async Task GetBuilding(List<string> links)
        {
           
            for (int i = 0; i < links.Count; ++i)
            {
               
                buildings.Add(_parser.Parse(links[i]) as Building);

                
            }
               await BuildingSerealize(buildings);

        }

        private async Task BuildingSerealize(ConcurrentBag<Building> buildings)
        {
          await Helper<ConcurrentBag<Building>>.SerializeT(buildings);
        }
    }
}
