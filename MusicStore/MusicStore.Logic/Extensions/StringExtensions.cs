namespace MusicStore.Logic.Extensions;

public static class StringExtensions
{
        #region public METHODS
        public static string ForegroundColor( this string source , string colorInstruction ) => source.Color( colorInstruction );
        public static string BackgroundColor( this string source , string colorInstruction ) => source.Color( colorInstruction , foreground: false );

        public static string Color( this string source , string colorInstruction , bool foreground = true )
        {
                var asciiColorString = Decode( colorInstruction , foreground );

                return
                  new StringBuilder( )
                   .Append( asciiColorString )
                   .Append( source )
                   .Append( _asciiColorReset )
                   .ToString( );
        }

        public static string ColorGradient( this string source , string from_ColorInstruction , string to_ColorInstruction )
        {
                int stringLength = source.Length;


                throw new NotImplementedException( );
        }

        public static bool IsNumber( this string source )
        {
                bool result = true;
                for(int i = 0 ; i < source.Length && result ; i++)
                        if(char.IsLetter( source[ i ] ))
                                result = false;
                return result;
        }
        #endregion

        #region FIELDS
        private static readonly string _asciiColorReset = "\u001b[0m";
        #endregion

        #region private METHODS
        private static string Decode( string colorName , bool foreground )
        {
                var result = new StringBuilder( ).Append( $"\u001b[{(foreground ? "38" : "48")};2;" );

                try
                {
                        if(colorName.InstructionIsAColorName( ))
                                result.Append( colorName.ToLower( ) switch
                                {
                                        "red" => "255;0;0",
                                        "green" => "0;255;0",
                                        "blue" => "0;0;255",
                                        "black" => "0;0;0",
                                        _ => throw new Exception( ),
                                } );
                        else if(colorName.InstructionIsValidRGB( ))
                                result.Append( DecodeRGB( colorName ) );
                        else
                                result.Append( "255;255;255" );
                }
                catch(Exception)
                {
                        Console.WriteLine( ErrorHeader( ) + $" Wrong Color Name inputed!\n\t\t \"{colorName}\"".Color( "Red" ) );
                        OutputIsDefaultColor( );
                        result.Append( "255;255;255" );
                }
                return result.Append( 'm' ).ToString( );
        }

        private static string DecodeRGB( string colorName )
        {
                char seperatorChar = GetSeperator( colorName );
                string[] rgbValues = colorName.Split( seperatorChar );

                return
                   new StringBuilder( )
                    .Append( rgbValues[ 0 ] )
                    .Append( ';' )
                    .Append( rgbValues[ 1 ] )
                    .Append( ';' )
                    .Append( rgbValues[ 2 ] )
                    .ToString( );
        }

        private static bool InstructionIsValidRGB( this string source )
        {
                bool result = true;
                char seperatorChar = GetSeperator( source );

                try
                {
                        string[] rgbValues = source.Split( seperatorChar );
                        if(rgbValues.Length != 3)
                                throw new ArgumentOutOfRangeException( source );

                        for(int i = 0 ; i < rgbValues.Length ; i++)
                                if(!rgbValues[ i ].IsNumber( ) || int.Parse( rgbValues[ i ] ) < 0 || int.Parse( rgbValues[ i ] ) > 255)
                                        throw new Exception( );
                }
                catch(ArgumentOutOfRangeException)
                {
                        Console.WriteLine( ErrorHeader( ) + $" Wrong Length of Color Format inputed!\n\t\t \"{source}\"".Color( "Red" ) );
                        OutputIsDefaultColor( );
                        result = false;
                }
                catch(Exception)
                {
                        Console.WriteLine( ErrorHeader( ) + $" Wrong Color Format inputed!\n\t\t \"{source}\"".Color( "Red" ) );
                        OutputIsDefaultColor( );
                        result = false;
                }
                return result;
        }

        private static char GetSeperator( string source )
        {
                char seperatorChar = default;

                if(source.Contains( ';' ))
                        seperatorChar = ';';
                else if(source.Contains( ',' ))
                        seperatorChar = ',';
                return seperatorChar;
        }

        private static bool InstructionIsAColorName( this string source )
        {
                bool result = true;
                for(int i = 0 ; i < source.Length && result ; i++)
                        if(char.IsDigit( source[ i ] ))
                                result = false;
                return result;
        }

        private static void OutputIsDefaultColor( ) => Console.WriteLine( "\t\t Output is default-colored:".Color( "Red" ) );
        private static string ErrorHeader( ) => "\t[ERROR:]".Color( "Black" ).Color( "Red" , foreground: false );
        #endregion
}