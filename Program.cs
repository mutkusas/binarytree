using System;

namespace DanskeMedis
{
    class Program
    {
        static int greatestScore = 0;
        static String pathOfGreatestScore;

        static void Main(String[] args)
        {
            const String FILE_NAME = "input.txt";
            
            string[] lines = System.IO.File.ReadAllLines(FILE_NAME);
            int treeLevel = lines.Length - 1;
            System.Console.WriteLine("Contents of {0}", FILE_NAME);

            foreach(String row in lines)
            {
                Console.WriteLine(row);
            }

            int[,] arrayOfValues = new int[treeLevel+1, treeLevel+1];

            
            for (int i = 0; i < treeLevel+1; i++)
            {
                String[] tempArray = lines[i].Split(" ");
                for (int j = 0; j < tempArray.Length; j++)
                {
                    arrayOfValues[i, j] = Int32.Parse(tempArray[j]);
                }
            }
            
            WalkAround(arrayOfValues, treeLevel, 0, 0, 0, "");
            Console.WriteLine("*****************************");
            Console.WriteLine("Greatest score of this map is: {0}", greatestScore);
            Console.WriteLine("Path to reach this score is: {0}", pathOfGreatestScore);
            Console.WriteLine("*****************************");

            Console.ReadLine();
        }

        public static void WalkAround(int[,] values, int length, int currentY, int currentX, int sum, String path)
        {
            path += " -> " + values[currentY, currentX];
            sum += values[currentY, currentX];
            if (currentY < length)
            {
                if (IsWalkable(values[currentY, currentX], values[currentY + 1, currentX]))
                {
                    WalkAround(values, length, currentY + 1, currentX, sum, path);
                }
                if (IsWalkable(values[currentY, currentX], values[currentY + 1, currentX + 1]))
                {
                    WalkAround(values, length, currentY + 1, currentX + 1, sum, path);
                }
            } else
            {
                Console.WriteLine("Path: {0} Score: {1}", path, sum);
                if (sum > greatestScore)
                {
                    greatestScore = sum;
                    pathOfGreatestScore = path;
                    return;
                }
            }            
        }

        public static Boolean IsWalkable(int current, int next)
        {
            if (current%2 == 0)
            {
                return next % 2 == 1 ? true: false;
            } else
            {
                return next % 2 == 0 ? true: false;
            }
        }
    }
}
