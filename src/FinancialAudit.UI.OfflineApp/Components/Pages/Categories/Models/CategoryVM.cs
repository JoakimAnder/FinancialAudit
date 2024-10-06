using FinancialAudit.UI.OfflineApp.Helpers.Models;
using FinancialAudit.UI.OfflineApp.Models;

namespace FinancialAudit.UI.OfflineApp.Components.Pages.Categories.Models;
public class CategoryVM(Category backingModel) : ViewModel<Category>(backingModel)
{
	public string Id { get; set; } = backingModel.Id;
	public string Name { get; set; } = backingModel.Name;
	public string Description { get; set; } = backingModel.Description;

	public static implicit operator CategoryVM(Category model) => new(model);

}