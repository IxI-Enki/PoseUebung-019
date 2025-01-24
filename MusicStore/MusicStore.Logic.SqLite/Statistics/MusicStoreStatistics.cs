namespace MusicStore.Logic.SqLite.Statistics;

public static class MusicStoreStatistics
{
        public static void PrintArtistAndAlbum( MusicStoreContext context )
        {
                context.ArtistSet
                        .Where( a => a.Albums.Count > 1 )
                        .OrderBy( a => a.Name )
                        .ThenBy( a => a.Id )
                        .ToList( )
                        .ForEach( a =>
                        {
                                Console.WriteLine( a.Name );

                                a
                                 .Albums
                                 .ForEach( al => Console.WriteLine( $"\t {al.Title}".ForegroundColor( "120,255,20" ) ) );
                        } );
        }

        public static void PrintArtistAndTracks( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 ArtistName = a.Album!.Artist!.Name ,
                                 TrackTitle = a.Title! ,
                         } )
                         .OrderBy( a => a.ArtistName )
                         .ThenBy( a => a.TrackTitle )
                         .ToList( );

                Console.WriteLine( " Artists and Tracks " );
                Console.WriteLine( "--------------------" );

                query
                     .GroupBy( e => e.ArtistName )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( a.Key );

                             a
                              .ToList( )
                              .ForEach( a => Console.WriteLine( $"  {a.TrackTitle}" ) );
                     } );
        }

        public static void PrintArtistAndTimes( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 ArtistName = a.Album!.Artist!.Name ,
                                 TrackDuration = a.Milliseconds ,
                         } )
                         .OrderBy( a => a.ArtistName )
                         .ToList( );

                Console.WriteLine( );
                Console.WriteLine( "                   Artists and Times                  ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "------------------------------------------------------".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( " Artist      Sum Of All Tracks           Average Time \n".ForegroundColor( "40,255,200" ) );

                query
                     .GroupBy( e => e.ArtistName )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( a.Key );
                             Console.WriteLine( $"  {a.Sum( e => e.TrackDuration ) / 1000.0,20:f2}".ForegroundColor( "20,255,120" ) + "[sec]" + $"{a.Average( e => e.TrackDuration ) / 1000.0,20:f2}".ForegroundColor( "20,255,120" ) + "[sec]" );
                     } );
        }

        public static void PrintAlbumAndTracks( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 AlbumTitle = a.Album!.Title ,
                                 TrackTitle = a.Title ,
                         } )
                         .OrderBy( a => a.AlbumTitle )
                         .ToList( );

                Console.WriteLine( );
                Console.WriteLine( "                   Albums and Tracks                  ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "------------------------------------------------------".ForegroundColor( "40,255,200" ) );

                query
                     .GroupBy( e => e.AlbumTitle )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( a.Key );

                             a
                              .ToList( )
                              .ForEach( a => Console.WriteLine( $"  {a.TrackTitle}".ForegroundColor( "120,120,120" ) ) );

                             Console.WriteLine( );
                     } );
        }

        public static void PrintAlbumAndTimes( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 AlbumTitle = a.Album!.Title ,
                                 AlbumTime = a.Milliseconds
                         } )
                         .OrderBy( a => a.AlbumTitle )
                         .ToList( );

                Console.WriteLine( );
                Console.WriteLine( "                   Albums and Times                   ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "------------------------------------------------------".ForegroundColor( "40,255,200" ) );

                query
                     .GroupBy( e => e.AlbumTitle )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( a.Key.ForegroundColor( "green" ) );
                             Console.WriteLine( $"  {a.Sum( e => e.AlbumTime ) / 1000.0,20:f2}".ForegroundColor( "20,255,120" ) + "[sec]" );
                             Console.WriteLine( );
                     } );
        }

        public static void PrintAverageByGenre( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 GenreTitle = a.Genre!.Name ,
                                 GenreTime = a.Milliseconds
                         } )
                         .OrderBy( a => a.GenreTitle )
                         .ToList( );

                Console.WriteLine( );
                Console.WriteLine( "                  Average by Genres                  ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "-----------------------------------------------------".ForegroundColor( "40,255,200" ) );

                query
                     .GroupBy( e => e.GenreTitle )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( $"{a.Key}".ForegroundColor( "20,120,255" ) );
                             Console.WriteLine( $"  {a.Average( e => e.GenreTime ) / 1000.0,20:f2}".ForegroundColor( "20,255,120" ) + "[sec]" );
                             Console.WriteLine( );
                     } );
        }

        public static void PrintAverageByAlbum( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 AlbumTitle = a.Album!.Title ,
                                 AlbumTime = a.Milliseconds
                         } )
                         .OrderBy( a => a.AlbumTitle )
                         .ToList( );

                Console.WriteLine( );
                Console.WriteLine( "                   Average Albumtimes                 ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "------------------------------------------------------".ForegroundColor( "40,255,200" ) );

                query
                     .GroupBy( e => e.AlbumTitle )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( $"{a.Key}".ForegroundColor( "20,120,255" ) );
                             Console.WriteLine( $"  {a.Average( e => e.AlbumTime ) / 1000.0,20:f2}".ForegroundColor( "20,255,120" ) + "[sec]" );
                             Console.WriteLine( );
                     } );
        }

        public static void PrintAverageByTrack( MusicStoreContext context )
        {
                var query = context.TrackSet
                        .Select( a => new
                        {
                                TrackDuration = a.Milliseconds
                        } )
                        .ToList( )
                        .Average( e => e.TrackDuration );

                Console.WriteLine( );
                Console.WriteLine( "       Average Tracktime of all Tracks        ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "----------------------------------------------".ForegroundColor( "green" ) );

                Console.WriteLine( $"{query / 1000.0,10:f2}".ForegroundColor( "20,255,120" ) + "[sec]" );
        }

        public static void PrintGenreAndTitles( MusicStoreContext context )
        {
                var query = context.TrackSet
                         .Select( a => new
                         {
                                 GenreName = a.Genre!.Name ,
                                 TitleNames = a.Title
                         } )
                         .OrderBy( a => a.GenreName )
                         .ToList( );

                Console.WriteLine( );
                Console.WriteLine( "                   Genres Titles                      ".ForegroundColor( "40,255,200" ) );
                Console.WriteLine( "------------------------------------------------------".ForegroundColor( "40,255,200" ) );

                query
                     .GroupBy( e => e.GenreName )
                     .ToList( )
                     .ForEach( a =>
                     {
                             Console.WriteLine( $"{a.Key}".ForegroundColor( "20,120,255" ) );

                             a
                              .ToList( )
                              .ForEach( a => Console.WriteLine( $"  {a.TitleNames}".ForegroundColor( "120,120,120" ) ) );
                     } );
        }
}
