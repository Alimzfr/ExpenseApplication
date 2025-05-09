namespace ExpenseApplication.Client.Services.Services;

public interface ICustomLocalStorageService
{
    T? GetItem<T>(string key);
    ValueTask<T?> GetItemAsync<T>(string key, CancellationToken cancellationToken = default);
    void SetItem<T>(string key, T data);
    ValueTask SetItemAsync<T>(string key, T data, CancellationToken cancellationToken = default);
    void RemoveItem(string key);
    ValueTask RemoveItemAsync(string key, CancellationToken cancellationToken = default);
    void RemoveItems(IEnumerable<string> keys);
    ValueTask RemoveItemsAsync(IEnumerable<string> keys, CancellationToken cancellationToken = default);
    void Clear();
    ValueTask ClearAsync(CancellationToken cancellationToken = default);
}