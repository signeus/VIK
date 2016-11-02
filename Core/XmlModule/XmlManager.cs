using System.Xml;
using System.Collections.Generic;
using VIK.Core.Entities;

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

        public List<CommandEntity> RecoverItems()
        {
            List<CommandEntity> resultList = new List<CommandEntity>();
            XmlNodeList grammar = xDoc.GetElementsByTagName("grammar");
            XmlNodeList lista = ((XmlElement)grammar[0]).GetElementsByTagName("rule");
            foreach (XmlElement nodo in lista)
            {
                XmlNodeList items = nodo.GetElementsByTagName("item");
                if (items.Count > 0)
                {
                    foreach (XmlElement elem in items)
                    {
                        if (!string.IsNullOrWhiteSpace(elem.InnerText))
                        {
                            CommandEntity entity = new CommandEntity();
                            entity.VoiceCommand = elem.FirstChild.InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                            XmlNodeList tags = elem.GetElementsByTagName("tag");
                            foreach (XmlElement tag in tags)
                            {
                                string tagContext = tag.InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                                string[] attribs = tagContext.Split(';');
                                Dictionary<string, string> attributes = new Dictionary<string, string>();

                                foreach (var attrib in attribs)
                                {
                                    if (attrib.Contains(":"))
                                    {
                                        string[] pair = attrib.Split(':');
                                        attributes.Add(pair[0], pair[1]);
                                    }
                                }

                                if (attributes.Count > 0)
                                {
                                    entity.KeyCommand = attributes["asignedkey"];
                                    entity.Descrption = attributes["description"];
                                    entity.Speaking = attributes["speak"];
                                }
                                resultList.Add(entity);
                            }
                        }
                    }
                }
            }
            return resultList;
        }

        public bool CreateXml(string filename) //CommandEntity entity, 
        {
            XmlDocument doc = new XmlDocument();


            //Node Root Grammar
            doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            XmlNode nodeGrammar = doc.CreateElement("grammar");
           

            Dictionary<string, string> listAttribsGrammar = new Dictionary<string, string>();
            listAttribsGrammar.Add("version", "1.0");
            listAttribsGrammar.Add("xml:lang", "es-ES");
            listAttribsGrammar.Add("xmlns", "http://www.w3.org/2001/06/grammar");
            listAttribsGrammar.Add("tag-format", "semantics/1.0");
            listAttribsGrammar.Add("root", "Main");
            
            CreateAttributes(doc, nodeGrammar, listAttribsGrammar);

            //Node Rule Main
            XmlNode nodeMainRule = doc.CreateElement("rule");

            Dictionary<string, string> listAttribsMainRule = new Dictionary<string, string>();
            listAttribsMainRule.Add("id", "Main");

            CreateAttributes(doc, nodeMainRule, listAttribsMainRule);

            XmlNode nodeItem = doc.CreateElement("item");
            nodeMainRule.AppendChild(nodeItem);

            XmlNode nodeRuleRef = doc.CreateElement("ruleref");
            Dictionary<string, string> ruleRefList = new Dictionary<string, string>();
            ruleRefList.Add("uri", "#test"); //Reference to Name of Id Rule
            CreateAttributes(doc, nodeRuleRef, ruleRefList);

            nodeItem.AppendChild(nodeRuleRef);

            //Node Rule with items
            XmlNode nodeRule = doc.CreateElement("rule");

            Dictionary<string, string> listAttribsRules = new Dictionary<string, string>();
            listAttribsRules.Add("id", "Test");  //Name of Id Rule
            listAttribsRules.Add("scope", "public");

            XmlNode nodeOneOf = doc.CreateElement("one-of");
            nodeRule.AppendChild(nodeOneOf);

            //Foreach element in list
            XmlNode nodeItemElem = doc.CreateElement("item");
            nodeItemElem.InnerText = "Pestaña \n";
            nodeOneOf.AppendChild(nodeItemElem);
            XmlNode nodeTag = doc.CreateElement("tag");
            nodeTag.InnerText = "\t\n asignedkey:J; \n";
            nodeItemElem.AppendChild(nodeTag);

            CreateAttributes(doc, nodeRule, listAttribsRules);

            nodeGrammar.AppendChild(nodeMainRule);
            nodeGrammar.AppendChild(nodeRule);

            doc.AppendChild(nodeGrammar);

            doc.Save(filename);

            return true;
        }
        
        private void CreateAttributes(XmlDocument doc, XmlNode node, Dictionary<string, string> dictionary)
        {
            foreach(var row in dictionary)
            {
                XmlAttribute attr = doc.CreateAttribute(row.Key);
                attr.Value = row.Value;

                //Add the attribute to the document.
                node.Attributes.Append(attr);
            }
        }
    }
}
