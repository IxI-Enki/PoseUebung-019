namespace MusicStore.Logic.Contracts;

/// <summary>
/// Represents an album in the music store.
/// </summary>
public interface IAlbum : IIdentifiable
{
        #region Properties
        /// <summary>
        /// Gets or sets the artist ID.
        /// </summary>
        int ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the title of the album.
        /// </summary>
        string Title { get; set; }
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the artist associated with the album.
        /// </summary>
        Models.Artist? Artist { get; set; }

        /// <summary>
        /// Gets or sets the tracks in the album.
        /// </summary>
        List<Models.Track> Tracks { get; set; }
        #endregion Navigation Properties
}
