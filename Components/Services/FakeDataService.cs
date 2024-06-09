namespace GestionBudget.Components.Services;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using GestionBudget.Components.Models;

public class FakeDataService
{
    public async Task<List<BankAccount>> GetAccountsAsync()
    {
        var json = await File.ReadAllTextAsync("Components/Data/FakeAccounts.json");
        return JsonSerializer.Deserialize<List<BankAccount>>(json);
    }

    public async Task<List<Expense>> GetExpensesAsync()
    {
        var json = await File.ReadAllTextAsync("Components/Data/FakeExpenses.json");
        return JsonSerializer.Deserialize<List<Expense>>(json);
    }
}
