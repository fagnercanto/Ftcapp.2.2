using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Const;
using Sigef.Poc.Ftcapp.Interface.Commands;
using System;

namespace Sigef.Poc.Ftcapp.Interface.Model
{
    public class MensagemModel : BaseNotifyPropertyChanged, ICloneable
    {
        //public MensagemModel(Mensagem mensagem)
        //{
        //    this.Cod = mensagem.MensagemId;
        //    this.Tipo = mensagem.Tipo;
        //    this.Msg = mensagem.Msg;
        //}

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


        private string _Msg;
        public string Msg
        {
            get
            {
                if (_Msg == null)
                {
                    _Msg = "";
                }

                return _Msg;
            }
            set
            {
                SetField(ref _Msg, value);

            }
        }

        private string _Tipo;
        public string Tipo
        {
            get
            {
                if (_Tipo == null)
                {
                    _Tipo = "";
                }

                return _Tipo;
            }
            set
            {
                SetField(ref _Tipo, value);
                switch (value)
                {
                    case ConstMensagem.ERRO:
                        break;
                    case ConstMensagem.SUCCESS:
                        break;
                    case ConstMensagem.WARNING:
                        break;
                    default:
                        break;
                }

            }
        }

        private string _Cor;
        public string Cor
        {
            get
            {
                if (_Cor == null)
                {
                    _Cor = "";
                }

                return _Cor;
            }
            set
            {
                SetField(ref _Cor, value);

            }
        }

        public object Clone()
        {

            throw new NotImplementedException();
        }
    }
}
