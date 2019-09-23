using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Film;
using ProjMediaCollection.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjMediaCollection.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public IActionResult CreateMovieList(CreateMovieListViewModel model )
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newPlaylist = new MoviePlaylist
            {
                Name = model.Name,
                UserId = userName,

            };
            _applicationDbContext.MoviePlaylists.Add(newPlaylist);
            _applicationDbContext.SaveChanges();

            return View("CreateMovieList");
        }

        public IActionResult CreateMovieList()
        {
            return View();
        }
        //public IActionResult AddMovie(int id, AddMovieViewModel model)
        //{
        //    if (!TryValidateModel(model))
        //    {
        //        return View(model);
        //    }

        //    var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var movieToPlaylist = new UserMovie
        //    {
        //        MovieId = id,
        //        UserId = userName
        //    };

        //    _applicationDbContext.UserMovies.Add(movieToPlaylist);
        //    _applicationDbContext.SaveChanges();

        //    return RedirectToAction("IndexMovie", "Movie");
        //}

        public IActionResult MyMovieIndex()
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMovieIndexViewModel myMovieIndex = new MyMovieIndexViewModel();
            IEnumerable<MoviePlaylist> userMoviesListDb = _applicationDbContext.MoviePlaylists
                .Where(x => x.UserId == userName)
                .Include(x => x.User)
                .ToList();

            foreach (var item in userMoviesListDb)
            {
                myMovieIndex.MyMovieList.Add(new MyMovieListViewModel()
                {
                    Id = item.Id,
                    Name =item.Name
                });
            }

            return View(myMovieIndex);
        }
    }
}
