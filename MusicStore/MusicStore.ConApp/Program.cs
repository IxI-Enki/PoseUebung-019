namespace MusicStore.ConApp;

internal class Program
{
        static void Main( )
        {
                int index = 1;
                string input = string.Empty;

                MusicStoreContext context = new( );
                IContext? contextSQL = Factory.CreateContext( );

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
                Console.WriteLine( $"   Exit ................x".ForegroundColor( "red" ) );
                Console.Write( $"\n{" ",-11}{"Your choice:".BackgroundColor( "255,255,255" ).ForegroundColor( "black" )} " );
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
                Console.Write( "  Continue with Enter..." );
                Console.ReadLine( );
                index = 1;
        }

        private static void PrintMainMenuLegend( ref int index )
        {
                Console.WriteLine( $"  Ältere Übungen:       ".ForegroundColor( "160,160,160" ) );
                Console.WriteLine( $"        ( CSV Database )".ForegroundColor( "160,160,160" ) );
                Console.WriteLine( $"   Print Objects .......{index++}".ForegroundColor( "100,100,100" ) );
                Console.WriteLine( $"   Print Statistics ....{index++}".ForegroundColor( "100,100,100" ) );
                Console.WriteLine( );
                Console.WriteLine( $"  Aktuelle Übung:       ".ForegroundColor( "200,255,200" ) );
                Console.WriteLine( $"     ( SQLite Database )".ForegroundColor( "200,255,200" ) );
                Console.WriteLine( $"   Manage Objects ......{index++}".ForegroundColor( "120,255,120" ) );
                Console.WriteLine( );
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
                Console.WriteLine( $"   {nameof( PrintArtists )} ........{index++}".ForegroundColor( "0,255,155" ) );
                Console.WriteLine( $"   {nameof( PrintGenres )} .........{index++}".ForegroundColor( "15,245,140" ) );
                Console.WriteLine( $"   {nameof( PrintAlbums )} .........{index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"   {nameof( PrintTracks )} .........{index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( );
                Console.WriteLine( $"   Back ................0" );
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
                Console.WriteLine( $"   ArtistAndAlbum ......{index++}".ForegroundColor( "0,255,155" ) );
                Console.WriteLine( $"   ArtistAndTracks .....{index++}".ForegroundColor( "15,245,140" ) );
                Console.WriteLine( $"   ArtistAndTimes ......{index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"   AlbumAndTracks ......{index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( $"   AlbumAndTimes  ......{index++}".ForegroundColor( "60,215,95" ) );
                Console.WriteLine( $"   AverageByGenre ......{index++}".ForegroundColor( "75,205,80" ) );
                Console.WriteLine( $"   AverageByAlbum ......{index++}".ForegroundColor( "90,195,65" ) );
                Console.WriteLine( $"   AverageByTrack ......{index++}".ForegroundColor( "105,185,50" ) );
                Console.WriteLine( $"   GenreAndTitles ......{index++}".ForegroundColor( "120,175,35" ) );
                Console.WriteLine( $"   Back ................0" );
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
                Console.WriteLine( $"   {nameof( PrintArtists ),-13}........{index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"   {nameof( AddArtist ),-10}...........{index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( $"   {nameof( DeleteArtist ),-13}........{index++}".ForegroundColor( "60,215,95" ) );
                Console.WriteLine( $"   {nameof( QueryArtists ),-13}........{index++}".ForegroundColor( "75,205,80" ) );
                Console.WriteLine( );  //                       16 .....              
                Console.WriteLine( $"   {nameof( PrintGenres ),-12}.........{index++}".ForegroundColor( "90,195,65" ) );
                Console.WriteLine( $"   {nameof( AddGenre ),-9}............{index++}".ForegroundColor( "105,185,50" ) );
                Console.WriteLine( $"   {nameof( DeleteGenre ),-12}.........{index++}".ForegroundColor( "120,175,35" ) );
                Console.WriteLine( $"   {nameof( QueryGenres ),-12}.........{index++}".ForegroundColor( "135,165,50" ) );
                Console.WriteLine( );  //                       16 .....
                Console.WriteLine( $"   {nameof( PrintAlbums ),-12}.........{index++}".ForegroundColor( "150,155,65" ) );
                Console.WriteLine( $"   {nameof( AddAlbum ),-9}...........{index++}".ForegroundColor( "165,145,80" ) );
                Console.WriteLine( $"   {nameof( DeleteAlbum ),-12}........{index++}".ForegroundColor( "180,135,95" ) );
                Console.WriteLine( $"   {nameof( QueryAlbums ),-12}........{index++}".ForegroundColor( "195,125,110" ) );
                Console.WriteLine( );  //                       16 ....
                Console.WriteLine( $"   {nameof( PrintTracks ),-12}........{index++}".ForegroundColor( "210,115,125" ) );
                Console.WriteLine( $"   {nameof( AddTrack ),-9}...........{index++}".ForegroundColor( "225,105,140" ) );
                Console.WriteLine( $"   {nameof( DeleteTrack ),-12}........{index++}".ForegroundColor( "240,95,155" ) );
                Console.WriteLine( $"   {nameof( QueryTracks ),-12}........{index++}".ForegroundColor( "255,85,170" ) );
                Console.WriteLine( );
                Console.WriteLine( $"   Back ................0" );
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
                                DeleteArtist( context );
                                break;
                        case 4:
                                QueryArtists( context );
                                break;

                        case 5:
                                PrintGenres( context );
                                break;
                        case 6:
                                AddGenre( context );
                                break;
                        case 7:
                                DeleteGenre( context );
                                break;
                        case 8:
                                QueryGenres( context );
                                break;

                        case 9:
                                PrintAlbums( context );
                                break;
                        case 10:
                                AddAlbum( context );
                                break;
                        case 11:
                                DeleteAlbum( context );
                                break;
                        case 12:
                                QueryAlbums( context );
                                break;

                        case 13:
                                PrintTracks( context );
                                break;
                        case 14:
                                AddTrack( context );
                                break;
                        case 15:
                                DeleteTrack( context );
                                break;
                        case 16:
                                QueryTracks( context );
                                break;
                        default:
                                break;
                }
        }

        private static void QueryTracks( IContext context )
        {
                throw new NotImplementedException( );
        }

        private static void DeleteTrack( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Delete Track:" );
                Console.WriteLine( "------------" );

                Console.WriteLine( );
                Console.WriteLine( "Title: " );
                var name = Console.ReadLine( );
                var entity = context.TrackSet.FirstOrDefault( e => e.Title == name );

                if(entity != null)
                {
                        try
                        {
                                context.TrackSet.Remove( entity );
                                context.SaveChanges( );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }

        private static void QueryAlbums( IContext context )
        {
                throw new NotImplementedException( );
        }

        private static void DeleteAlbum( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Delete Album:" );
                Console.WriteLine( "-------------" );

                Console.WriteLine( );
                Console.WriteLine( "Title: " );
                var name = Console.ReadLine( );
                var entity = context.AlbumSet.FirstOrDefault( e => e.Title == name );

                if(entity != null)
                {
                        try
                        {
                                context.AlbumSet.Remove( entity );
                                context.SaveChanges( );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }

        private static void QueryGenres( IContext context )
        {
                throw new NotImplementedException( );
        }

        private static void DeleteGenre( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Delete Genre:" );
                Console.WriteLine( "-------------" );

                Console.WriteLine( );
                Console.WriteLine( "Name: " );
                var name = Console.ReadLine( );
                var entity = context.GenreSet.FirstOrDefault( e => e.Name == name );

                if(entity != null)
                {
                        try
                        {
                                context.GenreSet.Remove( entity );
                                context.SaveChanges( );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }

        private static void QueryArtists( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Query-Artists:" );
                Console.WriteLine( "--------------" );

                Console.WriteLine( "Query (e.g. Name.Contains(\"AC/DC\")" );
                Console.Write( "Query: " );
                Console.WriteLine("DOESNT WORK YET");

                /*
                var query = Console.ReadLine( )!;
                try
                {
                        foreach(var artist in context.ArtistSet.Where( query ).Include( e => e.Name ))
                        {
                                Console.WriteLine( $"{artist}" );
                        }
                }
                catch(Exception ex)
                {
                        Console.WriteLine( ex.Message );
                }
                */
        }

        private static void DeleteArtist( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Delete Artist:" );
                Console.WriteLine( "--------------" );

                Console.WriteLine( );
                Console.WriteLine( "Name: " );
                var name = Console.ReadLine( );
                var entity = context.ArtistSet.FirstOrDefault( e => e.Name == name );

                if(entity != null)
                {
                        try
                        {
                                context.ArtistSet.Remove( entity );
                                context.SaveChanges( );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }

        private static void AddArtist( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Add Artist:   " );
                Console.WriteLine( "   --------------" );
                Console.Write( "   ArtistName [256]: " );

                var artist = new Entities.Artist( );
                var artistName = Console.ReadLine( )!;
                var ar = context.ArtistSet.FirstOrDefault( x => x.Name == artistName );

                if(artistName != string.Empty)
                        if(ar == null)
                        {
                                artist.Name = artistName;
                                context.ArtistSet!.Add( artist );
                                context.SaveChanges( );
                        }
                        else
                                Console.WriteLine( " Database already contains ".ForegroundColor( "red" ) + $"{artistName}".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
                else if(artistName == string.Empty)
                        Console.WriteLine( " can't add empty string ".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
        }

        private static void PrintArtists( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Artists:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.ArtistSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void PrintGenres( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Genres:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.GenreSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void AddGenre( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Add Genre:    " );
                Console.WriteLine( "   --------------" );
                Console.Write( "   Genre-Name [256]: " );

                var genre = new Entities.Genre( );
                var genreName = Console.ReadLine( )!;
                var gr = context.GenreSet.FirstOrDefault( x => x.Name == genreName );

                if(genreName != string.Empty)
                        if(gr == null)
                        {
                                genre.Name = genreName;
                                context.GenreSet!.Add( genre );
                                context.SaveChanges( );
                        }
                        else
                                Console.WriteLine( " Database already contains ".ForegroundColor( "red" ) + $"{genreName}".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
                else if(genreName == string.Empty)
                        Console.WriteLine( "   can't add empty string ".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );

        }
        private static void PrintAlbums( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Albums:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.AlbumSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void AddAlbum( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Add Album:" );
                Console.WriteLine( "------------" );

                var album = new Entities.Album( );

                Console.Write( "Name [256]:          " );
                album.Title = Console.ReadLine( )!;

                context.AlbumSet!.Add( album );

                context.SaveChanges( );
        }

        private static void PrintTracks( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Tracks:" );
                Console.WriteLine( "-------" );

                foreach(var item in context.TrackSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void AddTrack( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "Add Track:" );
                Console.WriteLine( "------------" );

                var track = new Entities.Track( );

                Console.Write( "Name [256]:          " );
                track.Title = Console.ReadLine( )!;

                context.TrackSet!.Add( track );

                context.SaveChanges( );
        }
}
