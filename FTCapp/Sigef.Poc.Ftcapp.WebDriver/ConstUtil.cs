
namespace Sigef.Poc.Ftcapp.WebDriver
{
    public class ConstUtil
    {

        public static string PROCESS_IE_BROWSER = "IEXPLORE";
        public static string PROCESS_IE_DRIVER = "IEDriverServer";
        public static string PROCESS_MS_BUILD = "MSBuild";

        public const string _PGLogin = "http://flnserv013/SIGEF/SIGEFPortal.html";
        public const string _PGInicial = "http://flnserv013/SIGEF2018/SEG/SEGPaginaInicial.aspx";
        public const string _PGConceito = "http://flnserv013/SIGEF2018/FIN/FINManterAgenciaBancaria.aspx?CdTransacao=337";
        
        public const string XPATH_GRID = ".//tr[@class='GridCabecalho']//parent::tbody[@class]//parent::table[@id='{0}']";
        public const string XPATH_COMANDO_COMPOSTO_COM_SPAN = "//input[@id='{0}'][(./preceding::span[string-length(text())<=2]) and position() = 1]";

        public const string XPATH_PRIMEIRO_CAMPO_PESQUISA = "//input[@id='{0}']/following::input[1][contains(@name,'SIGEFPesquisa')][1]";

        public const string XPATH_PRIMEIRA_CELULA_GRID = "//input[@id='{0}']/following::input[1][contains(@name,'SIGEFPesquisa')][1]";


        public static string GetPaginaInicial()
        {
            return "http://flnserv013/SIGEF2018/SEG/SEGPaginaInicial.aspx";
        }


        public static string GetPaginaHome()
        {
            return "http://flnserv013/SIGEF/SIGEFPortal.html";
        }

        //private string GetPaginaConceito(Caso caso)
        //{
        //    return caso.Transacao.NMTRANSACAO;
        //}

        

    }
}
