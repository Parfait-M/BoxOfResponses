using ResponseGenerator.Enumerations;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ResponseGenerator.Classes
{
    internal class ResponseStyles
    {
        Styles _style;

        public ResponseStyles( RESPONSE_STYLES style )
        {
            switch( style )
            {
                case RESPONSE_STYLES.STANDARD_MALE:
                    _style = new StandardMale();
                    break;
                case RESPONSE_STYLES.STANDARD_FEMALE:
                    _style = new StandardFemale();
                    break;
                case RESPONSE_STYLES.NARUTO:
                    _style = new Naruto();
                    break;
                default:
                    throw new ApplicationException( $"Invalid \"RESPONSE_STYLES\" value ({style}). Expected [{string.Join( ", ", Enum.GetValues<RESPONSE_STYLES>() )}]" );
            }
        }

        internal string Prefix      => _style.Prefix;
        internal string Suffix      => _style.Suffix;
        internal VoiceGender Gender => _style.Gender;
        internal VoiceAge Age       => _style.Age;

        abstract class Styles
        {
            internal virtual string Prefix => null;

            internal virtual string Suffix => null;

            internal virtual VoiceGender Gender => VoiceGender.NotSet;
            internal virtual VoiceAge Age => VoiceAge.NotSet;
        }

        class StandardMale : Styles
        {
            internal override VoiceGender Gender => VoiceGender.Male;

            internal override VoiceAge Age => VoiceAge.Adult;
        }

        class StandardFemale : Styles 
        {
            internal override VoiceGender Gender => VoiceGender.Female;
            internal override VoiceAge Age => VoiceAge.Adult;
        }

        class Naruto : Styles
        {
            internal override VoiceGender Gender => VoiceGender.Male;
            internal override VoiceAge Age => VoiceAge.Child;
            internal override string Suffix => " tebayo!";
        }
    }
}
