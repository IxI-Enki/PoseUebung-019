namespace MusicStore.Logic.DataContext;

/// <summary>
/// Represents the data context for the Music Store application.
/// </summary>
public sealed class MusicStoreContext : DbContext, IContext
{
        #region FIELDS
        private static string ConnectionString = "data source=MusicStore.db";
        #endregion
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {

                optionsBuilder.UseSqlite( ConnectionString );

                base.OnConfiguring( optionsBuilder );
        }


        #region PROPERTIES
        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        public DbSet<Entities.Genre> GenreSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        public DbSet<Entities.Artist> ArtistSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        public DbSet<Entities.Album> AlbumSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        public DbSet<Entities.Track> TrackSet { get; set; }


        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        public List<Entities.Genre>? GenreList { get; set; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        public List<Entities.Artist>? ArtistList { get; set; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        public List<Entities.Album>? AlbumList { get; set; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        public List<Entities.Track>? TrackList { get; set; }

        #endregion


        #region CONSTRUCTOR
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
        /// </summary>
        public MusicStoreContext( )
        {
               // GenreList = LoadGenresFromCsv( "Data/genres.csv" );
               // ArtistList = LoadArtistsFromCsv( "Data/artists.csv" );
               // AlbumList = LoadAlbumsFromCsv( "Data/albums.csv" , ArtistList );
               // TrackList = LoadTracksFromCsv( "Data/tracks.csv" , GenreList , AlbumList );
               // ArtistList.ForEach( a => a.Albums = AlbumList.Where( e => e.ArtistId == a.Id ).ToList( ) );
               // ArtistSet!.ForEachAsync( a => a.Albums = AlbumList.Where( e => e.ArtistId == a.Id ).ToList( ) );
        }

        #endregion


        #region METHODS
        /// <summary>
        /// Loads genres from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of genres.</returns>
        private static List<Entities.Genre> LoadGenresFromCsv( string path )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ';' ) )
                                .Select( e => new Entities.Genre( )
                                {
                                        Id = Convert.ToInt32( e[ 0 ] ) ,
                                        Name = e[ 1 ] ,
                                } )
                                .ToList( );
                return result;
        }

        /// <summary>
        /// Loads artists from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of artists.</returns>
        private static List<Entities.Artist> LoadArtistsFromCsv( string path )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ';' ) )
                                .Select( e => new Entities.Artist( )
                                {
                                        Id = Convert.ToInt32( e[ 0 ] ) ,
                                        Name = e[ 1 ] ,
                                } )
                                .ToList( );
                return result;
        }

        /// <summary>
        /// Loads albums from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <param name="artists">The collection of artists.</param>
        /// <returns>A list of albums.</returns>
        private static List<Entities.Album> LoadAlbumsFromCsv( string path , IEnumerable<Entities.Artist> artists )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ';' ) )
                                .Select( e => new Entities.Album( )
                                {
                                        Id = Convert.ToInt32( e[ 0 ] ) ,
                                        Title = e[ 1 ] ,
                                        ArtistId = Convert.ToInt32( e[ 2 ] ) ,

                                        Artist = artists.First( a => a.Id == Convert.ToInt32( e[ 2 ] ) ) ,
                                } ).ToList( );
                return result;
        }

        /// <summary>
        /// Loads tracks from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <param name="genres">The collection of genres.</param>
        /// <param name="albums">The collection of albums.</param>
        /// <returns>A list of tracks.</returns>
        private static List<Entities.Track> LoadTracksFromCsv( string path , IEnumerable<Entities.Genre> genres , IEnumerable<Entities.Album> albums )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ";" ) )
                                .Select( e => new Entities.Track( )
                                {
                                        Id = Convert.ToInt32( e[ 0 ] ) ,
                                        Title = e[ 1 ] ,
                                        AlbumId = Convert.ToInt32( e[ 2 ] ) ,
                                        Album = albums.First( a => Convert.ToString( a.Id ) == Convert.ToString( e[ 2 ] ) ) ,
                                        GenreId = Convert.ToInt32( e[ 3 ] ) ,
                                        Genre = genres.First( g => Convert.ToString( g.Id ) == Convert.ToString( e[ 3 ] ) ) ,
                                        Composer = e[ 4 ] ,
                                        Milliseconds = Convert.ToInt32( e[ 5 ] ) ,
                                        Bytes = Convert.ToInt32( e[ 6 ] ) ,
                                        UnitPrice = Convert.ToDouble( e[ 7 ] ) ,
                                } ).ToList( );
                return result;
        }

        #endregion
}