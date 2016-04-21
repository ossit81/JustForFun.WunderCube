using System.Collections.Generic;

namespace JustForFun.WunderCube.Core
{
    public class PointTraveller
    {
        private readonly Point _startPoint;

        private static readonly Point[] PointsToTravel =
        {
            new Point { X = 1, Y = 1, Z = 1 },
            new Point { X = 0, Y = 1, Z = 1 },
            new Point { X = -1, Y = 1, Z = 1 },
            new Point { X = 1, Y = 0, Z = 1 },
            new Point { X = 0, Y = 0, Z = 1 },
            new Point { X = -1, Y = 0, Z = 1 },
            new Point { X = 1, Y = -1, Z = 1 },
            new Point { X = 0, Y = -1, Z = 1 },
            new Point { X = -1, Y = -1, Z = 1 },

            new Point { X = 1, Y = 1, Z = 0 },
            new Point { X = 0, Y = 1, Z = 0 },
            new Point { X = -1, Y = 1, Z = 0 },
            new Point { X = 1, Y = 0, Z = 0 },
            //new Point { X = 0, Y = 0, Z = 0 },
            new Point { X = -1, Y = 0, Z = 0 },
            new Point { X = 1, Y = -1, Z = 0 },
            new Point { X = 0, Y = -1, Z = 0 },
            new Point { X = -1, Y = -1, Z = 0 },

            new Point { X = 1, Y = 1, Z = -1 },
            new Point { X = 0, Y = 1, Z = -1 },
            new Point { X = -1, Y = 1, Z = -1 },
            new Point { X = 1, Y = 0, Z = -1 },
            new Point { X = 0, Y = 0, Z = -1 },
            new Point { X = -1, Y = 0, Z = -1 },
            new Point { X = 1, Y = -1, Z = -1 },
            new Point { X = 0, Y = -1, Z = -1 },
            new Point { X = -1, Y = -1, Z = -1 },
        };

        private int _pointer = 0;
        private readonly PointTraveller _parent = null;
        private readonly Cube _cube;


        public Point StartPoint => _startPoint;

        public Node CurrentNode { get; }

        public PointTraveller Parent => _parent;

        public PointTraveller(Cube cube, Point startPoint, Node currentNode) : this(null, cube, startPoint, currentNode)
        {
        }

        protected PointTraveller(PointTraveller parent, Cube cube, Point startPoint, Node currentNode)
        {
            this._parent = parent;
            this._cube = cube;
            this.CurrentNode = currentNode;
            this._startPoint = startPoint;
        }


        public PointTraveller CreateChild(Point startPoint, Node currentNode)
        {
            return new PointTraveller(this, _cube, startPoint, currentNode);
        }

        private bool IsUsedPoint(Point point)
        {
            var current = this;
            while (current != null)
            {
                if (current.StartPoint == point)
                    return true;
                current = current._parent;
            }

            return false;
        }
        

        public Point GetNextPoint()
        {
            var nextPoint = _startPoint;
            while (nextPoint != null)
            {
                nextPoint = _pointer < PointsToTravel.Length ? PointsToTravel[_pointer++] : null;
                if (nextPoint != null) {
                    nextPoint = _startPoint + nextPoint;
                    if (_cube.IsInside(nextPoint) && !IsUsedPoint(nextPoint))
                    {
                        return nextPoint;
                    }
                }
            }
            
            return null;
        }

        public string GetWord()
        {
            return _cube.GetWord(TravelledRoute);
        }

        public IEnumerable<Point> TravelledRoute
        {
            get
            {
                List<Point> positions = new List<Point>();
                var currentTraveller = this;
                while (currentTraveller != null)
                {
                    positions.Add(currentTraveller.StartPoint);
                    currentTraveller = currentTraveller._parent;
                }
                positions.Reverse();
                return positions;
            }
        }

        public override string ToString()
        {
            return $"StartPoint:{StartPoint}; CurrentNode:{CurrentNode};";
        }
    }
}
