﻿namespace MusicStore.Logic.SqLite.Entities;

/// <summary>
/// Represents an artist in the music store.
/// </summary>
[Table( "Artists" )]
[Index( nameof( Name ) , IsUnique = true )]
[Serializable]
public partial class Artist : Entities.EntityObject, Contracts.IArtist
{
        #region Properties
        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        [MaxLength( 256 )]
        public string Name { get; set; } = string.Empty;
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the albums associated with the artist.
        /// </summary>
        public List<Entities.Album> Albums { get; set; } = new List<Entities.Album>( );

        public object ArtistInformation( )
        {
                StringBuilder result =
                        new StringBuilder( $"   Id:{Id} ,      {Name}       \n" )
                                  .Append( $"   ----------------------------\n" );
                return result.ToString( );
        }
        #endregion Navigation Properties

        /// <summary>
        /// Copies the properties from another artist.
        /// </summary>
        /// <param name="other">The other artist to copy properties from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the other artist is null.</exception>
        public void CopyProperties( IArtist other )
        {
                ArgumentNullException.ThrowIfNull( other );

                base.CopyProperties( other );

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
