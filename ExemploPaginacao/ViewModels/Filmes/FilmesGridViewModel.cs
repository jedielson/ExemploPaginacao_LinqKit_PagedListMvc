namespace ExemploPaginacao.ViewModels.Filmes
{
    using Models;

    using PagedList;

    public class FilmesGridViewModel
    {
        public FilmesFiltroViewModel Filter { get; set; }

        public IPagedList<Filme> Grid { get; set; }
    }
}