using Sigef.Poc.Ftcapp.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class TransacaoMap : EntityTypeConfiguration<Transacao>
    {
        public TransacaoMap()
        {
            ToTable("Transacao");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);

            Property(e => e.NMPAGINA).HasMaxLength(500).IsOptional();
            Property(e => e.NMTRANSACAO).HasMaxLength(500).IsOptional();
            Property(e => e.SGMODULO).HasMaxLength(500).IsOptional();
            Property(e => e.NMPAGINA).HasMaxLength(500).IsOptional();
            Property(e => e.CDTRANSACAO).IsOptional();
            
            

        }

    }
}
