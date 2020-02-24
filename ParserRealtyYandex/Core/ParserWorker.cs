using ParserRealtyYandex.Core.RealtyYandex;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public class ParserWorker<T> where T : class
    {
        private readonly IParser<T> _parser;
        private readonly IParserSettings _parserSettings;
        
        public bool IsActive { get; private set; }



        #region Constructor
        public ParserWorker(IParser<T> parser) {
            
            this._parser = parser;
        
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser) => this._parserSettings = parserSettings;

        #endregion

        public async Task Start()
        {
            IsActive = true;
             Worker();
        }

        public async Task Abort()
        {
            IsActive = false;
        }

        private async Task Worker()
        {
           // _parserSettings.Pages = _parser.ParseCountPages();
            List<string> links = new List<string>();
            //for (int i = 0; i < _parserSettings.Pages; i++)
            //{
            // links.AddRange(_parser.ParseLinks(i));             

            //}
            links.Add("https://realty.yandex.ru/perm/kupit/novostrojka/?page=2");
                GetBuilding(links);
        }

        private async Task GetBuilding(List<string> links)
        {
            List<Building> buildings = new List<Building>();
            for (int i = 0; i < links.Count; ++i)
            {
                try
                {
                buildings.Add(_parser.Parse(links[i]) as Building);

                }
                catch (System.Exception)
                {
                    --i;
                }
            }
               BuildingSerealize(buildings);

        }

        private async Task BuildingSerealize(List<Building> buildings)
        {
           Helper<List<Building>>.SerializeT(buildings);
        }
    }
}
