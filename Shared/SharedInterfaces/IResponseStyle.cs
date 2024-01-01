using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedInterfaces
{
    public interface IResponseStyle
    {
        string Prefix { get; }
        string Suffix { get; }
        dynamic Gender { get; }
        dynamic Age { get; }
    }
}
