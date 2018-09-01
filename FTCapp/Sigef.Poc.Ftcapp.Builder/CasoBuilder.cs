
using Sigef.Poc.Ftcapp.Entidade;
using System.Linq;

namespace Sigef.Poc.Ftcapp.Entidade
{
    public class CasoBuilder : BuilderBase
    {





        public void ConfigNewNomeCaso(Caso caso, Transacao transacao)
        {
            string Modulo = "SEMTRANSACAO";
            string NomeTransacao = "S";
            if (caso != null && transacao != null)
            {
                Modulo = transacao.SGMODULO;
                NomeTransacao = transacao.NMTRANSACAO;
            }

            caso.Nome = string.Format("[{0}][{1}]", Modulo, NomeTransacao);
        }

        public void ConfigCasoNome(Caso caso, Transacao transacao)
        {
            ConfigNewNomeCaso(caso, transacao);
        }



        public Caso NewCasoCopy(Caso obj, Transacao transacao)
        {
            ConfigCasoNome(obj, transacao);
            return obj;
        }



        //public Caso GetDefaultSelectedCaso(DBObj VM)
        //{
        //    Caso selected = null;
        //    if (VM.BVMCasos != null)
        //    {
        //        selected = VM.BVMCasos.FirstOrDefault();
        //        if (selected != null && selected != null)
        //        {
        //            selected.SelectedComand = VM.SelectedCaso.Comandos.FirstOrDefault();
        //        }

        //    }

        //    return selected;
        //}


    }
}
