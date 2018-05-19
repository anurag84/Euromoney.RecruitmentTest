using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public interface IFunctionality
    {
        int CheckNegativeCount(string content);

        string FilterOutNegativeWords(string content, bool filterOutFlag);
    }
}
