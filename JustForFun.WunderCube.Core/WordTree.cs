namespace JustForFun.WunderCube.Core
{
    public class WordTree : Node
    {
        public static readonly WordTree Empty = new WordTree(new string[] {});

        public WordTree(string[] words) : base(null)
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
                        currentNode[c] = new Node(currentNode);
                    }
                    currentNode = currentNode[c];
                    currentNode.IsEndOfWord |= index+1 == wordLength;
                }
            }
        }
    }
}
