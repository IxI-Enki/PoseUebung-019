namespace MusicStore.Logic.SqLite.Contracts;

public interface IContext : IDisposable
{
        #region PROPERTIES
        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        DbSet<Entities.Genre> GenreSet { get; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        DbSet<Entities.Artist> ArtistSet { get; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        DbSet<Entities.Album> AlbumSet { get; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        DbSet<Entities.Track> TrackSet { get; }
 
        #endregion
        int SaveChanges( );
}