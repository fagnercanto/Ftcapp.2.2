using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        
        T Find(int id);
        IQueryable<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
        

    }

}
