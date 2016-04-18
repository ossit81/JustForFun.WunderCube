using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustForFun.WunderCube.Core
{
    public class CubeSolver
    {
        private readonly Cube _cube;
        private readonly WordTree _wordTree;

        public CubeSolver(Cube cube, WordTree wordTree)
        {
            this._cube = cube;
            this._wordTree = wordTree;
        }

        public IEnumerable<string> Solve()
        {
            var results = new HashSet<string>();
            
            var tasks = new List<Task<HashSet<string>>>();

            for (int z = 0; z < _cube.Depth; z++)
            {
                for (int y = 0; y < _cube.Height; y++)
                {
                    for (int x = 0; x < _cube.Width; x++)
                    {
                        tasks.Add(GetWordResultsAsync(new WordFinder(new Point { X = x, Y = y, Z = z }, _cube, _wordTree)));
                    }
                }
            }
            
            Task.WaitAll(tasks.ToArray());

            foreach (var task in tasks)
            {
                results.UnionWith(task.Result);
            }

            return results.OrderBy(w => w);
        }


        private static Task<HashSet<string>> GetWordResultsAsync(WordFinder wordFinder)
        {
            return Task.Run( () => { return wordFinder.Find(); } );
        }

    }

}
