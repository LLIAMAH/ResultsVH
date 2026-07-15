using ResultsVH.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ResultsVH.Implementations;

public class ResultList<T> : Result<IList<T>>, IResultList<T>
{

    [JsonConstructor]
    protected ResultList(bool isSuccess, [MaybeNull] IList<T> data, string message)
        : base(isSuccess, data, message) { }

    public ResultList(IList<T> data) : this(true, data, null!) { }

    public ResultList(string message) : this(false, null!, message) { }
}

public class ResultListWithException<T> 
    : ResultWithException<IList<T>>, IResultListWithException<T>
{
    public ResultListWithException(IList<T> data) : base(data) { }

    public ResultListWithException(Exception message) : base(message) { }
}

public class ResultListWithErrorsArray<T> 
    : ResultWithErrorsArray<IList<T>>, IResultListWithErrorsArray<T>
{
    public ResultListWithErrorsArray(IList<T> data) : base(data) { }

    public ResultListWithErrorsArray(string[] message) : base(message) { }
}

public class ResultListWithExceptionsArray<T>
    : ResultWithExceptionsArray<IList<T>>, IResultListWithExceptionsArray<T>
{
    public ResultListWithExceptionsArray(IList<T> data) : base(data) { }

    public ResultListWithExceptionsArray(Exception[] message) : base(message) { }
}