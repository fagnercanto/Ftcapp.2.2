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

    
    
        public class SuiteService : BaseService<Suite>, ISuiteService
        {
            IUnitOfWork _unitOfWork;
            //ISuiteRepository _repository;
            public SuiteService()
            {
                _unitOfWork = unitOfWork;
            }


        public List<EnumValidateModel> Validate(Suite item)
        {
            Validations = new List<EnumValidateModel>();
            Checagem(item);
            return Validations;
            
        }

        private void Checagem(Suite SuiteConceito)
        {
            
            
            if (SuiteConceito.CasoLista == null && SuiteConceito.CasoLista.Count == 0)
            {
                Validations.Add(EnumValidateModel.SUITE_ENPTY_CASOLISTA);
            }
            if (string.IsNullOrEmpty(SuiteConceito.Nome))
            {
                Validations.Add(EnumValidateModel.SUITE_EMPTY_NOME);
            }

            foreach (var caso in SuiteConceito.CasoLista)
            {


                ChecaCaso(caso);
                foreach (var comando in caso.ComandoLista)
                {

                    ChecaComando(comando);
                    ChecaElemento(comando.Elemento);



                }
            }

            
        }

        private void ChecaElemento(Elemento elemento)
        {
            if (string.IsNullOrEmpty(elemento.Nome))
            {
                Validations.Add(EnumValidateModel.CASO_EMPTY_COMANDOLIST);
            }
            if (string.IsNullOrEmpty(elemento.CodigoUi))
            {
                throw new Exception();
            }
            else if (string.IsNullOrEmpty(elemento.TipoControle))
            {
                throw new Exception();
            }
        }

        private void ChecaComando(Comando comando)
        {
            if (comando.Elemento == null)
            {
                throw new Exception();
            }
            else if (string.IsNullOrEmpty(comando.Acao))
            {
                throw new Exception();
            }
            else if (comando.Elemento == null)
            {
                throw new Exception();
            }
            else if (string.IsNullOrEmpty(comando.TipoComando))
            {
                throw new Exception();
            }
            else if (comando.Order == 0)
            {
                comando.Order = 4;

                throw new Exception();
            }
        }

        private void ChecaCaso(Caso caso)
        {
            if(string.IsNullOrEmpty(caso.Nome))
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

        public void AddSuite(Suite item)
        {
            IBaseRepository<Suite> sr = new BaseRepository<Suite>(_unitOfWork);
            IBaseRepository<Caso> ca = new BaseRepository<Caso>(_unitOfWork);
            IBaseRepository<Comando> co = new BaseRepository<Comando>(_unitOfWork);
            IBaseRepository<Elemento> el = new BaseRepository<Elemento>(_unitOfWork);
            IBaseRepository<Transacao> tr = new BaseRepository<Transacao>(_unitOfWork);
            IBaseRepository<Config> cf = new BaseRepository<Config>(_unitOfWork);
            IBaseRepository<Rule> rl = new BaseRepository<Rule>(_unitOfWork);
            IBaseRepository<ValorSugestao> ov = new BaseRepository<ValorSugestao>(_unitOfWork);
            IBaseRepository<Variavel> vr = new BaseRepository<Variavel>(_unitOfWork);












            foreach (var caso in item.CasoLista)
            {
                if (!(caso.Nome == "[1][[Login]]" || caso.Nome == "[2][[Menu]]" && caso.Id > 0)) { 
                
                
                foreach (var rule in caso.Config.RuleLista)
                {
                    if (rule.Id == 0)
                    {
                        rl.Add(rule);
                    }
                    else { rl.Edit(rule); }

                }

                foreach (var cmd in caso.ComandoLista)
                {


                    foreach (var opt in cmd.Elemento.OptionValues)
                    {
                        if (opt.Id == 0) { ov.Add(opt); } else { ov.Edit(opt); }
                    }
                    cmd.Elemento.OptionValues = new List<ValorSugestao>(cmd.Elemento.OptionValues);
                    if (cmd.Elemento.Id == 0)
                    {

                        el.Add(cmd.Elemento);
                    }
                    else { el.Edit(cmd.Elemento); }

                    if (cmd.Id == 0) { co.Add(cmd); } else { co.Edit(cmd); }

                }
                caso.Config.RuleLista = new List<Rule>(caso.Config.RuleLista);
                if (caso.Config.Id == 0) { cf.Add(caso.Config); } else { cf.Edit(caso.Config); }

                caso.Transacao.ElementoLista = new List<ElementoTransacao>(caso.Transacao.ElementoLista);
                if (caso.Transacao.Id == 0) { tr.Add(caso.Transacao); } else { tr.Edit(caso.Transacao); }

                caso.ComandoLista = new List<Comando>(caso.ComandoLista);
                if (caso.Id == 0) { ca.Add(caso); } else { ca.Edit(caso); }
                }
            }
            foreach (var variavel in item.VariavelLista)
            {
                if (variavel.Id == 0) { vr.Add(variavel); } else { vr.Edit(variavel); }
            }

            item.CasoLista = new List<Caso>(item.CasoLista);
            item.VariavelLista = new List<Variavel>(item.VariavelLista);
            if (item.Id == 0)
            {

                sr.Add(item);

            }
            else
            {

                sr.Edit(item);
            }

            _unitOfWork.Save();

#if DEBUG

            var sss = sr.Find(item.Id);
            //System.Diagnostics.Debug.Assert(sss.CasoLista.Count == item.CasoLista.Count, item.Nome + "########## ERRO SALVAR SUITE############\n ERRO N SALVOU LISTA DE CASOS CORRETAMENTE\n###################", "Suite");

#endif
        }


       


        public List<Suite> FindSuiteByName(string nome)
        {
            List<Suite> Suites = null;
            var lt = List().Where(e => e.Nome == nome);
            if (lt.Count() == 0)
            {
                Suites = new List<Suite>();
            }
            else
            {
                Suites = lt.ToList();

            }
            return Suites;
        }

        public List<Suite> FindSuiteByContains(string contains)
        {
            List<Suite> Suites = null;
            var lt = List().Where(e => e.Nome.Contains(contains));
            if (lt.Count() == 0)
            {
                Suites = new List<Suite>();
            }
            else
            {
                Suites = lt.ToList();

            }
            return Suites;
        }

            
        }

}
