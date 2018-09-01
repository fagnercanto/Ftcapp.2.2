using Sigef.Poc.Ftcapp.Util.Byte;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sigef.Poc.Ftcapp.Interface.Commands
{
    public abstract class BaseNotifyPropertyChanged : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

            }


        }

        private ByteUtil _ByteUtil;
        public ByteUtil ByteUtil
        {
            get
            {
                if (_ByteUtil == null)
                {
                    _ByteUtil = new ByteUtil();
                }
                return _ByteUtil;
            }
            set
            {

                SetField(ref _ByteUtil, value);
            }
        }



    }
}
