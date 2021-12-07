using System.Collections.Generic;

namespace Commons
{
    public interface IResult
    {
        dynamic TaskToSolve();

        dynamic ReadFromFile();
    }
}