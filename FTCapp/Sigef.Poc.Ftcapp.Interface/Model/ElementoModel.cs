using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System;

namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class ElementoModel : BaseNotifyPropertyChanged, ICloneable
    {

        public ElementoModel(Elemento elemento)
        {
            this.elemento = elemento;
            this.Codigo = elemento.Id;
            this.Nome = elemento.Nome;
            this.Selected = elemento.Selected;
            this.TagName = elemento.TagName;
            this.Text = elemento.Text;
            this.Altura = elemento.Altura;
            this.Largura = elemento.Largura;
            this.X = elemento.X;
            this.Y = elemento.Y;
            this.Type = elemento.Type;
            this.Displayed = elemento.Displayed;
            this.Enabled = elemento.Enabled;
            this.ClassName = elemento.ClassName;
            this.CodigoUi = elemento.CodigoUi;
            this.IsObrigatorio = elemento.IsObrigatorio ? "SIM" : "NAO";
            this.IsCampoPesquisa = elemento.IsCampoPesquisa ? "SIM" : "NAO";
            this.IsComposto = elemento.IsComposto ? "SIM" : "NAO";
            this.IsGrid = elemento.isGrid ? "SIM" : "NAO";
            this.IsCampoPesquisa = elemento.IsCampoPesquisa ? "SIM" : "NAO";
        }

        public Elemento elemento { get; set; }

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

        private string _codigoUi;
        public string CodigoUi
        {
            get
            {

                return _codigoUi;
            }
            set
            {
                if (elemento.CodigoUi != value)
                {
                    elemento.CodigoUi = value;
                }
                SetField(ref _codigoUi, value);
            }
        }

        private string _className;
        public string ClassName
        {
            get { return _className; }
            set {
                if (elemento.ClassName != value)
                {
                    elemento.ClassName = value;
                }
                SetField(ref _className, value); 
            }
        }

        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set {
                if (elemento.Nome != value)
                {
                    elemento.Nome = value;
                }
                SetField(ref _nome, value); 
            }
        }

        private string _altura;
        public string Altura
        {
            get { return _altura; }
            set {

                if (elemento.Altura != value)
                {
                    elemento.Altura = value;
                }
                SetField(ref _altura, value); }
        }

        private string _largura;
        public string Largura
        {
            get { return _largura; }
            set {

                if (elemento.Altura != value)
                {
                    elemento.Altura = value;
                }
                SetField(ref _largura, value); }
        }

        private string _x;
        public string X
        {
            get { return _x; }
            set {
                if (elemento.X != value)
                {
                    elemento.X = value;
                }
                SetField(ref _x, value); }
        }

        private string _y;
        public string Y
        {
            get { return _y; }
            set {
                if (elemento.Y != value)
                {
                    elemento.Y = value;
                }

                SetField(ref _y, value); 
            }
        }

        public object Clone()
        {

            return this.MemberwiseClone();
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                if (elemento.Type != value)
                {
                    elemento.Type = value;
                }
                SetField(ref _type, value);

            }
        }

        private bool _Displayed;
        public bool Displayed
        {
            get { return _Displayed; }
            set {
                if (elemento.Displayed != value)
                {
                    elemento.Displayed = value;
                }
                SetField(ref _Displayed, value); 
            
            }
        }

        private bool _Enabled;
        public bool Enabled
        {
            get { return _Enabled; }
            set {
                if (elemento.Enabled != value)
                {
                    elemento.Enabled = value;
                }
                SetField(ref _Enabled, value); 
            }
        }

        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set {

                if (elemento.Selected != value)
                {
                    elemento.Selected = value;
                }
                SetField(ref _Selected, value); 
            
            }
        }


        private string _TagName;
        public string TagName
        {
            get { return _TagName; }
            set {
                if (elemento.TagName != value)
                {
                    elemento.TagName = value;
                }
                SetField(ref _TagName, value); 
            }
        }

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set {
                if (elemento.Text != value)
                {
                    elemento.Text = value;
                }
                SetField(ref _Text, value); 
            }
        }

        private string _IsComposto;
        public string IsComposto
        {
            get { return _IsComposto; }
            set {
               
                SetField(ref _IsComposto, value); 
            }
        }

        private string _IsGrid;
        public string IsGrid
        {
            get { return _IsGrid; }
            set { SetField(ref _IsGrid, value); }
        }

        private string _IsObrigatorio;
        public string IsObrigatorio
        {
            get { return _IsObrigatorio; }
            set { SetField(ref _IsObrigatorio, value); }
        }

        private string _IsCampoPesquisa;
        public string IsCampoPesquisa
        {
            get { return _IsCampoPesquisa; }
            set { SetField(ref _IsCampoPesquisa, value); }
        }

        private int _codigoComandosCompostos;
        public int CodigoComandoComposto
        {
            get
            {

                return _codigoComandosCompostos;

            }
            set
            {
                SetField(ref _codigoComandosCompostos, value);
            }
        }
    }
}
