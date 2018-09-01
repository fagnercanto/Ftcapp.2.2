using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigef.Poc.Ftcapp.Util;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class Caso 
    {
        public Caso()
        {
            ComandoLista = new List<Comando>();
            Config = new Config();
            RunTipo = ConstRunTipo.RUN_ACCESS;
            Data = DateTime.Now;

        }
        
        public int Id { get; set; }
        
       

        public string UrlAccess { get; set; }
        public string LastUrl { get; set; }
        
        public int Order { get; set; }
        public string Nome { get; set; }

        public string NomeEditavel { get; set; }

        public DateTime Data { get; set; }

        public string status { get; set; }

        //Relacoes

        public virtual Config Config { get; set; }

        public virtual ICollection<Comando> ComandoLista { get; set; }

        public virtual Transacao Transacao { get; set; }

        

        public string RunTipo { get; set; }

        public virtual ICollection<Suite> SuiteLista { get; set; }

        public byte[] ScrenShotBytes { get; set; }

        public string ScrenShot { get; set; }


    }

}
