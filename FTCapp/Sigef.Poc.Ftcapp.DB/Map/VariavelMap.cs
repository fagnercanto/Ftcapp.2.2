using Sigef.Poc.Ftcapp.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class VariavelMap : EntityTypeConfiguration<Variavel>
    {
        public VariavelMap()
        {
            ToTable("Variavel");
            // // Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
            HasKey(e => e.Id);
            Property(e => e.Tipo).IsOptional();
            Property(e => e.Find).IsOptional();
            Property(e => e.Valor).IsOptional();
            // Property("Elemento").

            HasMany<Suite>(s => s.SuiteLista)
                 .WithMany(c => c.VariavelLista)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("SuiteRefId");
                     cs.MapRightKey("VariavelRefId");
                     cs.ToTable("SuiteVariavel");
                 });

            // Um comando deve ter apenas um Elemento
            
        }
    }
}
