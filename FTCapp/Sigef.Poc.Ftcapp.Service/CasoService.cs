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

    
    
        public class CasoService : BaseService<Caso>, ICasoService
        {
            IUnitOfWork _unitOfWork;
            //ICasoRepository _repository;
            public CasoService()
            {
                _unitOfWork = unitOfWork;
            }


        public List<EnumValidateModel> Validate(Caso item)
        {
            Validations = new List<EnumValidateModel>();
            Checagem(item);
            return Validations;
            
        }

        private void Checagem(Caso caso)
        {


            ChecaCaso(caso);

            
        }


        private void ChecaCaso(Caso caso)
        {
            if (string.IsNullOrEmpty(caso.Nome))
            {
                Validations.Add(EnumValidateModel.CASO_EMPTY_NOME);
            }
            else if (caso.ComandoLista == null || caso.ComandoLista.Count == 0)
            {
                Validations.Add(EnumValidateModel.CASO_EMPTY_COMANDOLIST);
            }
            else if (caso.Order <= 0)
            {
                Validations.Add(EnumValidateModel.CASO_EMPTY_ORDER);
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void AddCaso(Caso item)
        {
            IBaseRepository<Caso> sr = new BaseRepository<Caso>(_unitOfWork);
            IBaseRepository<Caso> ca = new BaseRepository<Caso>(_unitOfWork);
            IBaseRepository<Comando> co = new BaseRepository<Comando>(_unitOfWork);
            IBaseRepository<Elemento> el = new BaseRepository<Elemento>(_unitOfWork);
            IBaseRepository<ElementoTransacao> elt = new BaseRepository<ElementoTransacao>(_unitOfWork);
            IBaseRepository<Transacao> tr = new BaseRepository<Transacao>(_unitOfWork);
            IBaseRepository<Config> cf = new BaseRepository<Config>(_unitOfWork);
            IBaseRepository<Rule> rl = new BaseRepository<Rule>(_unitOfWork);
            IBaseRepository<ValorSugestao> ov = new BaseRepository<ValorSugestao>(_unitOfWork);
            IBaseRepository<Variavel> vr = new BaseRepository<Variavel>(_unitOfWork);

                foreach (var rule in item.Config.RuleLista)
                {
                    if (rule.Id == 0) {
                        rl.Add(rule);
                    }
                    else { rl.Edit(rule); }
                    
                }
                foreach (var e in item.Transacao.ElementoLista)
                {
                    
                    
                    if (e.Id == 0) { elt.Add(e); } else { elt.Edit(e); }
                    
                }
                foreach (var cmd in item.ComandoLista) {
                    
                    
                    foreach (var opt in cmd.Elemento.OptionValues)
                    {
                        if (opt.Id == 0) { ov.Add(opt); } else { ov.Edit(opt); }
                    }
                    cmd.Elemento.OptionValues = new List<ValorSugestao>(cmd.Elemento.OptionValues);
                    if (cmd.Elemento.Id == 0) { el.Add(cmd.Elemento); } else { el.Edit(cmd.Elemento); }
                    
                    if (cmd.Id == 0) { co.Add(cmd); } else { co.Edit(cmd); }
                    
                }
                item.Config.RuleLista = new List<Rule>(item.Config.RuleLista);
                if (item.Config.Id == 0) { cf.Add(item.Config); } else { cf.Edit(item.Config); }

                item.Transacao.ElementoLista = new List<ElementoTransacao>(item.Transacao.ElementoLista);
                if (item.Transacao.Id == 0) { tr.Add(item.Transacao); } else { tr.Edit(item.Transacao); }

                item.ComandoLista = new List<Comando>(item.ComandoLista);
                if (item.Id == 0) { ca.Add(item); } else { ca.Edit(item); }
            
            if (item.Id == 0)
            {
                
                sr.Add(item);
               
            }
            else {
                
                sr.Edit(item);
            }

            _unitOfWork.Save();
            
#if DEBUG
           
            
                   
#endif
        }

        public List<Caso> FindCasoByName(string nome)
        {
            List<Caso> casos = null;
           var lt =  List().Where(e => e.Nome == nome);
           if (lt.Count() == 0)
           {
               casos = new List<Caso>();
           }
           else {
               casos = lt.ToList();
           
           }
           return casos;
        }

        public List<Caso> FindCasoByContains(string contains)
        {
            List<Caso> casos = null;
            var lt = List().Where(e => e.Nome.Contains(contains));
            if (lt.Count() == 0)
            {
                casos = new List<Caso>();
            }
            else
            {
                casos = lt.ToList();

            }
            return casos;
        }
            
        }

}
