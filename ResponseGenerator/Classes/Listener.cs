using ResponseGenerator.Enumerations;
using ResponseGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseGenerator.Classes
{
    internal class Listener : IListener
    {
        public event Action<KEYWORDS> KeywordSpokenEvent;

        public Listener()
        {
            
        }

        void IListener.StartListening( KEYWORDS[] keywords )
        {
            throw new NotImplementedException();
        }

        void IListener.StopListening( KEYWORDS[] keywords )
        {
            throw new NotImplementedException();
        }

        void IListener.StopListening()
        {
            throw new NotImplementedException();
        }
    }
}
