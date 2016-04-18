using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class PointTest
    {
        [Fact]
        public void OperatorPlus_AddsPointComponentsTogether()
        {
            var point1 = new Point() { X = 100, Y = 200, Z = 300 };
            var point2 = new Point() { X = 1, Y = 2, Z = 3 };

            var result = point1 + point2;

            Assert.Equal(point1.X + point2.X, result.X);
            Assert.Equal(point1.Y + point2.Y, result.Y);
            Assert.Equal(point1.Z + point2.Z, result.Z);
        }

        [Fact]
        public void OperatorEqual_AllComponentsMatchTogether()
        {
            var point1 = new Point() { X = 100, Y = 200, Z = 300 };
            var point2 = new Point() { X = 100, Y = 200, Z = 300 };
            
            Assert.Equal(point1, point2);
        }
        [Fact]
        public void OperatorNotEqual_AllComponentsNotMatchTogether()
        {
            var target = new Point() { X = 100, Y = 200, Z = 300 };

            Assert.NotEqual(target, new Point() { X = 100, Y = 200, Z = 0 });
            Assert.NotEqual(target, new Point() { X = 100, Y = 0, Z = 300 });
            Assert.NotEqual(target, new Point() { X = 0, Y = 200, Z = 300 });
            Assert.NotEqual(target, null);
        }

        [Fact]
        public void OperatorNotEqual_Wtf()
        {
            var target = new Point() { X = 100, Y = 200, Z = 300 };

            Assert.True(target != null);
        }


        [Fact]
        public void OperatorNotEqual_Wtf2()
        {
            Point target = null;

            Assert.True(target == null);
        }
    }
}
