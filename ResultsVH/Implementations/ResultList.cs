using ResultsVH.Interfaces;

namespace ResultsVH.Implementations;

public class ResultList<T> : Result<IList<T>>, IResultList<T>
{
    public ResultList(IList<T> data) : base(data) { }

    public ResultList(string message) : base(message) { }
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