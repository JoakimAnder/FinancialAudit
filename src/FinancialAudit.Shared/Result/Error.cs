namespace FinancialAudit.Shared.Result;

public class Error(string code, string? description = default)
{
	private const string UNKNOWN_CODE = "UNKNOWN";

	public string Code { get; } = code;
	public string? Description { get; } = description;

	public static readonly Error None = new(string.Empty);
	public static readonly Error Unknown = new(UNKNOWN_CODE);
}
