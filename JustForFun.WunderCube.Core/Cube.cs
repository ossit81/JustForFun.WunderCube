using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JustForFun.WunderCube.Core
{
    public class Cube
    {
        private char[,,] _blocks;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }

        public char[,,] Blocks
        {
            get
            {
                return _blocks ?? (_blocks = new char[,,] {});
            }
        }

        public Cube(string cubeString)
        {
            _blocks = Parse3DArrayFromString(cubeString);
        }
        
        private char[,,] Parse3DArrayFromString(string cubeString)
        {
            cubeString = cubeString.Trim();

            string newLine = cubeString.Contains("\r\n") ? "\r\n" : "\n";

            string[] blocks = Regex.Split(cubeString, $@"{newLine}\s*{newLine}", RegexOptions.Singleline);

            var firstBlockRows = blocks.First().Split(new[] { newLine }, StringSplitOptions.None);

            this.Width = firstBlockRows.First().Length;
            this.Height = firstBlockRows.Length;
            this.Depth = blocks.Length;

            var result = new char[Depth, Height, Width];

            for (int z = 0; z < Depth; z++)
            {
                var block = blocks[z];
                var rows = block.Split(new[] { newLine }, StringSplitOptions.None);
                for (int y = 0; y < Height; y++)
                {
                    var row = y < rows.Length ? rows[y] : "";
                    var rowCharArray = row.ToCharArray();
                    for (int x = 0; x < Width; x++)
                    {
                        char c = x < rowCharArray.Length ? rowCharArray[x] : ' ';
                        result[z, y, x] = c;
                    }
                }
            }

            return result;
        }

        public char GetChar(Point position)
        {
            return _blocks[position.Z, position.Y, position.X];
        }

        public string GetWord(IEnumerable<Point> points)
        {
            var result = new StringBuilder();
            foreach (var point in points)
            {
                result.Append(GetChar(point));
            }
            return result.ToString();
        }

        public char SetChar(Point position, char value)
        {
            return _blocks[position.Z, position.Y, position.X] = value;
        }

        public bool IsInside(Point point)
        {
            return point.X >= 0 && point.X < Width
                   && point.Y >= 0 && point.Y < Height
                   && point.Z >= 0 && point.Z < Depth;

        }

    }
}
