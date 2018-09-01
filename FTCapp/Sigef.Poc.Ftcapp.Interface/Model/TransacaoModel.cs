using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class TransacaoModel : BaseNotifyPropertyChanged, ICloneable
    {
        public Transacao transacao { get; set; }
        public TransacaoModel(Transacao transacao) {
            this.transacao = transacao;
            this.Codigo = transacao.Id;
            this.CDTRANSACAO = transacao.CDTRANSACAO;
            this.NMPAGINA = transacao.NMPAGINA;
            this.NMTRANSACAO = transacao.NMTRANSACAO;
            this.SGMODULO = transacao.SGMODULO;
            transacao.ElementoLista.ToList().ForEach(e => {

                Elemento ee = ElementoToElementoTransacao(e);
                ElementoList.Add(new ElementoModel(ee));
            });
        }
        private static ElementoTransacao ElementoToElementoTransacao2(Elemento el)
        {
            ElementoTransacao elcopy = new ElementoTransacao();

            elcopy.TipoControle = el.TipoControle;
            elcopy.CodigoUi = el.CodigoUi;
            elcopy.ClassName = el.ClassName;
            elcopy.Nome = el.Nome;
            elcopy.Altura = el.Altura;
            elcopy.Largura = el.Largura;
            elcopy.X = el.X;
            elcopy.Y = el.Y;
            elcopy.Type = el.Type;
            elcopy.Displayed = el.Displayed;
            elcopy.Enabled = el.Enabled;
            elcopy.Selected = el.Selected;
            elcopy.TagName = el.TagName;
            elcopy.TabIndex = el.TabIndex;
            elcopy.Text = el.Text;
            elcopy.IsComposto = el.IsComposto;
            elcopy.IsObrigatorio = el.IsObrigatorio;
            elcopy.IsCampoPesquisa = el.IsCampoPesquisa;
            elcopy.CodigoComandoComposto = el.CodigoComandoComposto;
            elcopy.FindElementBy = el.FindElementBy;
            elcopy.onclick = el.onclick;
            elcopy.isGrid = el.isGrid;


            return elcopy;
        }
        private static Elemento ElementoToElementoTransacao(ElementoTransacao el)
        {
            Elemento elcopy = new Elemento();

            elcopy.TipoControle = el.TipoControle;
            elcopy.CodigoUi = el.CodigoUi;
            elcopy.ClassName = el.ClassName;
            elcopy.Nome = el.Nome;
            elcopy.Altura = el.Altura;
            elcopy.Largura = el.Largura;
            elcopy.X = el.X;
            elcopy.Y = el.Y;
            elcopy.Type = el.Type;
            elcopy.Displayed = el.Displayed;
            elcopy.Enabled = el.Enabled;
            elcopy.Selected = el.Selected;
            elcopy.TagName = el.TagName;
            elcopy.TabIndex = el.TabIndex;
            elcopy.Text = el.Text;
            elcopy.IsComposto = el.IsComposto;
            elcopy.IsObrigatorio = el.IsObrigatorio;
            elcopy.IsCampoPesquisa = el.IsCampoPesquisa;
            elcopy.CodigoComandoComposto = el.CodigoComandoComposto;
            elcopy.FindElementBy = el.FindElementBy;
            elcopy.onclick = el.onclick;
            elcopy.isGrid = el.isGrid;


            return elcopy;
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

        private int _CDTRANSACAO;
        public int CDTRANSACAO
        {
            get { return _CDTRANSACAO; }
            set {
                if (transacao.CDTRANSACAO != value)
                {
                    transacao.CDTRANSACAO = value;
                }
                SetField(ref _CDTRANSACAO, value); 
            }
        }

        private string _NMTRANSACAO;


        public string NMTRANSACAO
        {
            get { return _NMTRANSACAO; }
            set {
                if (transacao.NMTRANSACAO != value)
                {
                    transacao.NMTRANSACAO = value;
                }
                SetField(ref _NMTRANSACAO, value); }
        }

        private string _NMPAGINA;


        public string NMPAGINA
        {
            get { return _NMPAGINA; }
            set {
                if (transacao.NMPAGINA != value)
                {
                    transacao.NMPAGINA = value;
                }
                SetField(ref _NMPAGINA, value); 
            }
        }

        private string _SGMODULO;


        public string SGMODULO
        {
            get { return _SGMODULO; }
            set {
                if (transacao.SGMODULO != value)
                {
                    transacao.SGMODULO = value;
                }
                SetField(ref _SGMODULO, value); 
            }
        }

        private bool _IsCurrent;



        public bool IsCurrent
        {
            get { return _IsCurrent; }
            set { 
                
                SetField(ref _IsCurrent, value); }
        }

        private ObservableCollection<ElementoModel> _ElementoList;
        public virtual ObservableCollection<ElementoModel> ElementoList
        {
            get
            {

                  
                if(_ElementoList==null){
                    _ElementoList = new ObservableCollection<ElementoModel>();
                }

                return _ElementoList;

            }
            set
            {
                SetField(ref _ElementoList, value);
            }
        }

        private ElementoModel _SelectedElemento;


        public ElementoModel SelectedElemento
        {
            get { return _SelectedElemento; }
            set { SetField(ref _SelectedElemento, value); }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
