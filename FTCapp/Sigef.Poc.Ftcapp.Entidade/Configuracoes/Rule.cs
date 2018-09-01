
using System.Collections.Generic;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigef.Poc.Ftcapp.Util;
namespace Sigef.Poc.Ftcapp.Entidade.Configuracoes
{
    public class Rule 
    {
        
        public int Id { get; set; }
        
       

        public string Nome { get; set; }

        public string XPath { get; set; }


        public virtual ICollection<Config> ConfigLista { get; set; }
    }
}
