using ResponseGenerator.Enumerations;
using ResponseGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseGenerator.Classes
{
    internal class Speaker : ISpeaker
    {
        readonly KEYWORDS[] _keywords;
        readonly IListener  _listener;
        readonly IResponder _responder;
        List<string>        _responses;
        DateTime?           _startListeningDate;
        DateTime?           _stopListeningDate;

        public Speaker( KEYWORDS[] keywords, RESPONSE_STYLES style )
        {
            _keywords = keywords;
            _listener = new Listener();
            _responder = new Responder( style );
        }

        int ISpeaker.NumResponses => _responses.Count;

        TimeSpan ISpeaker.ListeningDuration => _startListeningDate == null ? new TimeSpan( 0 , 0 , 0 ) : (_stopListeningDate ?? DateTime.Now) - _startListeningDate.Value;

        void ISpeaker.Start()
        {
            _startListeningDate = DateTime.Now;
            _listener.StartListening( _keywords );
        }

        void ISpeaker.Stop()
        {
            _listener.StopListening();
        }

        void OnKeywordSpoken( KEYWORDS keyword )
        {
            _responses.Add( _responder.GetResponse( keyword ) );
        }
    }
}
