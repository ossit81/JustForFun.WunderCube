namespace JustForFun.WunderCube.Core
{
    public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public static readonly Point Zero = new Point() { X = 0, Y = 0, Z = 0 };

        public static Point operator +(Point p1, Point p2)
        {
            return new Point() { X = p1.X + p2.X, Y = p1.Y + p2.Y, Z = p1.Z + p2.Z };
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return Equals(p1, p2);
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !Equals(p1, p2);
        }


        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"X:{X};Y:{Y};Z:{Z}";
        }
    }
}
