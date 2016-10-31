using System.Xml;
using System.Collections.Generic;

namespace VIK.Core.XmlModule
{
    class XmlManager
    {
        XmlDocument xDoc = null;

        public XmlManager()
        {
            xDoc = new XmlDocument();
        }
        
        public void LoadFile(string fileName)
        {
            xDoc.Load(fileName);
        }

        public void LoadFileByDictionary(Dictionary<string, string> dictionary, string fileNameSelected)
        {
            xDoc.Load(dictionary[fileNameSelected]);
        }

        public List<string> RecoverItems()
        {
            List<string> resultList = new List<string>();
            XmlNodeList grammar = xDoc.GetElementsByTagName("grammar");
            XmlNodeList lista = ((XmlElement)grammar[0]).GetElementsByTagName("rule");
            foreach (XmlElement nodo in lista)
            {
                XmlNodeList items = nodo.GetElementsByTagName("item");
                if (items.Count > 0)
                {
                    foreach (XmlElement elem in items)
                    {
                        if(!string.IsNullOrWhiteSpace(elem.InnerText))
                            resultList.Add(elem.InnerText);
                    }
                }
            }
            return resultList;
        }
    }
}
