using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Film;
using ProjMediaCollection.Domain.Muziek;
using ProjMediaCollection.Models.MovieViewModels;
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

        //UserMovies////////////////////////////////////////
        [Authorize]
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

            return RedirectToAction("MyMovieIndex");
        }

        [Authorize]
        public IActionResult CreateMovieList()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToPlaylist(int id, AddMovieViewModel model)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MoviePlaylist moviePlaylist = _applicationDbContext.MoviePlaylists
                .Include(x => x.UserMovie)
                //.ThenInclude(x => x.MoviePlaylist)
                .FirstOrDefault(x => x.Id.ToString() == model.SelectedMoviePlaylist);

            var userMovie = new UserMovie
            {
                MovieId = id,
                MoviePlaylistId = Convert.ToInt32(model.SelectedMoviePlaylist),
            };

            var movieToplaylist = new MoviePlaylist
            {
                UserId = userName,
                Name = model.SelectedMoviePlaylist,
                //UserMovie = model.MovieId

            };
            _applicationDbContext.UserMovies.Add(userMovie);
            _applicationDbContext.SaveChanges();

            return View(model);
        }

        [Authorize]
        public IActionResult MyMovieIndex()
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMovieIndexViewModel myMovieIndex = new MyMovieIndexViewModel();
            IEnumerable<MoviePlaylist> userMoviesListDb = _applicationDbContext.MoviePlaylists
                .Where(x => x.UserId == userName)
                .Include(x => x.User)
                .Include(x => x.UserMovie)
                    .ThenInclude(x => x.Movie)
                .ToList();

            List<MyMovieplaylistViewModel> movieList = new List<MyMovieplaylistViewModel>();
            
            foreach (var item in userMoviesListDb)
            {
                
                List<MyMoviesListViewModel> moviesInList = new List<MyMoviesListViewModel>();
                foreach (var movie in _applicationDbContext.UserMovies.Where(x=>x.MoviePlaylistId==item.Id))
                {
                    moviesInList.Add(new MyMoviesListViewModel()
                    {
                        Id = movie.Id,
                        Cover = movie.Movie.Cover,
                        Releas = movie.Movie.Releas,
                        Title = movie.Movie.Title
                    });
                }
                movieList.Add(new MyMovieplaylistViewModel() { Id = item.Id, MyMoviesLists = moviesInList, Name = item.Name });

            }
            myMovieIndex.MyMoviePlayList = movieList;

            return View(myMovieIndex);
        }
        //UserMusic////////////////////////////////////////////////////

        [Authorize]
        [HttpPost]
        public IActionResult CreateMusicPlaylist(CreateMusicPlaylistViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMusicPlaylist musicPlaylist = new MyMusicPlaylist
            {
                PlaylistName = model.MusicPlaylistName,
                UserId = userName
            };

            _applicationDbContext.MyMusicPlaylists.Add(musicPlaylist);
            _applicationDbContext.SaveChanges();

            return View("CreateMusicPlaylist");

        }

        [Authorize]
        public IActionResult CreateMusicPlaylist()
        {
            return View();
        }

        public IActionResult MyMusicIndex()
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMovieIndexViewModel myMovieIndex = new MyMovieIndexViewModel();
            IEnumerable<MoviePlaylist> userMoviesListDb = _applicationDbContext.MoviePlaylists
                .Where(x => x.UserId == userName)
                .Include(x => x.User)
                .Include(x => x.UserMovie)
                    .ThenInclude(x => x.Movie)
                .ToList();

            List<MyMovieplaylistViewModel> movieList = new List<MyMovieplaylistViewModel>();

            foreach (var item in userMoviesListDb)
            {

                List<MyMoviesListViewModel> musicInList = new List<MyMoviesListViewModel>();
                foreach (var movie in _applicationDbContext.MusicPlaylistAlbums.Where(x => x.MyMusicPlaylistId == item.Id))
                {
                    musicInList.Add(new MyMoviesListViewModel()
                    {
                        Id = movie.Id,
                        Cover = movie.Album.Cover,
                        Title = movie.Album.Titel,
                    });
                }
                movieList.Add(new MyMovieplaylistViewModel() { Id = item.Id, MyMoviesLists = musicInList, Name = item.Name });

            }
            myMovieIndex.MyMoviePlayList = movieList;

            return View(myMovieIndex);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAlbumToPlaylist(int id, AddAlbumViewModel model)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMusicPlaylist musicPlaylist = _applicationDbContext.MyMusicPlaylists
                .Include(x => x.MyAlbum)
                //.ThenInclude(x => x.MoviePlaylist)
                .FirstOrDefault(x => x.Id.ToString() == model.SelectedMusicPlaylist);

            var playlistAlbum = new MyMusicPlaylistAlbum
            {
                AlbumId = id,
                MyMusicPlaylistId = Convert.ToInt32(model.SelectedMusicPlaylist),
            };

            var musicToPlaylist = new MyMusicPlaylist
            {
                UserId = userName,
                PlaylistName = model.SelectedMusicPlaylist,
                //UserMovie = model.MovieId

            };
            _applicationDbContext.MusicPlaylistAlbums.Add(playlistAlbum);
            _applicationDbContext.SaveChanges();

            return View(model);
        }
    }
}
