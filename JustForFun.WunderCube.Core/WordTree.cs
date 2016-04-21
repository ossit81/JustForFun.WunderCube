using System.Collections.Generic;

namespace JustForFun.WunderCube.Core
{
    public class Node
    {
        public Dictionary<char, Node> Child { get; } = new Dictionary<char, Node>();

        public Node this[char key]
        {
            get
            {
                return Child[key];
            }
            set
            {
                Child[key] = value;
            }
        }

        public bool IsLeap => Child.Count == 0;
        public bool IsEndOfWord { get; set; }

        public bool ContainsKey(char key)
        {
            return Child.ContainsKey(key);
        }
    }

    public class WordTree : Node
    {
        public static readonly WordTree Empty = new WordTree(new string[] {});

        public WordTree(string[] words)
        {
            foreach (var word in words)
            {
                var characters = word.ToCharArray();
                Node currentNode = this;
                var wordLength = characters.Length;
                for (int index = 0; index < wordLength; index++)
                {
                    var c = characters[index];
                    if (!currentNode.ContainsKey(c))
                    {
                        currentNode[c] = new Node();
                    }
                    currentNode = currentNode[c];
                    currentNode.IsEndOfWord |= index+1 == wordLength;
                }
            }
        }
    }
}
