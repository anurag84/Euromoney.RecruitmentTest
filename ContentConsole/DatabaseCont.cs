using ContentConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class DatabaseCont : IDatabase
    {
        private List<string> _negativeWordRepo;

        public DatabaseCont()
        {
            _negativeWordRepo = new List<string>();
        }

        public DatabaseCont(List<string> values)
        {
            _negativeWordRepo = new List<string>();
            _negativeWordRepo.AddRange(values);
        }

        public List<string> AddNegativeWords(string NewWord)
        {
            if (NewWord != null && NewWord.Length > 0)
            {
                if (!_negativeWordRepo.Contains(NewWord))
                {
                    _negativeWordRepo.Add(NewWord);
                }
            }
            return _negativeWordRepo;
        }

        public List<string> GetNegativeWords()
        {
            //Database code to fetch negative words.
            _negativeWordRepo.Add("bad");
            _negativeWordRepo.Add("nasty");
            _negativeWordRepo.Add("horrible");

            return _negativeWordRepo;
        }
    }
}
