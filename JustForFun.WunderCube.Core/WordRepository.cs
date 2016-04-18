using System.IO;

namespace JustForFun.WunderCube.Core
{
    public class WordRepository
    {
        public WordTree GetWordTree(string wordTextPath)
        {
            var words = File.ReadAllLines(wordTextPath);
            var result = new WordTree(words);

            return result;
        }
    }
}
