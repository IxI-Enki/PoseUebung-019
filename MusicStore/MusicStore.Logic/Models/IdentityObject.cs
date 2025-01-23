namespace MusicStore.Logic.Models;

/// <summary>
/// Represents an abstract base class for identifiable objects.
/// </summary>
[Serializable]
public abstract partial class IdentityObject : IIdentifiable
{
        #region Properties

        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public int Id { get; internal set; }

        #endregion Properties

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals( object? obj )
        {
                if(obj is IdentityObject other)
                {
                        return Id == other.Id;
                }
                return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode( )
        {
                return Id;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString( )
        {
                return Id.ToString( );
        }
}
