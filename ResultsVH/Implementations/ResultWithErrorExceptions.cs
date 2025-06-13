using ResultsVH.Interfaces;

namespace ResultsVH.Implementations;

public class ResultWithException<T> 
    : Result<T, Exception>, IResultWithException<T>
{
    public ResultWithException(T data) : base(data) { }

    public ResultWithException(Exception message) : base(message) { }
}

public class ResultWithExceptionsArray<T> 
    : Result<T, Exception[]>, IResultWithExceptionsArray<T>
{
    public ResultWithExceptionsArray(T data) : base(data) { }

    public ResultWithExceptionsArray(Exception[] message) : base(message) { }
}