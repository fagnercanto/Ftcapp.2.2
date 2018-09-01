using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class ConfigModel : BaseNotifyPropertyChanged, ICloneable
    {

        public ConfigModel(Config config)
        {
            this.config = config;
            this.Codigo = config.Id;
            config.RuleLista.ToList().ForEach(rule =>
            {
                this.RuleList.Add(new RuleModel(rule));
            });
        }
        public Config config { get; set; }
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

        

        private RuleModel _SelectedRule;
        public virtual RuleModel SelectedRule
        {
            get
            {
                return _SelectedRule;
            }
            set { SetField(ref _SelectedRule, value); }
        }

        private ObservableCollection<RuleModel> _RuleList;
        public virtual ObservableCollection<RuleModel> RuleList
        {
            get
            {
                if (_RuleList == null || _RuleList.Count == 0)
                {
                    _RuleList = CreateDefaultRuleModels();

                }

                return _RuleList;

            }
            set
            {
                SetField(ref  _RuleList, value);
            }
        }

        private ObservableCollection<RuleModel> CreateDefaultRuleModels()
        {
            ObservableCollection<RuleModel> rules = new ObservableCollection<RuleModel>();


            //rules.Add(CreateDefaultRuleModels(codigo++, "Limpar", "//img[@codigo='SIGEFBotoesImpressao_BtnLimpar']"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "Imprimir", "//img[@codigo='SIGEFBotoesImpressao_BtnImprimir']"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "Ajuda", "//img[@codigo='SIGEFBotoesImpressao_BtnAjuda']"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "Fechar", "//img[@codigo='SIGEFBotoesImpressao_BtnFechar']"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "Const.ConstControlTypeUI.TYPE_COMBOBOX", "//select[@class='SIGEFComboBox']"));
            //rules.Add(CreateDefaultRuleModels(codigo++, Const.ConstControlTypeUI.TYPE_COMBOBOX + "items", "//select[@class='SIGEFComboBox']//option"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "GridColumns", "//tr[@class='GridCabecalho']//td"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "GridCell", "//tr[@class][contains(@class,'Grid')][not(contains(@class,'GridCabecalho'))]//td"));


            //rules.Add(CreateDefaultRuleModels(codigo++, Const.ConstControlTypeUI.TYPE_TEXTBOX, "//input[@class][contains(@class,'SIGEFPesquisa') or contains(@class,'SIGEFTextbox')]"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "Botao Pesquisa", "//a[@codigo][contains(@codigo,'lnkBtnPesquisa')]"));
            //rules.Add(CreateDefaultRuleModels(codigo++, "Aba", "//input[@codigo][contains(@codigo,'Aba') or contains(@codigo,'aba') and contains(@type,'image') ]"));

            /*
             
             * botao limpar = //img[@codigo='SIGEFBotoesImpressao_BtnLimpar']
btn imprimir = //img[@codigo='SIGEFBotoesImpressao_BtnImprimir']
//img[@codigo='SIGEFBotoesImpressao_BtnAjuda']
//img[@codigo='SIGEFBotoesImpressao_BtnFechar']

combobox //select[@class='SIGEFComboBox']
combobox opcoes //select[@class='SIGEFComboBox']//option

GridColunas  //tr[@class='GridCabecalho']//td

GridCells //tr[@class][contains(@class,'Grid')][not(contains(@class,'GridCabecalho'))]//td

SigefPesquisa //input[@class][contains(@class,'SIGEFPesquisa')]
//input[@class][contains(@class,'SIGEFPesquisa')]
//input[@class][contains(@class,'SIGEFTextbox')]

campos texto //input[@class][contains(@class,'SIGEFPesquisa') or contains(@class,'SIGEFTextbox')]

botao pesquisa //a[@codigo][contains(@codigo,'lnkBtnPesquisa')]

aba //input[@codigo][contains(@codigo,'Aba') or contains(@codigo,'aba') and contains(@type,'image') ]
             
             */
            return rules;
        }

        private ObservableCollection<string> _formatElementNameList;
        public virtual ObservableCollection<string> FormatElementNameList
        {
            get
            {
                if (_formatElementNameList == null)
                {
                    _formatElementNameList = new ObservableCollection<string>();

                }

                return _formatElementNameList;

            }
            set
            {
                SetField(ref  _formatElementNameList, value);
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
