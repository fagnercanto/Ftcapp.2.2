using Sigef.Poc.Ftcapp.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class ElementoTransacaoMap : EntityTypeConfiguration<ElementoTransacao>
    {
        public ElementoTransacaoMap()
        {
            ToTable("ElementTransacao");

            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);

            Property(e => e.CodigoUi).HasMaxLength(350).IsOptional();
            Property(e => e.Nome).HasMaxLength(350).IsOptional();
            Property(e => e.ClassName).HasMaxLength(350).IsOptional();
            Property(e => e.TagName).HasMaxLength(350).IsOptional();
            Property(e => e.Text).HasMaxLength(500).IsOptional();
            Property(e => e.Type).HasMaxLength(350).IsOptional();
            Property(e => e.TipoControle).HasMaxLength(350).IsOptional();
            Property(e => e.CodigoComandoComposto).IsOptional();
            Property(e => e.Enabled).IsOptional();
            Property(e => e.Displayed).IsOptional();
            Property(e => e.Altura).HasMaxLength(120).IsOptional();
            Property(e => e.Largura).HasMaxLength(120).IsOptional();
            Property(e => e.onclick).HasMaxLength(4000).IsOptional();
            //ListaOpcional
            //HasMany(e => e.OptionValues).WithOptional();

            HasMany<Transacao>(s => s.TransacaoLista)
                 .WithMany(c => c.ElementoLista)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("TransacaoaRefId");
                     cs.MapRightKey("ElementoTransacaoRefId");
                     cs.ToTable("TransacaoElementoTransacao");
                 });
        }
    }
}
