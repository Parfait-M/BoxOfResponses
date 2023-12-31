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
        ResponseStyles _responseStyle;

        public Responder( ResponseStyles style )
        {
            _responseStyle = style;
        }

        ResponseStyles IResponder.ResponseStyles { get { return _responseStyle; } }

        void IResponder.SetResponseStyle( ResponseStyles style )
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
