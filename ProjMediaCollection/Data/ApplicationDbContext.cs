using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjMediaCollection.Domain.Film;
using ProjMediaCollection.Domain.Muziek;
using ProjMediaCollection.Domain.Series;

namespace ProjMediaCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Movie Dbset//
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieGenre> Genres { get; set; }
        public DbSet<MovieGenresMovie> MovieGenresMovies { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
        public DbSet<MoviePlaylist> MoviePlaylists { get; set; }
        //Muziek DbSet//
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<MyMusicPlaylist> MyMusicPlaylists { get; set; }
        public DbSet<MyMusicPlaylistAlbum> MusicPlaylistAlbums { get; set; }
        public DbSet<MyMusicPlaylistSong> MyMusicPlaylistSongs {get;set;}
        //Series DbSet//
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<SeriesGenre> SeriesGenres { get; set;}
        public DbSet<SerieGenresSerie> SerieGenresSeries { get; set; }
        public DbSet<MySeriePlaylist> MySeriePlaylists { get; set; }
        public DbSet<MySeriePlaylistSerie> MySeriePlaylistSeries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieDirector>().HasKey(x => new { x.DirectorId, x.MovieId });
            builder.Entity<MovieGenresMovie>().HasKey(x => new { x.MovieGenreId, x.MovieId });
            builder.Entity<SongArtist>().HasKey(x => new { x.ArtistId, x.SongId });
            builder.Entity<AlbumArtist>().HasKey(x => new { x.ArtistId, x.AlbumId });
            builder.Entity<SongGenre>().HasKey(x => new { x.MusicGenreId, x.SongId });
            builder.Entity<SerieGenresSerie>().HasKey(x => new { x.SeriesGenreId, x.SerieId });

            builder.Entity<MovieGenre>().HasData(
                new MovieGenre { Id = 1, Name = "Sifi" },
                new MovieGenre { Id = 2, Name = "Comedy" },
                new MovieGenre { Id = 3, Name = "Horror" },
                new MovieGenre { Id = 4, Name = "Romance" },
                new MovieGenre { Id = 5, Name = "Drama" },
                new MovieGenre { Id = 6, Name = "Action" },
                new MovieGenre { Id = 7, Name = "Documentary" },
                new MovieGenre { Id = 8, Name = "Adventure" },
                new MovieGenre { Id = 9, Name = "Fantasy" },
                new MovieGenre { Id = 10, Name = "Other" }
                );
            builder.Entity<MusicGenre>().HasData(
                new MusicGenre { Id = 1, Name = "Jazz" },
                new MusicGenre { Id = 2, Name = "Rock" },
                new MusicGenre { Id = 3, Name = "Hip Hop" },
                new MusicGenre { Id = 4, Name = "Country" },
                new MusicGenre { Id = 5, Name = "Classic" },
                new MusicGenre { Id = 6, Name = "Metal" },
                new MusicGenre { Id = 7, Name = "Pop" },
                new MusicGenre { Id = 8, Name = "Reggae" },
                new MusicGenre { Id = 9, Name = "Rap" },
                new MusicGenre { Id = 10, Name = "Other" }
                );
            builder.Entity<SeriesGenre>().HasData(
                new MovieGenre { Id = 1, Name = "Sifi" },
                new MovieGenre { Id = 2, Name = "Comedy" },
                new MovieGenre { Id = 3, Name = "Horror" },
                new MovieGenre { Id = 4, Name = "Romance" },
                new MovieGenre { Id = 5, Name = "Drama" },
                new MovieGenre { Id = 6, Name = "Action" },
                new MovieGenre { Id = 7, Name = "Documentary" },
                new MovieGenre { Id = 8, Name = "Adventure" },
                new MovieGenre { Id = 9, Name = "Fantasy" },
                new MovieGenre { Id = 10, Name = "Other" }
                );
            base.OnModelCreating(builder);
        }


    }
}
