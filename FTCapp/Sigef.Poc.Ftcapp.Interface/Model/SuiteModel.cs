using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class SuiteModel : BaseNotifyPropertyChanged
    {
        public SuiteModel(Suite suite)
        {
            this.suite = suite;
            SuiteModelUpdate(suite);

        }

        

        public void SuiteModelUpdate(Suite suite)
        {
            foreach(var caso in suite.CasoLista)
            {
                try
                {
                    if (caso.Nome == "Transacao Manter Agrupamento OETransacao Manter Agrupamento OE[incluir]") {
                        Casos.Add(new CasoModel(caso));
                    }
                    Casos.Add(new CasoModel(caso));
                }
                catch {
                    var n = caso.Nome;
                }
            }
            
            this.Nome = suite.Nome;
            this.Codigo = suite.Id;
        }

        public Suite suite { get; set; } 

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

        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (suite.Nome != value)
                {
                    suite.Nome = value;
                }
                SetField(ref _nome, value);
            }
        }


        private CasoModel _selectedCaso;
        public CasoModel SelectedCaso
        {
            get
            {

                if (_selectedCaso == null) {
                    _selectedCaso = Casos.First();
                }
                return _selectedCaso;
            }

            set
            {
                if (value != null)
                {
                    SetField(ref _selectedCaso, value);

                    CasoModel casoItem = Casos.FirstOrDefault(e => e.Codigo == _selectedCaso.Codigo);

                    if (casoItem != null)
                    {
                        Casos[Casos.IndexOf(casoItem)] = _selectedCaso;
                    }

                }


                //UpdateItem(_selectedSuite, Casos);




            }
        }

        private ObservableCollection<CasoModel> _Casos;

        public ObservableCollection<CasoModel> Casos
        {
            get
            {
                if (_Casos == null)
                {
                    _Casos = new ObservableCollection<CasoModel>();
                }
                return _Casos;
            }

            set
            {
                SetField(ref _Casos, value);
            }
        }
    }
}
