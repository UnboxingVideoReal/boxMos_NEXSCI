using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;

namespace boxMos_NEXSCI
{
    public class Main
    {
        public static string query = "select pl_name,avg(ra),avg(dec) from PS group by pl_name";
        public static string url = $"https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query={query}";

        public static List<string> ARRAYOFPLANETS = new List<string>();
        public static async void Setup()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(url);
                XDocument xml = XDocument.Parse(result);
                Debug.WriteLine(result);

                // yea no idk what im doing i saw this on a stackoverflow thing and i tried to recreate it 
                /* what i want is to get each entry in the table (see "https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query=select pl_name,avg(ra),avg(dec) from PS group by pl_name" for the xml fiole)
                   and put it in the ARRAYOFPLANETS list but idk the dimensions of the table idk what the table looks like at all idk how to interpret this xml
                */
                var elements = xml.Descendants("VOTABLE").Elements("RESOURCE").Elements("TABLE").Elements("DATA").Elements("TABLEDATA").Elements("TR").Elements("TD").ToString();

                Debug.WriteLine(elements);
            }
        }
    }
}
