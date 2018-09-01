
using System.Collections.Generic;
using Sigef.Poc.Ftcapp.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class ValorSugestao
    {
        public ValorSugestao(){
            
        }
       
        public int Id { get; set; }
        
       
        public string valor { get; set; }

        //relacoes
        public virtual ICollection<Elemento> ElementoLista { get; set; }
    }
}
