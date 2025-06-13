using ResultsVH.Interfaces;

namespace ResultsVH.Implementations;

public class Result<T, TE> : IResult<T, TE>
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public TE? Message { get; }

    public Result(T data)
    {
        this.IsSuccess = true;
        this.Data = data;
        this.Message = default;
    }

    public Result(TE message)
    {
        this.IsSuccess = false;
        this.Message = message;
        this.Data = default;
    }
}