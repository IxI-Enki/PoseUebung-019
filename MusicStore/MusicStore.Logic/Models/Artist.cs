namespace MusicStore.Logic.Models;

/// <summary>
/// Represents an artist in the music store.
/// </summary>
[Serializable]
public partial class Artist : IdentityObject, Contracts.IArtist
{
        #region Properties
        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the albums associated with the artist.
        /// </summary>
        public List<Models.Album> Albums { get; set; } = new List<Models.Album>( );
        #endregion Navigation Properties

        /// <summary>
        /// Copies the properties from another artist.
        /// </summary>
        /// <param name="other">The other artist to copy properties from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the other artist is null.</exception>
        public void CopyProperties( Contracts.IArtist other )
        {
                ArgumentNullException.ThrowIfNull( other );

                Id = other.Id;
                Name = other.Name;
        }

        /// <summary>
        /// Returns a string that represents the current artist.
        /// </summary>
        /// <returns>A string that represents the current artist.</returns>
        public override string ToString( )
        {
                return $"{Name}";
        }
}