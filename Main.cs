using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Xml;

namespace boxMos_NEXSCI
{
    public class Main
    {
        public static string query = "select pl_name,avg(ra),avg(dec) from PS group by pl_name";
        public static string url = $"https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query={query}";
        public static async void Setup()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(url);
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(result);
                Debug.WriteLine(result);
            }
        }
    }
}
