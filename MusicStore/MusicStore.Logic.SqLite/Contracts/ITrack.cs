namespace MusicStore.Logic.SqLite.Contracts;

/// <summary>
/// Represents a track in the music store.
/// </summary>
public interface ITrack : IIdentifiable
{
        #region Properties
        /// <summary>
        /// Gets or sets the album ID.
        /// </summary>
        int AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the genre ID.
        /// </summary>
        int GenreId { get; set; }

        /// <summary>
        /// Gets or sets the title of the track.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the composer of the track.
        /// </summary>
        string Composer { get; set; }

        /// <summary>
        /// Gets or sets the duration of the track in milliseconds.
        /// </summary>
        long Milliseconds { get; set; }

        /// <summary>
        /// Gets or sets the size of the track in bytes.
        /// </summary>
        long Bytes { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the track.
        /// </summary>
        double UnitPrice { get; set; }
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the album associated with the track.
        /// </summary>
        Entities.Album? Album { get; set; }

        /// <summary>
        /// Gets or sets the genre associated with the track.
        /// </summary>
         Entities.Genre? Genre { get; set; }
        #endregion Navigation Properties
}
