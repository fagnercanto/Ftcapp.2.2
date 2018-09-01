using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System;

namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class RuleModel : BaseNotifyPropertyChanged, ICloneable
    {
        public Rule rule { get; set; }
        public RuleModel(Sigef.Poc.Ftcapp.Entidade.Configuracoes.Rule rule)
        {
            this.rule = rule;
            this.Codigo = rule.Id;
            this.Nome = rule.Nome;
            this.XPath = rule.XPath;
        }

        private int _codigo;
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {

                SetField(ref _codigo, value);
            }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set {

                if (rule.Nome != value)
                {
                    rule.Nome = value;
                }
                SetField(ref _Nome, value); 
            }
        }

        private string _XPath;
        public string XPath
        {
            get { return _XPath; }
            set {
                if (rule.XPath != value)
                {
                    rule.XPath = value;
                }
                SetField(ref _XPath, value); }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
