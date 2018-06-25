using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CVeditor.Helpers
{
    public static class XDocumentHelper
    {
        public static string DescendantElement(this XDocument xDocument, string nodeName)
        {
            var Xelements= xDocument.Descendants().Where(p => p.Name.LocalName == nodeName).ToList();
            var element = Xelements[0].Value;
            return element;
        }
    }
}