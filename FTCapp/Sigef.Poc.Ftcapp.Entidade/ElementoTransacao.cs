using Sigef.Poc.Ftcapp.Util;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sigef.Poc.Ftcapp.Entidade
{
    public class ElementoTransacao 
    {
        public ElementoTransacao()
        {
           
            FindElementBy = ConstFindElementBy.BY_ID;
        }
        
        public int Id { get; set; }
        
       

        public string TipoControle { get; set; }

        public string CodigoUi { get; set; }

        public string ClassName { get; set; }

        public string Nome { get; set; }

        public string Altura { get; set; }

        public string Largura { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public string Type { get; set; }

        public bool Displayed { get; set; }

        public bool Enabled { get; set; }

        public bool Selected { get; set; }

        public string TagName { get; set; }

        public string TabIndex { get; set; }

        public string Text { get; set; }

        public bool IsComposto { get; set; }

        public bool IsObrigatorio { get; set; }

        public bool IsCampoPesquisa { get; set; }

        public int CodigoComandoComposto { get; set; }

        public string FindElementBy { get; set; }

        public string onclick { get; set; }

        public bool isGrid { get; set; }

        //Relacoes

        public virtual ICollection<Transacao> TransacaoLista { get; set; }


        public bool IsBtnPesquisa { get; set; }
    }
}
