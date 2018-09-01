using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service.Interfaces
{
    public interface IElementoService : IBaseService<Elemento>, IDisposable
    {

        List<EnumValidateModel> Validate(Elemento Elemento);


        void AddElemento(Elemento Elemento);
    }

}
