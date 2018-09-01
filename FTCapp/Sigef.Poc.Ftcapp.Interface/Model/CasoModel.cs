using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.Interface.Commands;
using Sigef.Poc.Ftcapp.Util.Byte;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class CasoModel : BaseNotifyPropertyChanged, ICloneable
    {

        

        public CasoModel(Caso caso)
        {
            this.caso = caso;

            Nome = caso.Nome;
            NomeEditavel = caso.NomeEditavel;
            Codigo = caso.Id;
            this.Order = caso.Order;
            this.Data = caso.Data;
            this.ScrapConfig = new ConfigModel(caso.Config);
            if (caso.Transacao == null) {
                caso.Transacao = new Transacao();
                caso.Transacao.NMTRANSACAO = caso.Nome;
            }
            this.Transacao = new TransacaoModel(caso.Transacao);
            this.ScreanShot = ByteUtil.byteArrayToImage(caso.ScrenShotBytes);
            foreach (var comando in caso.ComandoLista) {
                Comandos.Add(new ComandoModel(comando));
            }
        }

        private int _order;
        public int Order
        {
            get
            {

                return _order;
            }
            set
            {
                if (caso.Order != value)
                {
                    caso.Order = value;
                }
                SetField(ref _order, value);
            }
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




        private string _nome;
        public string Nome
        {
            get
            {
                if (_nome == null)
                {
                    _nome = "";
                }

                return _nome;
            }
            set
            {
                if (caso.Nome != value)
                {
                    caso.Nome = value;
                }
                SetField(ref _nome, value);

            }
        }

        private ConfigModel _ScrapConfig;
        public ConfigModel ScrapConfig
        {
            get
            {

                return _ScrapConfig;


            }
            set
            {
                
                SetField(ref _ScrapConfig, value);

            }
        }

        private string _nomeEditavel;
        public string NomeEditavel
        {
            get { return _nomeEditavel; }
            set
            {
                if (caso.NomeEditavel != value)
                {
                    caso.NomeEditavel = value;
                }
                SetField(ref _nomeEditavel, value);

            }
        }

        private TransacaoModel _transacao;
        public TransacaoModel Transacao
        {
            get
            {
                return _transacao;
            }
            set
            {
                SetField(ref _transacao, value);
                //if (_transacao != null && _transacao.Cod > 0)
                //{
                //    Cod = _transacao.Cod;

                //}
            }
        }
        //public int? Cod { get; set; }


        private ComandoModel _selectedComandTodo;
        public ComandoModel SelectedComandTodo
        {
            get
            {
                if (SelectedComand == null) {
                    SelectedComand = Comandos.First();
                }
                return _selectedComandTodo;
            }
            set
            {
                SetField(ref _selectedComandTodo, value);
                if (value != null && Comandos != null && Comandos.Count > 0)
                {
                    if (Comandos.Any(e => e.Elemento.Nome.Equals(_selectedComandTodo.Elemento.Nome)))
                    {
                        var cmdSelect = Comandos.FirstOrDefault(e => e.Elemento.Nome.Equals(_selectedComandTodo.Elemento.Nome));
                        if (SelectedComand != cmdSelect)
                        {
                            SelectedComand = cmdSelect;
                        }

                    }

                }
            }
        }

        private ComandoModel _selectedComand;
        public ComandoModel SelectedComand
        {
            get
            {
                if (_selectedComand != null) {
                    _selectedComand.Elemento = _selectedComand.Elemento;
                }
            
            return _selectedComand;
            }
            set
            {
                if (value != null)
                {
                    if (value != null)
                    {
                        _selectedComand = value;
                        _selectedComand.Elemento = _selectedComand.Elemento;
                    }
                    SetField(ref _selectedComand, value);


                    //    if (ComandosTodos != null && ComandosTodos.Count > 0)
                    //    {
                    //        if (ComandosTodos.Any(e => e.Elemento.Nome.Equals(_selectedComand.Elemento.Nome)))
                    //        {
                    //            var cmdTDSelecionado = ComandosTodos.FirstOrDefault(e => e.Elemento.Nome.Equals(_selectedComand.Elemento.Nome));
                    //            if (SelectedComandTodo != cmdTDSelecionado)
                    //            {
                    //                SelectedComandTodo = cmdTDSelecionado;
                    //            }

                    //        }

                    //    }

                    //}

                }


            }
        }

        private ObservableCollection<ComandoModel> _Comandos;
        public ObservableCollection<ComandoModel> Comandos
        {
            get
            {
                if (_Comandos == null)
                {
                    _Comandos = new ObservableCollection<ComandoModel>();

                }
                return _Comandos;
            }
            set
            {
                SetField(ref _Comandos, value);

            }
        }

        private ObservableCollection<ComandoModel> _ComandosTodos;
        public ObservableCollection<ComandoModel> ComandosTodos
        {
            get
            {
                if (_ComandosTodos == null)
                {
                    _ComandosTodos = new ObservableCollection<ComandoModel>();

                }
                return _ComandosTodos;
            }
            set
            {
                SetField(ref _ComandosTodos, value);
            }
        }
    

        private bool _isPassou;
        public bool IsPassou
        {
            get
            {

               
                return _isPassou;


            }
            set
            {
                SetField(ref _isPassou, value);
                if (_isPassou)
                {
                    Cor = ConstCOR.SUCCESS;
                }
                else
                {
                    Cor = ConstCOR.ERRO;

                }


            }
        }

        private bool _IsRodou;
        public bool IsRodou
        {
            get
            {
                return _IsRodou;

            }
            set
            {
                SetField(ref _IsRodou, value);
                if (!_IsRodou)
                {
                    Cor = ConstCOR.NORMAL;
                }
            }
        }


        private bool _IsAtivo;
        public bool IsAtivo
        {
            get
            {
                return _IsAtivo;
            }
            set
            {
                SetField(ref _IsAtivo, value);

            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private DateTime _Data;
        public DateTime Data
        {
            get
            {
                if (_Data == null || _Data == DateTime.MinValue)
                {
                    _Data = DateTime.Now;
                }
                return _Data;
            }

            
            set {

                if (caso.Data != value)
                {
                    caso.Data = value;
                }
                SetField(ref _Data, value); }
        }


        private string _cor;
        public string Cor
        {

            get
            {
                return _cor;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _cor = ConstCOR.NORMAL;
                }
                SetField(ref _cor, value);
            }
        }

        private string _msg;



        public string MSG
        {
            get
            {
                return _msg;
            }
            set {
               
                SetField(ref _msg, value); }
        }


       

        private Image _screanshot;


        public Image ScreanShot
        {
            get
            {
                return _screanshot;
            }
            set {

                if (value !=null && caso.ScrenShotBytes != ByteUtil.imageToByteArray(value))
                {
                    caso.ScrenShotBytes = ByteUtil.imageToByteArray(value);
                    ScreanshotImageSourse = ByteUtil.ToImageSource(value, ImageFormat.Png);
                }
                SetField(ref _screanshot, value); }
        }

        private ImageSource _screanshotImageSourse;


        public ImageSource ScreanshotImageSourse
        {
            get
            {
                return _screanshotImageSourse;
            }
            set {

               
                SetField(ref _screanshotImageSourse, value); }
        }


        public Caso caso { get; set; }
    }
}
