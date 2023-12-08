using ResponseGenerator.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseGenerator.Interfaces
{
    internal interface IListener
    {
        void StartListening( KEYWORDS[] keywords );
        void StopListening( KEYWORDS[] keywords );
        void StopListening();

        event Action<KEYWORDS> KeywordSpokenEvent;
    }
}
