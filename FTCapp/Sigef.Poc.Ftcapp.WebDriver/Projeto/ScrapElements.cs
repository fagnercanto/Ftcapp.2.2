using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.FTCapp.Util.DTO;
using Sigef.Poc.FTCapp.Util;
using System.Collections.Generic;
using System.Linq;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;

namespace Sigef.Poc.Ftcapp.WebDriver.Projeto
{
    public class ScrapElements : WebDriverPai
    {
        public List<ElementoScrap> GetSharedElements(ICollection<Rule> ruleList)
        {
            _ElementosScrap = new List<ElementoScrap>();
            foreach(var item in ruleList){
                var els = driver.FindElements(By.XPath(item.XPath));
                //var elss = driver.FindElements(By.XPath("//div[contains(@class,'modulo')]/descendant::a[string-length(text())>2]"));
                foreach (var el in els.Distinct()) {
                    var objel =  GetObjectElement(el);
                    _ElementosScrap.Add(objel);
                }
                
            }
            return _ElementosScrap;
        }

        private List<ElementoScrap> GetElementoScrap(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> els)
        {
            List<ElementoScrap> lt = new List<ElementoScrap>();
            
            if (els != null && els.Count > 0) {
                foreach(var el in  els){

                    var item =  GetObjectElement(el);
                    lt.Add(item);
                }
                
            
            }
            return lt;
        }

        private ElementoScrap GetObjectElement(IWebElement el)
        {
            string arquivo = "";
            
            ElementoScrap esp = new ElementoScrap();
            esp.Selected = el.Selected;
            esp.TagName = el.TagName;
            esp.Enable = el.Enabled;
            esp.Displayed = el.Displayed;
            esp.Text = string.IsNullOrEmpty(el.Text) ? el.GetAttribute("value") : el.Text;
            esp.Type = GetType(el);
            esp.Height = el.Size.Height.ToString();
            esp.Width = el.Size.Width.ToString();
            esp.X = el.Location.X;
            esp.Y = el.Location.Y;
            esp.ClassName = GetClassName(el);
            esp.UICodigo = GetUICodigo(el);
            esp.OnClick = GetOnClick(el);
            esp.Grid = GetIsGrid(esp.UICodigo, el.TagName);
            var classNameProximoCampo = "";
            esp.CampoPesquisa = GetIsCampoPesquisa(esp.UICodigo, el.TagName, esp.ClassName, classNameProximoCampo);
            esp.TabIndex = el.GetAttribute("tabindex");

            bool isBotao = IsbotaoORTab(esp.TagName, esp.TabIndex, esp.Type, esp.UICodigo);
            if (isBotao)
            {
                string src = el.GetAttribute("src");
                if (src!=null && src != "")
                {
                    arquivo = src.Split('/').Last().Split('.').First();
                    arquivo = arquivo.First().ToString().ToUpper() + arquivo.Substring(1).Replace("_"," ");
                }
                esp.Label = arquivo;
            }
            else {
                esp.Label = GetLabel(esp.TagName, el.GetAttribute("innerText"), esp.UICodigo);
            }
            

            
            return esp;
        }


        public bool GetIsCampoPesquisa(string Id, string tagname, string className, string classProximoCampo)
        {
            if (tagname != "input") { return false; }
            bool result = false;

            if (className.Contains("SIGEFPesquisa") || classProximoCampo.Contains("SIGEFPesquisa"))
            {
                result = true;
            }
            return result;
        }

        public string GetOnClick(IWebElement el)
        {
            return el.GetAttribute("onclick");
        }
        
        public string GetType(IWebElement el)
        {
            return el.GetAttribute("type");
        }
        
        public string GetUICodigo(IWebElement el)
        {
            return el.GetAttribute("id");
        }

        public string GetLabel(string tagName, string innerText, string UIcodigo)
        {
            
            string result = "";

            if (tagName == "a")
            {
                result = innerText;
            }
            else
            {
                string xpath = "//*[@id='" + UIcodigo + "']/preceding::span[string-length(text())>2][1]";
                var sresult = driver.FindElements(By.XPath(xpath));
                if (sresult.Count > 0)
                {
                    result = sresult[0].Text;
                }
            }
            if (result == "")
            {
                result = UIcodigo;
            }
            return result;
        }

        public bool GetIsGrid(string Id, string tagname)
        {
            if (tagname != "table") { return false; }
            
            return IsGrid(Id);
        }

        public bool GetIsComposto(string uiCodigo ,string tagName,string className)
        {

            if (tagName != "input") { return false; }
            bool result = false;


            if (className.Contains("_SIGEFPesquisa"))
            {
                result = true;
            }
            return result;
        }

        public bool GetIsCampoPesquisa(string Id, string tagname, string className)
        {

            if (tagname != "input") { return false; }
            bool result = false;

            if (className.Contains("_SIGEFPesquisa"))
            {
                result = true;
            }
            else {
                result = IsCampoPesquisa(Id);
            }
            return result;
        }


        public bool GetIsCampoPesquisaREFAZER(string Id, string tagname, string className)
        {

            if (tagname != "input") { return false; }
            bool result = false;

            if (className.Contains("_SIGEFPesquisa"))
            {
                result = true;
            }
            else
            {
                result = IsCampoPesquisa(Id);
            }
            return result;
        }
        private bool IsGrid(string id)
        {
            bool result = false;
            var rs = driver.FindElements(By.XPath(string.Format(ConstUtil.XPATH_GRID, id)));

            if (rs != null && rs.Count > 0)
            {
                result = true;
            }
            return result;
        }

        private bool IsComposto(string id)
        {
           
            bool result = false;
           
            ////input[@id='txtNuEditalLicitacao_SIGEFPesquisa'][(./preceding::span[string-length(text())<=2]) and position() = 1]
            var rs = driver.FindElements(By.XPath(string.Format(ConstUtil.XPATH_COMANDO_COMPOSTO_COM_SPAN, id)));

            if (rs != null && rs.Count > 0)
            {
                result = true;
            }

            return result;
        }


        private bool IsCampoPesquisa(string id)
        {

            bool result = false;

            
            var rs = driver.FindElements(By.XPath(string.Format(ConstUtil.XPATH_PRIMEIRO_CAMPO_PESQUISA, id)));

            if (rs != null && rs.Count > 0)
            {
                result = true;
            }

            return result;
        }


        private bool IsbotaoORTab(string TagName, string Tabindex, string type, string id)
        {
            if (type == "image" && TagName == "input") 
            {
                return true;
            }

            if (Tabindex!=null && type!="text")
            {
                return true;
            }
            
            if (!string.IsNullOrEmpty(id) && (id.ToUpper().Contains("SIGEFBotoesManutencao".ToUpper()) || id.ToUpper().Contains("btn".ToUpper()) ))
            {
                return  true;
            }

            return false;
        }

        public List<ValorSugestao> GetComboboxOptions(string Id)
        {
            List<ValorSugestao> result = new List<ValorSugestao>();
            var select = new SelectElement(driver.FindElement(By.Id(Id)));
            if (select.Options != null)
                select.Options.ToList().ForEach(e =>
                {
                    result.Add(new ValorSugestao { valor = e.Text });
                });
            return result;
        }


        public string GetClassName(IWebElement el)
        {
            return el.GetAttribute("class");
        }

        public ScrapElements(IWebDriver pdriver)
        {
            // TODO: Complete member initialization
            driver = pdriver;
        }
    }
}
