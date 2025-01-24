namespace MusicStore.Logic.Contracts;

public interface IContext : IDisposable
{
        #region PROPERTIES
        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        List<Models.Genre>? GenreSet { get; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        List<Models.Artist>? ArtistSet { get; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        List<Models.Album>? AlbumSet { get; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        List<Models.Track>? TrackSet { get; }


        /*
        DbSet<Entities.Genre>  GenreDbSet { get; }

        DbSet<Entities.Artist> ArtistDbSet { get; }

        DbSet<Entities.Album> AlbumDbSet { get; }

        DbSet<Entities.Track>  TrackDbSet { get; }
        */
        #endregion
        int SaveChanges( );
}