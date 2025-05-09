namespace ExpenseApplication.Client.Services.Services;

public class CustomLocalStorageService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService) : ICustomLocalStorageService
{
    public T? GetItem<T>(string key) => syncLocalStorageService.GetItem<T>(key);
    public void SetItem<T>(string key, T data) => syncLocalStorageService.SetItem(key, data);
    public void RemoveItem(string key) => syncLocalStorageService.RemoveItem(key);
    public void RemoveItems(IEnumerable<string> keys) => syncLocalStorageService.RemoveItems(keys);
    public void Clear() => syncLocalStorageService.Clear();

    public async ValueTask<T?> GetItemAsync<T>(string key, CancellationToken cancellationToken = default) => await localStorageService.GetItemAsync<T>(key, cancellationToken);
    public async ValueTask SetItemAsync<T>(string key, T data, CancellationToken cancellationToken = default) => await localStorageService.SetItemAsync(key, data, cancellationToken);
    public async ValueTask RemoveItemAsync(string key, CancellationToken cancellationToken = default) => await localStorageService.RemoveItemAsync(key, cancellationToken);
    public async ValueTask RemoveItemsAsync(IEnumerable<string> keys, CancellationToken cancellationToken = default) => await localStorageService.RemoveItemsAsync(keys, cancellationToken);
    public async ValueTask ClearAsync(CancellationToken cancellationToken = default) => await localStorageService.ClearAsync(cancellationToken);
}