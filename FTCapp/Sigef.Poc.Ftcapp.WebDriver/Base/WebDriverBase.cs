using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Sigef.Poc.FTCapp.Util;

using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.WebDriver.Util;
using System;
using System.Collections.Generic;

namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class WebDriverBase
    {

        //protected IWebDriver _driver;

        //protected DBObj _VM;


        //private List<string> _LabelsObrigatorios;
        //public List<string> LabelsObrogatorios
        //{
        //    get
        //    {
        //        if (CollectionUtil.IsNullOrEmpty(_LabelsObrigatorios))
        //        {
        //            var els = _driver.FindElements(By.ClassName(ConstClassName.SIGEFLabel_Padrao));
        //            _LabelsObrigatorios = new List<string>();
        //            foreach (IWebElement item in els)
        //            {
        //                var id = item.GetAttribute("codigo");
        //                var text = StringUtil.IsNullReturnEmpty(item.Text.ToString());
        //                if (!string.IsNullOrEmpty(id) && text.Contains("*"))
        //                {
        //                    _LabelsObrigatorios.Add(id);
        //                }

        //            }

        //        }
        //        return _LabelsObrigatorios;
        //    }
        //    set { _LabelsObrigatorios = value; }
        //}

        //public WebDriverBase(DBObj VM)
        //{


        //    ProcessUtil.KillProcess(ConstProccess.IE_BROWSER);
        //    ProcessUtil.KillProcess(ConstProccess.IE_DRIVER);
        //    _VM = VM;
        //    _driver = GETIEDriver();
        //    //_driver = GETIEDriver();
        //    AbrePaginaLogin(_driver);
        //    EfetuaLoginLogin();
        //    AcessaConceito(_PGConceito);
        //    //RuntimeArgumentHandle();
        //}
        //private const string _PGLogin = "http://flnserv013/SIGEF/SIGEFPortal.html";
        //private const string _PGInicial = "http://flnserv013/SIGEF2018/SEG/SEGPaginaInicial.aspx";
        //private const string _PGConceito = "http://flnserv013/SIGEF2018/FIN/FINManterAgenciaBancaria.aspx?CdTransacao=337";



        //private void AbrePaginaLogin(IWebDriver _driver)
        //{
        //    try
        //    {
        //        _driver.Url = _PGInicial;
        //        _driver.Url = _PGLogin;
        //    }
        //    catch (UnhandledAlertException uex)
        //    {
        //        Console.Write(uex.Message);
        //        _driver.Url = _PGLogin;
        //    }
        //}

        //public IWebDriver GETIEDriver()
        //{
        //    if (_driver == null)
        //    {
        //        _driver = _driver = new InternetExplorerDriver();
        //        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        //    }
        //    return _driver;
        //}

        //protected void AcessaConceito(string conceitoUri)
        //{
        //    try
        //    {
        //        _driver.Navigate().GoToUrl(conceitoUri);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new System.ArgumentException(ex.Message);
        //    }

        //}

        //private void EfetuaLoginLogin()
        //{
        //    try
        //    {

        //        _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe")));


        //        _driver.FindElement(By.Cod("txtSenha")).SendKeys("123"); ;
        //        _driver.FindElement(By.Cod("txtCPF")).SendKeys("04088701925"); ;


        //        try
        //        {
        //            _driver.FindElement(By.Cod("cmbEnviar")).Click();



        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine(ex.Message);
        //            _driver.Quit();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new System.ArgumentException(ex.Message);
        //    }

        //}

        //public Comando GetCommand(IWebElement e, DBObj VM)
        //{
        //    return new ComandoBuilder().BuildComando(e.Selected, e.TagName, e.Enabled, e.Displayed, e.Text, e.GetAttribute("type"), e.Text, e.Size.Height.ToString(), e.Size.Width.ToString(), e.Location.X, e.Location.Y, e.GetAttribute("class").ToString(), e.GetAttribute("codigo"), VM, GetLabel(e));
        //}


        //public string GetLabel(IWebElement e)
        //{
        //    string result = "";

        //    string Cod = StringUtil.IsNullReturnEmpty(e.GetAttribute("id"));

        //    if (Isbotao(e))
        //    {
        //        result = Cod.Replace("btnManutencao", "");
        //    }
        //    else
        //    {
        //        string xpath = "//*[@id='" + Cod + "']/preceding::span[string-length(text())>2][1]";
        //        result = _driver.FindElement(By.XPath(xpath)).Text;
        //    }
        //    return result;
        //}

        //private bool Isbotao(IWebElement el)
        //{
        //    bool result = false;
        //    var id = el.GetAttribute("id");
        //    if (!string.IsNullOrEmpty(id) && id.ToUpper().Contains("btnManutencao".ToUpper()))
        //    {
        //        result = true;
        //    }

        //    return result;
        //}

        //private bool IsCampoPesquisa(IWebElement e)
        //{
        //    return e.GetAttribute("class").Equals(ConstClassName.SIGEFPesquisa_INPUT);
        //}


    }
}
