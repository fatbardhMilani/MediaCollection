using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Series;
using ProjMediaCollection.Models.SerieViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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

            return RedirectToAction("IndexSerie");
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


            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<SelectListItem> PlaylistToSelect = new List<SelectListItem>();
            foreach (var item in _applicationDbContext.MySeriePlaylists.Where(x => x.UserId == userName).ToList())
            {
                PlaylistToSelect.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.PlaylistName });
            }
            serieIndex.MySeriePlaylistToSelect = PlaylistToSelect;

            return View(serieIndex);
        }
        
        public IActionResult DetailSerie(int id)
        {
            Serie serieFromDb = _applicationDbContext.Series
                //.Include(x => x.SerieGenres)
                //    .ThenInclude(x => x.SeriesGenre)
                //.Include(x => x.SerieSeasons)
                .SingleOrDefault(x => x.Id == id);

            List<SerieGenreTagDetailViewModel> genres = new List<SerieGenreTagDetailViewModel>();

            foreach (var item in _applicationDbContext.SerieGenresSeries.Include(x => x.SeriesGenre).Where(x => x.SerieId == id))
            {
                genres.Add(new SerieGenreTagDetailViewModel { Name = item.SeriesGenre.Name });
            }


            List<SeasonListViewModel> seasonList = new List<SeasonListViewModel>();

            foreach (var item in _applicationDbContext.Seasons)
            {
                seasonList.Add(new SeasonListViewModel
                {
                    Cover = item.Cover,
                    Title = item.Title,
                    Id = item.Id,
                    Description = item.Description
                });
            }

            DetailSerieViewModel serieDetail = new DetailSerieViewModel()
            {
                Id = id,
                Cover = serieFromDb.Cover,
                Title = serieFromDb.Title,
                SerieGenreTagDetails = genres,
                SeasonsToAddToSerie = seasonList
            };

            return View(serieDetail);
        }

        [Route("season/{id}")]
        public IActionResult DetailSeason(int id)
        {
            Season seasonFromDb = _applicationDbContext.Seasons.SingleOrDefault(x => x.Id == id);

            List<EpisodeListViewModel> episodeList = new List<EpisodeListViewModel>();

            foreach (var item in _applicationDbContext.Episodes)
            {
                episodeList.Add(new EpisodeListViewModel
                {
                    Picture = item.Picture,
                    Title = item.Title,
                    Description = item.Description,
                    //Id = item.Id
                });
            }

            DetailSeasonViewModel seasonDetail = new DetailSeasonViewModel()
            {
                EpisodesToAddToSeason = episodeList,
                SeasonId = id
            };

            return View(seasonDetail);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSeason(int id, AddSeasonViewModel model)
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
                catch {}

                var addSeason = new Season()
                {
                    Title = model.Title,
                    Cover = memoryStream.ToArray(),
                    Description = model.Description,
                    SerieId = id
                };

                _applicationDbContext.Seasons.Add(addSeason);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("DetailSerie", new { id = id });
            }
        }

        [Authorize]
        public IActionResult AddSeason()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddEpisode(int id, AddEpisodeViewModel model)
        {
            //if (TryValidateModel(model))
            //{
            //    return View(model);
            //}

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await model.Picture.CopyToAsync(memoryStream);
                }
                catch{}

                var addEpisode = new Episode()
                {
                    Title = model.Title,
                    Picture = memoryStream.ToArray(),
                    Description = model.Description,
                    SeasonId = id,
                };

                _applicationDbContext.Episodes.Add(addEpisode);
                _applicationDbContext.SaveChanges();
            }

            return RedirectToAction("DetailSeason", new { id =id });
        }

        [Authorize]
        public IActionResult AddEpisode()
        {
            return View();
        }
    }
}
