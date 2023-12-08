using ResponseGenerator.Enumerations;
using ResponseGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseGenerator.Classes
{
    internal class Responder : IResponder
    {
        public RESPONSE_STYLES ResponseStyle { get; set; }

        public Responder( RESPONSE_STYLES style )
        {
            ResponseStyle = style;
        }

        string IResponder.GetResponse( KEYWORDS keyword )
        {
            throw new NotImplementedException();
        }
    }
}
