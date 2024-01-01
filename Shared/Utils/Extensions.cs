using SharedEnumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Extensions
    {
        public static bool ArrayEqual( this KEYWORDS[] keywords , KEYWORDS[] newWords )
        {
            if( keywords == null && newWords == null )
                return true;
            else if( keywords != null && newWords != null )
            {
                if( keywords.Length != newWords.Length )
                    return false;

                for( int i = 0; i < keywords.Length; i++ )
                {
                    if( keywords[i] != newWords[i] )
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
