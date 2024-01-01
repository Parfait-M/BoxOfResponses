using SharedEnumerations;
using SharedInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSpeechResponder
{
    public class Responder : IResponder
    {
        IResponseStyle _responseStyle;

        public Responder( IResponseStyle style )
        {
            _responseStyle = style;
        }

        IResponseStyle IResponder.ResponseStyle { get { return _responseStyle; } }

        void IResponder.SetResponseStyle( IResponseStyle style )
        {
            _responseStyle = style;
        }

        string IResponder.GetResponse( KEYWORDS keyword )
        {
            string response = null;

            switch( keyword )
            {
                case KEYWORDS.AH_CHEEW:
                    break;
                case KEYWORDS.GOOD_MORNING:
                    response = "Good morning";
                    break;
                case KEYWORDS.GOOD_AFTERNOON:
                    response = "Good afternoon";
                    break;
                case KEYWORDS.GOOD_EVENING:
                    response = "Good evening";
                    break;
                default:
                    break;
            }

            return _responseStyle.Prefix + response + _responseStyle.Suffix;
        }
    }
}
