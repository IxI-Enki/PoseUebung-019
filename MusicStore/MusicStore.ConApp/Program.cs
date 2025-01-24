namespace MusicStore.ConApp;

internal class Program
{
        static void Main( )
        {
                int index = 1;
                string input = string.Empty;
                MusicStoreContext context = new MusicStoreContext( );
                //  Logic.Contracts.IContext? contextb = Logic.DataContext.Factory.CreateContext( );

                PrintGenres( context );
                // PrintAlbums(context);

                while(input.ToLower( ) != "x")
                {
                        Console.Clear( );
                        Console.WriteLine( "         MusicStore         ".BackgroundColor( "45,225,110" ).ForegroundColor( "black" ) );
                        Console.WriteLine( "============================\n".ForegroundColor( "45,225,110" ) );

                        Console.WriteLine( $"{nameof( PrintGenres )}....{index++}".ForegroundColor( "0,255,155" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintArtistAndTracks )}...{index++}".ForegroundColor( "15,245,140" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintArtistAndTimes )}....{index++}".ForegroundColor( "30,235,125" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAlbumAndTracks )}....{index++}".ForegroundColor( "45,225,110" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAlbumAndTimes )}.....{index++}".ForegroundColor( "60,215,95" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAverageByGenre )}....{index++}".ForegroundColor( "75,205,80" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAverageByAlbum )}....{index++}".ForegroundColor( "90,195,65" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAverageByTrack )}....{index++}".ForegroundColor( "105,185,50" ) );
                        Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintGenreAndTitles )}....{index++}".ForegroundColor( "120,175,35" ) );

                        Console.WriteLine( );
                        Console.WriteLine( $"Exit...................x".ForegroundColor( "red" ) );
                        Console.Write( "\nYour choice:".BackgroundColor( "255,255,255" ).ForegroundColor( "black" ) + " " );

                        input = Console.ReadLine( )!;

                        if(input == string.Empty)
                                index = 1;

                        if(int.TryParse( input , out int choice ))
                        {
                                switch(choice)
                                {
                                        case 1:
                                                MusicStoreStatistics.PrintArtistAndTimes( context );
                                                break;
                                        case 2:
                                                MusicStoreStatistics.PrintArtistAndTimes( context );
                                                break;
                                        case 3:
                                                MusicStoreStatistics.PrintArtistAndTimes( context );
                                                break;
                                        case 4:
                                                MusicStoreStatistics.PrintAlbumAndTracks( context );
                                                break;
                                        case 5:
                                                MusicStoreStatistics.PrintAlbumAndTimes( context );
                                                break;
                                        case 6:
                                                MusicStoreStatistics.PrintAverageByGenre( context );
                                                break;
                                        case 7:
                                                MusicStoreStatistics.PrintAverageByAlbum( context );
                                                break;
                                        case 8:
                                                MusicStoreStatistics.PrintAverageByTrack( context );
                                                break;
                                        case 9:
                                                MusicStoreStatistics.PrintGenreAndTitles( context );
                                                break;
                                        default:
                                                break;
                                }
                                index = 1;
                                Console.WriteLine( );
                                Console.Write( "Continue with Enter..." );
                                Console.ReadLine( );
                        }
                }
        }
        //  private static void AddArtist( Logic.Contracts.IContext context )
        //  {
        //          Console.WriteLine( );
        //          Console.WriteLine( "Add Artist:" );
        //          Console.WriteLine( "------------" );
        //
        //          var artist = new Logic.Entities.Artist( );
        //
        //          Console.Write( "Name [256]:          " );
        //          artist.Name = Console.ReadLine( )!;
        //
        //          context.ArtistDbSet!.Add( artist );
        //
        //          context.SaveChanges( );
        //  }

        private static void PrintGenres( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Genres:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.GenreSet!)
                        Console.WriteLine( $"{item}" );
        }

        private static void PrintArtists( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Artists:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.ArtistSet!)
                        Console.WriteLine( $"{item}" );
        }

        private static void PrintAlbums( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Albums:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.AlbumSet!)
                        Console.WriteLine( $"{item}" );
        }

        private static void PrintTracks( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Tracks:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.TrackSet!)
                        Console.WriteLine( $"{item}" );
        }
}
