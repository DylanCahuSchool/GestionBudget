namespace GestionBudget.Components.Models
{
    public class BankAccount
    {
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public decimal Change { get; set; }
        public bool IsPositiveChange { get; set; }
    }
}
