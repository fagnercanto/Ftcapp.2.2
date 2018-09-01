using System.Collections.Generic;

namespace Sigef.Poc.Ftcapp.Entidade
{
    public class XpathBuilder
    {
        public XpathBuilder(List<string> XPathExpressionList)
        {
            _XPathExpressionList = XPathExpressionList;
        }


        public List<string> _XPathExpressionList { get; set; }

        public string XPathExpression()
        {
            string expression = "";
            _XPathExpressionList.ForEach(e =>
            {
                expression += e + " and ";
            });
            return expression;
        }


    }
}
