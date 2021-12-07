using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesByMatch
{
    public class Result : IResult
    {
        /*
         * Complete the 'sockMerchant' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY ar
         */

        public dynamic TaskToSolve()
        {
            var readData = ReadFromFile();
            var _parameters = new { n = (int)readData.n, ar = (List<int>)readData.ar };

            if (_parameters.ar.Count == _parameters.n)
            {
                var grouped = _parameters.ar.JoinBy(
                       x => x,
                       x => x,
                       (previous, current) => previous == current);

                var teste = grouped.Where(item => item.Count() > 1);

                int count = 0;
                grouped.Where(item => item.Count() > 1).ToList()
                    .ForEach(item => count += item.Count() / 2);

                return count;
            }
            else
                throw new Exception(String.Format("The number of socks in the pile and the array with colors of each sock must match. Passed n: {0} and size ar: {1}", _parameters.n, _parameters.ar.Count));
        }

        public dynamic ReadFromFile()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            return new { n, ar };
        }
    }
}
