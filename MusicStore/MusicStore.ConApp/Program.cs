using MusicStoreContext = MusicStore.Logic.DataContext.MusicStoreContext;
using IContext = MusicStore.Logic.SqLite.Contracts.IContext;

namespace MusicStore.ConApp;

internal class Program
{
        static void Main( )
        {
                int index = 1;
                string input = string.Empty;

                MusicStoreContext context = new( );
                IContext? contextSQL = MusicStore.Logic.SqLite.DataContext.Factory.CreateContext( );

                int mainChoice = 0;
                while(input.ToLower( ) != "x")
                {
                        Console.Clear( );

                        PrintHeader( );

                        PrintMainMenu( ref index , ref mainChoice );

                        PrintChoicePrompt( ref index );

                        input = GetUserInput( ref index );

                        mainChoice = PrintChosenAction( input , context , contextSQL , ref mainChoice );

                        ResetChoice( ref index );
                }
        }

        private static void PrintHeader( )
        {
                Console.WriteLine( "         MusicStore         ".BackgroundColor( "45,225,110" ).ForegroundColor( "black" ) );
                Console.WriteLine( "============================\n".ForegroundColor( "45,225,110" ) );
        }
        private static void PrintChoicePrompt( ref int index )
        {
                Console.WriteLine( $"Exit...................x".ForegroundColor( "red" ) );
                Console.Write( "\nYour choice:".BackgroundColor( "255,255,255" ).ForegroundColor( "black" ) + " " );
        }
        private static string GetUserInput( ref int index )
        {
                string input = Console.ReadLine( )!;
                if(input == string.Empty)
                        index = 1;
                return input;
        }
        private static bool ParseUserInput( string input , out int choice ) => int.TryParse( input , out choice );
        private static int PrintChosenAction( string input , MusicStoreContext context , IContext sqlContexts , ref int mainChoice )
        {
                if(ParseUserInput( input , out int choice ))
                {
                        switch(mainChoice)
                        {
                                case 0:
                                        mainChoice = choice;
                                        break;
                                case 1:
                                        NormalPrintChoice( context , choice , ref mainChoice );
                                        break;
                                case 2:
                                        StatisticsPrintChoice( context , choice , ref mainChoice );
                                        break;
                                case 3:
                                        SQLitePrintChoice( sqlContexts , choice , ref mainChoice );
                                        break;
                                default:
                                        break;
                        }
                }

                return mainChoice;
        }
        private static void ResetChoice( ref int index )
        {
                Console.WriteLine( );
                Console.Write( "Continue with Enter..." );
                Console.ReadLine( );
                index = 1;
        }

        private static void PrintMainMenuLegend( ref int index )
        {
                Console.WriteLine( $"Print Objects from csv Database......{index++}" );
                Console.WriteLine( $"Print Statistics from csv Database...{index++}" );
                Console.WriteLine( $"Manage Objects in SQLite Database....{index++}" );
                index = 1;
        }
        private static int PrintMainMenu( ref int index , ref int mainChoice )
        {
                switch(mainChoice)
                {
                        case 0:
                                PrintMainMenuLegend( ref index );
                                break;
                        case 1:
                                NormalPrintLegend( ref index );
                                break;
                        case 2:
                                StatisticPrintLegend( ref index );
                                break;

                        case 3:
                                SQLitePrintLegend( ref index );
                                break;
                        default:
                                break;
                }
                return index;
        }

        private static void NormalPrintLegend( ref int index )
        {
                Console.WriteLine( $"{nameof( PrintArtists )}...{index++}" );
                Console.WriteLine( $"{nameof( PrintGenres )}....{index++}" );
                Console.WriteLine( $"{nameof( PrintAlbums )}....{index++}" );
                Console.WriteLine( $"{nameof( PrintTracks )}....{index++}" );
                Console.WriteLine( );
                Console.WriteLine( $"zurück.........0" );
        }
        private static void NormalPrintChoice( MusicStoreContext context , int choice , ref int mainChoice )
        {
                switch(choice)
                {
                        case 0:
                                mainChoice = 0;
                                break;
                        case 1:
                                PrintArtists( context );
                                break;
                        case 2:
                                PrintGenres( context );
                                break;
                        case 3:
                                PrintAlbums( context );
                                break;
                        case 4:
                                PrintTracks( context );
                                break;
                        default:
                                break;
                }
        }
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

        private static void StatisticPrintLegend( ref int index )
        {
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintArtistAndAlbum )}....{index++}".ForegroundColor( "0,255,155" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintArtistAndTracks )}...{index++}".ForegroundColor( "15,245,140" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintArtistAndTimes )}....{index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAlbumAndTracks )}....{index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAlbumAndTimes )}.....{index++}".ForegroundColor( "60,215,95" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAverageByGenre )}....{index++}".ForegroundColor( "75,205,80" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAverageByAlbum )}....{index++}".ForegroundColor( "90,195,65" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintAverageByTrack )}....{index++}".ForegroundColor( "105,185,50" ) );
                Console.WriteLine( $"{nameof( MusicStoreStatistics.PrintGenreAndTitles )}....{index++}".ForegroundColor( "120,175,35" ) );
                Console.WriteLine( $"zurück.................0" );
        }
        private static void StatisticsPrintChoice( MusicStoreContext context , int choice , ref int mainChoice )
        {
                switch(choice)
                {
                        case 0:
                                mainChoice = 0;
                                break;
                        case 1:
                                MusicStoreStatistics.PrintArtistAndAlbum( context );
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
        }


        private static void SQLitePrintLegend( ref int index )
        {
                Console.WriteLine( $"{nameof( PrintArtists )}...{index++}" );
                Console.WriteLine( $"{nameof( AddArtist )}....{index++}" );
                Console.WriteLine( );
                Console.WriteLine( $"zurück.........0" );
        }
        private static void SQLitePrintChoice( IContext context , int choice , ref int mainChoice )
        {
                switch(choice)
                {
                        case 0:
                                mainChoice = 0;
                                break;
                        case 1:
                                PrintArtists( context );
                                break;
                        case 2:
                                AddArtist( context );
                                break;
                        case 3:
                                break;
                        case 4:
                                break;
                        default:
                                break;
                }
        }

        private static void AddArtist( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Add Artist:" );
                Console.WriteLine( "------------" );

                var artist = new MusicStore.Logic.SqLite.Entities.Artist( );

                Console.Write( "Name [256]:          " );
                artist.Name = Console.ReadLine( )!;

                context.ArtistSet!.Add( artist );

                context.SaveChanges( );
        }
        private static void PrintArtists( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Artists:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.ArtistSet!)
                        Console.WriteLine( $"{item}" );
        }

}
