using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class CubeTest
    {
        public readonly string TestCubeString =
@"AJFE
APUW
OGMR
MNXK

DNSI
FODS
JEGI
WKPR

EQMF
RKID
DMIR
EOSD

RTSL
DKPI
SPOI
JQDT";





        [Fact]
        public void Parse3DArrayFromString_WunderCubeShouldContain4x4x4Elements()
        {
            var target = new Cube(TestCubeString);
            Assert.Equal(4*4*4, target.Blocks.Length);
        }


        [Fact]
        public void Blocks_CubeShouldContainAllColumnElements()
        {
            var testString = @"1234";

            var target = new Cube(testString);
            var results = target.Blocks;
            Assert.Equal('1', results[0, 0, 0]);
            Assert.Equal('2', results[0, 0, 1]);
            Assert.Equal('3', results[0, 0, 2]);
            Assert.Equal('4', results[0, 0, 3]);
        }


        [Fact]
        public void Blocks_CubeShouldContainAllRowElements()
        {
            var testString = @"
1
2
3
4";

            var target = new Cube(testString);
            var results = target.Blocks;
            Assert.Equal('1', results[0, 0, 0]);
            Assert.Equal('2', results[0, 1, 0]);
            Assert.Equal('3', results[0, 2, 0]);
            Assert.Equal('4', results[0, 3, 0]);
        }


        [Fact]
        public void Blocks_CubeShouldContainAllDepthElements()
        {
            var testString = @"
1

2

3

4";
            var target = new Cube(testString);
            var results = target.Blocks;
            Assert.Equal('1', results[0, 0, 0]);
            Assert.Equal('2', results[1, 0, 0]);
            Assert.Equal('3', results[2, 0, 0]);
            Assert.Equal('4', results[3, 0, 0]);
        }


        [Fact]
        public void Blocks_CubeStringWithDifferrentZizes()
        {
            var expectedDepth = 3;
            var expectedHeight = 2;
            var expectedWidt = 4;

            var testString = @"
1111
122

211111
2111111

31
32
33
";
            var target = new Cube(testString);
            var results = target.Blocks;

            Assert.Equal(expectedDepth, target.Depth);
            Assert.Equal(expectedHeight, target.Height);
            Assert.Equal(expectedWidt, target.Width);
            Assert.Equal(expectedDepth * expectedHeight * expectedWidt, results.Length);
        }


    }
}
