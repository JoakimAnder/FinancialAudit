using FinancialAudit.Shared.Result;

namespace FinancialAudit.Domain.Budgets;
public class Budget
{
    private Budget(Id id, Name name, Percentages percentages)
    {

    }
}

public class Id
{
    private Id(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static Result<Id> Create(Guid guid = default)
    {
        guid = guid == default ? Guid.NewGuid() : guid;
        return new Id(guid);
    }
}

public class Name
{
    private static Error EmptyNameError => new("Budget.Name.Empty", "The name of a budget can't be empty");

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

public class Percentages
{
    private Percentages()
    {

    }
}
