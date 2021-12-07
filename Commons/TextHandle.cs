using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Commons
{
    public static class TextHandle
    {
        public static void WriteFile(IResult taskToSolve)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int result = taskToSolve.TaskToSolve();

            Console.WriteLine("The Result obtained was: {0}",result);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
