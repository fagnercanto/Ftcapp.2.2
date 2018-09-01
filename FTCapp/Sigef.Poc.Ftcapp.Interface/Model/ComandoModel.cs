using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Media;
namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class ComandoModel : BaseNotifyPropertyChanged, ICloneable
    {

        public Comando comando { get; set; }
        public ComandoModel(Comando comando)
        {
            this.comando = comando;

            this.Codigo = comando.Id;
            this.Order = comando.Order;
            this.Elemento = new ElementoModel(comando.Elemento);
            this.ValueElemento = comando.ValorElemento;
            if (this.Elemento != null)
            {
                this.TipoControle = comando.Elemento.TipoControle;
                if (comando.Elemento.OptionValues != null)
                {
                    comando.Elemento.OptionValues.ToList().ForEach(e =>
                    {
                        ComandosSugeridos.Add(e.valor);
                    });
                }
            }
            if (comando.Resultado != null)
            {
                this.Data = comando.Resultado.DataInicio;
                this.Diferenca = comando.Resultado.Diferenca;
                this.ScShot = ByteUtil.byteArrayToImage(comando.Resultado.ScrenShotBytes);
                switch (comando.Resultado.status) { 
                    case ConstResultadoStatus.STATUS_NAO_PASSOU:
                        Cor = ConstCOR.ERRO;
                        IsPassou = false;
                        break;
                    case ConstResultadoStatus.STATUS_PASSOU:
                        Cor = ConstCOR.SUCCESS;
                        IsPassou = true;
                        break;
                    default:
                        IsPassou = false;
                        Cor = ConstCOR.WARNING;
                        break;
                }
            }
            this.Valor = comando.Acao;
            this.SelectedComandoSugerido = comando.Acao;
            this.ValueText = comando.ValorElemento;
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

        private int _order;
        public int Order
        {
            get
            {
                
                return _order;
            }
            set
            {
                if (comando.Order != value)
                {
                    comando.Order = value;
                }
                SetField(ref _order, value);
            }
        }

        private bool _isComandValueVisible;
        public bool IsComandValueVisible
        {
            get { return _isComandValueVisible; }
            set { SetField(ref _isComandValueVisible, value); }
        }

        private bool _isComandResultVisible;
        public bool IsComandResulVisible
        {
            get { return _isComandResultVisible; }
            set { SetField(ref _isComandResultVisible, value); }
        }

        private string _valor;
        public string Valor
        {
            get { return _valor; }
            set
            {
                if (comando.Acao != value)
                {
                    comando.Acao = value;
                }

                SetField(ref _valor, value);

                if (string.IsNullOrEmpty(_valor))
                {
                    IsComandResulVisible = false;
                }
                else
                {
                    IsComandResulVisible = true;
                }
            }
        }

        private bool _isPassou;
        public bool IsPassou
        {
            get { return _isPassou; }
            set
            {
               
                SetField(ref _isPassou, value);

                if (IsPassou)
                {
                    Cor = ConstCOR.SUCCESS;
                }
                else
                {
                    Cor = ConstCOR.ERRO;

                }
            }
        }

        private string _cor;
        public string Cor { get { return _cor; } set { SetField(ref _cor, value); } }

        private string _valueElemento;
        public string ValueElemento
        {
            get { return _valueElemento; }
            set {

                if (comando.ValorElemento != value)
                {
                    comando.ValorElemento = value;
                }
                SetField(ref _valueElemento, value); }
        }

        private string _valueText;
        public string ValueText
        {
            get { return _valueText; }
            set {
                if (comando.ValorElemento != value)
                {
                    comando.ValorElemento = value;
                }
                SetField(ref _valueText, value); }
        }

        private string _selectedvalue;
        public string SelectedValue
        {
            get { return _selectedvalue; }

            set
            {
                SetField(ref _selectedvalue, value);

            }
        }

        private ObservableCollection<string> _values;
        public virtual ObservableCollection<string> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new ObservableCollection<string>();
                }
                return
                    _values;

            }
            set
            {

                SetField(ref _values, value);
            }
        }

        private ElementoModel _elemento;
        public virtual ElementoModel Elemento
        {
            get
            {

                return _elemento;
            }
            set
            {

                SetField(ref _elemento, value);
                //if (_elemento != null && _elemento.ElementoInfoId > 0)
                //{
                //    ElementoInfoId = _elemento.ElementoInfoId;

                //}

                //Elemento = _elemento;
            }
        }
        //public int? ElementoInfoId { get; set; }

        private string _TipoControle;

        public string TipoControle
        {
            get { return _TipoControle; }
            set
            {
                if (comando.Elemento.TipoControle != value)
                {
                    comando.Elemento.TipoControle = value;
                }
                SetField(ref _TipoControle, value);
            }
        }

        private ObservableCollection<string> _comandosSugeridos;
        public ObservableCollection<string> ComandosSugeridos
        {
            get
            {
                if (_comandosSugeridos == null) {
                    _comandosSugeridos = new ObservableCollection<string>();
                }
                return _comandosSugeridos;

            }
            set
            {
                SetField(ref _comandosSugeridos, value);
            }
        }

        private string _SelectedComandoSugerido;

        public string SelectedComandoSugerido
        {
            get { return _SelectedComandoSugerido; }
            set
            {
                
                SetField(ref _SelectedComandoSugerido, value);
                //if (
                //    _SelectedComandoSugerido == Sigef.Poc.Ftcapp.Entidade.Const.ConstActionCommand.ACTION_CLICK ||
                //    _SelectedComandoSugerido == Sigef.Poc.Ftcapp.Entidade.Const.ConstActionCommand.ACTION_CLOSE_ALERT ||
                //    _SelectedComandoSugerido == Sigef.Poc.Ftcapp.Entidade.Const.ConstActionCommand.ACTION_SWITCH_TO_LAST ||
                //    _SelectedComandoSugerido == Sigef.Poc.Ftcapp.Entidade.Const.ConstActionCommand.ACTION_SWITCH_TO_BACK ||
                //    _SelectedComandoSugerido == Sigef.Poc.Ftcapp.Entidade.Const.ConstActionCommand.ACTION_ClOSE_ALL_PAGES
                //    )
                //{
                //    IsComandValueVisible = false;
                //    IsComandResulVisible = false;
                //}
                //else
                //{
                //    IsComandValueVisible = true;
                //    if (!string.IsNullOrEmpty(Valor))
                //    {
                //        IsComandResulVisible = true;
                //    }

                //}
            }
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

                if (comando.Resultado.DataInicio != value)
                {
                    comando.Resultado.DataInicio = value;
                }
                SetField(ref _Data, value); }
        }

        private TimeSpan _Diferenca;
        public TimeSpan Diferenca
        {
            get
            {
                if (_Diferenca == null)
                {
                    _Diferenca = new TimeSpan(0);
                }
                return _Diferenca;

            }
            set {
                if (comando.Resultado.Diferenca != value)
                {
                    comando.Resultado.Diferenca = value;
                }
                SetField(ref _Diferenca, value); 
            
            }
        }

        private Image _scShot;
        public Image ScShot
        {
            get { return _scShot; }
            set {
                if (value != null && comando.Resultado.ScrenShotBytes != ByteUtil.imageToByteArray(value))
                {
                    comando.Resultado.ScrenShotBytes = ByteUtil.imageToByteArray(value);
                    ScreanshotImageSourse = ByteUtil.ToImageSource(value, ImageFormat.Png);
                }
                SetField(ref _scShot, value); 
            }
        }


        private ImageSource _screanshotImageSourse;


        public ImageSource ScreanshotImageSourse
        {
            get
            {
                return _screanshotImageSourse;
            }
            set
            {


                SetField(ref _screanshotImageSourse, value);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

       
    }
}
