using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class Functionality : IFunctionality
    {
        private readonly IDatabase _databaseContext;

        public Functionality(IDatabase dbContext)
        {
            _databaseContext = dbContext;
        }

        public int CheckNegativeCount(string content)
        {
            int negativeWordCount = 0;

            if (content != null)
            {
                List<string> negativeWords = _databaseContext.GetNegativeWords();

                var regex = new Regex(@"\b[\s,\.-:;]*");
                var words = regex.Split(content).Where(x => !string.IsNullOrEmpty(x));
                negativeWords.ForEach(str => str.ToLower());

                foreach (var word in words)
                {
                    var count = from c in negativeWords
                                where negativeWords.Any(word.ToLower().Contains)
                                select c;

                    if (count.Count() > 0)
                    {
                        negativeWordCount++;
                    }
                }
            }
            return negativeWordCount;
        }

        public string FilterOutNegativeWords(string content, bool filterOutFlag)
        {
            if (content != null && content.Length > 0)
            {
                if (filterOutFlag)
                {
                    List<string> negativeWords = _databaseContext.GetNegativeWords();
                    var regex = new Regex(@"\b[\s,\-:;]*");
                    var words = regex.Split(content).Where(x => !string.IsNullOrEmpty(x));
                    string returnContent = "";

                    negativeWords.ForEach(str => str.ToLower());

                    foreach (var word in words)
                    {
                        if (word.Length > 2)
                        {
                            if (negativeWords.Contains(word.ToLower()))
                            {
                                var filteredString = new String('*', word.Length - 2);

                                returnContent = returnContent + word.Substring(0, 1) + filteredString + word.Substring(word.Length - 1) + " ";
                            }
                            else
                            {
                                returnContent = returnContent + word + " ";
                            }
                        }
                        else
                        {
                            if (word == ".")
                            {
                                returnContent = returnContent.Substring(0, returnContent.Length - 1) + word;
                            }
                            else
                            {
                                returnContent = returnContent + word + " ";
                            }
                        }
                    }
                    return returnContent;
                }
                else
                {
                    return content;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
