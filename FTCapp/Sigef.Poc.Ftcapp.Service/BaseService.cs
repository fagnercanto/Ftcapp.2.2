using Sigef.Poc.Ftcapp.DB;
using Sigef.Poc.Ftcapp.DB.Data.Contexts.Interfaces;
using Sigef.Poc.Ftcapp.DB.Data.Repositories;
using Sigef.Poc.Ftcapp.Service.Interfaces;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.Service
{
        public class BaseService<T> : IBaseService<T> where T : class
    {
        private IUnitOfWork _unitOfWork;

        public IUnitOfWork unitOfWork{
        get{
            if(_unitOfWork==null)
        {
                _unitOfWork = new DataContext();
            
            }
        return _unitOfWork;
        }
            set { _unitOfWork = value; }
        } 


        IBaseRepository<T> _repository;
        public List<EnumValidateModel> Validations;
        public BaseService()
        {
            _repository = new BaseRepository<T>(unitOfWork);
        }
  
        public T Find(int id)
        {
            return _repository.Find(id);
        }
  
        public IQueryable<T> List()
        {
            return _repository.List();
        }
  
        public void Add(T item)
        {          
            _repository.Add(item);
            unitOfWork.Save();
        }
  
        public void Remove(T item)
        {
            _repository.Remove(item);
            unitOfWork.Save();
        }
  
        public void Edit(T item)
        {
            _repository.Edit(item);
            unitOfWork.Save();
        }

        
    }



}
