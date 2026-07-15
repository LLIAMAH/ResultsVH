using ResultsVH.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ResultsVH.Implementations;

public class ResultBool : Result<bool>, IResultBool
{

    [JsonConstructor]
    protected ResultBool(bool isSuccess, [MaybeNull] bool data, string message) 
        : base(isSuccess, data, message) { }

    public ResultBool(bool data) : this(true, data, null!) { }

    public ResultBool(string message) : this(false, false, message) { }
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
    [JsonConstructor]
    protected ResultBoolWithErrorsArray(bool isSuccess, [MaybeNull] bool data, string[] message)
        : base(isSuccess, data, message) { }

    public ResultBoolWithErrorsArray(bool data) : this(true, data, null!) { }

    public ResultBoolWithErrorsArray(string[] message) : this(false, false, message) { }
}

public class ResultBoolWithExceptionsArray 
    : ResultWithExceptionsArray<bool>, IResultBoolWithExceptionsArray
{
    public ResultBoolWithExceptionsArray(bool data) : base(data) { }

    public ResultBoolWithExceptionsArray(Exception[] message) : base(message) { }
}