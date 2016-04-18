using System.Collections.Generic;

namespace JustForFun.WunderCube.Core
{

    public class WordFinder
    {
        private readonly Point _position;
        private readonly Cube _cube;
        private readonly WordTree _wordTree;

        public WordFinder(Point position, Cube cube, WordTree wordTree)
        {
            _position = position;
            _cube = cube;
            _wordTree = wordTree;
        }

        public HashSet<string> Find()
        {
            var results = new HashSet<string>();

            var c = _cube.GetChar(_position);
            if (_wordTree.ContainsKey(c))
            {
                Node currentNode = _wordTree[c];
                var pointTraveller = new PointTraveller(_cube, _position, currentNode);
                
                while (pointTraveller != null)
                {
                    currentNode = pointTraveller.CurrentNode;
                    Point nextPoint = pointTraveller.GetNextPoint();
                    while (nextPoint != null)
                    {
                        c = _cube.GetChar(nextPoint);
                        if (currentNode.ContainsKey(c))
                        {
                            currentNode = currentNode[c];
                            pointTraveller = pointTraveller.CreateChild(nextPoint, currentNode);
                            if (currentNode.IsEndOfWord)
                            {
                                results.Add(pointTraveller.GetWord());
                            }
                        }
                        
                        nextPoint = pointTraveller.GetNextPoint();
                    }

                    pointTraveller = pointTraveller.Parent;
                }

            }

            return results;
        }
        
    }
}
