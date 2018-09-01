
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class ConceitoBuilder
    {


        public string MontaUriConceito(string NMPAGINA, int CDTRANSACAO, string baseUri)
        {


            var nmconceitoUri = NMPAGINA;

            var cdConceitoUri = "?CdTransacao=" + CDTRANSACAO;

            var UriConceito = baseUri + NMPAGINA + cdConceitoUri;
            return UriConceito;
        }

    }
}
