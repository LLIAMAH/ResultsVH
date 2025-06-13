# ResultsVH 

The library which provides the set of results

It splits structures to options: 
- Interfaces
- Implementations

## The base of the Results

The base of the Results are: 
- An interface IResult<T, TE>
- And Implementation: Result<T, TE>

### The Interface `IResult<out T, out TE>`

The code of the interface is
```
public interface IResult<out T, out TE>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public TE? Message { get; }
}
```
and contains from:
- Main result: the boolean `IsSuccess` which returns `true` or `false` depending on this **either** `Data` or `Message` will have values.
- If implementation is used with constructor, which provides `data` (ses implementation constructors description) - the `Data` takes value, the `Message` is set to `default` and `IsSuccess` defined as `true`.
- If implementation is used with constructor, which provides `message` (ses implementation constructors description) - the `Message` takes value, the `Data` is set to `default` and `IsSuccess` defined as `false`. 

### The Implementation `Result<T, TE>`

The implementation `Result<T, TE>` contains 2 constructors (each child class recalls the `base(X)`):
```
/// Successful
public Result(T data)
{
    this.IsSuccess = true;
    this.Data = data;
    this.Message = default;
}
```
```
/// Failed
public Result(TE message)
{
    this.IsSuccess = false;
    this.Message = message;
    this.Data = default;
}
```

## The full list of interfaces (with according implementations)

The Base
- `IResult<out T, out TE>`

The list of the interfaces which are replacing the `TE`
- `IResult<out T>`: `TE` defined as `string`
- `IResultWithException<out T>`: `TE` defined as `Exception`
- `IResultWithErrorsArray<out T>`: `TE` defined as array of `string`
- `IResultWithExceptionsArray<out T>`: `TE` defined as array of `Exception`

The list of the interfaces which are replacing the `T`
- `IResultBool: IResult<bool>`
- `IResultBoolWithException : IResultWithException<bool>`
- `IResultBoolWithErrorsArray : IResultWithErrorsArray<bool>`
- `IResultBoolWithExceptionsArray : IResultWithExceptionsArray<bool>`
- `IResultList<T> : IResult<IList<T>>`
- `IResultListWithException<T> : IResultWithException<IList<T>>`
- `IResultListWithErrorsArray<T> : IResultWithErrorsArray<IList<T>>`
- `IResultListWithExceptionsArray<T> : IResultWithExceptionsArray<IList<T>>`

Please be free to implement any other interface base on provided ones which will be useful for you.