using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Series;
using ProjMediaCollection.Models.SerieViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Controllers
{
    public class SerieController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SerieController (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateSerie(CreateSerieViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await model.Cover.CopyToAsync(memoryStream);
                }
                catch{}

                var serieToCreate = new Serie()
                {
                    Title = model.Title,
                    Cover = memoryStream.ToArray(),
                    Description = model.Description
                };

                _applicationDbContext.Series.Add(serieToCreate);
                _applicationDbContext.SaveChanges();

                List<SerieGenresSerie> serieGenres = new List<SerieGenresSerie>();

                foreach (var item in model.SerieGenreTags)
                {
                    if (item.Checked == true)
                    {
                        serieGenres.Add(new SerieGenresSerie { SeriesGenreId = item.Id, SerieId = serieToCreate.Id });
                        _applicationDbContext.SerieGenresSeries.Add(new SerieGenresSerie { SeriesGenreId =item.Id, SerieId = serieToCreate.Id});
                    }
                }

                serieToCreate.SerieGenres = serieGenres;

               
                _applicationDbContext.SaveChanges();
            }

            return View("IndexSerie");
        }

        [Authorize]
        public IActionResult CreateSerie()
        {
            var serie = new CreateSerieViewModel();

            List<SerieGenreTagViewModel> tags = new List<SerieGenreTagViewModel>();
            foreach (var item in _applicationDbContext.SeriesGenres)
            {
                tags.Add(new SerieGenreTagViewModel { Id = item.Id, Name = item.Name });
            }

            serie.SerieGenreTags = tags;
            return View(serie);
        }

        public IActionResult IndexSerie()
        {
            IndexSerieViewModel serieIndex = new IndexSerieViewModel();
            IEnumerable<Serie> serieFromDb = _applicationDbContext.Series.ToList();

            foreach (var serie in serieFromDb)
            {
                serieIndex.SerieList.Add(new ListSeriesViewModel()
                {
                    Id = serie.Id,
                    Title = serie.Title,
                    Cover = serie.Cover
                });
            }


            //var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //List<SelectListItem> PlaylistToSelect = new List<SelectListItem>();
            //foreach (var item in _applicationDbContext.MyMusicPlaylists.Where(x => x.UserId == userName).ToList())
            //{
            //    PlaylistToSelect.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.PlaylistName });
            //}
            //albumIndex.MyMusicPlaylistToSelect = PlaylistToSelect;

            return View(serieIndex);
        }
    }
}
