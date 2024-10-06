namespace FinancialAudit.Shared.DI;

[AttributeUsage(AttributeTargets.Class)]
public class SingletonAttribute(Type asType) : Attribute
{
    public Type AsType { get; } = asType;
}

[AttributeUsage(AttributeTargets.Class)]
public class ScopedAttribute(Type asType) : Attribute
{
    public Type AsType { get; } = asType;
}

[AttributeUsage(AttributeTargets.Class)]
public class TransientAttribute(Type asType) : Attribute
{
    public Type AsType { get; } = asType;
}
