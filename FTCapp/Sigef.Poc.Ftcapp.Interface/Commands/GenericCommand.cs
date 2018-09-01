using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Interface.Model;
using Sigef.Poc.Ftcapp.Interface.ViewModelBase;
using System.Linq;

namespace Sigef.Poc.Ftcapp.Interface.Commands
{
    public class GenericCommand : BaseViewCommand
    {
        private EnumCommand _comand;
        public GenericCommand(BaseViewModel Selected, EnumCommand comand)
        {
            _comand = comand;
            _selected = Selected;
        }

        public override bool CanExecute(object parameter)
        {
            return _selected != null;
        }

        public override void Execute(object parameter)
        {
            switch (_comand)
            {
                case EnumCommand.EXCLUIR_CASO:
                    var c = (Caso)parameter;

                   // Caso casoDel = _selected.VM.BVMCasos.Where(e => e.Cod == c.Cod).FirstOrDefault();

                    //ExcluirCaso(_selected.VM, casoDel);

                    //_selected.VM.BVMCasos.Remove(casoDel);
                    //_selected.tr.Casos.FirstOrDefault().Get
                    //if (_selected.VM.BVMCasos != null)
                    //{
                    //    _selected.VM.SelectedCaso = _selected.VM.BVMCasos.FirstOrDefault();
                    //    if (_selected.VM.SelectedCaso != null && _selected.VM.SelectedCaso.Comandos != null)
                    //    {
                    //        _selected.VM.SelectedCaso.SelectedComand = _selected.VM.SelectedCaso.Comandos.FirstOrDefault();
                    //    }

                    //}

                    break;
                case EnumCommand.REFRESH:
                    _selected.Refresh();

                    

                    break;
                case EnumCommand.EXCLUIR_COMANDO:
                    var cPar = (Comando)parameter;
                    //var comandoDel = _selected.tr.SelectedCaso.Comandos.Where(e => e.Cod == cPar.Cod).FirstOrDefault();
                    //_selected.tr.SelectedCaso.Comandos.Remove(comandoDel);

                    //_selected.tr.SelectedCaso.SelectedComand = _selected.tr.SelectedCaso.Comandos.FirstOrDefault();
                    //_selected.tr.SelectedCaso = (Caso)_selected.tr.SelectedCaso.Clone();


                   // _selected.VM = ExcluirComando(_selected.VM, cPar);
                    //_selected.RefreshScreamShot();
                    break;
                case EnumCommand.SALVAR:
                    Save();
                    break;
                case EnumCommand.SCRAP:
                    //_selected.VM = Scrap(_selected.VM);
                    break;
                case EnumCommand.ADD_CASO:
                   int order = _selected.SelectedSuiteCurrent.Casos.Max(e => e.Order) + 1;
                   CasoModel caso = _selected.SelectedSuite.SelectedCaso;
                   caso.Order = order;
                    _selected.SelectedSuiteCurrent.Casos.Add(_selected.SelectedSuite.SelectedCaso);
                    _selected.SelectedSuiteCurrent.Casos = _selected.SelectedSuiteCurrent.Casos;
                    break;
                case EnumCommand.ADD_COMAND:
                    var cmd = (Comando)parameter;
                    //_selected.VM = ADDComando(_selected.VM, cmd);


                    //if (_selected.tr.SelectedCaso.Comandos.Contains(cmd)) {
                    //    cmd = _selected.tr.SelectedCaso.Comandos.Where(e => e.Cod == ((Comando)parameter).Cod).FirstOrDefault();
                    //}
                    //cmd.Cod = _selected.tr.SelectedCaso.Comandos.Max(e => e.Cod) + 1;

                    //_selected.tr.SelectedCaso.Comandos.Add(cmd);
                    //_selected.tr.SelectedCaso.SelectedComand = cmd;

                    //_selected.tr.SelectedCaso.SelectedComandTodo = _selected.tr.SelectedCaso.ComandosTodos.Where(e => e.Elemento.Cod == cmd.Elemento.Cod).FirstOrDefault();



                    // _selected.RefreshScreamShot();
                    break;
                case EnumCommand.RODAR:
                    Rodar(_selected.SelectedSuite);
                   
                    break;
                //case EnumCommand.REFRESH_SCREAM_SHOT:
                //    //_selected.RefreshScreamShot();

                //    break;
                case EnumCommand.NEW_CASO:
                    //_selected.VM = _selected.NewCaso(_selected.VM);
                    // _selected.RefreshScreamShot();

                    break;
                case EnumCommand.ADD_SUITES_SELECTEDS:
                    var suitesse = _selected.SelectedsSuites;
                    _selected.SelectedsSuites = new System.Collections.ObjectModel.ObservableCollection<SuiteModel>(_selected.SelectedsSuites);
                    


                    break;
                case EnumCommand.ADD_SUITE:
                    var suiteModel = _selected.SelectedSuite;
                    var suite = suiteModel.suite;
                    suite.Id = 0;
                    _selected.SelectedSuiteCurrent = new SuiteModel(suite);
                    

                    break;
                case EnumCommand.NEW_SUITE:

                    _selected.SelectedSuiteCurrent = new SuiteModel(new Suite());
                    // _selected.RefreshScreamShot();

                    break;
                case EnumCommand.NEW_COMANDO:
                    //_selected.VM = _selected.NewComando(_selected.VM);
                    // _selected.RefreshScreamShot();

                    break;
                case EnumCommand.NEW_RULE:

                    var rule = new Rule();
                    //if (_selected.VM.SelectedCaso.ScrapConfig.RuleList.Count == 0)
                    //{
                    //    rule.Cod = 0;
                    //}
                    //else
                    //{
                    //    rule.Cod = _selected.VM.SelectedCaso.ScrapConfig.RuleList.Max(e => e.Cod) + 1;
                    //}
                    //rule.Nome = "Msg Tipo do Elemento";
                    //rule.XPath = "//*[@codigo][not(contains(@codigo,'Aba')";
                    //_selected.VM.SelectedCaso.ScrapConfig.RuleList.Add(rule);
                    //_selected.VM.SelectedCaso.ScrapConfig.SelectedRule = rule;

                    break;
                default:
                    break;
            }

            
        }

        private void Rodar(Model.SuiteModel suiteModel)
        {
            _selected.Rodar(suiteModel);
            
        }




    }
}
