using System.ComponentModel;

namespace ExpenseApplication.Client.Helper;

public static class EnumHelper
{
    public static List<T> GetEnumItems<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }

    public static string GetEnumDescription<T>(this T enums) where T : Enum
    {
        var fieldInfo = enums.GetType().GetField(enums.ToString());
        var attributes = (DescriptionAttribute[]?)fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes is { Length: > 0 } ? attributes[0].Description : enums.ToString();
    }
}