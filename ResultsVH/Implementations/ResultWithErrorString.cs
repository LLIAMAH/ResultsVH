using ResultsVH.Interfaces;

namespace ResultsVH.Implementations;

public class Result<T> : Result<T, string>, IResult<T>
{
    public Result(T data) : base(data) { }

    public Result(string message) : base(message) { }
}

public class ResultWithErrorsArray<T> : Result<T, string[]>, IResultWithErrorsArray<T>
{
    public ResultWithErrorsArray(T data) : base(data) { }

    public ResultWithErrorsArray(string[] message) : base(message) { }
}