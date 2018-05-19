using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public interface IDatabase
    {
        List<string> GetNegativeWords();
        List<string> AddNegativeWords(string NewWord);
    }
}
