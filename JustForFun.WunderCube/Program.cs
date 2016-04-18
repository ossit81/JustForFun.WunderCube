using System;
using System.IO;
using System.Linq;
using JustForFun.WunderCube.Core;

namespace JustForFun.WunderCube
{
    class Program
    {
        private static string CubeFile = "cube.txt";
        private static string WordsFile = "words.txt";

        private static string ResultFile = "results.txt";

        static readonly CubeRepository CubeRepository = new CubeRepository();
        static readonly WordRepository WordRepository = new WordRepository();

        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            var cube = CubeRepository.GetCube(CubeFile);
            Console.Out.WriteLine("Cube creation time: " + (DateTime.Now - startTime));
            
            startTime = DateTime.Now;
            var wordTree = WordRepository.GetWordTree(WordsFile);
            Console.Out.WriteLine("WordTree creation time: " + (DateTime.Now - startTime));

            startTime = DateTime.Now;
            var cubeSolver = new CubeSolver(cube, wordTree);
            var words = cubeSolver.Solve();
            Console.Out.WriteLine("Cube solving time: " + (DateTime.Now - startTime));
            Console.Out.WriteLine("Word count: " + words.Count());
            
            Console.Out.WriteLine("Writing words to output file '{0}'...", ResultFile);
            if (File.Exists(ResultFile))
            {
                File.Delete(ResultFile);
            }

            File.WriteAllText(ResultFile, "Cube contains following words:");
            File.WriteAllLines(ResultFile, words);

            Console.Out.WriteLine("Output file successfully created.");
            
            Console.Out.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
