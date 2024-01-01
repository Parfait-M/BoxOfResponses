using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedInterfaces
{
    public interface ISpeaker
    {
        void Start();

        void Stop();

        string[]    Responses { get; }
        string      Keywords { get; }
        TimeSpan    ListeningDuration { get; }
    }
}
