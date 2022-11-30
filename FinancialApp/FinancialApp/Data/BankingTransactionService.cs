using FinancialApp.Models;
using FinancialApp.Data;
using Microsoft.EntityFrameworkCore;
using FinancialApp.Logic;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Data
{
    public class BankingTransactionService
{

        private static ApplicationDBContext context;
        private static CsvManager csvManager = new CsvManager();
        private static DataMapper dataMapper = new DataMapper();

        public BankingTransactionService(ApplicationDBContext _context)
        {
            context = _context;
        }

        public BankingTransaction[] GetTransactionsAsync()
        {
            return context.bankingtransactions.ToArray();
        }

        public string ImportCSVIntoDatabase(string CsvPath)
        {
            try
            {
                csvManager.loadCSV(CsvPath);
                var categories = context.transactioncategories.ToList();
                dataMapper.setCategories(categories);
                dataMapper.map_csvData_to_database(csvManager.ksk_csv, ref context);
                dataMapper.getAdditionalData(ref context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "OK";
        }

    }
}