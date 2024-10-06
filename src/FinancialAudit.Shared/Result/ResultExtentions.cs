namespace FinancialAudit.Shared.Result;
public static class ResultExtentions
{
	public static IEnumerable<Error> Errors<TValue>(this IEnumerable<Result<TValue>> results)
		=> results.Where(r => r.IsFailure).Select(r => r.Error);

	public static (bool isSuccess, ValidationErrors errors) ToValidation<TValue, TError>(this IEnumerable<Result<TValue>> results)
	{
		var errors = results.Errors().ToArray();
		return (errors.Length == 0, errors);
	}

	public static IEnumerable<Error> Errors(this IEnumerable<Result<object>> results)
		=> results.Where(r => r.IsFailure).Select(r => r.Error);

	public static (bool isSuccess, ValidationErrors errors) ToValidation(this IEnumerable<Result<object>> results)
	{
		var errors = results.Errors().ToArray();
		return (errors.Length == 0, errors);
	}



}
