using FinancialApp.Models;
using FinancialApp.Data;

namespace FinancialApp.Logic
{
    public class DataMapper
    {
        categoryManager _categoryManager;

        public void setCategories(List<TransactionCategory> categories)
        {
            _categoryManager = new categoryManager(categories);
        }
        public void map_csvData_to_database(List<CsvManager.ksk_csv_row> csv_data, ref ApplicationDBContext database)
        {
            foreach (CsvManager.ksk_csv_row row in csv_data)
            {
                String unqiue = GenerateKey(row);
                Int32 Count = (from BankingTransaction tmp in database.bankingtransactions where tmp.uniqe_key == unqiue select tmp).Count();
                if (Count == 0)
                {
                    createDatabaseEntry(row, ref database, unqiue);
                }
            }
            database.SaveChanges();
        }

        public void createDatabaseEntry(CsvManager.ksk_csv_row row, ref ApplicationDBContext database, String unqiue)
        {
            BankingTransaction tmp_object = new BankingTransaction();
            tmp_object.id = 0;
            tmp_object.uniqe_key = unqiue;
            tmp_object.date = DateTime.ParseExact(row.Buchungstag, "dd.MM.yyyy", null);
            tmp_object.description1 = row.Buchungstext;
            tmp_object.description2 = row.Verwendungszweck;
            tmp_object.category = _categoryManager.getCategoryByName("Sonstiges").category_name;
            tmp_object.cost_fixed = false;
            tmp_object.recipient1 = row.Beguenstigter_Zahlungspflichtiger;
            tmp_object.recipient2 = row.Kontonummer_IBAN;
            tmp_object.value = Convert.ToDouble(row.Betrag);
            database.bankingtransactions.Add(tmp_object);
        }

        public void getAdditionalData(ref ApplicationDBContext database)
        {
            foreach (BankingTransaction entry in database.bankingtransactions)
            {
                entry.category = _categoryManager.findCategory(entry).category_name;
                entry.cost_fixed = _categoryManager.isFixed(entry);
            }
            database.SaveChanges();
        }

        public string GenerateKey(CsvManager.ksk_csv_row row)
        {
            //date
            String unique = row.Buchungstag.Replace(".", "");
            //name of recipient
            if (row.Beguenstigter_Zahlungspflichtiger.Length > 5)
            {
                unique += "_" + row.Beguenstigter_Zahlungspflichtiger.ToLower().Replace(" ", "_").Substring(0, 5);
            }
            else
            {
                unique += "_" + "XXXXX";
            }
            //iban of recipient
            if (row.Kontonummer_IBAN.Length >= 5)
            {
                unique += "_" + row.Kontonummer_IBAN.Substring(0, 5);
            }
            else
            {
                unique += "_" + "XXXXX";
            }
            //value
            unique += "_" + row.Betrag.Replace("-", "").Replace(",", "X");
            return unique;
        }
    }
}
