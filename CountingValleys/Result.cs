using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountingValleys
{
    public class Result : IResult
    {
        /*
      * Complete the 'countingValleys' function below.
      *
      * The function is expected to return an INTEGER.
      * The function accepts following parameters:
      *  1. INTEGER steps
      *  2. STRING path
      */

        public dynamic TaskToSolve()
        {
            var readData = ReadFromFile();
            var _parameters = new { steps = (int)readData.steps, path = (string)readData.path };

            int currentHeight = 0;
            int countValleys = 0;
            bool activateValley = false;

            if(_parameters.steps >= 2 && _parameters.steps <= Math.Pow(10,6))
            {
                foreach (var pathStep in _parameters.path)
                {
                    currentHeight += pathStep == 'U' ? 1 : -1;

                    if(currentHeight == -1 && !activateValley)
                        activateValley = true;

                    if(currentHeight == 0 && activateValley)
                    {
                        countValleys++;
                        activateValley = false;
                    }
                } 
            }

            return countValleys;
        }

        public dynamic ReadFromFile()
        {
            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            return new { steps, path };
        }
    }
}
