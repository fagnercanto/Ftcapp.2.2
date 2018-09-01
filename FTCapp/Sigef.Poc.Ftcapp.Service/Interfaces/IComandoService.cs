using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service.Interfaces
{
    public interface IComandoService : IBaseService<Comando>, IDisposable
    {

        List<EnumValidateModel> Validate(Comando Comando);


        void AddComando(Comando Comando);
    }

}
