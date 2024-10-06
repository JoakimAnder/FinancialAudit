namespace FinancialAudit.UI.Components.Icons;
public sealed class IconType
{
    public static IconType Create(string cssClass) => new(cssClass);

    private IconType(string cssClass)
    {
        CssClass = cssClass;
    }

    public string CssClass { get; }
}

public static class Icons
{
    public static readonly IconType Edit = IconType.Create("fa-solid fa-pencil");
    public static readonly IconType Save = IconType.Create("fa-regular fa-floppy-disk");
    public static readonly IconType Cancel = IconType.Create("fa-solid fa-xmark");

    public static readonly IconType Category = IconType.Create("fa-solid fa-icons");
    public static readonly IconType Transaction = IconType.Create("fa-solid fa-money-bill-1-wave");
    public static readonly IconType Budget = IconType.Create("fa-solid fa-chart-pie");
}
