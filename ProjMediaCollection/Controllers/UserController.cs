using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Film;
using ProjMediaCollection.Domain.Muziek;
using ProjMediaCollection.Domain.Series;
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
        public IActionResult AddToPlaylist(int id, string SelectedMoviePlaylist)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MoviePlaylist moviePlaylist = _applicationDbContext.MoviePlaylists
                .Include(x => x.UserMovie)
                //.ThenInclude(x => x.MoviePlaylist)
                .FirstOrDefault(x => x.Id.ToString() == SelectedMoviePlaylist);

            var userMovie = new UserMovie
            {
                MovieId = id,
                MoviePlaylistId = Convert.ToInt32(SelectedMoviePlaylist),
            };

            var movieToplaylist = new MoviePlaylist
            {
                UserId = userName,
                Name = SelectedMoviePlaylist,
                //UserMovie = model.MovieId

            };
            _applicationDbContext.UserMovies.Add(userMovie);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("IndexMovie", "Movie");
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

            return RedirectToAction("MyMusicIndex");

        }

        [Authorize]
        public IActionResult CreateMusicPlaylist()
        {
            return View();
        }

        public IActionResult MyMusicIndex()
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMusicIndexViewModel myMusicIndex = new MyMusicIndexViewModel();
            IEnumerable<MyMusicPlaylist> userMusicListDb = _applicationDbContext.MyMusicPlaylists
                .Where(x => x.UserId == userName)
                .Include(x => x.User)
                .Include(x => x.MyAlbum)
                    .ThenInclude(x => x.Album)
                .ToList();

            List<MyMusicPlaylistViewModel> musicList = new List<MyMusicPlaylistViewModel>();

            foreach (var item in userMusicListDb)
            {

                List<MySelectedMusicViewModel> musicInList = new List<MySelectedMusicViewModel>();
                foreach (var album in _applicationDbContext.MusicPlaylistAlbums.Where(x => x.MyMusicPlaylistId == item.Id))
                {
                    musicInList.Add(new MySelectedMusicViewModel()
                    {
                        Id = album.Id,
                        Cover = album.Album.Cover,
                        Title = album.Album.Titel,
                        AlbumId = album.AlbumId
                    });
                }
                musicList.Add(new MyMusicPlaylistViewModel() { Id = item.Id, MySelectedMusic = musicInList, Name = item.PlaylistName });

            }
            myMusicIndex.MyMusicPlaylist = musicList;

            return View(myMusicIndex);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAlbumToPlaylist(int id, string SelectedMyMusicPlaylist)
        {
        
                
                var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MyMusicPlaylist musicPlaylist = _applicationDbContext.MyMusicPlaylists
                .Include(x => x.MyAlbum)
                //.ThenInclude(x => x.MoviePlaylist)
                .FirstOrDefault(x => x.Id.ToString() == SelectedMyMusicPlaylist);

            var playlistAlbum = new MyMusicPlaylistAlbum
            {
                AlbumId = id,
                MyMusicPlaylistId = Convert.ToInt32(SelectedMyMusicPlaylist),
            };

            var musicToPlaylist = new MyMusicPlaylist
            {   
        //        public int Id { get; set; }
        //public MyMusicPlaylist MyMusicPlaylist { get; set; }
        //public int MyMusicPlaylistId { get; set; }
        //public Album Album { get; set; }
        //public int AlbumId { get; set; }
        Id = id,
        UserId = userName,
                PlaylistName = SelectedMyMusicPlaylist,
                MyAlbum = musicPlaylist.MyAlbum,
                MyMusicPlayListAlbumId = musicPlaylist.MyMusicPlayListAlbumId,
                MyMusicPlayListSongId = musicPlaylist.MyMusicPlayListSongId,
                MySong = musicPlaylist.MySong,
                //User = HttpContext.User.Identity.
                //UserMovie = model.MovieId

            };
            _applicationDbContext.MusicPlaylistAlbums.Add(playlistAlbum);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("IndexAlbum","Music");
        }

        /////////////////////SERIES////////////////////////


        [Authorize]
        [HttpPost]
        public IActionResult CreateSeriePlaylist(CreateSeriePlaylistViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MySeriePlaylist seriePlaylist = new MySeriePlaylist
            {
                PlaylistName = model.SeriePlaylistName,
                UserId = userName
            };

            _applicationDbContext.MySeriePlaylists.Add(seriePlaylist);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("CreateSeriePlaylist");

        }

        [Authorize]
        public IActionResult CreateSeriePlaylist()
        {
            return View();
        }


        public IActionResult MySerieIndex()
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MySerieIndexViewModel mySerieIndex = new MySerieIndexViewModel();
            IEnumerable<MySeriePlaylist> userSerieListDb = _applicationDbContext.MySeriePlaylists
                .Where(x => x.UserId == userName)
                .Include(x => x.User)
                .Include(x => x.MySerie)
                    .ThenInclude(x => x.Serie)
                .ToList();

            List<MySeriePlaylistViewModel> serieList = new List<MySeriePlaylistViewModel>();

            foreach (var item in userSerieListDb)
            {

                List<MySelectedSerieViewModel> serieInList = new List<MySelectedSerieViewModel>();
                foreach (var serie in _applicationDbContext.MySeriePlaylistSeries.Where(x => x.MySeriePlaylistId == item.Id))
                {
                    serieInList.Add(new MySelectedSerieViewModel()
                    {
                        Id = serie.Id,
                        Cover = serie.Serie.Cover,
                        Title = serie.Serie.Title,
                        SerieId = serie.SerieId
                    });
                }
                serieList.Add(new MySeriePlaylistViewModel() { Id = item.Id, MySelectedSerie = serieInList, Name = item.PlaylistName });

            }
            mySerieIndex.MySeriePlaylist = serieList;

            return View(mySerieIndex);
        }



        [Authorize]
        [HttpPost]
        public IActionResult AddSerieToPlaylist(int id, string SelectedMySeriePlaylist)
        {


            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            MySeriePlaylist seriePlaylist = _applicationDbContext.MySeriePlaylists
                .Include(x => x.MySerie)
                //.ThenInclude(x => x.MoviePlaylist)
                .FirstOrDefault(x => x.Id.ToString() == SelectedMySeriePlaylist);

            var playlistSerie = new MySeriePlaylistSerie
            {
                SerieId = id,
                MySeriePlaylistId = Convert.ToInt32(SelectedMySeriePlaylist),
            };

            var serieToPlaylist = new MySeriePlaylist
            {
                Id = id,
                UserId = userName,
                PlaylistName = SelectedMySeriePlaylist,
                MySerie = seriePlaylist.MySerie,
                MySeriePlaylistSerieId = seriePlaylist.MySeriePlaylistSerieId,

            };
            _applicationDbContext.MySeriePlaylistSeries.Add(playlistSerie);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("IndexSerie", "Serie");
        }


    }
}
