
using Sigef.Poc.Ftcapp.Crl;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Interface.Model;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Sigef.Poc.Ftcapp.Util;
using System.Collections.Generic;
using Sigef.Poc.Ftcapp.Service.Interfaces;
using Sigef.Poc.Ftcapp.Service;
using System.Windows;
using System;

namespace Sigef.Poc.Ftcapp.Interface.ViewModelBase
{
    public class BaseViewModel : BaseNotifyPropertyChanged
    {


        private static ISuiteService _IsuiteService;

        public ISuiteService Service
        {
            get
            {
                if (_IsuiteService == null)
                {
                    _IsuiteService = new SuiteService();
                }
                return _IsuiteService;

            }
        }


        public FTCappCrl _FTCappCrl;

        public FTCappCrl controller
        {
            get
            {
                if (_FTCappCrl == null)
                {
                    _FTCappCrl = new FTCappCrl();
                }
                return _FTCappCrl;

            }
        }

        public BaseViewModel()
        {
            try
            {
                _FTCappCrl = controller;
                SALVAR = new GenericCommand(this, EnumCommand.SALVAR);
                SCRAP_COMMAND = new GenericCommand(this, EnumCommand.SCRAP);
                RODAR = new GenericCommand(this, EnumCommand.RODAR);

                //Suite
                SALVAR_SUITE = new GenericCommand(this, EnumCommand.SALVAR_SUITE);
                ADD_SUITE = new GenericCommand(this, EnumCommand.ADD_SUITE);
                NEW_SUITE = new GenericCommand(this, EnumCommand.NEW_SUITE);
                EXCLUIR_SUITE = new GenericCommand(this, EnumCommand.EXCLUIR_SUITE);
                //comando
                ADD_COMAND = new GenericCommand(this, EnumCommand.ADD_COMAND);
                NEW_COMANDO = new GenericCommand(this, EnumCommand.NEW_COMANDO);
                EXCLUIR_COMANDO = new GenericCommand(this, EnumCommand.EXCLUIR_COMANDO);
                //caso
                ADD_CASO = new GenericCommand(this, EnumCommand.ADD_CASO);
                NEW_CASO = new GenericCommand(this, EnumCommand.NEW_CASO);
                EXCLUIR_CASO = new GenericCommand(this, EnumCommand.EXCLUIR_CASO);
                //Rule
                NEW_RULE = new GenericCommand(this, EnumCommand.NEW_RULE);
                //
                ADD_SUITES_SELECTEDS = new GenericCommand(this, EnumCommand.ADD_SUITES_SELECTEDS);
                REFRESH = new GenericCommand(this, EnumCommand.REFRESH);

                GetSuites();


                //controller.ListTransacoesComElementos().ForEach(e => {
                //    Transacoes.Add(new TransacaoModel(e));
                //});
                //Transacoes = 

            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }

        }

        private ObservableCollection<SuiteModel> GetSuites()
        {
            List<string> contains = new List<string>();
            contains.Add("[Transacao]");
            contains.Add("][Manter");

            List<Suite> list = null;
            try
            {
                list = controller.SuiteListByContais(contains, 2);
            }
            catch {
                list = controller.SuiteListByContais(contains, 2);
            }

            foreach (var item in list)
            {
                    try
                    {
                       
                            Suites.Add(new SuiteModel(item));
                       
                        
                    }
                    catch {
                        var n = item.Nome;
                    }
                
                
            }
            Suites = Suites;
            return Suites;
        }

        #region SUITE MODEL

        private SuiteModel _selectedCBXSuite;
        public SuiteModel SelectedCbxSuite
        {
            get
            {
                return _selectedCBXSuite;
            }

            set
            {
                if (value != null && !SelectedsSuites.Contains(value))
                {
                    SelectedsSuites.Add(value);
                    SelectedsSuites = new ObservableCollection<SuiteModel>(SelectedsSuites);
                }
                
                SetField(ref _selectedCBXSuite, value);
            }

        }

        private SuiteModel _selectedSuiteCurrent;
        public SuiteModel SelectedSuiteCurrent
        {
            get
            {

                return _selectedSuiteCurrent;
            }

            set
            {
                SetField(ref _selectedSuiteCurrent, value);
            }

        }


        private SuiteModel _selectedSuite;
        public SuiteModel SelectedSuite
        {
            get
            {

                
                return _selectedSuite;
            }

            set
            {
                SetField(ref _selectedSuite, value);
            }

        }

        private ObservableCollection<SuiteModel> _suites;
        public ObservableCollection<SuiteModel> Suites
        {
            get
            {
                if (_suites == null)
                {
                    _suites = new ObservableCollection<SuiteModel>();
                }

                return _suites;

            }
            set
            {
                SetField(ref _suites, value);
            }
        }

        private ObservableCollection<SuiteModel> _suitesConsulta;
        public ObservableCollection<SuiteModel> SuitesConsulta
        {
            get
            {
                if (_suites == null)
                {
                    _suites = new ObservableCollection<SuiteModel>();
                }

                return _suites;

            }
            set
            {
                SetField(ref _suites, value);
            }
        }

        


        private ObservableCollection<SuiteModel> _SelectedsSuites;
        public ObservableCollection<SuiteModel> SelectedsSuites
        {
            get
            {

                if (_SelectedsSuites == null) {
                    _SelectedsSuites = new ObservableCollection<SuiteModel>();
                }
                

                return _SelectedsSuites;

            }
            set
            {
                SetField(ref _SelectedsSuites, value);
            }
        }

        #endregion

        #region TRANSACAO MODEL

        private ObservableCollection<TransacaoModel> _transacoes;
        public ObservableCollection<TransacaoModel> Transacoes
        {
            get
            {
                if (_transacoes == null)
                {
                    _transacoes = new ObservableCollection<TransacaoModel>();
                }

                return _transacoes;

            }
            set
            {
                SetField(ref _transacoes, value);
            }
        }

        private TransacaoModel _selectedTransacao;
        public TransacaoModel SelectedTransacao
        {
            get
            {


                return _selectedTransacao;
            }

            set
            {
                SetField(ref _selectedTransacao, value);
            }

        }

        #endregion

        #region VIEW COMANDS ADD NEW EXCLUIR
        public GenericCommand SALVAR { get; set; }
        public GenericCommand SCRAP_COMMAND { get; set; }
        public GenericCommand RODAR { get; set; }
        //SUITE
        public GenericCommand SALVAR_SUITE { get; set; }
        public GenericCommand ADD_SUITE { get; set; }
        public GenericCommand NEW_SUITE { get; set; }
        public GenericCommand EXCLUIR_SUITE { get; set; }
        //CASO
        public GenericCommand ADD_CASO { get; set; }
        public GenericCommand NEW_CASO { get; set; }
        public GenericCommand EXCLUIR_CASO { get; set; }
        //Comando
        public GenericCommand ADD_COMAND { get; set; }
        public GenericCommand NEW_COMANDO { get; set; }
        public GenericCommand EXCLUIR_COMANDO { get; set; }
        //RULE 
        public GenericCommand NEW_RULE { get; set; }
        public GenericCommand REFRESH { get; set; }

        public GenericCommand ADD_SUITES_SELECTEDS { get; set; }
        
        
        
        
        

        

        

       

        public GenericCommand SELECIONA_VALUES { get; set; }




        #endregion


        internal void Rodar(SuiteModel suiteModel)
        {
            _FTCappCrl = controller;
            _FTCappCrl.RunTeste(suiteModel.suite);
            Suites = new ObservableCollection<SuiteModel>(GetSuites());
        }

        internal void Refresh()
        {
            Suites = GetSuites();
        }


        #region CONTROLES

        private double _WidthPanelElemento;
        public double WidthPanelElemento
        {
            get
            {

                if (_WidthPanelElemento < 1.0) {
                    _WidthPanelElemento = 500;
                }
                return _WidthPanelElemento;

            }
            set
            {
                SetField(ref _WidthPanelElemento, value);
            }
        }

        private GridLength _WidthLeftPanelMain;
        public GridLength WidthLeftPanelMain
        {
            get
            {


                return _WidthLeftPanelMain;

            }
            set
            {
                SetField(ref _WidthLeftPanelMain, value);
                if (value.Value < 1.0)
                {
                    _WidthPanelElemento = 500;
                }
                else {
                    WidthPanelElemento = _WidthLeftPanelMain.Value;
                }
                
            }
        }


        #endregion
    }
}
