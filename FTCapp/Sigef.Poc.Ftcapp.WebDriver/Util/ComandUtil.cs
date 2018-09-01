using OpenQA.Selenium;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class ComandUtil
    {

        //public static Comando RunSendKey(IWebElement el, Comando cmd)
        //{

        //    var Resultado = "";
        //    var valorComando = cmd.ValueText;
        //    cmd.Cor = ConstCOR.SUCCESS;

        //    if (valorComando == null || string.IsNullOrEmpty(valorComando))
        //    {
        //        el.Clear();
        //        cmd.Acao = "";
        //        valorComando = "";
        //    }
        //    else
        //    {
        //        el.SendKeys(valorComando);
        //        Resultado = el.GetAttribute("value");
        //    }


        //    //cmd.onkeydown = el.GetAttribute("onkeydown");
        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = cmd.Acao == valorComando;
        //    return cmd;
        //}

        //public static Comando RunClick(IWebElement el, Comando cmd)
        //{
        //    try
        //    {
        //        el.Click();
        //        cmd.IsPassou = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //        cmd.IsPassou = false;
        //    }
        //    return cmd;
        //}

        //public static Comando RunMaior(IWebElement el, Comando cmd)
        //{
        //    var iv = 0;
        //    var ev = 0;

        //    var Resultado = "";
        //    var valorComando = cmd.ValueText;

        //    Resultado = el.GetAttribute("value");
        //    if (valorComando != null)
        //    {
        //        Int32.TryParse(valorComando, out iv);
        //        Int32.TryParse(Resultado, out ev);

        //    }
        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = iv > ev;
        //    return cmd;
        //}

        //public static Comando RunIGUAL(IWebElement el, Comando cmd)
        //{

        //    var Resultado = "";
        //    var valorComando = cmd.ValueText;

        //    Resultado = el.GetAttribute("value");

        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = cmd.Acao == valorComando;
        //    return cmd;
        //}

        //public static Comando RunSelected(IWebElement el, Comando cmd)
        //{

        //    var Resultado = "";
        //    Resultado = el.GetAttribute("value");
        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = cmd.IsPassou = el.GetAttribute("selected") == "true";
        //    return cmd;
        //}

        //public static Comando RunUnSelected(IWebElement el, Comando cmd)
        //{
        //    cmd = RunSelected(el, cmd);
        //    cmd.IsPassou = !cmd.IsPassou;
        //    return cmd;

        //}

        //public static Comando RunContains(IWebElement el, Comando cmd)
        //{
        //    var valorComando = cmd.ValueText;

        //    var Resultado = el.GetAttribute("value");

        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = Resultado.Contains(valorComando);
        //    return cmd;

        //}

        //public static Comando RunIsEnable(IWebElement el, Comando cmd)
        //{
        //    var valorComando = cmd.ValueText;

        //    var Resultado = el.GetAttribute("value");

        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = el.Enabled;
        //    return cmd;

        //}

        //public static Comando RunCheck(IWebElement el, Comando cmd)
        //{
        //    var valorComando = cmd.ValueText;

        //    var Resultado = el.GetAttribute("value");
        //    el.Click();
        //    bool passou = el.GetAttribute("checked") == "true";
        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = passou;
        //    return cmd;

        //}


        //public static Comando RunFormula(IWebElement el, Comando cmd, DBObj VM)
        //{
        //    var valorComando = cmd.ValueText;
        //    var valor = new  FormulaBuilder().Run(cmd.ValueText, VM);
        //    el.SendKeys(valor);
        //    var Resultado = el.GetAttribute("value");

        //    //cmd. = RunSelected(el, cmd);
        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = true;
        //    return cmd;

        //}


        //public static System.Collections.Generic.List<int> ListIdComandosCompostos { get; set; }

        //internal static Comando RunIsVisible(IWebElement el, Comando cmd)
        //{
        //    var valorComando = cmd.ValueText;

        //    var Resultado = el.GetAttribute("display");

        //    cmd.Acao = Resultado;
        //    cmd.IsPassou = Resultado != "none";
        //    return cmd;
        //}
    }
}
