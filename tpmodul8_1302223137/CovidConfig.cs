using System;
using System.Text.Json;

public class CovidConfig
{ 
	public string satuan_suhu { get; set; }
	public int batas_hari_demam { get; set; }	
	public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }
   
    public CovidConfig() { }
  
    public class KonfigCovid
    {

        public CovidConfig konfig;

        private const string filePath = "C:\\Kuliah\\SEMESTER 4\\KPL\\Praktikum\\TPMOD8\\tpmodul8_1302223137\\tpmodul8_1302223137\\covid_config.json";
       
        public KonfigCovid()
        {
            try
            {
                ReadKonfigFile();
            }
            catch
            {
                SetDefault();
                WriteKonfigFile();
            }
        }

        public void ReadKonfigFile()
        {
            String configJson = File.ReadAllText(filePath);
            konfig = JsonSerializer.Deserialize<CovidConfig>(configJson);
        }

        public void WriteKonfigFile()
        {
            JsonSerializerOptions opsi = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String text = JsonSerializer.Serialize(konfig);
            File.WriteAllText(filePath, text);
        }

        public void SetDefault()
        {
            konfig = new CovidConfig();
            konfig.satuan_suhu = "celcius";
            konfig.batas_hari_demam = 14;
            konfig.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini.";
            konfig.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini.";
        }

        public void UbahSatuan()
        {
            if(this.konfig.satuan_suhu == "celcius")
            {
                this.konfig.satuan_suhu = "fahrenheit";
            }
            else
            {
                this.konfig.satuan_suhu = "celcius";
            }

        }
    } 
 }
    
