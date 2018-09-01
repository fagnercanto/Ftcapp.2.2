using Sigef.Poc.Ftcapp.Entidade.Configuracoes;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class RuleMap : EntityTypeConfiguration<Rule>
    {
        public RuleMap()
        {
            ToTable("Rule");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);
            Property(e => e.Nome).HasMaxLength(120).IsOptional();
            Property(e => e.XPath).HasMaxLength(2000).IsOptional();

            HasMany<Config>(s => s.ConfigLista)
                 .WithMany(c => c.RuleLista)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("ConfigRefId");
                     cs.MapRightKey("RuleRefId");
                     cs.ToTable("ConfigRule");
                 });

        }
    }
}
