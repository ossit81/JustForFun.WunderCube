using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class WordFinderTest
    {
        [Fact]
        public void Find_WillFindWordFromManyLayers()
        {

            var wordTree = new WordTree(new[] { "TEST" });
            var cube = new Cube(@"
T___
____
____
____

____
_E__
____
____

____
____
__S_
____

____
____
____
___T
");

            var target = new WordFinder(Point.Zero, cube, wordTree);

            var results = target.Find();

            Assert.Contains("TEST", results);
        }

        [Fact]
        public void Find_DontReturnAnyResultsIfDontFindFullWord()
        {

            var wordTree = new WordTree( new[] { "TEST" } );
            var cube = new Cube(@"
T___
_E__
__S_
T___
");

            var target = new WordFinder(Point.Zero, cube, wordTree);

            var results = target.Find();

            Assert.Equal(0, results.Count);

        }

        [Fact]
        public void Find_CantUseAlreadyUsedCharacters()
        {

            var wordTree = new WordTree(new[] { "TEST" });
            var cube = new Cube(@"
TE__
_S__
____
____
");

            var target = new WordFinder(Point.Zero, cube, wordTree);

            var results = target.Find();

            Assert.Equal(0, results.Count);

        }


        [Fact]
        public void Find_CanReturnMultipleWordsFromOneStartPoint()
        {

            var wordTree = new WordTree(new[] { "TIKKU", "TAKKU" });
            var cube = new Cube(@"
TA__
_IKK
___U
____
");

            var target = new WordFinder(Point.Zero, cube, wordTree);

            var results = target.Find();

            Assert.Equal(2, results.Count());

            Assert.Contains("TIKKU", results);
            Assert.Contains("TAKKU", results);

        }


        [Fact]
        public void Find_CanReturnMultipleWordsFromBranches()
        {

            var wordTree = new WordTree(new[] { "TIKKU", "TIKKA" });
            var cube = new Cube(@"
T__A
_IKK
___U
____
");

            var target = new WordFinder(Point.Zero, cube, wordTree);

            var results = target.Find();

            Assert.Equal(2, results.Count());

            Assert.Contains("TIKKU", results);
            Assert.Contains("TIKKA", results);

        }
    }
}
