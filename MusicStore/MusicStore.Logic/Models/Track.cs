namespace MusicStore.Logic.Models
{
        /// <summary>
        /// Represents a track in the music store.
        /// </summary>
        [Serializable]
        public partial class Track : IdentityObject, ITrack
        {
                #region Properties
                /// <summary>
                /// Gets or sets the album ID.
                /// </summary>
                public int AlbumId { get; set; }

                /// <summary>
                /// Gets or sets the genre ID.
                /// </summary>
                public int GenreId { get; set; }

                /// <summary>
                /// Gets or sets the title of the track.
                /// </summary>
                public string Title { get; set; } = string.Empty;

                /// <summary>
                /// Gets or sets the composer of the track.
                /// </summary>
                public string Composer { get; set; } = string.Empty;

                /// <summary>
                /// Gets or sets the duration of the track in milliseconds.
                /// </summary>
                public long Milliseconds { get; set; }

                /// <summary>
                /// Gets or sets the size of the track in bytes.
                /// </summary>
                public long Bytes { get; set; }

                /// <summary>
                /// Gets or sets the unit price of the track.
                /// </summary>
                public double UnitPrice { get; set; }
                #endregion Properties

                #region Navigation Properties
                /// <summary>
                /// Gets or sets the album associated with the track.
                /// </summary>
                public Album? Album { get; set; }

                /// <summary>
                /// Gets or sets the genre associated with the track.
                /// </summary>
                public Genre? Genre { get; set; }
                #endregion Navigation Properties

                /// <summary>
                /// Copies the properties from another track.
                /// </summary>
                /// <param name="other">The other track to copy properties from.</param>
                /// <exception cref="ArgumentNullException">Thrown when the other track is null.</exception>
                public void CopyProperties( ITrack other )
                {
                        ArgumentNullException.ThrowIfNull( other );

                        Id = other.Id;
                        AlbumId = other.AlbumId;
                        GenreId = other.GenreId;
                        Title = other.Title;
                        Composer = other.Composer;
                        Milliseconds = other.Milliseconds;
                        Bytes = other.Bytes;
                        UnitPrice = other.UnitPrice;
                }

                /// <summary>
                /// Returns a string that represents the current track.
                /// </summary>
                /// <returns>A string that represents the current track.</returns>
                public override string ToString( )
                {
                        return $"{Title}";
                }
        }
}
