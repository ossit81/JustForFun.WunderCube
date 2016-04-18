using System.Linq;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class CubeSolverTest
    {

        [Fact]
        public void Solve_DontReturnNull()
        {
            var target = new CubeSolver(new Cube(""), WordTree.Empty);
            var results = target.Solve();

            Assert.NotNull(results);
        }


        [Fact]
        public void Solve_CanFindTheWordFromFromManyPossibleBranches()
        {
            var expectedWord = "TEST";

            var wordTree = new WordTree(new []{ expectedWord });

            var target = new CubeSolver(new Cube(@"
___T
ESS_
SES_
ETES
"), wordTree);
            var results = target.Solve();

            Assert.Contains(expectedWord, results);
        }


        [Fact]
        public void Solve_ResultsDontContainDublicates()
        {
            var expectedWord = "TEST";

            var wordTree = new WordTree(new[] { expectedWord });

            var target = new CubeSolver(new Cube(@"
TEST
____
____
TEST
"), wordTree);
            var results = target.Solve();

            Assert.Equal(1, results.Count());
            Assert.Contains(expectedWord, results);
        }

    }
}
