using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigef.Poc.Ftcapp.Util;
using System.Collections.Generic;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class Comando 
    {
        public Comando() {
            
        }

        
        public int Id { get; set; }
        
       
        public int Order { get; set; }
        public string Acao { get; set; }


        public string TipoComando { get; set; }

        public string ValorElemento { get; set; }

        public string TipoValorElemento { get; set; }

        //Relacoes
        public virtual Elemento Elemento { get; set; }
        public virtual Resultado Resultado { get; set; }

       

        public virtual ICollection<Caso> CasoLista { get; set; }

        public string Url { get; set; }
    }
}
