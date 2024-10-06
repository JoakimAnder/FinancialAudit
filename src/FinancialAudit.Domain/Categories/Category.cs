using FinancialAudit.Shared.Result;

namespace FinancialAudit.Domain.Categories;

public class Category
{
    private Category(Id id, Name name, Description description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Id Id { get; }
    public Name Name { get; }
    public Description Description { get; }

    public static Result<Category> Create(Id id, Name name, Description description)
    {
        return new Category(id, name, description);
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
    private static Error EmptyNameError => new("Transaction.Name.Empty", "The name of a transaction can't be empty");

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

    public static Result<Description> Create(string? description)
    {
        description = description?.Trim() ?? string.Empty;
        return new Description(description);
    }
}
