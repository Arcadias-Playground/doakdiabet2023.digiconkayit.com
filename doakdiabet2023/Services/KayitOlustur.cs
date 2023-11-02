using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace doakdiabet2023.Services
{
    public class KayitOlustur
    {
        public bool TCKimlikKontrol(string tcKimlik)
        {
            // Veritabanı bağlantısı oluşturun ve veritabanı sorgusu hazırlayın
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\doakdiabet2023.mdb;Persist Security Info=True";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM KatilimciTablosu WHERE TCNo = @tcKimlik", connection))
                {
                    command.Parameters.AddWithValue("@tcKimlik", tcKimlik);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // TC kimlik numarası daha önce aynı şekilde girilmişse
                    if (count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void KayitOl(string tcKimlik)
        {
            if (TCKimlikKontrol(tcKimlik))
            {
                Console.WriteLine("Bu TC kimlik numarası ile daha önce kayıt olunmuş.");
            }
            else
            {
                // Yeni kayıt oluşturme işlemi
                // Yeni kaydı veritabanına ekleyin
                // ...
                Console.WriteLine("Kayıt başarıyla oluşturuldu.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            KayitOlustur kayitOlustur = new KayitOlustur();
            string tcKimlik = "12345678901"; // Kaydınızı kontrol etmek istediğiniz TC kimlik numarasını buraya girin

            kayitOlustur.KayitOl(tcKimlik);
        }
    }
}