using Sigef.Poc.Ftcapp.DB;
using Sigef.Poc.Ftcapp.DB.Data.Contexts.Interfaces;
using Sigef.Poc.Ftcapp.DB.Data.Repositories;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Service.Interfaces;
using Sigef.Poc.Ftcapp.Util.ValidateEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sigef.Poc.Ftcapp.Service
{

    
    
        public class ElementoService : BaseService<Elemento>, IElementoService
        {
            IUnitOfWork _unitOfWork;
            //IElementoRepository _repository;
            public ElementoService()
            {
                _unitOfWork = unitOfWork;
            }


        public List<EnumValidateModel> Validate(Elemento item)
        {
            Validations = new List<EnumValidateModel>();
            Checagem(item);
            return Validations;
            
        }

        private void Checagem(Elemento ElementoConceito)
        {


           

            
        }

       

        



       

        



        public void AddElemento(Elemento Elemento)
        {
            Add(Elemento);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        }

}
