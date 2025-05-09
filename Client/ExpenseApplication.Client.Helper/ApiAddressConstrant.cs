namespace ExpenseApplication.Client.Helper;

public class ApiAddressConstants
{
    public const string Login = "api/Account/Login";
    public const string RefreshToken = "api/Account/RefreshToken";
    public const string Logout = "api/Account/Logout";
    public const string EmployeeGetExpenses = "api/Employee/GetExpenses";
    public const string EmployeeGetUserExpenseFormById = "api/Employee/GetUserExpenseFormById";
    public const string ManagerGetExpenses = "api/Manager/GetExpenses";
    public const string AccountantGetExpenses = "api/Accountant/GetExpenses";
    public const string AdminGetExpenses = "api/Admin/GetExpenses";
    public const string ManagerApproveExpense = "api/Manager/ApproveExpense";
    public const string ManagerRejectExpense = "api/Manager/RejectExpense";
    public const string AccountantPayExpense = "api/Accountant/PayExpense";
    public const string EmployeeCreateExpense = "api/Employee/CreateExpense";
    public const string EmployeeUpdateExpense = "api/Employee/UpdateExpense";
    public const string AdminGetExpenseTransactions = "api/Admin/GetExpenseTransactions";
    public const string AdminDeleteAllLogs = "api/Admin/DeleteAllLogs";
    public const string AdminGetExpenseStatusTypeCountReport = "api/Admin/GetExpenseStatusTypeCountReport";
    public const string AdminGetSystemLogLevelCountReport = "api/Admin/GetSystemLogLevelCountReport";
    public const string AdminGetTotalPaidExpensesMonthlyAmountReport = "api/Admin/GetTotalPaidExpensesMonthlyAmountReport";
    public const string AdminGetExpenseStatusTypeMonthlyCountReport = "api/Admin/GetExpenseStatusTypeMonthlyCountReport";
    public const string AdminGetExpenseActionTypeMonthlyCountReport = "api/Admin/GetExpenseActionTypeMonthlyCountReport";
}