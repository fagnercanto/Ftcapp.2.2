using Sigef.Poc.Ftcapp.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class SuiteMap : EntityTypeConfiguration<Suite>
    {
        public SuiteMap()
        {
            ToTable("Suite");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);
            Property(e => e.Nome).HasMaxLength(120).IsOptional();
            
            //Property(e => e.NomeEditavel).HasMaxLength(120).IsOptional();
            //Property(e => e.Data).IsOptional();
            //Property(e => e.status).IsOptional();
            //HasOptional(x => x.Config)
            //  .WithOptionalPrincipal();

            //Lista opcional
            //HasMany(e => e.CasoLista).WithOptional();


        }
    }
}
