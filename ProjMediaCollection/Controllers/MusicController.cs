using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Data;
using ProjMediaCollection.Domain.Muziek;
using ProjMediaCollection.Models;
using ProjMediaCollection.Models.MusicViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjMediaCollection.Controllers
{
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MusicController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumViewModel model)
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
                catch
                {
                }

                var album = new Album()
                {
                    Titel = model.Title,
                    Cover = memoryStream.ToArray()
                };

                _applicationDbContext.Albums.Add(album);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("IndexAlbum");
            }
        }

        [Authorize]
        public IActionResult CreateAlbum()
        {
            return View();
        }

        public IActionResult IndexAlbum()
        {
            AlbumIndexViewModel albumIndex = new AlbumIndexViewModel();
            IEnumerable<Album> albumsFromDb = _applicationDbContext.Albums.ToList();

            foreach (var album in albumsFromDb)
            {
                albumIndex.AlbumList.Add(new AlbumListViewModel()
                {
                    Id = album.Id,
                    Titel = album.Titel,
                    Cover = album.Cover
                });
            }


            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<SelectListItem> PlaylistToSelect = new List<SelectListItem>();
            foreach (var item in _applicationDbContext.MyMusicPlaylists.Where(x => x.UserId == userName).ToList())
            {
                PlaylistToSelect.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.PlaylistName });
            }
            albumIndex.MyMusicPlaylistToSelect = PlaylistToSelect;

            return View(albumIndex);
        }

        public IActionResult DetailAlbum(int id)
        {
            Album albumfromDb = _applicationDbContext.Albums
                .Include(x => x.AlbumSongs)
                .SingleOrDefault(x => x.Id == id);

            List<SongListViewModel> addSongs = new List<SongListViewModel>();

            foreach (var song in albumfromDb.AlbumSongs)
            {
                var newSongToAlbum = new SongListViewModel()
                {
                    Title = song.Titel,
                    Artist = song.Artist,
                    Release = song.Release,
                    Id = song.Id
                };
                addSongs.Add(newSongToAlbum);
            }

            DetailAlbumViewModel albumDetail = new DetailAlbumViewModel()
            {
                Id = albumfromDb.Id,
                Cover = albumfromDb.Cover,
                Title = albumfromDb.Titel,
                SongsToAddToAlbum =addSongs,
            };


            return View(albumDetail);
        }

        [Authorize]
        public IActionResult EditAlbum(int id)
        {
            Album albumFromDb = _applicationDbContext.Albums.SingleOrDefault(x => x.Id == id);
            EditAlbumViewModel albumToEdit = new EditAlbumViewModel
            {
                Title = albumFromDb.Titel,

            };

            return View(albumToEdit);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditAlbum(int id, EditAlbumViewModel model)
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
                catch
                {
                }

                Album albumToUpdate = _applicationDbContext.Albums.SingleOrDefault(x => x.Id == id);

                albumToUpdate.Titel = model.Title;
                if (model.Cover != null)
                {
                    albumToUpdate.Cover = memoryStream.ToArray();
                }

                _applicationDbContext.Albums.Update(albumToUpdate);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("IndexAlbum");
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddSong(int id,AddSongViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            var newSong = new Song()
            {
                //Id = model.Id,
                Titel = model.Title,
                Artist = model.Artist,
                Release = model.Release,
                AlbumId = id

            };
            _applicationDbContext.Songs.Add(newSong);
            _applicationDbContext.SaveChanges();

            List<SongGenre> selectedSongGenre = new List<SongGenre>();
            foreach (var genre in model.SongGenreTags)
            {
                if (genre.Checked == true)
                {
                    _applicationDbContext.SongGenres.Add(new SongGenre { MusicGenreId = genre.Id, SongId = newSong.Id });
                    //selectedSongGenre.Add(new SongGenre { MusicGenreId = genre.Id, SongId = newSong.Id });
                }
            }

            newSong.GenresSong = selectedSongGenre;

            //_applicationDbContext.Songs.Update(newSong);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("DetailAlbum", new { id = id });
        }

        [Authorize]
        public IActionResult AddSong()
        {
            var model = new AddSongViewModel();

            List<SongGenreTagViewModel> genreTags = new List<SongGenreTagViewModel>();
            foreach (var item in _applicationDbContext.MusicGenres.ToList())
            {
                genreTags.Add(new SongGenreTagViewModel { Id = item.Id, Name = item.Name });
            }

            model.SongGenreTags = genreTags;
            return View(model);
        }

        public IActionResult DetailSong(int id)
        {
            //SIMON zeg lijst eerst van songs en includen//

            Song songFromDb = _applicationDbContext.Songs

                //.Include(x => x.GenresSong)
                //    .ThenInclude(x => x.MusicGenre)
                .SingleOrDefault(x => x.Id == id);

            List<SongGenreTagDetailViewModel> songGenreTagDetails = new List<SongGenreTagDetailViewModel>();

            foreach (var genre in _applicationDbContext.SongGenres.Include(x =>x.MusicGenre).Where(x => x.SongId == id))
            {
                var songGenreToDetail = new SongGenreTagDetailViewModel()
                {
                    Name = genre.MusicGenre.Name
                };

                songGenreTagDetails.Add(songGenreToDetail);
            }


            //List<SongGenreTagDetailViewModel> songGenreTagDetails = new List<SongGenreTagDetailViewModel>();

            //foreach (var genre in songFromDb.GenresSong.Select(x => x.MusicGenre))
            //{
            //    var songGenreToDetail = new SongGenreTagDetailViewModel()
            //    {
            //        Name = genre.Name
            //    };

            //    songGenreTagDetails.Add(songGenreToDetail);
            //}

            DetailSongViewModel model = new DetailSongViewModel()
            {
                Title = songFromDb.Titel,
                Artist = songFromDb.Artist,
                Release = songFromDb.Release,
                SongGenreTagsDetail = songGenreTagDetails

            };

            return View(model);
        }
    }
}
