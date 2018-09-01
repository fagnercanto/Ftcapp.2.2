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

    
    
        public class TransacaoService : BaseService<Transacao>, ITransacaoService
        {
            IUnitOfWork _unitOfWork;
            //ITransacaoRepository _repository;
            public TransacaoService()
            {
                _unitOfWork = unitOfWork;
            }


        public List<EnumValidateModel> Validate(Transacao item)
        {
            Validations = new List<EnumValidateModel>();
            Checagem(item);
            return Validations;
            
        }

        private void Checagem(Transacao TransacaoConceito)
        {


           

            
        }

       

        

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Transacao> FindTransacaoByName(string nome)
        {
            List<Transacao> Transacaos = null;
            var lt = List().Where(e => e.NMTRANSACAO == nome);
            if (lt.Count() == 0)
            {
                Transacaos = new List<Transacao>();
            }
            else
            {
                Transacaos = lt.ToList();

            }
            return Transacaos;
        }

        public List<Transacao> FindTransacaoByContains(string contains)
        {
            List<Transacao> Transacaos = null;
            var lt = List().Where(e => e.NMTRANSACAO.Contains(contains));
            if (lt.Count() == 0)
            {
                Transacaos = new List<Transacao>();
            }
            else
            {
                Transacaos = lt.ToList();

            }
            return Transacaos;
        }



        public void AddTransacao(Transacao Transacao)
        {
            Add(Transacao);
        }
        }

}
