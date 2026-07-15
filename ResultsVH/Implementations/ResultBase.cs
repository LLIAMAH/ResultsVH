using ResultsVH.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ResultsVH.Implementations;

public class Result<T, TE> : IResult<T, TE>
{
    public bool IsSuccess { get; }
    [MaybeNull]
    public T? Data { get; }
    public TE? Message { get; }

    [JsonConstructor]
    protected Result(bool isSuccess, [MaybeNull] T? data, TE? message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public Result(T data) : this(true, data, default(TE)) { }

    public Result(TE message) : this(false, default(T), message) { }
}