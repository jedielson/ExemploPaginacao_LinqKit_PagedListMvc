namespace ExemploPaginacao.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Diagnostics;

    public class EntityContext : DbContext
    {
        static EntityContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public EntityContext()
            : base("StringConexao")
        {
            Database.Log = s => Debug.Write(s);
        }

        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FilmeMap());
            //modelBuilder.Configurations.Add(new ArtistMap());
            //modelBuilder.Configurations.Add(new AlbumMap());
            //modelBuilder.Configurations.Add(new CartMap());
            //modelBuilder.Configurations.Add(new OrderMap());
            //modelBuilder.Configurations.Add(new OrderDetailMap());
        }
    }
}