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
    public class CasoRepository : BaseRepository<Caso>, ICasoRepository
        
    {
        IUnitOfWork unitOfWork = new DataContext();
        public CasoRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            
        }

       


    }



}
