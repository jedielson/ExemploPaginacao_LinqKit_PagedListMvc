namespace ExemploPaginacao.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
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

                filmes.Add(filme);
            }
            context.SaveChanges();
        }
    }

}