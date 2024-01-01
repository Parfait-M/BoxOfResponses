using SharedEnumerations;
using SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using SystemSpeechListener;
using SystemSpeechResponder;

namespace SystemSpeechSpeaker
{
    public class Speaker : ISpeaker
    {
        readonly KEYWORDS[] _keywords;
        readonly IListener  _listener;
        readonly IResponder _responder;
        List<string>        _responses;
        DateTime?           _startListeningDate;
        DateTime?           _stopListeningDate;
        SpeechSynthesizer   _speechSynthesizer;

        public Speaker( RESPONSE_STYLES style , params KEYWORDS[] keywords )
        {
            _keywords = keywords;
            _listener = new Listener();
            _responder = new Responder( new SystemSpeechResponseStyle( style ) );
            _responses = new List<string>();
            _speechSynthesizer = new SpeechSynthesizer();
        }

        string[] ISpeaker.Responses => _responses.ToArray();

        TimeSpan ISpeaker.ListeningDuration => _startListeningDate == null ? new TimeSpan( 0 , 0 , 0 ) : ( _stopListeningDate ?? DateTime.Now ) - _startListeningDate.Value;

        string ISpeaker.Keywords => string.Join( ", " , _keywords );

        void ISpeaker.Start()
        {
            _startListeningDate = DateTime.Now;
            _listener.KeywordSpokenEvent += OnKeywordSpoken;
            _listener.StartListening( _keywords );
            _speechSynthesizer.SelectVoiceByHints( _responder.ResponseStyle.Gender , _responder.ResponseStyle.Age );
            _speechSynthesizer.Volume = 90;
        }

        void ISpeaker.Stop()
        {
            if( _startListeningDate == null )
                return;

            _listener.StopListening();
            _listener.KeywordSpokenEvent -= OnKeywordSpoken;
        }

        void OnKeywordSpoken( KEYWORDS keyword )
        {
            string response = _responder.GetResponse( keyword );
            _responses.Add( response );
            _speechSynthesizer.Speak( response );
        }
    }
}
