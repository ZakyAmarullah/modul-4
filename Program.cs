using System;

public class KodeProduk
{
    public static string getKodeProduk(string produk)
    {
        string[,] dataKodeproduk = {
            {"Laptop", "E100"},
            {"Smartphone", "E101"},
            {"Tablet", "E102"},
            {"Headset", "E103"},
            {"Keyboard", "E104"},
            {"Mouse", "E105"},
            {"Printer", "E106"},
            {"Monitor", "E107"},
            {"Smartwatch", "E108"},
            {"Kamera", "E109"}

        };

        for (int i = 0; i < dataKodeproduk.GetLength(0); i++)
        {
            if (dataKodeproduk[i, 0].Equals(produk, StringComparison.OrdinalIgnoreCase))
            {
                return dataKodeproduk [i, 1];
            };
        };
        return "Produk tidak ditemukan";
    }
}

public class Program
{
    public static void Main()
    {
        KodeProduk Kode = new KodeProduk();
        Console.WriteLine("Masukkan nama produk : ");
        string produk = Console.ReadLine() ?? "";
        string kode = KodeProduk.getKodeProduk(produk);
        Console.WriteLine($"Kode Produk {produk} : {kode}");
        Main();
    }
}