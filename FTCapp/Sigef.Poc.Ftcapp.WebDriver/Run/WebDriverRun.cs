using OpenQA.Selenium;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.WebDriver.Util;
using System;
using System.Linq;

namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class WebDriverRun : WebDriverBase
    {
        //ComandoBuilder ComandoBuilder = new ComandoBuilder();
        //ResultadoBuilder ResultadoBuilder = new ResultadoBuilder();
        //ConceitoBuilder ConceitoBuilder = new ConceitoBuilder();
        //public DBObj rVM { get; set; }
        //public WebDriverRun(DBObj VM)
        //    : base(VM)
        //{
        //    VM.SelectedCaso.Cor = ConstCOR.NORMAL;
        //    VM.SelectedCaso.Comandos = ComandoBuilder.LimpaComandos(VM.SelectedCaso.Comandos);
        //    VM.SelectedCaso.Comandos = ComandoBuilder.RetiraComandosErro(VM.SelectedCaso.Comandos);

        //    VM.SelectedCaso.Resultados = ResultadoBuilder.CriaObjResultados(VM.SelectedCaso.Resultados);

        //    VM.SelectedCaso.SelectedResultado = ResultadoBuilder.CriaObjResultado(VM.SelectedCaso.Nome, VM.SelectedCaso.NomeEditavel, VM.SelectedCaso.Cod);
        //    VM.SelectedCaso.Resultados.Add(VM.SelectedCaso.SelectedResultado);
        //    var uriConceito = ConceitoBuilder.MontaUriConceito(VM.SelectedCaso.Transacao.NMPAGINA, VM.SelectedCaso.Transacao.CDTRANSACAO, ProjetoUtil._baseUri);
        //    AcessaConceito(uriConceito);
        //    //testComando();

        //    foreach (var cmd in VM.SelectedCaso.Comandos)
        //    {
        //        VM.SelectedCaso.SelectedResultado.Data = DateTime.Now;
        //        cmd.Data = DateTime.Now;
        //        RunCmd(cmd);

        //        cmd.Diferenca = DateTime.Now - cmd.Data;
        //        string nome = VM.SelectedCaso.Cod.ToString() + VM.SelectedCaso.SelectedResultado.Cod.ToString() + cmd.Cod;
        //        cmd.ScShot = ScreamShotUtil.GetScreamShot(GETIEDriver(), nome);
        //    }

        //    VM.SelectedCaso.Comandos = VM.SelectedCaso.Comandos;
        //    VM.SelectedCaso.SelectedResultado.Comandos = VM.SelectedCaso.Comandos;
        //    VM.SelectedCaso.SelectedResultado.ScrenShot = ScreamShotUtil.GetScreamShot(GETIEDriver(), VM.SelectedCaso.Cod.ToString() + VM.SelectedCaso.SelectedResultado.Cod);
        //    var elements = WebElementUtil.GetElementsBy(GETIEDriver(), By.ClassName("SIGEFMensagemErro"));
        //    VM.SelectedCaso.SelectedResultado.IsRodou = true;
        //    VM.SelectedCaso.SelectedResultado.IsPassou = false;
        //    VM.SelectedCaso.Cor = ConstCOR.ERRO;

        //    if (!VM.SelectedCaso.Comandos.Any(e => e.IsPassou == false))
        //    {
        //        VM.SelectedCaso.SelectedResultado.IsPassou = true;
        //        VM.SelectedCaso.Cor = ConstCOR.SUCCESS;
        //    }
        //    var elError = _driver.FindElements(By.ClassName("SIGEFMensagemErro"));
        //    if (elError.Count > 0 && elError[0].Text.Trim() != "")
        //    {
        //        VM.SelectedCaso.SelectedResultado.IsPassou = false;
        //        VM.SelectedCaso.SelectedResultado.MSG = "Mensagem de erro presente na tela";
        //        VM.SelectedCaso.Cor = ConstCOR.ERRO;
        //    }
        //    rVM = VM;

        //}


        //private void RunCmd(Comando item)
        //{
        //    try
        //    {
        //        switch (item.SelectedComandoSugerido)
        //        {
        //            case ConstActionCommand.ACTION_INSERT:
        //                //_driver.FindElement(By.Cod(item.Elemento.Cod)).SendKeys(item.ValueText);
        //                item = ComandUtil.RunSendKey(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstActionCommand.ACTION_CLICK:
        //                //_driver.FindElement(By.Cod(item.Elemento.Cod)).Click();
        //                item = ComandUtil.RunClick(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstActionCommand.ACTION_SELECT:
        //                item = ComandUtil.RunSelected(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstActionCommand.ACTION_CHECK:
        //                item = ComandUtil.RunCheck(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstValidationCommand.IS_ENABLE:
        //                item = ComandUtil.RunIsEnable(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);

        //                break;
        //            case ConstAssertionValueCommand.UI_VALUE_CONTAINS:
        //                item = ComandUtil.RunContains(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstAssertionValueCommand.UI_VALUE_MAIOR:
        //                item = ComandUtil.RunMaior(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstAssertionValueCommand.UI_VALUE_IGUAL:
        //                item = ComandUtil.RunIGUAL(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //            case ConstAssertionValueCommand.UI_VALUE_CHECKED:
        //                if (item.SelectedValue == ConstSugestionValue.Assertion_Value_TRUE)
        //                {
        //                    item = ComandUtil.RunSelected(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                }
        //                else if (item.SelectedValue == ConstSugestionValue.Assertion_Value_FALSE)
        //                {
        //                    item = ComandUtil.RunUnSelected(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                }
        //                break;
        //            case ConstAssertionUIVariavelCommand.UI_FORMULA:
        //                item = ComandUtil.RunFormula(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item, _VM);
        //                break;
        //            case ConstAssertionUIVariavelCommand.UI_CASO:
        //                //item = ComandUtil.RunFormula(WebElementUtil.GetWebElementByID(_driver, item.Elemento.Cod), item, _VM);
        //                break;
        //            case ConstValidationCommand.IS_VISIBLE:
        //                item = ComandUtil.RunIsVisible(WebElementUtil.GetWebElementByID(_driver, item.Elemento.CodigoUi), item);
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //        item.IsPassou = false;
        //    }
        //}

        //public void testComando()
        //{
        //    var newValue = "teste3";
        //    _driver.FindElement(By.Cod("txtBanco_SIGEFPesquisa")).SendKeys("4");
        //    _driver.FindElement(By.Cod("txtCodigo")).SendKeys("3");
        //    _driver.FindElement(By.Cod("btnManutencao_BtnConsultar")).Click();

        //    _driver.FindElement(By.Cod("txtNome")).Clear();
        //    _driver.FindElement(By.Cod("txtNome")).SendKeys(newValue);

        //    var btnAlterar = _driver.FindElement(By.Cod("btnManutencao_BtnAlterar"));
        //    if (btnAlterar.Enabled)
        //    {
        //        btnAlterar.Click();
        //    }
        //    string value2 = _driver.FindElement(By.Cod("txtNome")).GetAttribute("value");
        //    if (value2 == newValue)
        //    {
        //        System.Diagnostics.Debug.WriteLine("          sim");
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine("          nao");
        //    }
        //    _driver.Quit();
        //}



    }


}

