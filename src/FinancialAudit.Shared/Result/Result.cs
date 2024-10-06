namespace FinancialAudit.Shared.Result;

public readonly struct Result<TValue>
{
	private readonly TValue? _value;
	private readonly Error? _error;

	public Result()
	{
		IsFailure = true;
		_error = Error.Unknown;
	}
	private Result(TValue value)
	{
		IsFailure = false;
		_value = value;
	}
	private Result(Error error)
	{
		IsFailure = true;
		_error = error;
	}

	public bool IsFailure { get; }
	public bool IsSuccess => !IsFailure;
	public TValue Value => _value!;
	public Error Error => _error!;

	public static Result<TValue> Success(TValue value)
		=> new(value);
	public static Result<TValue> Failure(Error error)
		=> new(error);

	public static implicit operator Result<TValue>(TValue value)
		=> Success(value);
	public static implicit operator Result<TValue>(Error error)
		=> Failure(error);


	public TResult Match<TResult>(Func<TValue, TResult> success, Func<Error, TResult> failure)
		=> IsSuccess ? success(Value) : failure(Error);
	public bool TryGetValue(out TValue value)
	{
		value = Value;
		return IsSuccess;
	}

}
