namespace FinancialAudit.Shared.Result;

public class ValidationErrors : Error
{
	private const string VALIDATION_ERROR_CODE = "ValidationError";
	private const string VALIDATION_ERROR_DESCRIPTION = "A validation problem occured";

	private ValidationErrors(IEnumerable<Error> errors) : base(VALIDATION_ERROR_CODE, VALIDATION_ERROR_DESCRIPTION)
	{
		Errors = errors.ToArray();
	}

	public IEnumerable<Error> Errors { get; }

	public static ValidationErrors FromErrors(IEnumerable<Error> errors)
		=> new(errors);
	public static ValidationErrors FromResults<TValue>(IEnumerable<Result<TValue>> results)
		=> FromErrors(results.Errors());
	public static ValidationErrors FromResults(IEnumerable<Result<object>> results)
		=> FromErrors(results.Errors());

	public static implicit operator ValidationErrors(Error[] errors)
		=> FromErrors(errors);
}