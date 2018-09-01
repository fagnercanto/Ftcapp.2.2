using Sigef.Poc.Ftcapp.DB.Data.Contexts.Interfaces;
using Sigef.Poc.Ftcapp.Util;
using Sigef.Poc.Ftcapp.Util.Jason;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.DB.Data.Repositories
{
    public class BaseRepository<T>
        : IDisposable, IBaseRepository<T> where T : class
    {
        private DataContext _context;

        #region Ctor
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _context = unitOfWork as DataContext;
        }
        #endregion

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public void Add(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                   

                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:[Name:" +
                        eve.Entry.Entity.GetType().Name + "][Statate:" + eve.Entry.State + "]", "DbEntityValidationException:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("[Property: \"{0}\"] [Erro: \"{1}\"][PropertyName:" +
                            ve.PropertyName + "][ErrorMessage:" + ve.ErrorMessage + "]");
                    }
                 
                }
                throw;
            }
            catch {
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, "", "");

            }
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void Edit(T item)
        {
            try { 
            _context.Entry(item).State = EntityState.Modified;
            }catch(Exception ex){
                new Sigef.Poc.Ftcapp.Util.LOG.LogUtil().FormaTLogException(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.GetType().Name, ex.Message);
                }
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Refresh()
        {
            _context.Dispose();
            _context = new DataContext();
        }
    }
    }




