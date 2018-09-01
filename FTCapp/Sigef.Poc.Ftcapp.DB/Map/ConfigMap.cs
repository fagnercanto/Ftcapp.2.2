using Sigef.Poc.Ftcapp.Entidade;
using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class ConfigMap : EntityTypeConfiguration<Config>
    {
        public ConfigMap()
        {
            ToTable("Config");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);
            


            //Lista opcional
            //HasMany(e => e.RuleLista).WithOptional();


        }
    }
}
