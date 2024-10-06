using System.Reflection;

namespace FinancialAudit.UI.OfflineApp.Helpers.Models;

public class ViewModel<TModel>(TModel backingModel)
{
    private const BindingFlags InstanceProperties = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    public bool IsEditable { get; set; }
    public TModel BackingModel { get; set; } = backingModel;
    public Loader Loader { get; } = new();

    public virtual void Reset()
    {
        var vmType = GetType();
        var mType = typeof(TModel);
        foreach (var vmProp in vmType.GetProperties(InstanceProperties))
        {
            var backingProp = mType.GetProperties(InstanceProperties)
                .FirstOrDefault(p => p.Name == vmProp.Name && p.PropertyType == vmProp.PropertyType);
            if (backingProp is null || !backingProp.CanRead || !vmProp.CanWrite)
                continue;

            var value = backingProp.GetValue(BackingModel);
            vmProp.SetValue(this, value);
        }
    }

    public virtual void StartEdit() => IsEditable = true;
    public virtual void CancelEdit()
    {
        IsEditable = false;
        Reset();
    }

}
