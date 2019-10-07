using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Film;
using ProjMediaCollection.Models;
using ProjMediaCollection.Models.MovieViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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

        [Authorize]
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
                    Director = movieModel.Director,
                    Description = movieModel.Description,
                    Duration = movieModel.Duration
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

        [Authorize]
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

        public IActionResult IndexMovie(string search, List<MovieGenreTagViewModel> tagSearch)
        {

            IndexMovieViewModel movieSearch = new IndexMovieViewModel();

            IQueryable<Movie> query = _applicationDbContext.Movies.Include(x => x.Genre).ThenInclude(x => x.MovieGenre);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Title.Contains(search));
            }

            if (tagSearch !=null && tagSearch.Any(x => x.Checked == true))
            {
                List<int> checkedIds = new List<int>();

                foreach (var item in tagSearch)
                {
                    if (item.Checked == true)
                    {
                        checkedIds.Add(item.Id);
                    }
                }
                query = query.Where(mov => checkedIds.All(id => mov.Genre.Select(x => x.MovieGenreId).Contains(id)));
            }

            IEnumerable<Movie> movieToSearch = query.ToList();

            List<MovieGenreTagViewModel> tag = new List<MovieGenreTagViewModel>();
            foreach(var item in _applicationDbContext.Genres.ToList())
            {
                tag.Add(new MovieGenreTagViewModel { Name = item.Name, Id = item.Id });
            }
            movieSearch.TagSearch = tag;

            //IndexMovieViewModel indexMovie = new IndexMovieViewModel();
            //IEnumerable<Movie> moviesFromDb = _applicationDbContext.Movies.ToList();

            foreach (var item in movieToSearch)
            {
                movieSearch.MovieList.Add(new ListMovieViewModel()
                {
                    Id = item.Id,
                    Cover = item.Cover,
                    Title = item.Title,
                    Release = item.Releas
                });
            }

            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<SelectListItem> PlaylistToSelect = new List<SelectListItem>();
            foreach (var item in _applicationDbContext.MoviePlaylists.Where(x => x.UserId == userName).ToList())
            {
                PlaylistToSelect.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            movieSearch.MoviePlaylistToSelect = PlaylistToSelect;

            return View(movieSearch);
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
                Id = movieFromDb.Id,
                Title = movieFromDb.Title,
                Cover = movieFromDb.Cover,
                Releas = movieFromDb.Releas,
                Director = movieFromDb.Director,
                Description = movieFromDb.Description,
                Duration = movieFromDb.Duration,
                MovieGenreTagDetails = tags
            };



            List<MovieReview> reviews = _applicationDbContext.MovieReviews.Where(x => x.MovieId== id).ToList();

            List<MovieReviewViewModel> reviewList = new List<MovieReviewViewModel>();

            foreach (var item in reviews)
            {
                var user = _applicationDbContext.Users.FirstOrDefault(x => x.Id == item.UserId);
                reviewList.Add(new MovieReviewViewModel()
                {
                    UserName = user.UserName,
                    Rating = item.Rating,
                    Review = item.Review
                });
            }
            detailMovie.MovieReviews = reviewList;



            return View(detailMovie);
        }

        [Authorize]
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
                Releas = movieFromDb.Releas,
                Director = movieFromDb.Director,
                Description = movieFromDb.Description,
                Duration = movieFromDb.Duration
            };
            movieToEdit.MovieGenreTags = movieGenres;

            return View(movieToEdit);
        }

        [Authorize]
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
                movieToEdit.Director = editMovieModel.Director;
                movieToEdit.Description = editMovieModel.Description;
                movieToEdit.Duration = editMovieModel.Duration;

                if (editMovieModel.Cover != null)
                {
                    movieToEdit.Cover = memoryStream.ToArray();
                }

                _applicationDbContext.Movies.Update(movieToEdit);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("IndexMovie");
            };

            
        }

        [Authorize(Roles = "Admin")]
        //[HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            Movie movieToDelete = _applicationDbContext.Movies.SingleOrDefault(x => x.Id == id);
            _applicationDbContext.Movies.Remove(movieToDelete);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("IndexMovie");
        }


        public IActionResult AddReview(int id, CreateReviewViewModel CreateRating)// hier ga je niveau dieper dus naam moet matchn
        {
            if (!TryValidateModel(CreateRating))
            {
                return RedirectToAction("Detail", new { Id = id });
            }
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var createRating = new MovieReview()
            {
                MovieId = id,
                UserId = userName,
                Review = CreateRating.Review,
                Rating = CreateRating.Rating
            };

            _applicationDbContext.MovieReviews.Add(createRating);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("DetailMovie", new { Id = id });
        }

    }

}
