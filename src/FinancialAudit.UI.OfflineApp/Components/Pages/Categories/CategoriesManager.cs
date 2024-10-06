using FinancialAudit.Shared.DI;
using FinancialAudit.Shared.Result;
using FinancialAudit.UI.OfflineApp.Models;

namespace FinancialAudit.UI.OfflineApp.Components.Pages.Categories;
public interface ICategoriesManager
{
    Task<Category[]> GetAll();
    Task<Result<bool>> SaveEdit(Category newModel);
}

[Transient(typeof(ICategoriesManager))]
public class CategoriesManager : ICategoriesManager
{

    private List<Category> data = [
            new Category(Guid.NewGuid().ToString("N"), "Fun", "Fun stuff"),
            new Category(Guid.NewGuid().ToString("N"), "Income", "Salary"),
            new Category(Guid.NewGuid().ToString("N"), "Housing", "Electricity bill"),
            new Category(Guid.NewGuid().ToString("N"), "Food", "Food"),
            ];

    public Task<Category[]> GetAll()
    {
        return Task.FromResult(data.ToArray());
    }

    private static readonly Error CategoryNotFoundError = new("EditCategory.Save", "Category can not be found");
    public async Task<Result<bool>> SaveEdit(Category newModel)
    {
        var old = data.FirstOrDefault(c => c.Id == newModel.Id);
        if (old is null)
            return CategoryNotFoundError;

        data.Remove(old);
        data.Add(newModel);

        await Task.Delay(TimeSpan.FromSeconds(2));

        return true;
    }

}
