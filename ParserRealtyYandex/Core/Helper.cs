using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace ParserRealtyYandex.Core
{
    public class Helper<T> where T : class
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public static async Task SerializeT(T obj)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (var sw = new StreamWriter("result.xml",true))
            {
                formatter.Serialize(sw, obj);               
            }
          //  MessageBox.Show("End");
            }
            catch { }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
