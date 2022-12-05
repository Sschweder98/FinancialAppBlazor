public class CsvManager
{
    private StreamReader reader;
    public List<ksk_csv_row> ksk_csv = new List<ksk_csv_row>();
    public void loadCSV(String file)
    {
        ksk_csv.Clear();
        reader = new StreamReader(file);
        while (reader.Peek() >= 0)
        {
            analyse_line(reader.ReadLine());
        }
    }

    private void analyse_line(String line)
    {
        if (line.Contains("Auftragskonto"))
        {
            return;
        }
        string[] line_arr = line.Split(";");
        ksk_csv.Add(new ksk_csv_row()
        {
            Auftragskonto = line_arr[0],
            Buchungstag = line_arr[1],
            Valutadatum = line_arr[2],
            Buchungstext = line_arr[3],
            Verwendungszweck = line_arr[4],
            Glaeubiger_ID = line_arr[5],
            Mandatsreferenz = line_arr[6],
            Kundenreferenz__End_to_End_ = line_arr[7],
            Sammlerreferenz = line_arr[8],
            Lastschrift_Ursprungsbetrag = line_arr[9],
            Auslagenersatz_Ruecklastschrift = line_arr[10],
            Beguenstigter_Zahlungspflichtiger = line_arr[11],
            Kontonummer_IBAN = line_arr[12],
            BIC__SWIFT_Code_ = line_arr[13],
            Betrag = line_arr[14],
            Waehrung = line_arr[15],
            Info = line_arr[16]
        });
    }

    public class ksk_csv_row
    {
        public string? Auftragskonto { get; set; }
        public string? Buchungstag { get; set; }
        public string? Valutadatum { get; set; }
        public string? Buchungstext { get; set; }
        public string? Verwendungszweck { get; set; }
        public string? Glaeubiger_ID { get; set; }
        public string? Mandatsreferenz { get; set; }
        public string? Kundenreferenz__End_to_End_ { get; set; }
        public string? Sammlerreferenz { get; set; }
        public string? Lastschrift_Ursprungsbetrag { get; set; }
        public string? Auslagenersatz_Ruecklastschrift { get; set; }
        public string? Beguenstigter_Zahlungspflichtiger { get; set; }
        public string? Kontonummer_IBAN { get; set; }
        public string? BIC__SWIFT_Code_ { get; set; }
        public string? Betrag { get; set; }
        public string? Waehrung { get; set; }
        public string? Info { get; set; }

    }

}
