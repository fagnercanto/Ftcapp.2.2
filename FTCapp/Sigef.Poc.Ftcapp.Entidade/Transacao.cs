
using Sigef.Poc.Ftcapp.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class Transacao 
    {
        public Transacao()
        {
            ElementoLista = new List<ElementoTransacao>();
        }
        
        public int Id { get; set; }
        
       
        public int CDTRANSACAO { get; set; }

        public string NMTRANSACAO { get; set; }

        public string NMPAGINA { get; set; }

        public string SGMODULO { get; set; }

        //Relacoes
        public virtual ICollection<ElementoTransacao> ElementoLista { get; set; }

       

    }
}
