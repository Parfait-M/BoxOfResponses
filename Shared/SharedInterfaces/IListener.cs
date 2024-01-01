using SharedEnumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedInterfaces
{
    public interface IListener
    {
        void StartListening( KEYWORDS[] keywords );
        void StopListening( KEYWORDS[] keywords );
        void StopListening();

        event Action<KEYWORDS> KeywordSpokenEvent;
    }
}
