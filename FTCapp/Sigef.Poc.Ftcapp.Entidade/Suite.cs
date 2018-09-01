using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sigef.Poc.Ftcapp.Util;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sigef.Poc.Ftcapp.Entidade 
{
    public class Suite 
    {
        public Suite()
        {
            CasoLista = new List<Caso>();
            VariavelLista = new List<Variavel>();
        }
        
        public int Id { get; set; } 
        
        public string Nome { get; set; }

        //Relacoes
        public virtual ICollection<Caso> CasoLista { get; set; }

        public virtual ICollection<Variavel> VariavelLista { get; set; }

    }

}
