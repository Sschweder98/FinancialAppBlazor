using Microsoft.EntityFrameworkCore;
using FinancialApp.Models;

namespace FinancialApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }



        public DbSet<BankingTransaction> bankingtransactions { get; set; }
        public DbSet<TransactionCategory> transactioncategories { get; set; }
    }
}
