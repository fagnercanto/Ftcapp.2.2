using Sigef.Poc.Ftcapp.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class ComandoMap : EntityTypeConfiguration<Comando>
    {
        public ComandoMap()
        {
            ToTable("Comando");
            // // Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
            HasKey(e => e.Id);
            Property(e => e.TipoComando).IsOptional();
            Property(e => e.Acao).IsOptional();
            Property(e => e.ValorElemento).IsOptional();
            // Property("Elemento").
            HasRequired(e => e.Elemento);
            

            HasMany<Caso>(s => s.CasoLista)
                 .WithMany(c => c.ComandoLista)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("CasoRefId");
                     cs.MapRightKey("ComandoRefId");
                     cs.ToTable("CasoComando");
                 });

            // Um comando deve ter apenas um Elemento
            
        }
    }
}
