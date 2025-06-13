using ResultsVH.Interfaces;

namespace ResultsVH.Implementations;

public class ResultBool : Result<bool>, IResultBool
{
    public ResultBool(bool data) : base(data) { }

    public ResultBool(string message) : base(message) { }
}

public class ResultBoolWithException 
    : ResultWithException<bool>, IResultBoolWithException
{
    public ResultBoolWithException(bool data) : base(data) { }

    public ResultBoolWithException(Exception message) : base(message) { }
}

public class ResultBoolWithErrorsArray
    : ResultWithErrorsArray<bool>, IResultBoolWithErrorsArray
{
    public ResultBoolWithErrorsArray(bool data) : base(data) { }

    public ResultBoolWithErrorsArray(string[] message) : base(message) { }
}

public class ResultBoolWithExceptionsArray 
    : ResultWithExceptionsArray<bool>, IResultBoolWithExceptionsArray
{
    public ResultBoolWithExceptionsArray(bool data) : base(data) { }

    public ResultBoolWithExceptionsArray(Exception[] message) : base(message) { }
}