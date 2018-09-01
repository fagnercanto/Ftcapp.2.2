using Sigef.Poc.Ftcapp.DB.Data.Contexts.Interfaces;
using Sigef.Poc.Ftcapp.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.DB.Data.Repositories
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
        
    {
        IUnitOfWork unitOfWork = new DataContext();
        public TransacaoRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }

       


    }



}
