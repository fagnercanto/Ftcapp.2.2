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
    public class Config 
    {
        public Config()
        {
            RuleLista = new List<Rule>();

        }
       
        public int Id { get; set; }
        
       

        
        //Relacoes
        public virtual ICollection<Rule> RuleLista { get; set; }

    }
}
