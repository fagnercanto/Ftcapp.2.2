using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigef.Poc.Ftcapp.Util;
using System.Collections.Generic;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class Variavel
    {
        public Variavel()
        {
           
        }

        
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }

        public string Find { get; set; }
        
        public string Valor { get; set; }

        public virtual ICollection<Suite> SuiteLista { get; set; }

    }
}
