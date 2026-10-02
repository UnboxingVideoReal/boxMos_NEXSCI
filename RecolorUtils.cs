using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace boxMos_NEXSCI
{

    public static class RecolorUtils
    {
        
        public static HttpClient web = new HttpClient();

        /// <summary>
        /// convert a string, usually one returned by <see cref="Fetch(string)"/>-ing from a website. this will probably return the same thing but i wanna be safe so
        /// </summary>
        /// <param name="name">name of the file, include .xml at the end btw. dont need to do content\\ ora nything</param>
        /// <param name="xmlstring">contents of the string youw ant to convert to xml</param>
        /// <returns>xml xmldocument</returns>
        public static XmlDocument StringToXML(string name, string xmlstring)
        {
            XmlDocument doc = new XmlDocument();
            var iguessbro = xmlstring;
            doc.LoadXml(iguessbro.ToString());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("Content\\" + name + ".xml", settings))
            {
                doc.Save(writer);
            }
            doc.Load("Content\\" + name + ".xml");

            Debug.WriteLine(name + " created");
            return doc; 
        }
        /// <summary>
        /// use <see cref="HttpClient"/> to fetch a website
        /// </summary>
        /// <param name="site">site</param>
        /// <returns>string</returns>

        public static async Task<string> Fetch(string site)
        {
            using HttpResponseMessage response = await web.GetAsync(site);
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Debug.WriteLine("fetched " + site);
            return await responseBody;
        }

        public static XDocument CreateXDocument(string path)
        {
            using (XmlReader reader = XmlReader.Create(path, new XmlReaderSettings()))
            {
                return XDocument.Load(reader);
            }
        }

        public static string SearchInContent(string file)
        {
            string[] content = Directory.GetFiles(Main.directory);
            string flippy = "0x80070002 - The system cannot find the file specified.";
            string filePath = Path.Combine(Main.directory, file);
            foreach (string item in content)
            {
                if (item == filePath)
                {
                    flippy = item;
                    break;
                }

            }
            Debug.WriteLine(flippy);
            return flippy;
        }

        public static T Convert<T>(this XElement gubby, string name) where T : notnull
        {
            var def = default(T);

            if (gubby != null)
            {
                var gub = gubby.Element(name);
                if (gub != null)
                {
                    string value = gub.Value;
                    if (value != null)
                    {
                        def = (T)System.Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
                    }
                }
            }
            return def;
        }

        public static List<T> ReadXDoc<T>(XDocument xdoc, string element) where T : notnull
        {
            List<T> _return = new List<T>();
            foreach (XElement entry in xdoc.Descendants())
            {
                if (entry.Name.LocalName == element)
                {
                    var omg = (T)System.Convert.ChangeType(entry.Value.Trim(), typeof(T), CultureInfo.InvariantCulture);
                    _return.Add(omg);
                }
            }
            return _return;

        }

        public static async Task<XmlDocument> FetchandXml(string link)
        {
            string testXML = await Fetch(link);
            XmlDocument xml = StringToXML("test", testXML);
            return xml;
        }

        public static async Task<List<T>> sFetchandRead<T>(string link, string element) where T : notnull
        {
            XmlDocument wa = await FetchandXml(link);
            //Debug.WriteLine(wa.OuterXml);

            string path = new Uri(wa.BaseURI).LocalPath; // null cuz loadxml
            //Debug.WriteLine(path);
            XDocument xdoc = CreateXDocument(path);
            return ReadXDoc<T>(xdoc, element);

        }

        //public static List<T> PlotXML<T>(string path)
        //{
        //    List<T> list = new List<T>();
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(path);

        //    XmlReaderSettings settings = new XmlReaderSettings();

        //    using (XmlReader reader = XmlReader.Create(path, settings))
        //    {
        //        XDocument xdoc = XDocument.Load(reader);

        //        List<string> nodes = xdoc.Descendants().Select(x => x.Name.LocalName).Distinct().ToList();

        //        reader.MoveToContent();

        //        while (reader.Read())
        //        {
        //            if (reader.NodeType == XmlNodeType.Element)
        //            {

        //            }
        //        }
        //    }
        //}
    }
}



// THE XML PROCESS:
/*          XmlDocument wa = await testXml();
            Debug.WriteLine(wa.OuterXml);

            string path = new Uri(wa.BaseURI).LocalPath; // null cuz loadxml
            Debug.WriteLine(path);
            XDocument xdoc = RecolorUtils.CreateXDocument(path);
            List<string> names = RecolorUtils.ReadXDoc<string>(xdoc, "TR");
            Debug.WriteLine(names);
*/

// * first, load the XmlDocument from FetchandXml(link)
// * then, save the uri.localpath to var
// * createxdocument(path)
// * readxdoc<T>(xdoc, element)

// OR: use sFetchandRead<T>(link) - easy!