using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpingOnTheClouds
{
    public class Result : IResult
    {
        public dynamic ReadFromFile()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

            return new { n, c };
        }

        public dynamic TaskToSolve()
        {
            var readData = ReadFromFile();
            var _parameters = new { n = (int)readData.n, c = (List<int>)readData.c };

            var allowedClouds = _parameters.c
                .Select((value, index) => new { value, index })
                .Where(item => item.value == 0)
                .Select(item => item.index);

            return shortestPath(0,0,allowedClouds);
        }

        private int shortestPath(int currentPosition,int pathSize, IEnumerable<int> allowedClouds)
        {
            if (currentPosition == allowedClouds.Count())
                return pathSize;

            var possiblePaths =  allowedClouds.NextTwo(currentPosition);

            if (possiblePaths.Item2 != default)
                return shortestPath(possiblePaths.Item2, pathSize +1,allowedClouds);
            else
                return shortestPath(possiblePaths.Item1, pathSize + 1, allowedClouds);
        }
    }
}
