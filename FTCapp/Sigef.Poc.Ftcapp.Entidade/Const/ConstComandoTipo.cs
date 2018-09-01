
namespace Sigef.Poc.Ftcapp.Entidade.Const
{
    public class ConstTipoComando
    {
        public const string TYPE_ACTION_ELEMENT = "ACTION";
        public const string TYPE_ACTION_WEBDRIVER = "TYPE_ACTION_WEBDRIVER";
        public const string TYPE_VALIDATION_ELEMENT_STATE = "TYPE_VALIDATION_ELEMENT_STATE";
        public const string TYPE_VALIDATION_ELEMENT_VALUE = "TYPE_VALIDATION_ELEMENT_VALUE";
        public const string TYPE_VARIAVEL = "TYPE_VARIAVEL";
    }


    public class ConstActionCommand
    {
        public const string ACTION_SWITCH_TO_CONTAIS = "Ir para url que contem";
        public const string ACTION_INSERT = "Inserir";
        public const string ACTION_INSERT_IF_EMPTY = "Inserir se vazio";
        public const string ACTION_CLICK = "Clicar";
        public const string ACTION_CLICK_ONCLIK = "public const string ACTION_CLICK =";
        public const string ACTION_SELECT = "Selecionar";
        public const string ACTION_CHECK = "Check";

        public const string ACTION_SWITCH_TO = "Ir Para a url";

        public const string ACTION_GRID_GETFIRST_ITEM = "Primeiro item da grid";

        public const string ACTION_RUN_JS = "Rodar Javascript";
        public const string ACTION_CLOSE_ALERT = "Fechar janela alerta";

        public const string ACTION_SCRAP = "Busca Elementos";

        public const string ACTION_SWITCH_TO_FRAME = "IR Para o Frame";
        public const string ACTION_SWITCH_TO_LAST = "Ir para popup";

        public const string ACTION_SWITCH_TO_BACK = "Voltar pagina";

        public const string ACTION_GO_TO = "Abrir Pagina";

        public const string ACTION_SET_TEXT_VARIAVEL = "SET VARIAVEL";

        public const string ACTION_NO = "NO_ACTION";

        public const string ACTION_ClOSE_ALL_PAGES = "Fechar todas as janelas";
    }
    public class ConstAssertionValueCommand
    {

        //validacoes
        public const string UI_VALUE_CONTAINS = "Contem";
        public const string UI_VALUE_MAIOR = "Maior";
        public const string UI_VALUE_IGUAL = "Igual";
        public const string UI_VALUE_CHECKED = "Checked";

    }

    public class ConstValidationCommand
    {

        //validacoes
        public const string IS_VISIBLE = "Esta visível";
        public const string IS_NOT_VISIBLE = "Não esta visível";
        public const string IS_ENABLE = "Esta habilitado";
        public const string IS_NOT_ENABLE = "Não esta habilitado";
        public const string IS_CHECKED = "Esta checked";
        public const string IS_UNCHECKED = "Não esta checked";

        public const string CONTAINS = "Acao contem";
        public const string NOT_CONTAINS = "Acao não Contem";
        public const string IS_MAIOR = "Acao é maior que";
        public const string IS_MENOR = "Acao é menor que";
        public const string IS_IGUAL = "Acao é igual a";
        public const string IS_DIFERENTE = "Acao é diferente de";


    }

    public class ConstAssertionUIVariavelCommand
    {

        //validacoes

        public const string UI_FORMULA = "Formula";
        public const string UI_CASO = "Caso Uso";

    }


    public class ConstSugestionValue
    {

        public const string Assertion_Value_TRUE = "SIM";
        public const string Assertion_Value_FALSE = "NAO";

    }

    public class ConstControlTypeUI
    {
        public const string TYPE_TEXTBOX = "TextBox";
        public const string TYPE_BUTTON = "Botão";
        public const string TYPE_COMBOBOX = "ComboBoxk";
        public const string TYPE_CHECKBOX = "CheckBox";
        public const string TYPE_TABLE_ITEM = "TableItem";
        public const string TYPE_GRID = "Grid";
        public const string TYPE_CELL_GRID = "CellGrid";
        public const string TYPE_MSG = "MSG";
        public const string TYPE_TEXTBOX_PESQUISA = "TextBoxPesquisa";
        public const string TYPE_PESQUISA = "BOTAO_PESQUISA(?)";
        public const string TYPE_TAB = "TYPE_TAB";

        public const string TYPE_CELL = "TYPE_CELL";

        public const string TYPE_PAGINA = "PAGINA";

        public const string TYPE_IFRAME = "IFRAME";
        public const string TYPE_LINK = "LINK";
        
        public const string TYPE_CASO_USO = "CASO";
        public const string TYPE_FORMULA = "FORMULA";
        public const string TYPE_VARIAVEL = "VARIAVEL";
        


    }
    public class ConFigDefault
    {
        public const string XPATH_SCRAP = "//*[@codigo][not(contains(@codigo,'__VIEWSTATE') or contains(@codigo,'tooltip') or contains(@codigo,'aba') or contains(@codigo,'hdn') or contains(@codigo,'hidden') or contains(@codigo,'tb') or contains(@codigo,'TD') or contains(@codigo,'lbl') or contains(@codigo,'div') or contains(@codigo,'Form1')  or contains(@codigo,'msg')   )]";
    }

    public class ConstCOR
    {
        public const string ERRO = "Red";
        public const string SUCCESS = "Green";
        public const string NORMAL = "#FF119EDA";
        public const string WARNING = "#FF999900";
    }

    public class ConstMensagem
    {
        public const string ERRO = "ERRO";
        public const string SUCCESS = "SUCCESS";
        public const string NORMAL = "NORMAL";
        public const string WARNING = "WARNING";

    }

    public class ConstProccess
    {
        public const string IE_BROWSER_PROCESS = "IEXPLORE";
        public const string IE_DRIVER_PROCESS = "IEDriverServer";

    }

    public class ConstPaginaUrl
    {
        public const string _LOGIN = "http://flnserv013/SIGEF/SIGEFPortal.html";
        public const string _INICIAL = "http://flnserv013/SIGEF2018/SEG/SEGPaginaInicial.aspx";

    }

    public class ConstClassName
    {
        public const string SIGEFPesquisa_INPUT = "SIGEFPesquisa";
        public const string SIGEFMensagemErro = "SIGEFMensagemErro";
        public const string SIGEFMensagemSucesso = "SIGEFMensagemSucesso";
        public const string SIGEFTextbox = "SIGEFTextbox";
        public const string SIGEFLabel_Padrao = "SIGEFLabel_Padrao";
    }

    public class ConstResultadoStatus
    {
        public const string STATUS_PASSOU = "PASSOU";
        public const string STATUS_NAO_PASSOU = "NAO PASSOU";
        public const string STATUS_PAGINA_EXCEPTION = "PAGINA_EXCEPTION";
        public const string STATUS_WEBDRIVER_EXCEPTION = "WEBDRIVER_EXCEPTION";
        public const string STATUS_BROSWER_EXCEPTION = "BROSWER_EXCEPTION";
        public const string STATUS_EXCEPTION_DESCONHECIDA = "STATUS_EXCEPTION_DESCONHECIDA";
        public const string STATUS_INICIADO = "STATUS_INICIADO";
    }

    public class ConstCasoStatus
    {
        public const string STATUS_PASSOU = "PASSOU";
        public const string STATUS_NAO_PASSOU = "NAO PASSOU";
        public const string STATUS_ALERT = "ALERT";
    }

    public class ConstFindElementBy {

        public const string BY_ID = "BY_ID";
        public const string BY_XPATH = "BY_XPATH";
        public const string BY_NOT_FIND = "BY_NOT_FIND";
    }

    public class ConstRunTipo
    {
        public const string RUN_ACCESS = "RUN_ACCESS";
        public const string RUN_TESTE = "RUN_TESTE";
    }

}
