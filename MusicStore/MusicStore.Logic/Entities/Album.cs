namespace MusicStore.Logic.Entities;

/// <summary>
/// Represents an album in the music store.
/// </summary>
[Serializable]
public partial class Album : IdentityObject, IAlbum
{
        #region Properties
        /// <summary>
        /// Gets or sets the artist ID.
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the title of the album.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the artist associated with the album.
        /// </summary>
        public Artist? Artist { get; set; }

        /// <summary>
        /// Gets or sets the tracks in the album.
        /// </summary>
        public List<Track> Tracks { get; set; } = new List<Track>( );
        #endregion Navigation Properties

        /// <summary>
        /// Copies the properties from another album.
        /// </summary>
        /// <param name="other">The other album to copy properties from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the other album is null.</exception>
        public void CopyProperties( IAlbum other )
        {
                ArgumentNullException.ThrowIfNull( other );

                Id = other.Id;
                ArtistId = other.ArtistId;
                Title = other.Title;
        }

        /// <summary>
        /// Returns a string that represents the current album.
        /// </summary>
        /// <returns>A string that represents the current album.</returns>
        public override string ToString( )
        {
                return $"{Title}";
        }
}
