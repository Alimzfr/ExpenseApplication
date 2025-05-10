using System.ComponentModel;

namespace ExpenseApplication.Common.Enums;

public enum CurrencyType : short
{
    [Description("en-GB")]
    EUR = 0,

    [Description("en-US")]
    USD = 1,

    [Description("ur-PK")]
    PKR = 2,

    [Description("tr-TR")]
    INR = 3,

    [Description("tr-TR")]
    TRY = 4
}