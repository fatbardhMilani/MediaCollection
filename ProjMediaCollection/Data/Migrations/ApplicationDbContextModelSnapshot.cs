﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjMediaCollection.Data;

namespace ProjMediaCollection.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Film.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Firstname");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Film.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Cover");

                    b.Property<TimeSpan>("Duration");

                    b.Property<DateTime>("Releas");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Film.MovieDirector", b =>
                {
                    b.Property<int>("DirectorId");

                    b.Property<int>("MovieId");

                    b.HasKey("DirectorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieDirectors");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Film.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MovieId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Genres");

                    b.HasData(
                        new { Id = 1, Name = "Sifi" },
                        new { Id = 2, Name = "Comedy" },
                        new { Id = 3, Name = "Horror" },
                        new { Id = 4, Name = "Romance" },
                        new { Id = 5, Name = "Drama" },
                        new { Id = 6, Name = "Action" },
                        new { Id = 7, Name = "Documentary" },
                        new { Id = 8, Name = "Adventure" },
                        new { Id = 9, Name = "Fantasy" },
                        new { Id = 10, Name = "Other" }
                    );
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Cover");

                    b.Property<string>("Titel");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.AlbumArtist", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<int>("AlbumId");

                    b.HasKey("ArtistId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("AlbumArtists");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId");

                    b.Property<byte[]>("Foto");

                    b.Property<DateTime>("GeboorteDatum");

                    b.Property<string>("Naam");

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.MusicGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MusicGenres");

                    b.HasData(
                        new { Id = 1, Name = "Jazz" },
                        new { Id = 2, Name = "Rock" },
                        new { Id = 3, Name = "Hip Hop" },
                        new { Id = 4, Name = "Country" },
                        new { Id = 5, Name = "Classic" },
                        new { Id = 6, Name = "Metal" },
                        new { Id = 7, Name = "Pop" },
                        new { Id = 8, Name = "Reggae" },
                        new { Id = 9, Name = "Rap" },
                        new { Id = 10, Name = "Other" }
                    );
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumId");

                    b.Property<int>("ArtistId");

                    b.Property<string>("Titel");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.SongArtist", b =>
                {
                    b.Property<int>("ArtistId");

                    b.Property<int>("SongId");

                    b.HasKey("ArtistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("SongArtists");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<byte[]>("Picture");

                    b.Property<int>("SeasonId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Cover");

                    b.Property<string>("Description");

                    b.Property<int>("SerieId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Cover");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.SeriesGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("SerieId");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("SeriesGenres");

                    b.HasData(
                        new { Id = 1, Name = "Sifi" },
                        new { Id = 2, Name = "Comedy" },
                        new { Id = 3, Name = "Horror" },
                        new { Id = 4, Name = "Romance" },
                        new { Id = 5, Name = "Drama" },
                        new { Id = 6, Name = "Action" },
                        new { Id = 7, Name = "Documentary" },
                        new { Id = 8, Name = "Adventure" },
                        new { Id = 9, Name = "Fantasy" },
                        new { Id = 10, Name = "Other" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Film.MovieDirector", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Film.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjMediaCollection.Domain.Film.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Film.MovieGenre", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Film.Movie")
                        .WithMany("Genre")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.AlbumArtist", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Muziek.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjMediaCollection.Domain.Muziek.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.Artist", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Muziek.Album")
                        .WithMany("AlbumArtists")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.Song", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Muziek.Album", "Album")
                        .WithMany("AlbumSongs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjMediaCollection.Domain.Muziek.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Muziek.SongArtist", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Muziek.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjMediaCollection.Domain.Muziek.Song", "Song")
                        .WithMany()
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.Episode", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Series.Season", "Season")
                        .WithMany("SeasonEpisodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.Season", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Series.Serie", "Serie")
                        .WithMany("SerieSeasons")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjMediaCollection.Domain.Series.SeriesGenre", b =>
                {
                    b.HasOne("ProjMediaCollection.Domain.Series.Serie")
                        .WithMany("SerieGenres")
                        .HasForeignKey("SerieId");
                });
#pragma warning restore 612, 618
        }
    }
}
