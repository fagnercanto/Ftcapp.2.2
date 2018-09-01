using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service.Interfaces
{
    public interface ISuiteService : IBaseService<Suite>, IDisposable
    {

        List<EnumValidateModel> Validate(Suite suite);

        List<Suite> FindSuiteByName(string nome);
        

        void AddSuite(Suite suite);
    }

}
