using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service.Interfaces
{
    public interface ICasoService : IBaseService<Caso>, IDisposable
    {

        List<EnumValidateModel> Validate(Caso Caso);


        List<Caso> FindCasoByName(string nome);

        void AddCaso(Caso Caso);
    }

}
