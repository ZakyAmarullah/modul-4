using System;
using static FanLaptop;

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

class FanLaptop
{
    public enum State { Quiet, Balanced, Performance, Turbo};
    public enum Trigger { ModeUp, ModeDown, TurboShortcut};
    private State currentState;

    public FanLaptop()
    {
        currentState = State.Quiet;
    }

    public class Transisi
    {
        public State currentState, nextState;
        public Trigger trigger;

        public Transisi(State stateAwal, State stateAkhir, Trigger trg)
        {
            currentState = stateAwal;
            nextState = stateAkhir;
            trigger = trg;
        }
    }

    Transisi[] transisi = {
    new Transisi(State.Quiet, State.Balanced, Trigger.ModeUp),
    new Transisi(State.Balanced, State.Performance, Trigger.ModeUp),
    new Transisi(State.Performance, State.Turbo, Trigger.ModeUp),
    new Transisi(State.Turbo, State.Performance, Trigger.ModeDown),
    new Transisi(State.Turbo, State.Quiet, Trigger.TurboShortcut),
    new Transisi(State.Quiet, State.Turbo, Trigger.TurboShortcut),
    new Transisi(State.Performance, State.Balanced, Trigger.ModeDown),
    new Transisi(State.Balanced, State.Quiet, Trigger.ModeDown)
    };



        public State gantiMode(State currentState, State turbo, Trigger trg)
        {
            foreach (var change in transisi)
            {
                if (currentState == change.currentState && trg == change.trigger)
                {
                    Console.WriteLine($"Fan {change.currentState} berubah menjadi, {change.nextState}");
                    return change.nextState;
                }
            }
            return currentState;
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

        FanLaptop laptop = new FanLaptop();
        laptop.gantiMode(FanLaptop.State.Quiet, FanLaptop.State.Turbo, FanLaptop.Trigger.TurboShortcut);
        laptop.gantiMode(FanLaptop.State.Quiet, FanLaptop.State.Balanced, FanLaptop.Trigger.ModeUp);
        laptop.gantiMode(FanLaptop.State.Balanced, FanLaptop.State.Performance, FanLaptop.Trigger.ModeUp);
        laptop.gantiMode(FanLaptop.State.Balanced, FanLaptop.State.Quiet, FanLaptop.Trigger.ModeDown);
        laptop.gantiMode(FanLaptop.State.Performance, FanLaptop.State.Balanced, FanLaptop.Trigger.ModeDown);
        laptop.gantiMode(FanLaptop.State.Performance, FanLaptop.State.Turbo, FanLaptop.Trigger.ModeUp);
        laptop.gantiMode(FanLaptop.State.Turbo, FanLaptop.State.Quiet, FanLaptop.Trigger.TurboShortcut);
        laptop.gantiMode(FanLaptop.State.Turbo, FanLaptop.State.Performance, FanLaptop.Trigger.ModeDown);
        
    }
}