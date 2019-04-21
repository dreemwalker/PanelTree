using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Xml;
namespace PanelTree.Models
{
    class XMLReader
    {
        private string filesPath;

        public XMLReader(string pathToFiles)
        {
            filesPath = pathToFiles;
        }
        public PanelsContainer GetPanels(string filename)
        {
            PanelsContainer container = new PanelsContainer();
            PanelItem panels= new PanelItem();
            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filesPath+filename);
           
            XmlElement xRoot = xDoc.DocumentElement;

            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            Preview p = new Preview();
            p.originalDocumentHeight = Convert.ToInt32(xRoot.Attributes.GetNamedItem("originalDocumentHeight").Value);
            p.originalDocumentWidth = Convert.ToInt32(xRoot.Attributes.GetNamedItem("originalDocumentWidth").Value);
            p.rootX = float.Parse(xRoot.Attributes.GetNamedItem("rootX").Value);
            p.rootY = float.Parse(xRoot.Attributes.GetNamedItem("rootY").Value);

            Thread.CurrentThread.CurrentCulture = temp_culture;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "panels")
                {
                    XmlNode rootPanelNode = xnode.FirstChild;
                    panels = GetPanelAttributesFromNode(rootPanelNode);
                    if (rootPanelNode.HasChildNodes)
                    {
                        panels.AttachedPanels = GetChildPanels(rootPanelNode);
                    }

                }

            }
            container.pw = p;
            container.panels = panels;
        
            return container;
        }

        

        private List<PanelItem> GetChildPanels(XmlNode node)
        {
            List<PanelItem> attachedPanels = new List<PanelItem>();
            XmlNode attachedItems = node.FirstChild;
            foreach (XmlNode item in attachedItems)
            {
                PanelItem tmp; 

                tmp = GetPanelAttributesFromNode(item);

                if (item.FirstChild.HasChildNodes)
                {
                   tmp.AttachedPanels = GetChildPanels(item);
                }
                attachedPanels.Add(tmp);
            }

            return attachedPanels;
        }

        private PanelItem GetPanelAttributesFromNode(XmlNode node)
        {
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            PanelItem res = new PanelItem();
            try
            {
                res.panelId = node.Attributes.GetNamedItem("panelId").Value;
                res.panelName = node.Attributes.GetNamedItem("panelName").Value;

                res.minRot= Convert.ToInt32( node.Attributes.GetNamedItem("minRot").Value);
                res.maxRot= Convert.ToInt32(node.Attributes.GetNamedItem("maxRot").Value);
                res.initialRot = Convert.ToInt32(node.Attributes.GetNamedItem("initialRot").Value);
                res.startRot = Convert.ToInt32(node.Attributes.GetNamedItem("startRot").Value);
                res.endRot = Convert.ToInt32(node.Attributes.GetNamedItem("endRot").Value);
           
                res.hingeOffset = float.Parse(node.Attributes.GetNamedItem("hingeOffset").Value);
         
                res.panelWidth = float.Parse(node.Attributes.GetNamedItem("panelWidth").Value);
                res.panelHeight = float.Parse(node.Attributes.GetNamedItem("panelHeight").Value);
            
                res.attachedToSide = Convert.ToInt32(node.Attributes.GetNamedItem("attachedToSide").Value);
            
           
                res.creaseBottom = float.Parse(node.Attributes.GetNamedItem("creaseBottom").Value);
                res.creaseTop = float.Parse(node.Attributes.GetNamedItem("creaseTop").Value);
                res.creaseLeft = float.Parse(node.Attributes.GetNamedItem("creaseLeft").Value);
                res.creaseRight = float.Parse(node.Attributes.GetNamedItem("creaseRight").Value);
            
                res.ignoreCollisions = Convert.ToBoolean(node.Attributes.GetNamedItem("ignoreCollisions").Value);
                res.mouseEnabled = Convert.ToBoolean(node.Attributes.GetNamedItem("mouseEnabled").Value);

            }
            catch (Exception e)
            {
                string s1 = node.Attributes.GetNamedItem("attachedToSide").Value;
                string s2 = node.Attributes.GetNamedItem("hingeOffset").Value;
            }

            Thread.CurrentThread.CurrentCulture = temp_culture;

            return res;
        }
      
    }
}
