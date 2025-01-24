namespace MusicStore.Logic.SqLite.Contracts;

/// <summary>
/// Represents an artist in the music store.
/// </summary>
public interface IArtist : IIdentifiable
{
        #region Properties
        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        string Name { get; set; }
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the albums associated with the artist.
        /// </summary>
        List<Entities.Album> Albums { get; set; }
        #endregion Navigation Properties
}
