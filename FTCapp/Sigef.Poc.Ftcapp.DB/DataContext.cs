
using Sigef.Poc.Ftcapp.DB.Data.Contexts.Interfaces;
using Sigef.Poc.Ftcapp.DB.Map;
using Sigef.Poc.Ftcapp.DB.Migrations;
using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using Sigef.Poc.Ftcapp.Util.LOG;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace Sigef.Poc.Ftcapp.DB
{
    /*
     ao incluir um novo DSSet/Tabela
     * Add-Migration comentario
       Update-Database
     */
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext()
        {
            string stringconection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\SIGEF\\SC\\Utilitarios\\FTCappPOC\\BD\\sqlserver\\ftcappDBtr8.mdf";

            Database.Connection.ConnectionString = stringconection;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;

            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

        }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<ElementoTransacao> ElementosTransacao { get; set; }
        public DbSet<Suite> Suites { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<Comando> Comandos { get; set; }

        public DbSet<Resultado> Resultados { get; set; }

        public DbSet<ValorSugestao> ValorSugestaos { get; set; }

        public DbSet<Config> Configs { get; set; }
        public DbSet<Rule> Rules { get; set; }

        public DbSet<Variavel> Variavels { get; set; }

        //public DbSet<ElementoExemplo> ElementoExemplo { get; set; }

        //public DbSet<ComandoExemplo> ComandoExemplo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new CasoMap());
            modelBuilder.Configurations.Add(new SuiteMap());
            modelBuilder.Configurations.Add(new ResultadoMap());
            modelBuilder.Configurations.Add(new TransacaoMap());
            modelBuilder.Configurations.Add(new ComandoMap());
            modelBuilder.Configurations.Add(new ValorSugestaoMap());
            modelBuilder.Configurations.Add(new ProjetoMap());
            modelBuilder.Configurations.Add(new ElementoMap());
            modelBuilder.Configurations.Add(new ElementoTransacaoMap());
            modelBuilder.Configurations.Add(new ConfigMap());
            modelBuilder.Configurations.Add(new RuleMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                         .Where(p => p.Name == "Id")
                         .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
            .Configure(p => p.HasMaxLength(250));





            
            
           
            
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
            .Configure(p => p.HasMaxLength(350));





            base.OnModelCreating(modelBuilder);

        }
        private LogUtil _log;

        public LogUtil log
        {
            get
            {
                if (_log == null) { _log = new LogUtil(); }
                return _log;
            }
            set { _log = value; }
        }
        public void Save()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    log.TraceInicioFim();
                    log.TraceOpenIdent();
                    
                    log.TraceWriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:[Name:"+
                        eve.Entry.Entity.GetType().Name + "][Statate:" + eve.Entry.State + "]", "DbEntityValidationException:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("[Property: \"{0}\"] [Erro: \"{1}\"][PropertyName:"+
                            ve.PropertyName + "][ErrorMessage:"+ ve.ErrorMessage+"]");
                    }
                    log.TraceCloseIdent();
                    log.TraceInicioFim();
                }
                throw;
            }

            
        }
    }
}
