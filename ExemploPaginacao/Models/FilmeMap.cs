namespace ExemploPaginacao.Models
{
    using System.Data.Entity.ModelConfiguration;

    public class FilmeMap : EntityTypeConfiguration<Filme>
    {
        public FilmeMap()
        {
            HasKey(x => x.FilmeId);

            Property(x => x.Ano);
            Property(x => x.Diretor);
            Property(x => x.Nome);
        }
    }
}