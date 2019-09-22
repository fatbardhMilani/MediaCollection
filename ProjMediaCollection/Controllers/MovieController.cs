using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Film;
using ProjMediaCollection.Models;
using ProjMediaCollection.Models.MovieViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjMediaCollection.Controllers
{
    public class MovieController : Controller
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public MovieController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieViewModel movieModel)
        {
            if (!TryValidateModel(movieModel))
            {
                return View(movieModel);
            }

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await movieModel.Cover.CopyToAsync(memoryStream);
                }
                catch{}

                var createMovie = new Movie()
                {
                    Title = movieModel.Title,
                    Cover = memoryStream.ToArray(),
                    Releas = movieModel.Releas,
                    //Duration = movieModel.Duration
                };

                List<MovieGenresMovie> selectedTags = new List<MovieGenresMovie>();
                foreach (var item in movieModel.MovieGenreTags)
                {
                    if (item.Checked == true)
                    {
                        selectedTags.Add(new MovieGenresMovie { MovieGenreId = item.Id, MovieId = createMovie.Id });
                    }
                }
                createMovie.Genre = selectedTags;

                _applicationDbContext.Movies.Add(createMovie);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("DetailMovie", new { Id = createMovie.Id });
            }
        }

        public IActionResult CreateMovie()
        {
            var movie = new CreateMovieViewModel();

            List<MovieGenreTagViewModel> tags = new List<MovieGenreTagViewModel>();
            foreach (var item in _applicationDbContext.Genres)
            {
                tags.Add(new MovieGenreTagViewModel { Id = item.Id, Name = item.Name });
            }

            movie.MovieGenreTags = tags;
            return View(movie);
        }

        public IActionResult IndexMovie()
        {
            IndexMovieViewModel indexMovie = new IndexMovieViewModel();
            IEnumerable<Movie> moviesFromDb = _applicationDbContext.Movies.ToList();

            foreach (var item in moviesFromDb)
            {
                indexMovie.MovieList.Add(new ListMovieViewModel()
                {
                    Id = item.Id,
                    Cover = item.Cover,
                    Title = item.Title,
                    Releas = item.Releas
                });
            }
            return View(indexMovie);
        }

        public IActionResult DetailMovie(int id)
        {
            Movie movieFromDb = _applicationDbContext.Movies
                .Include(x => x.Genre)
                .ThenInclude(x => x.MovieGenre)
                .SingleOrDefault(x => x.Id == id);

            List<MovieGenreTagDetailViewModel> tags = new List<MovieGenreTagDetailViewModel>();
            foreach (var item in movieFromDb.Genre.Select(x => x.MovieGenre))
            {
                var tagDb = new MovieGenreTagDetailViewModel()
                {
                    Name = item.Name
                };

                tags.Add(tagDb);
            }

            DetailMovieViewModel detailMovie = new DetailMovieViewModel()
            {

                Title = movieFromDb.Title,
                Cover = movieFromDb.Cover,
                Releas = movieFromDb.Releas,
                MovieGenreTagDetails = tags
            };


            return View(detailMovie);
        }

        public IActionResult EditMovie(int id)
        {
            Movie movieFromDb = _applicationDbContext.Movies
                .Include(x => x.Genre)
                    .ThenInclude(x => x.MovieGenre)
                .SingleOrDefault(x => x.Id == id);

            List<MovieGenreTagViewModel> movieGenres = new List<MovieGenreTagViewModel>();
            foreach (var item in _applicationDbContext.Genres.ToList())
            {
                var movieGenresDb = new MovieGenreTagViewModel { Id = item.Id, Name = item.Name };

                if (movieFromDb.Genre.Any(x => x.MovieId == movieFromDb.Id && x.MovieGenreId == item.Id))
                {
                    movieGenresDb.Checked = true;
                }

                movieGenres.Add(movieGenresDb);
            }

            EditMovieViewModel movieToEdit = new EditMovieViewModel()
            {
                Title = movieFromDb.Title,
                Releas = movieFromDb.Releas
            };
            movieToEdit.MovieGenreTags = movieGenres;

            return View(movieToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(int id, EditMovieViewModel editMovieModel)
        {
            if (!TryValidateModel(editMovieModel))
            {
                return View(editMovieModel);
            }

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await editMovieModel.Cover.CopyToAsync(memoryStream);
                }
                catch
                {
                }

                Movie movieToEdit = _applicationDbContext.Movies
                    .Include(x => x.Genre)
                    .SingleOrDefault(x => x.Id == id);

                _applicationDbContext.MovieGenresMovies.RemoveRange(movieToEdit.Genre);
                _applicationDbContext.SaveChanges();

                List<MovieGenresMovie> genresToEdit = new List<MovieGenresMovie>();
                foreach (var item in editMovieModel.MovieGenreTags)
                {
                    if (item.Checked == true)
                    {
                        genresToEdit.Add(new MovieGenresMovie { MovieGenreId = item.Id, MovieId = movieToEdit.Id });
                    }
                    
                }

                movieToEdit.Title = editMovieModel.Title;
                movieToEdit.Releas = editMovieModel.Releas;
                movieToEdit.Genre = genresToEdit;

                if (editMovieModel.Cover != null)
                {
                    movieToEdit.Cover = memoryStream.ToArray();
                }

                _applicationDbContext.Movies.Update(movieToEdit);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("IndexMovie");
            };

            
        }


    }

}
