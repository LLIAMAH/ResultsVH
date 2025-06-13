namespace ResultsVH.Interfaces;

public interface IResult<out T, out TE>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public TE? Message { get; }
}

public interface IResult<out T> : IResult<T, string>;
public interface IResultWithException<out T> : IResult<T, Exception>;
public interface IResultWithErrorsArray<out T> : IResult<T, string[]>;
public interface IResultWithExceptionsArray<out T> : IResult<T, Exception[]>;

public interface IResultBool: IResult<bool>;
public interface IResultBoolWithException : IResultWithException<bool>;
public interface IResultBoolWithErrorsArray : IResultWithErrorsArray<bool>;
public interface IResultBoolWithExceptionsArray : IResultWithExceptionsArray<bool>;

public interface IResultList<T> : IResult<IList<T>>;
public interface IResultListWithException<T> : IResultWithException<IList<T>>;
public interface IResultListWithErrorsArray<T> : IResultWithErrorsArray<IList<T>>;
public interface IResultListWithExceptionsArray<T> : IResultWithExceptionsArray<IList<T>>;