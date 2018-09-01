using Sigef.Poc.Ftcapp.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class CasoMap : EntityTypeConfiguration<Caso>
    {
        public CasoMap()
        {
            
            ToTable("Caso");
            HasKey(e => e.Id);

            Property(e => e.Nome).HasMaxLength(500).IsOptional();
            Property(e => e.NomeEditavel).HasMaxLength(120).IsOptional();
            Property(e => e.Data).IsOptional();
            Property(e => e.status).IsOptional();

            HasOptional(e => e.Transacao).WithOptionalPrincipal(); ;
          
          
            HasOptional(x => x.Config)
              .WithOptionalPrincipal();

            
                 HasMany<Suite>(s => s.SuiteLista)
                 .WithMany(c => c.CasoLista)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("SuiteRefId");
                     cs.MapRightKey("CasoRefId");
                     cs.ToTable("SuiteCaso");
                 });

           

        }
    }
}
