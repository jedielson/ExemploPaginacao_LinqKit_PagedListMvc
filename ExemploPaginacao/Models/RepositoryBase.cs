namespace ExemploPaginacao.Models
{
    using System.Linq;

    using LinqKit;

    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        private readonly EntityContext context;

        protected RepositoryBase()
        {
            context = new EntityContext();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().AsExpandable();
        }
    }
}