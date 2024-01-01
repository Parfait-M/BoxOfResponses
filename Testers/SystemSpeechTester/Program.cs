using SharedEnumerations;
using SharedInterfaces;
using SystemSpeechSpeaker;

namespace SystemSpeechTester
{
    internal class Program
    {
        static void Main( string[] args )
        {
            RESPONSE_STYLES currentStyle = RESPONSE_STYLES.STANDARD_MALE;
            KEYWORDS[] currentKeyWords = new[] {KEYWORDS.GOOD_MORNING };
            ISpeaker speaker = new Speaker( currentStyle, currentKeyWords );

            while( true )
            {
                try
                {
                    char choice =  GetSelection();
                    switch( choice )
                    {
                        case '1':
                            currentKeyWords = ChangeKeywords();
                            speaker.Stop();
                            speaker = new Speaker( currentStyle , currentKeyWords );
                            break;
                        case '2':
                            StartListening( speaker );
                            break;
                        case '3':
                            StopListening( speaker );
                            break;
                        case '4':
                            ViewResponses( speaker );
                            break;
                        case '5':
                            currentStyle = ChangeResponseStyle();
                            speaker.Stop();
                            speaker = new Speaker( currentStyle , currentKeyWords );
                            break;
                        case 'Q':
                        case 'q':
                            return;
                        default:
                            Console.WriteLine( "Invalid selection, please try again!" );
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine( "Invalid selection/operation. Please try again!" );
                }
            }

            char GetSelection()
            {
                try
                {
                    Console.WriteLine( "1. Change Keywords" );
                    Console.WriteLine( "2. Start Listening" );
                    Console.WriteLine( "3. Stop Listening" );
                    Console.WriteLine( "4. View responses" );
                    Console.WriteLine( "5. Change Response Style" );
                    Console.WriteLine( "Q. Exit" );
                    Console.Write( "\nEnter Selection: " );
                    var response = Console.ReadLine();
                    return Convert.ToChar( response );
                }
                catch
                {
                    throw;
                }
            }
        }

        static KEYWORDS[] ChangeKeywords()
        {
            DisplayEnum<KEYWORDS>();
            Console.Write( "\nEnter comma separated selection: " );
            try
            {
                var response = Console.ReadLine();
                var intValues = response?.Split(", ", StringSplitOptions.RemoveEmptyEntries ).Select( val => Convert.ToInt32( val ) ).ToArray();
                if( intValues == null )
                    throw new Exception( "Invalid option" );
                KEYWORDS[] kEYWORDs = new KEYWORDS[0];
                foreach( var val in intValues )
                    kEYWORDs = kEYWORDs.Append( (KEYWORDS)( val - 1 ) ).ToArray();
                return kEYWORDs;
            }
            catch( Exception )
            {
                throw;
            }
        }

        static RESPONSE_STYLES ChangeResponseStyle()
        {
            DisplayEnum<RESPONSE_STYLES>();
            Console.Write( "Enter selection: " );
            try
            {
                var response = Console.ReadLine();
                int val = Convert.ToInt32( response );
                return (RESPONSE_STYLES)( val - 1 );
            }
            catch( Exception )
            {
                throw;
            }
        }

        static void StartListening( ISpeaker speaker )
        {
            Console.WriteLine( $"Started listening for {speaker.Keywords}" );
            speaker.Start();
        }

        static void StopListening( ISpeaker speaker )
        {
            Console.WriteLine( $"Stopped listening to {speaker.Keywords}" );
            speaker.Stop();
            Console.WriteLine( $"Listening Duration: {speaker.ListeningDuration}" );
        }

        static void ViewResponses( ISpeaker speaker )
        {
            Console.WriteLine( $"Responses:\nr: {string.Join( "\nr: " , speaker.Responses )}" );
        }

        static void DisplayEnum<TEnum>() where TEnum : struct, Enum
        {
            int index = 1;
            var arr = Enum.GetValues<TEnum>().Select( val => $"{index++}. {val}" );
            Console.WriteLine( string.Join( "\n" , arr ) );
        }
    }
}