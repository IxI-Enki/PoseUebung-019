namespace MusicStore.Logic.SqLite.Entities;

/// <summary>
/// Represents a track in the music store.
/// </summary>
[Table( "Tracks" )]
[Index( nameof( AlbumId ) , IsUnique = true )]
[Serializable]
public partial class Track : Entities.EntityObject, Contracts.ITrack
{
        #region Properties
        /// <summary>
        /// Gets or sets the album ID.
        /// </summary>
        [MaxLength( 256 )]
        public int AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the genre ID.
        /// </summary>
        [MaxLength( 256 )]
        public int GenreId { get; set; }

        /// <summary>
        /// Gets or sets the title of the track.
        /// </summary>
        [MaxLength( 256 )]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the composer of the track.
        /// </summary>
        [MaxLength( 256 )]
        public string Composer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the duration of the track in milliseconds.
        /// </summary>
        [MaxLength( 600000 )]
        public long Milliseconds { get; set; }

        /// <summary>
        /// Gets or sets the size of the track in bytes.
        /// </summary>
        [MaxLength( 2048 )]
        public long Bytes { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the track.
        /// </summary>
        [MaxLength( 256 )]
        public double UnitPrice { get; set; }
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the album associated with the track.
        /// </summary>
        public Entities.Album? Album { get; set; }

        /// <summary>
        /// Gets or sets the genre associated with the track.
        /// </summary>
        public Entities.Genre? Genre { get; set; }
        #endregion Navigation Properties

        /// <summary>
        /// Copies the properties from another track.
        /// </summary>
        /// <param name="other">The other track to copy properties from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the other track is null.</exception>
        public void CopyProperties( ITrack other )
        {
                ArgumentNullException.ThrowIfNull( other );

                base.CopyProperties( other );

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

        public string TrackInformation( )
        {
                StringBuilder result =
                        new StringBuilder( $"   Id:{Id}       {Title}       \n" )
                                  .Append( $"   ----------------------------\n" )
                                  .Append( $"   Composer    : {Composer}    \n" )
                                  .Append( $"   Genre       : {Genre}       \n" )
                                  .Append( $"   Milliseconds: {Milliseconds}\n" );
                return result.ToString( );
        }
}
