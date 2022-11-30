namespace FinancialApp.Models
{
    public class BankingTransaction
    {
            public int id { get; set; }
            public string uniqe_key { get; set; }
            public DateTime date { get; set; }
            public string description1 { get; set; }
            public string description2 { get; set; }
            public string category { get; set; }
            public Boolean cost_fixed { get; set; }
            public string recipient1 { get; set; }
            public string recipient2 { get; set; }
            public double value { get; set; }
    }
}
