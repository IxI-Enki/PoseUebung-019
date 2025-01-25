namespace MusicStore.ConApp;

internal class Program
{
        static void Main( )
        {
                Console.OutputEncoding = Encoding.UTF8;
                int index = 1;
                string input = string.Empty;

                MusicStoreContext context = new( );

                IContext? contextSQL = Factory.CreateContext( );

                Factory.MigrateCSVDatabase( context , ref contextSQL );

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
                Console.WriteLine(
                        "░▒▓█".BackgroundColor( "black" ).ForegroundColor( "45,225,110" ) +
                        "     MusicStore     ".BackgroundColor( "45,225,110" ).ForegroundColor( "black" ) +
                        "█▓▒░".BackgroundColor( "black" ).ForegroundColor( "45,225,110" ) );
                Console.WriteLine( "════════════════════════════\n".ForegroundColor( "45,225,110" ) );
        }
        private static void PrintChoicePrompt( ref int index )
        {
                Console.WriteLine( $"   Exit _______________ x".ForegroundColor( "red" ) );
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


        private static void SQLitePrintLegend( ref int index )
        {
                Console.WriteLine( $"   {nameof( PrintArtists ),-13} ______ {index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"   {nameof( AddArtist ),-10} _________ {index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( $"   {nameof( DeleteArtist ),-13} ______ {index++}".ForegroundColor( "60,215,95" ) );
                Console.WriteLine( $"   {nameof( QueryArtists ),-13} ______ {index++}".ForegroundColor( "75,205,80" ) );
                Console.WriteLine( );  //                       16 .....              
                Console.WriteLine( $"   {nameof( PrintGenres ),-12} _______ {index++}".ForegroundColor( "90,195,65" ) );
                Console.WriteLine( $"   {nameof( AddGenre ),-9} __________ {index++}".ForegroundColor( "105,185,50" ) );
                Console.WriteLine( $"   {nameof( DeleteGenre ),-12} _______ {index++}".ForegroundColor( "120,175,35" ) );
                Console.WriteLine( $"   {nameof( QueryGenres ),-12} _______ {index++}".ForegroundColor( "135,165,50" ) );
                Console.WriteLine( );  //                       16 .....
                Console.WriteLine( $"   {nameof( PrintAlbums ),-12} _______ {index++}".ForegroundColor( "150,155,65" ) );
                Console.WriteLine( $"   {nameof( AddAlbum ),-9} _________ {index++}".ForegroundColor( "165,145,80" ) );
                Console.WriteLine( $"   {nameof( DeleteAlbum ),-12} ______ {index++}".ForegroundColor( "180,135,95" ) );
                Console.WriteLine( $"   {nameof( QueryAlbums ),-12} ______ {index++}".ForegroundColor( "195,125,110" ) );
                Console.WriteLine( );  //                       16 ....
                Console.WriteLine( $"   {nameof( PrintTracks ),-12} ______ {index++}".ForegroundColor( "210,115,125" ) );
                Console.WriteLine( $"   {nameof( AddTrack ),-9} _________ {index++}".ForegroundColor( "225,105,140" ) );
                Console.WriteLine( $"   {nameof( DeleteTrack ),-12} ______ {index++}".ForegroundColor( "240,95,155" ) );
                Console.WriteLine( $"   {nameof( QueryTracks ),-12} ______ {index++}".ForegroundColor( "255,85,170" ) );
                Console.WriteLine( );
                Console.WriteLine( $"   Back _______________ 0" );

        }
        private static void NormalPrintLegend( ref int index )
        {
                Console.WriteLine( $"   {nameof( PrintArtists )} _______ {index++}".ForegroundColor( "0,255,155" ) );
                Console.WriteLine( $"   {nameof( PrintGenres )} ________ {index++}".ForegroundColor( "15,245,140" ) );
                Console.WriteLine( $"   {nameof( PrintAlbums )} ________ {index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"   {nameof( PrintTracks )} ________ {index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( );
                Console.WriteLine( $"   Back _______________ 0" );
        }
        private static void PrintMainMenuLegend( ref int index )
        {
                Console.WriteLine( $"  Ältere Übungen:       ".ForegroundColor( "160,160,160" ) );
                Console.WriteLine( $"        ( CSV Database )".ForegroundColor( "160,160,160" ) );
                Console.WriteLine( $"   Print Objects ______ {index++}".ForegroundColor( "100,100,100" ) );
                Console.WriteLine( $"   Print Statistics ___ {index++}".ForegroundColor( "100,100,100" ) );
                Console.WriteLine( );
                Console.WriteLine( $"  Aktuelle Übung:       ".ForegroundColor( "200,255,200" ) );
                Console.WriteLine( $"     ( SQLite Database )".ForegroundColor( "200,255,200" ) );
                Console.WriteLine( $"   Manage Objects _____ {index++}".ForegroundColor( "120,255,120" ) );
                Console.WriteLine( );
                index = 1;
        }
        private static void StatisticPrintLegend( ref int index )
        {
                Console.WriteLine( $"   ArtistAndAlbum _____ {index++}".ForegroundColor( "0,255,155" ) );
                Console.WriteLine( $"   ArtistAndTracks ____ {index++}".ForegroundColor( "15,245,140" ) );
                Console.WriteLine( $"   ArtistAndTimes _____ {index++}".ForegroundColor( "30,235,125" ) );
                Console.WriteLine( $"   AlbumAndTracks _____ {index++}".ForegroundColor( "45,225,110" ) );
                Console.WriteLine( $"   AlbumAndTimes ______ {index++}".ForegroundColor( "60,215,95" ) );
                Console.WriteLine( $"   AverageByGenre _____ {index++}".ForegroundColor( "75,205,80" ) );
                Console.WriteLine( $"   AverageByAlbum _____ {index++}".ForegroundColor( "90,195,65" ) );
                Console.WriteLine( $"   AverageByTrack _____ {index++}".ForegroundColor( "105,185,50" ) );
                Console.WriteLine( $"   GenreAndTitles _____ {index++}".ForegroundColor( "120,175,35" ) );
                Console.WriteLine( $"   Back _______________ 0" );

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


        private static void PrintGenres( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Genres:                               ".ForegroundColor( "60,220,220" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.GenreSet!)
                        Console.WriteLine( $"   {item}   " );

        }
        private static void PrintAlbums( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Albums:                               ".ForegroundColor( "60,220,220" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.AlbumSet!)
                        Console.WriteLine( $"{item.AlbumInformation( )}   " );
        }
        private static void PrintArtists( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Artists:                              ".ForegroundColor( "60,220,220" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.ArtistSet!)
                        Console.WriteLine( $"   {item}   " );

        }
        private static void PrintTracks( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Tracks:                               ".ForegroundColor( "60,220,220" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.TrackSet!)
                        Console.WriteLine( $"{item.TrackInformation( )}   " );
        }
        private static void PrintGenres( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Genres:" );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.GenreSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void PrintArtists( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Artists:" );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.ArtistSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void PrintAlbums( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Albums:" );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.AlbumSet!)
                        Console.WriteLine( $"{item}" );
        }
        private static void PrintTracks( MusicStoreContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Tracks:" );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "60,220,220" ) );

                foreach(var item in context.TrackSet!)
                        Console.WriteLine( $"{item}" );
        }


        private static void DeleteGenre( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Delete Genre:                         ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "250,60,60" ) );

                Console.WriteLine( );
                Console.Write( "   Name: " );
                var name = Console.ReadLine( );
                var entity = context.GenreSet.FirstOrDefault( e => e.Name == name );

                if(entity != null)
                {
                        try
                        {
                                context.GenreSet.Remove( entity );
                                context.SaveChanges( );
                                Console.WriteLine( $"         {entity} gelöscht!".ForegroundColor( "250,60,40" ) );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "   Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }
        private static void DeleteAlbum( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Delete Album:                         ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( );
                Console.Write( "   Title: " );
                var name = Console.ReadLine( );
                var entity = context.AlbumSet.FirstOrDefault( e => e.Title == name );

                if(entity != null)
                {
                        try
                        {
                                context.AlbumSet.Remove( entity );
                                context.SaveChanges( );
                                Console.WriteLine( $"         {entity} gelöscht!".ForegroundColor( "250,60,40" ) );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "   Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }
        private static void DeleteArtist( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Delete Artist:                        ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( );
                Console.Write( "   Name: " );
                var name = Console.ReadLine( );
                var entity = context.ArtistSet.FirstOrDefault( e => e.Name == name );

                if(entity != null)
                {
                        try
                        {
                                context.ArtistSet.Remove( entity );
                                context.SaveChanges( );
                                Console.WriteLine( $"         {entity} gelöscht!".ForegroundColor( "250,60,40" ) );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "   Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }
        private static void DeleteTrack( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Delete Track:                         ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "250,60,60" ) );
                Console.WriteLine( );
                Console.Write( "   Title: " );
                var name = Console.ReadLine( );
                var entity = context.TrackSet.FirstOrDefault( e => e.Title == name );

                if(entity != null)
                {
                        try
                        {
                                context.TrackSet.Remove( entity );
                                context.SaveChanges( );
                                Console.WriteLine( $"         {entity} gelöscht!".ForegroundColor( "250,60,40" ) );
                        }
                        catch(Exception ex)
                        {
                                Console.WriteLine( ex.Message );
                                Console.WriteLine( "   Continue with enter..." );
                                Console.ReadLine( );
                        }
                }
        }

        private static void AddGenre( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Add Genre:                            ".ForegroundColor( "green" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
                Console.Write( "   Name [256]: " );

                var genre = new Entities.Genre( );
                var genreName = Console.ReadLine( )!;
                var gr = context.GenreSet.FirstOrDefault( x => x.Name == genreName );

                if(genreName != string.Empty)
                        if(gr == null)
                        {
                                genre.Name = genreName;
                                context.GenreSet!.Add( genre );
                                context.SaveChanges( );
                                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
                                Console.WriteLine( $"   {genre}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                        }
                        else
                                Console.WriteLine( "   Database already contains ".ForegroundColor( "red" ) + $"{genreName}".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
                else if(genreName == string.Empty)
                        Console.WriteLine( "   can't add empty string ".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );

        }
        private static void AddAlbum( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Add Album:                            ".ForegroundColor( "green" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );

                var album = new Entities.Album( );
                Console.Write( "   Title [256]: " );

                var albumTitle = Console.ReadLine( )!;

                var al = context.AlbumSet.FirstOrDefault( x => x.Title == albumTitle );

                if(albumTitle != string.Empty)
                        if(al == null)
                        {
                                album.Title = albumTitle;

                                int count = 0;
                                Console.Write( "   Artist [256]: " );
                                var artistName = Console.ReadLine( )!;
                                var ar = context.ArtistSet.FirstOrDefault( x => x.Name == artistName );
                                if(ar == null)
                                        Console.WriteLine( "   Artist nicht gefunden!".ForegroundColor( "250,60,60" ) );

                                while(ar == null && count < 3)
                                {
                                        count++;
                                        Console.Write( "   Artist [256]: " );
                                        artistName = Console.ReadLine( )!;
                                        ar = context.ArtistSet.FirstOrDefault( x => x.Name == artistName );
                                        if(ar == null)
                                                Console.WriteLine( "   Artist nicht gefunden!  ".ForegroundColor( "250,60,60" ) + $"{3 - count} {(3 - count == 0 ? "Abruch" : "Versuche")}" );
                                }
                                try
                                {
                                        if(ar != null)
                                        {
                                                album.ArtistId = ar.Id;
                                                context.AlbumSet.Add( album );
                                                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
                                                Console.WriteLine( $"   {album}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                Console.WriteLine( $"   {ar.Name}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
                                                Console.WriteLine( album.AlbumInformation( ) );
                                                context.SaveChanges( );
                                        }
                                }
                                catch(Exception ex)
                                {
                                        Console.WriteLine( ex.Message );
                                        Console.Write( "  Continue with enter..." );
                                        Console.ReadLine( );
                                }
                        }
                        else
                                Console.WriteLine( "   Database already contains ".ForegroundColor( "red" ) + $"{albumTitle}".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
                else if(albumTitle == string.Empty)
                        Console.WriteLine( "   can't add empty string ".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
        }
        private static void AddArtist( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Add Artist:                           ".ForegroundColor( "green" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
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
                                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
                                Console.WriteLine( $"   {artist}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                        }
                        else
                                Console.WriteLine( "   Database already contains ".ForegroundColor( "red" ) + $"{artistName}".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
                else if(artistName == string.Empty)
                        Console.WriteLine( "   can't add empty string ".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
        }
        private static void AddTrack( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Add Track:                            ".ForegroundColor( "green" ) );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ ".ForegroundColor( "green" ) );
                Console.Write( "   Title  [256]: " );

                var track = new Entities.Track( );
                var trackTitle = Console.ReadLine( );
                var tr = context.TrackSet.FirstOrDefault( x => x.Title == trackTitle );

                if(trackTitle != string.Empty)
                        if(tr == null)
                        {
                                track.Title = trackTitle!;

                                int count = 0;
                                Console.Write( "   Album  [256]: " );
                                var albumName = Console.ReadLine( )!;
                                var al = context.AlbumSet.FirstOrDefault( x => x.Title == albumName );
                                if(al == null)
                                        Console.WriteLine( "   Album nicht gefunden!".ForegroundColor( "250,60,60" ) );

                                while(al == null && count < 3)
                                {
                                        count++;
                                        Console.Write( "   Album  [256]: " );
                                        albumName = Console.ReadLine( )!;
                                        al = context.AlbumSet.FirstOrDefault( x => x.Title == albumName );
                                        if(al == null)
                                                Console.WriteLine( "   Album nicht gefunden!  ".ForegroundColor( "250,60,60" ) + $"{3 - count} {(3 - count == 0 ? "Abruch" : "Versuche")}" );
                                }
                                try
                                {
                                        if(al != null)
                                        {
                                                Console.Write( "   Artist [256]: " );
                                                var artistName = Console.ReadLine( )!;
                                                var ar = context.ArtistSet.FirstOrDefault( x => x.Name == artistName );
                                                if(ar == null)
                                                        Console.WriteLine( "   Artist nicht gefunden!  ".ForegroundColor( "250,60,60" ) + $"{3 - count} {(3 - count == 0 ? "Abruch" : "Versuche")}" );

                                                count = 0;
                                                while(ar == null && count < 3)
                                                {
                                                        count++;
                                                        Console.Write( "   Artist [256]: " );
                                                        artistName = Console.ReadLine( )!;
                                                        ar = context.ArtistSet.FirstOrDefault( x => x.Name == artistName );
                                                        if(ar == null)
                                                                Console.WriteLine( "   Artist nicht gefunden!  ".ForegroundColor( "250,60,60" ) + $"{3 - count} {(3 - count == 0 ? "Abruch" : "Versuche")}" );
                                                }
                                                try
                                                {
                                                        if(ar != null)
                                                        {
                                                                Console.Write( "   Genre  [256]: " );
                                                                var genreName = Console.ReadLine( )!;
                                                                var g = context.GenreSet.FirstOrDefault( x => x.Name == genreName );
                                                                if(g == null)
                                                                        Console.WriteLine( "   Genre nicht gefunden!  ".ForegroundColor( "250,60,60" ) + $"{3 - count} {(3 - count == 0 ? "Abruch" : "Versuche")}" );

                                                                count = 0;
                                                                while(g == null && count < 3)
                                                                {
                                                                        count++;
                                                                        Console.Write( "   Genre  [256]: " );
                                                                        genreName = Console.ReadLine( )!;
                                                                        g = context.GenreSet.FirstOrDefault( x => x.Name == genreName );
                                                                        if(g == null)
                                                                                Console.WriteLine( "   Genre nicht gefunden!  ".ForegroundColor( "250,60,60" ) + $"{3 - count} {(3 - count == 0 ? "Abruch" : "Versuche")}" );
                                                                }
                                                                try
                                                                {
                                                                        if(g != null)
                                                                        {
                                                                                al.ArtistId = ar.Id;
                                                                                track.AlbumId = al.Id;
                                                                                track.GenreId = g.Id;

                                                                                Console.Write( "   Millisecnds : " );
                                                                                var millis = Console.ReadLine( );
                                                                                int.TryParse( millis , out int mill );
                                                                                track.Milliseconds = mill;

                                                                                Console.Write( "   Composer    : " );
                                                                                track.Composer = Console.ReadLine( )!;

                                                                                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ " );
                                                                                Console.WriteLine( $"   {track}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                                                Console.WriteLine( $"   {al.Title}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                                                Console.WriteLine( $"   {al.Artist}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                                                Console.WriteLine( $"   {track.Composer}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                                                Console.WriteLine( $"   {g.Name}  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                                                Console.WriteLine( $"   {track.Milliseconds}ms  hinzugefügt!".ForegroundColor( "40,250,60" ) );
                                                                                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ " );
                                                                                Console.WriteLine( track.TrackInformation( ) );

                                                                                context.TrackSet.Add( track );
                                                                                context.SaveChanges( );
                                                                        }
                                                                }
                                                                catch(Exception ex)
                                                                {
                                                                        Console.WriteLine( ex.Message );
                                                                        Console.Write( "  Continue with enter..." );
                                                                        Console.ReadLine( );
                                                                }
                                                        }
                                                }
                                                catch(Exception ex)
                                                {
                                                        Console.WriteLine( ex.Message );
                                                        Console.Write( "  Continue with enter..." );
                                                        Console.ReadLine( );
                                                }
                                        }
                                }
                                catch(Exception ex)
                                {
                                        Console.WriteLine( ex.Message );
                                        Console.Write( "  Continue with enter..." );
                                        Console.ReadLine( );
                                }
                        }
                        else
                                Console.WriteLine( "   Database already contains ".ForegroundColor( "red" ) + $"{trackTitle}".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
                else if(trackTitle == string.Empty)
                        Console.WriteLine( "   can't add empty string ".BackgroundColor( "200,20,20" ).ForegroundColor( "black" ) );
        }

        private static void QueryGenres( IContext context ) { }
        private static void QueryAlbums( IContext context ) { }
        private static void QueryArtists( IContext context )
        {
                Console.WriteLine( );
                Console.WriteLine( "   Query-Artists:                        " );
                Console.WriteLine( "   ━━━━━━━━━━━━━━━━━━━━━━ " );
                Console.WriteLine( "   Query (e.g. Name.Contains(\"AC/DC\")  " );
                Console.Write( "   Query: " );

                Console.WriteLine( "DOESNT WORK YET" );

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
        private static void QueryTracks( IContext context ) { }

}
