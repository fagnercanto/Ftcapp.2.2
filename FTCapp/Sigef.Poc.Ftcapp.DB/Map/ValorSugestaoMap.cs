using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    class ValorSugestaoMap : EntityTypeConfiguration<ValorSugestao>
    {
        public ValorSugestaoMap()
        {
            ToTable("ValorSugestao");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);

            Property(e => e.valor).HasMaxLength(350).IsOptional();

            HasMany<Elemento>(s => s.ElementoLista )
                 .WithMany(c => c.OptionValues)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("ElementoRefId");
                     cs.MapRightKey("OptionRefId");
                     cs.ToTable("ElementoOption");
                 });

        }

    }

}
