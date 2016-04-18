using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class NodeTest
    {
        [Fact]
        public void ToString_Test()
        {
            var target = new Node(null);
            target['A'] = new Node(target);
            target['A']['B'] = new Node(target['A']);
            target['A']['B']['C'] = new Node(target['A']['B']);

            Assert.Equal("ABC", target['A']['B']['C'].ToString());
        }


    }
}
