using System;
using System.Text.Json;
using static CovidConfig;


public class Program
{
    public static void Main(string[] args)
    {
        KonfigCovid config = new KonfigCovid();

        config.UbahSatuan();

        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " +  config.konfig.satuan_suhu + ": ");
        double suhuBadan;
        suhuBadan = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) Anda terakhir memiliki gejala demam?: ");
        int waktuDemam;
        waktuDemam = int.Parse(Console.ReadLine());

        if 
        (
            (config.konfig.satuan_suhu == "celcius" && suhuBadan >= 36.5 && suhuBadan <= 37.5) ||
            (config.konfig.satuan_suhu == "fahrenheit" && suhuBadan >= 97.7 && suhuBadan <= 99.5) &&
            waktuDemam < config.konfig.batas_hari_demam
        )
        {
            Console.WriteLine(config.konfig.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.konfig.pesan_ditolak);
        }
    }
}