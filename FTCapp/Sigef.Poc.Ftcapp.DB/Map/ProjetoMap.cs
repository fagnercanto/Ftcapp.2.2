using Sigef.Poc.Ftcapp.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigef.Poc.Ftcapp.DB.Map
{
    public class ProjetoMap : EntityTypeConfiguration<Projeto>
    {
        public ProjetoMap() {
            ToTable("Projeto");
            //Property(e => e.Cod).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasKey(e => e.Id);

            Property(e => e.Url).HasMaxLength(350).IsOptional();
            Property(e => e.Nome).IsOptional();
            Property(e => e.BaseUri).IsOptional();

            HasMany(e => e.TransacaoLista).WithOptional();
        }
    }
}
