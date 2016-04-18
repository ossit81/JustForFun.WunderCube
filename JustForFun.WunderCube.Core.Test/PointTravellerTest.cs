using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JustForFun.WunderCube.Core.Test
{
    public class PointTravellerTest
    {
        [Fact]
        public void NextPoint_TravelsAllNearestPoints()
        {
            var expectedCount = 3*3*3 - 1;
            var cube = new Cube(@"
XXX
XXX
XXX

XXX
X_X
XXX

XXX
XXX
XXX");


            var target = new PointTraveller(cube, new Point {X = 1, Y = 1, Z = 1}, WordTree.Empty);

            List<Point> points = new List<Point>();

            Point nextPoint = target.GetNextPoint();
            while (nextPoint != null)
            {
                points.Add(nextPoint);
                nextPoint = target.GetNextPoint();
            }
            
            Assert.Equal(expectedCount, points.Count);
        }


        [Fact]
        public void NextPoint_IfStartPointIsZeroAllNextPointComponentsShouldBeBetweenZeroAndOne()
        {
            var cube = new Cube(@"
XXX
XXX
XXX");
            
            var target = new PointTraveller(cube, Point.Zero, WordTree.Empty);

            Point nextPoint = target.GetNextPoint();
            while (nextPoint != null)
            {
                Assert.InRange(nextPoint.X, 0, 1);
                Assert.InRange(nextPoint.Y, 0, 1);
                Assert.InRange(nextPoint.Z, 0, 1);

                nextPoint = target.GetNextPoint();
            } 
            
        }


        [Fact]
        public void NextPoint_IsNeverStartPoint()
        {
            var cube = new Cube(@"
___
___
___

___
___
___

___
___
___");

            var startPoint = new Point() { X = 1, Y = 1, Z = 1 };
            PointTraveller target = new PointTraveller(cube, startPoint, WordTree.Empty);

            Point nextPoint = target.GetNextPoint();
            while (nextPoint != null)
            {
                Assert.NotEqual(startPoint, nextPoint);
                
                nextPoint = target.GetNextPoint();
            } 
            
        }


        [Fact]
        public void NextPoint_EmptyCubeReturnsNullNextPoint()
        {
            var target = new PointTraveller(new Cube(string.Empty), Point.Zero, new WordTree(new string[] {}));

            Point nextPoint = target.GetNextPoint();
            Assert.Null(nextPoint);
        }


        [Fact]
        public void NextPoint_ShouldDrawCircleToCube()
        {
            var expectedCube = new Cube(@"
XXX
XXX
XXX

XXX
X_X
XXX

XXX
XXX
XXX
");
            
            var cube = new Cube(@"
___
___
___

___
___
___

___
___
___");

            var startPoint = new Point() { X = 1, Y = 1, Z = 1 };
            PointTraveller target = new PointTraveller(cube, startPoint, WordTree.Empty);

            Point nextPoint = target.GetNextPoint();
            while (nextPoint != null)
            {
                cube.SetChar(nextPoint, 'X');
                nextPoint = target.GetNextPoint();
            }

            for (int z = 0; z < cube.Depth; z++)
            {
                for (int y = 0; y < cube.Height; y++)
                {
                    for (int x = 0; x < cube.Width; x++)
                    {
                        Assert.Equal(expectedCube.Blocks[z, y, x], cube.Blocks[z, y, x]);
                    }
                }
            }

        }

    }
}
