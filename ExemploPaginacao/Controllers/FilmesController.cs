using System.Web.Mvc;

namespace ExemploPaginacao.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using LinqKit;

    using Models;

    using PagedList;

    using ViewModels.Filmes;

    //using Models.PredicateBuilder;

    public class FilmesController : Controller
    {
        private readonly FilmesRepository repository;
        public FilmesController()
        {
            this.repository = new FilmesRepository();
        }

        // GET: Filmes
        public ActionResult Index()
        {
            return View(new FilmesFiltroViewModel());
        }

        [HttpPost]
        public ActionResult Index(FilmesFiltroViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult CarregarGrid(FilmesFiltroViewModel filter, int? page)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), filter);
            }

            var data = new FilmesGridViewModel
            {
                Filter = filter,
                Grid = this.repository.GetAll()
                                .Where(BuildFilter(filter))
                                .OrderBy(x => x.FilmeId)
                                .ToPagedList(page ?? 1, 10)
            };

            return PartialView("Grid", data);
        }

        private Expression<Func<Filme, bool>> BuildFilter(FilmesFiltroViewModel filter)
        {
            var predicate = PredicateBuilder.True<Filme>();

            if (filter.Ano != null && filter.Ano > 0)
            {
                predicate = predicate.And(x => x.Ano == filter.Ano);
            }

            if (!string.IsNullOrEmpty(filter.Diretor) || !string.IsNullOrWhiteSpace(filter.Diretor))
            {
                predicate = predicate.And(x => x.Diretor.Contains(filter.Diretor));
            }

            if (!string.IsNullOrEmpty(filter.Nome) && !string.IsNullOrWhiteSpace(filter.Nome))
            {
                predicate = predicate.And(x => x.Nome.Contains(filter.Nome));
            }

            return predicate;
        }
    }
}