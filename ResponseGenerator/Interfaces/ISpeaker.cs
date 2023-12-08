using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseGenerator.Interfaces
{
    internal interface ISpeaker
    {
        void Start();
        void Stop();
        int NumResponses {  get; }
        TimeSpan ListeningDuration { get; }
    }
}
