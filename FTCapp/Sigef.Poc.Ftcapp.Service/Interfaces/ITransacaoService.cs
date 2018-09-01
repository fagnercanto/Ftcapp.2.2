using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service.Interfaces
{
    public interface ITransacaoService : IBaseService<Transacao>, IDisposable
    {

        List<EnumValidateModel> Validate(Transacao Transacao);


        List<Transacao> FindTransacaoByName(string nome);

        void AddTransacao(Transacao Transacao);
    }

}
