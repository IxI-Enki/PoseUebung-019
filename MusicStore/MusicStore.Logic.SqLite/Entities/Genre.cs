namespace MusicStore.Logic.SqLite.Entities;

/// <summary>
/// Represents a music genre with an identifiable ID and a name.
/// </summary>
[Table( "Genres" )]
[Index( nameof( Name ) , IsUnique = true )]
[Serializable]
public partial class Genre : EntityObject, Contracts.IGenre
{
        #region Properties
        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        [MaxLength( 256 )]
        public string Name { get; set; } = string.Empty;
        #endregion Properties

        #region Navigation Properties
        /// <summary>
        /// Gets or sets the tracks associated with the genre.
        /// </summary>
        public List<Entities.Track> Tracks { get; set; } = new List<Entities.Track>( );
        #endregion Navigation Properties

        /// <summary>
        /// Copies the properties from another genre.
        /// </summary>
        /// <param name="other">The other genre to copy properties from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the other genre is null.</exception>
        public void CopyProperties( IGenre other )
        {
                ArgumentNullException.ThrowIfNull( other );
                base.CopyProperties( other );

                Name = other.Name;
        }

        /// <summary>
        /// Returns a string that represents the current genre.
        /// </summary>
        /// <returns>A string that represents the current genre.</returns>
        public override string ToString( )
        {
                return $"Id: {Id}, {Name}";
        }
}

