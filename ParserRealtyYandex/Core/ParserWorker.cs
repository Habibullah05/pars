using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserRealtyYandex.Core
{
    public class ParserWorker<T> where T : class
    {
        private IParser<T> parser;
        private IParserSettings parserSettings;
        private HtmlLoader loader;
        public bool IsActive { get; private set; }

        #region Protorties
        public IParserSettings Settings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }
        public IParser<T> Parser
        {
            get { return parser; }
            set
            {
                parser = value;
            }
        }

        #endregion

        #region Constructor
        public ParserWorker(IParser<T> parser) => this.parser = parser;
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser) => this.parserSettings = parserSettings;

        #endregion

        public async Task Start()
        {
            IsActive = true;
            await Worker();
        }

        public async Task Abort()
        {
            IsActive = false;
        }

        private async Task Worker()
        {
            string page = await loader.GetSoursePages();
            Settings.Pages = int.Parse(page);
            for (int i = 0; i < Settings.Pages; i++)
            {
                if (!IsActive) return;

                var source = await loader.GetSourceByPage(i);
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(source);

                parser.Parse(document);


            }
        }



    }
}
