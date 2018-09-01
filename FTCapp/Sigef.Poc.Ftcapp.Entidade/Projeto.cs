using Sigef.Poc.Ftcapp.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class Projeto 
    {
        public Projeto()
        {
            TransacaoLista = new List<Transacao>();
        }
        
        public int Id { get; set; }
        
       

        public string Nome { get; set; }

        public string Url { get; set; }

        public string BaseUri { get; set; }

        //Relacoes
        public virtual ICollection<Transacao> TransacaoLista { get; set; }


    }

}
