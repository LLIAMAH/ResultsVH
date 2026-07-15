using ResultsVH.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ResultsVH.Implementations;

public class Result<T> : Result<T, string>, IResult<T>
{
    [JsonConstructor]
    protected Result(bool isSuccess, [MaybeNull] T data, string message)
        : base(isSuccess, data, message) { }

    public Result(T data) : this(true, data, null!) { }

    public Result(string message) : this(false, default(T)!, message) { }
}

public class ResultWithErrorsArray<T> : Result<T, string[]>, IResultWithErrorsArray<T>
{
    [JsonConstructor]
    protected ResultWithErrorsArray(bool isSuccess, [MaybeNull] T data, string[] message)
        : base(isSuccess, data, message) { }

    public ResultWithErrorsArray(T data) : this(true, data, null!) { }

    public ResultWithErrorsArray(string[] message) : this(false, default(T)!, message) { }
}