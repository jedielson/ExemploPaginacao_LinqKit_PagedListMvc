namespace ExemploPaginacao.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using ExemploPaginacao.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExemploPaginacao.Models.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExemploPaginacao.Models.EntityContext context)
        {

            var filmes = new List<Filme>();
            for (int i = 1; i < 101; i++)
            {
                var filme = new Filme
                {
                    Diretor = "Diretor " + i,
                    Ano = DateTime.Now.Year,
                    Nome = "Filme " + i

                };
            }

            context.Filmes.AddRange(filmes);
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
