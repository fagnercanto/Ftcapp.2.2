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

    
    
        public class ComandoService : BaseService<Comando>, IComandoService
        {
            IUnitOfWork _unitOfWork;
            //IComandoRepository _repository;
            public ComandoService()
            {
                _unitOfWork = unitOfWork;
            }


        public List<EnumValidateModel> Validate(Comando item)
        {
            Validations = new List<EnumValidateModel>();
            Checagem(item);
            return Validations;
            
        }

        private void Checagem(Comando ComandoConceito)
        {


           

            
        }

       

        



       

        



        public void AddComando(Comando Comando)
        {
            Add(Comando);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        }

}
