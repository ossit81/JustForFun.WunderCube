using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class WordTreeTest
    {
        [Fact]
        public void Node_IsLeap_IsTrueIfItsLastNodeOfTree()
        {
            var target = new WordTree(new [] { @"AA", "AAA", "ABC", "BAC" });

            Assert.True(target['A']['B']['C'].IsLeap);
        }

        [Fact]
        public void Node_IsLeap_IsFalseIfItsNotLastNodeOfTree()
        {
            var target = new WordTree(new[] { @"AA", "AAA", "ABC", "BAC" });

            Assert.False(target['A']['B'].IsLeap);
        }

        [Fact]
        public void WordTree_IsEndOfWordBoolean_HasSetForWordLastCharacterNode()
        {
            var target = new WordTree(new[] { @"AA", "AAA", "ABC", "BAC" });

            Assert.True(target['A']['A'].IsEndOfWord);

            Assert.False(target['A'].IsEndOfWord);
        }


        [Fact]
        public void ContainsKey_ReturnsTrueIfContainsKey()
        {
            var target = new WordTree(new[] { @"test"});
            
            Assert.True(target.ContainsKey('t'));
        }


        [Fact]
        public void ContainsKey_ReturnsFalseIfNotContainsKey()
        {
            var target = new WordTree(new[] { @"test" });

            Assert.False(target.ContainsKey('a'));
        }


    }
}
