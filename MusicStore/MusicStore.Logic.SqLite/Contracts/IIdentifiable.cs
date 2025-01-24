namespace MusicStore.Logic.SqLite.Contracts;

public interface IIdentifiable
{
        #region Properties
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        int Id { get; }
        #endregion Properties
}
