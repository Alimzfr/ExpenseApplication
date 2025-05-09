using System.ComponentModel;

namespace ExpenseApplication.Common.Enums;

public enum CurrencyType : short
{
    [Description("tr-TR")]
    TRY = 0,

    [Description("en-GB")]
    EUR = 1,

    [Description("en-US")]
    USD = 2,

    [Description("ur-PK")]
    PKR = 3,

    [Description("tr-TR")]
    INR = 4
}