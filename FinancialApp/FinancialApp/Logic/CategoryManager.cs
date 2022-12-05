using FinancialApp.Models;
namespace FinancialApp.Logic
{
    public class categoryManager
    {
        public List<TransactionCategory> categories;

        public categoryManager(List<TransactionCategory> _categories)
        {
            categories = _categories;
        }

        public TransactionCategory getCategoryByName(String name)
        {
            var tmp = (from category in categories where category.category_name == name select category).FirstOrDefault();
            if (tmp != null)
            {
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public TransactionCategory findCategory(BankingTransaction _Data)
        {
            //Einnahmen
            if (_Data.value > 0.00)
            {
                if (_Data.description1.ToLower().Contains("gehalt"))
                {
                    return getCategoryByName("Gehalt");
                }
                else if (_Data.description2.ToLower().Contains("miete"))
                {
                    return getCategoryByName("Mieteinnahmen");
                }
                else
                {
                    return getCategoryByName("Sonstige Einnahmen");
                }
            }

            //Umbuchung
            if (_Data.description1.ToLower().Contains("uebertrag") || _Data.recipient1.ToLower().Contains("sebastian schweder"))
            {
                return getCategoryByName("Umbuchung");
            }

            //Bargeldauszahlung
            if (_Data.description1.ToLower().Contains("bargeldauszahlung") || _Data.description1.ToLower().Contains("auszahl."))
            {
                return getCategoryByName("Bargeldauszahlung");
            }

            //Steuern
            if (_Data.recipient1.ToLower().Contains("bundeskasse") || _Data.recipient1.ToLower().Contains("stadt") || _Data.recipient1.ToLower().Contains("finanzamt") ||
             _Data.recipient1.ToLower().Contains("fuer fk schorndorf"))
            {
                return getCategoryByName("Bargeldauszahlung");
            }

            //Bars
            if (_Data.recipient1.ToLower().Contains("ssk") || _Data.recipient1.ToLower().Contains("skybar"))
            {
                return getCategoryByName("Bargeldauszahlung");
            }

            //Tankstellen
            if (_Data.recipient1.ToLower().Contains("agip") ||
            _Data.recipient1.ToLower().Contains("aral") ||
            _Data.recipient1.ToLower().Contains("avia") ||
            _Data.recipient1.ToLower().Contains("tankpoint") ||
            _Data.recipient1.ToLower().Contains("ran ts") ||
            _Data.recipient1.ToLower().Contains("shell"))
            {
                return getCategoryByName("Tankstelle");
            }

            //Lebensmittel-Einkauf
            if (_Data.recipient1.ToLower().Contains("netto marken") ||
            _Data.recipient1.ToLower().Contains("ecenter") ||
            _Data.recipient1.ToLower().Contains("edeka") ||
            _Data.recipient1.ToLower().Contains("kaufland") ||
            _Data.recipient1.ToLower().Contains("conad") ||
            _Data.recipient1.ToLower().Contains("tedi fil") ||
            _Data.recipient1.ToLower().Contains("backerei maurer") ||
            _Data.recipient1.ToLower().Contains("rewe")
            )
            {
                return getCategoryByName("Lebensmittel");
            }

            //Hausverwaltung
            if (_Data.recipient1.ToLower().Contains("hausverwaltung"))
            {
                return getCategoryByName("Hausverwaltung");
            }

            //Kredite
            if (_Data.recipient1.ToLower().Contains("santander") || _Data.description1.ToLower().Contains("einzug rate"))
            {
                return getCategoryByName("Kredit");
            }

            //Versicherung
            if (_Data.recipient1.ToLower().Contains("wwk") || _Data.recipient1.ToLower().Contains("versicherung"))
            {
                return getCategoryByName("Versicherung");
            }

            //Abonnements
            if (_Data.recipient1.ToLower().Contains("fitness") || _Data.recipient1.ToLower().Contains("strato ag") || _Data.recipient1.ToLower().Contains("Fitness"))
            {
                return getCategoryByName("Abonnements");
            }

            //OnlineShopping
            if (_Data.recipient1.ToLower().Contains("paypal") || _Data.recipient1.ToLower().Contains("amazon payments") || _Data.recipient1.ToLower().Contains("Fitness") ||
            _Data.recipient1.ToLower().Contains("amazon eu"))
            {
                return getCategoryByName("Onlineshopping");
            }

            //FastFood
            if (_Data.recipient1.ToLower().Contains("mcdonalds") || _Data.recipient1.ToLower().Contains("bk-sued"))
            {
                return getCategoryByName("FastFood");
            }

            //Restaurant
            if (_Data.recipient1.ToLower().Contains("schwabenalm") || _Data.recipient1.ToLower().Contains("dimitra") || _Data.recipient1.ToLower().Contains("ketch may beef") ||
            _Data.recipient1.ToLower().Contains("kesselhaus"))
            {
                return getCategoryByName("Restaurant");
            }

            //Technik/Gaming
            if (_Data.recipient1.ToLower().Contains("media markt") || _Data.recipient1.ToLower().Contains("saturn"))
            {
                return getCategoryByName("Technik/Gaming");
            }

            //Mobilfunk
            if (_Data.recipient1.ToLower().Contains("telefonica"))
            {
                return getCategoryByName("Mobilfunk");
            }

            //Arztkosten
            if (_Data.recipient1.ToLower().Contains("dr. "))
            {
                return getCategoryByName("Arztkosten");
            }

            //Sonstiges
            return getCategoryByName("Sonstiges");
        }

        public Boolean isFixed(BankingTransaction _Data)
        {
            if (_Data.category == "Kredit" || _Data.category == "Versicherung" || _Data.category == "Abonnements" || _Data.category == "Mobilfunk" ||
            _Data.category == "Gehalt" || _Data.category == "Hausverwaltung" || _Data.category == "Hausverwaltung")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
