using SharedEnumerations;
using SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace SystemSpeechListener
{
    public class Listener : IListener
    {
        Thread                          _listeningThread;
        ManualResetEvent                _stopListening = new ManualResetEvent( false );
        KEYWORDS[]                      _currentKeywords;
        SpeechRecognitionEngine         _speechRecognitionEngine;
        Grammar                         _grammar;
        Dictionary<KEYWORDS, string>    _keywordStringPairs;

        public event Action<KEYWORDS> KeywordSpokenEvent;

        public Listener()
        {
            _speechRecognitionEngine = new SpeechRecognitionEngine();
            _keywordStringPairs = new Dictionary<KEYWORDS , string>();
        }

        void IListener.StartListening( KEYWORDS[] keywords )
        {
            if( _listeningThread != null && !_currentKeywords.ArrayEqual( keywords ) )
            {
                _stopListening.Set();
                _listeningThread.Join();
            }

            _currentKeywords = keywords;
            _keywordStringPairs = GetKeywordStringPairs( keywords );
            _stopListening.Reset();
            _listeningThread = new Thread( Listen );
            _listeningThread.Start();
        }

        void IListener.StopListening( KEYWORDS[] keywords )
        {
            if( IsListening() && _currentKeywords.ArrayEqual( keywords ) )
            {
                _stopListening.Set();
                _listeningThread.Join();
            }
        }

        void IListener.StopListening()
        {
            if( IsListening() )
            {
                _stopListening.Set();
                _listeningThread.Join();
            }
        }

        private bool IsListening() => _listeningThread != null && !_stopListening.WaitOne( 0 );

        private void Listen()
        {

            _grammar = new DictationGrammar();
            _speechRecognitionEngine.LoadGrammar( _grammar );
            try
            {
                _speechRecognitionEngine.SetInputToDefaultAudioDevice();
            }
            catch( Exception error )
            {
                Console.WriteLine( error.Message );
            }


            while( !_stopListening.WaitOne( 0 ) )
                ProcessKeywords( GetKeywords( GetSentence() ) );
            _speechRecognitionEngine.UnloadAllGrammars();
        }

        private string GetSentence()
        {
            string sentence = null;
            try
            {
                Console.WriteLine( "\nListening..." );
                var result = _speechRecognitionEngine.Recognize();
                Console.WriteLine( "stoppped listenning!" );
                if( result != null )
                {
                    sentence = result.Text;
                    Console.WriteLine( $"heard: {result.Text}, confidence: {result.Confidence}" );
                }
            }
            catch( Exception )
            {
                throw;
            }
            return sentence;
        }

        private KEYWORDS[] GetKeywords( string sentence )
        {
            KEYWORDS[] keywords = new KEYWORDS[0];

            if( sentence != null )
            {
                string lowerCaseSentence = sentence.ToLower();
                // Simple method to extract keywords from sentence
                foreach( var pair in _keywordStringPairs )
                {
                    if( lowerCaseSentence.Contains( pair.Value ) )
                        keywords = keywords.Append( pair.Key ).ToArray();
                }
            }
            return keywords;
        }

        private void ProcessKeywords( KEYWORDS[] keywords )
        {
            foreach( KEYWORDS keyword in keywords )
                KeywordSpokenEvent?.Invoke( keyword );
        }

        private Dictionary<KEYWORDS , string> GetKeywordStringPairs( KEYWORDS[] keywords )
        {
            var keywordStr = new Dictionary<KEYWORDS, string>();

            if( keywords != null )
            {
                foreach( KEYWORDS keyword in keywords )
                {
                    var str = keyword.ToString().Replace('_', ' ').ToLower();
                    keywordStr.Add( keyword , str );
                }
            }
            return keywordStr;
        }
    }
}
