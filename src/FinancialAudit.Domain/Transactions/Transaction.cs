using FinancialAudit.Shared.Result;

namespace FinancialAudit.Domain.Transactions;

public class Transaction
{
	private Transaction(Id id, Name name, Description description, Date date, Amount amount)
	{
		Id = id;
		Name = name;
		Description = description;
		Date = date;
		Amount = amount;
	}

	public Id Id { get; }
	public Name Name { get; }
	public Description Description { get; }
	public Date Date { get; }
	public Amount Amount { get; }

	public static Result<Transaction> Create(Id id, Name name, Description description, Date date, Amount amount)
	{
		return new Transaction(id, name, description, date, amount);
	}
}

public class Id
{
	private Id(string value)
	{
		Value = value;
	}

	public string Value { get; }

	public static Result<Id> Create(string? guid = default)
	{
		guid = guid == default ? Guid.NewGuid().ToString("N") : guid;
		return new Id(guid);
	}
}

public class Name
{
	private static readonly Error EmptyNameError = new("Transaction.Name.Empty", "The name of a transaction can't be empty");

	private Name(string value)
	{
		Value = value;
	}

	public string Value { get; }

	public static Result<Name> Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			return EmptyNameError;

		name = name.Trim();
		return new Name(name);
	}
}

public class Description
{
	private Description(string value)
	{
		Value = value;
	}

	public string Value { get; }

	public static Result<Description> Create(string? name)
	{
		name = name?.Trim() ?? string.Empty;
		return new Description(name);
	}
}

public class Date
{
	private Date(DateOnly value)
	{
		Value = value;
	}

	public DateOnly Value { get; }

	public static Result<Date> Create(DateOnly date)
	{
		if (date == default)
			return new Error("Transaction.Date.Empty", "The date of the transaction has not been provided");

		return new Date(date);
	}
}

public class Amount
{
	private Amount(decimal value)
	{
		Value = value;
	}

	public decimal Value { get; }

	public static Result<Amount> Create(decimal amount)
	{
		return new Amount(amount);
	}
}