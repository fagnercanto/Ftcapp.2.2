using Sigef.Poc.Ftcapp.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class ResultadoMap : EntityTypeConfiguration<Resultado>
    {
        public ResultadoMap()
        {
            ToTable("Resultado");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);
            Property(e => e.feedBack).HasMaxLength(200).IsOptional();
            
            Property(e => e.DataInicio).IsOptional();
            Property(e => e.Diferenca).IsOptional();

            

        }
    }
}
