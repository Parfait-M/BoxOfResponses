using SharedEnumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedInterfaces
{
    public interface IResponder
    {
        string GetResponse( KEYWORDS keyword );

        void SetResponseStyle( IResponseStyle style );

        IResponseStyle ResponseStyle { get; }
    }
}
