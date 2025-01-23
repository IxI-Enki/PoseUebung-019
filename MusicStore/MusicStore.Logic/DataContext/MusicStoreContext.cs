namespace MusicStore.Logic.DataContext;

/// <summary>
/// Represents the data context for the Music Store application.
/// </summary>
public sealed class MusicStoreContext
{
        #region PROPERTIES
        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        public List<Models.Genre> GenreSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        public List<Models.Artist> ArtistSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        public List<Models.Album> AlbumSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        public List<Models.Track> TrackSet { get; set; }
        #endregion 


        #region CONSTRUCTOR
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
        /// </summary>
        public MusicStoreContext( )
        {
                GenreSet = LoadGenresFromCsv( "Data/genres.csv" );
                ArtistSet = LoadArtistsFromCsv( "Data/artists.csv" );
                AlbumSet = LoadAlbumsFromCsv( "Data/albums.csv" , ArtistSet );
                TrackSet = LoadTracksFromCsv( "Data/tracks.csv" , GenreSet , AlbumSet );

                ArtistSet.ForEach( a => a.Albums = AlbumSet.Where( e => e.ArtistId == a.Id ).ToList( ) );
        }
        #endregion 


        #region METHODS
        /// <summary>
        /// Loads genres from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of genres.</returns>
        private static List<Models.Genre> LoadGenresFromCsv( string path )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ';' ) )
                                .Select( e => new Models.Genre( )
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
        private static List<Models.Artist> LoadArtistsFromCsv( string path )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ';' ) )
                                .Select( e => new Models.Artist( )
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
        private static List<Models.Album> LoadAlbumsFromCsv( string path , IEnumerable<Models.Artist> artists )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ';' ) )
                                .Select( e => new Models.Album( )
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
        private static List<Models.Track> LoadTracksFromCsv( string path , IEnumerable<Models.Genre> genres , IEnumerable<Models.Album> albums )
        {
                var result = File
                                .ReadAllLines( path )
                                .Skip( 1 )
                                .Select( e => e.Split( ";" ) )
                                .Select( e => new Models.Track( )
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