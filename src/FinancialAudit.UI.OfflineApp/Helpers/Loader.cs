
namespace FinancialAudit.UI.OfflineApp.Helpers;
public readonly struct Loader()
{
	private readonly List<DisposableLoader> activeLoaders = [];
	public readonly bool IsLoading => activeLoaders.Count != 0;

	public readonly IDisposable StartLoader()
	{
		var loader = new DisposableLoader(RemoveLoader);
		activeLoaders.Add(loader);
		return loader;
	}
	private readonly void RemoveLoader(DisposableLoader loader) => activeLoaders.Remove(loader);

	private readonly struct DisposableLoader(Action<DisposableLoader> onDispose) : IDisposable
	{
		public readonly void Dispose() => onDispose(this);
	}
}
