using Flurl;

namespace ExpenseApplication.Client.Helper;

public static class QueryStringHelper
{
    public static string AppendQueryStringToUrl(string url, Dictionary<string, string?>? queryParams)
    {
        if (queryParams?.Any() is true)
        {
            return queryParams.Aggregate(url, (current, keyValuePair) => current.AppendQueryParam(keyValuePair.Key, keyValuePair.Value)) ?? string.Empty;
        }

        return url;
    }
}