using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using VeritabaniIslemSaglayici.Access;

namespace VeritabaniIslemMerkeziBase
{
    public abstract class KatilimciTablosuIslemlerBase
    {
        public VTOperatorleri VTIslem;

        public List<KatilimciTablosuModel> VeriListe;

        public SurecBilgiModel SModel;
        public SurecVeriModel<KatilimciTablosuModel> SDataModel;
        public SurecVeriModel<IList<KatilimciTablosuModel>> SDataListModel;

        public KatilimciTablosuIslemlerBase()
        {
            VTIslem = new VTOperatorleri();
        }

        public KatilimciTablosuIslemlerBase(OleDbTransaction Transcation)
        {
            VTIslem = new VTOperatorleri(Transcation);
        }

        public virtual SurecBilgiModel YeniKayitEkle(KatilimciTablosuModel YeniKayit)
        {
            VTIslem.SetCommandText("INSERT INTO KatilimciTablosu (KatilimciID, AdSoyad, TCNo, ePosta, Telefon, SicilNo, Branş, Meslek, Unvan, Hastane, Sehir, Ilce, DogumTarihi, KvkkOnay , GuncellenmeTarihi, EklenmeTarihi) VALUES (@KatilimciID, @AdSoyad, @TCNo, @ePosta, @Telefon, @SicilNo, @Branş, @Meslek, @Unvan, @Hastane, @Sehir, @Ilce,  @DogumTarihi, KvkkOnay , @GuncellenmeTarihi, @EklenmeTarihi)");

            VTIslem.AddWithValue("KatilimciID", YeniKayit.KatilimciID);
            VTIslem.AddWithValue("AdSoyad", YeniKayit.AdSoyad);
            VTIslem.AddWithValue("TCNo", YeniKayit.TCNo);
            VTIslem.AddWithValue("ePosta", YeniKayit.ePosta);
            VTIslem.AddWithValue("Telefon", YeniKayit.Telefon);
            VTIslem.AddWithValue("SicilNo", YeniKayit.SicilNo);
            VTIslem.AddWithValue("Branş", YeniKayit.Branş);
            VTIslem.AddWithValue("Meslek", YeniKayit.Meslek);
            VTIslem.AddWithValue("Unvan", YeniKayit.Unvan);
            VTIslem.AddWithValue("Hastane", YeniKayit.Hastane);
            VTIslem.AddWithValue("Sehir", YeniKayit.Sehir);
            VTIslem.AddWithValue("Ilce", YeniKayit.Ilce);
            VTIslem.AddWithValue("DogumTarihi", YeniKayit.DogumTarihi);
            VTIslem.AddWithValue("KvkkOnay", YeniKayit.KvkkOnay);
            VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
            VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
            return VTIslem.ExecuteNonQuery();
        }

        public virtual SurecBilgiModel KayitGuncelle(KatilimciTablosuModel GuncelKayit)
        {
            VTIslem.SetCommandText("UPDATE KatilimciTablosu SET AdSoyad = @AdSoyad, TCNo = @TCNo, ePosta = @ePosta, Telefon = @Telefon, SicilNo = @SicilNo, Branş = @Branş, Meslek = @Meslek, Unvan = @Unvan, Hastane = @Hastane, Sehir = @Sehir, Ilce = @Ilce, DogumTarihi = @DogumTarihi, KvkkOnay = @KvkkOnay, GuncellenmeTarihi = @GuncellenmeTarihi, EklenmeTarihi = @EklenmeTarihi WHERE KatilimciID = @KatilimciID");

            VTIslem.AddWithValue("KatilimciID", GuncelKayit.KatilimciID);
            VTIslem.AddWithValue("AdSoyad", GuncelKayit.AdSoyad);
            VTIslem.AddWithValue("TCNo", GuncelKayit.TCNo);
            VTIslem.AddWithValue("ePosta", GuncelKayit.ePosta);
            VTIslem.AddWithValue("Telefon", GuncelKayit.Telefon);
            VTIslem.AddWithValue("SicilNo", GuncelKayit.SicilNo);
            VTIslem.AddWithValue("Branş", GuncelKayit.Branş);
            VTIslem.AddWithValue("Meslek", GuncelKayit.Meslek);
            VTIslem.AddWithValue("Unvan", GuncelKayit.Unvan);
            VTIslem.AddWithValue("Hastane", GuncelKayit.Hastane);
            VTIslem.AddWithValue("Sehir", GuncelKayit.Sehir);
            VTIslem.AddWithValue("Ilce", GuncelKayit.Ilce);
            VTIslem.AddWithValue("DogumTarihi", GuncelKayit.DogumTarihi);
            VTIslem.AddWithValue("KvkkOnay", GuncelKayit.KvkkOnay);
            VTIslem.AddWithValue("GuncellenmeTarihi", GuncelKayit.GuncellenmeTarihi);
            VTIslem.AddWithValue("EklenmeTarihi", GuncelKayit.EklenmeTarihi);

            return VTIslem.ExecuteNonQuery();
        }




        public virtual SurecBilgiModel KayitSil(int KatilimciID)
        {
            VTIslem.SetCommandText("DELETE FROM KatilimciTablosu WHERE KatilimciID=@KatilimciID");
            VTIslem.AddWithValue("KatilimciID", KatilimciID);
            return VTIslem.ExecuteNonQuery();
        }

        public virtual SurecVeriModel<KatilimciTablosuModel> KayitBilgisi(int KatilimciID)
        {
            VTIslem.SetCommandText($"SELECT {KatilimciTablosuModel.SQLSutunSorgusu} FROM KatilimciTablosu WHERE KatilimciID = @KatilimciID");
            VTIslem.AddWithValue("KatilimciID", KatilimciID);
            VTIslem.OpenConnection();
            SModel = VTIslem.ExecuteReader(CommandBehavior.SingleResult);
            if (SModel.Sonuc.Equals(Sonuclar.Basarili))
            {
                while (SModel.Reader.Read())
                {
                    KayitBilgisiAl();
                }
                if (SDataModel is null)
                {
                    SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                    {
                        Sonuc = Sonuclar.VeriBulunamadi,
                        KullaniciMesaji = "Belirtilen kayıt bulunamamıştır",
                        HataBilgi = new HataBilgileri
                        {
                            HataAlinanKayitID = 0,
                            HataKodu = 0,
                            HataMesaji = "Belirtilen kayıt bulunamamıştır"
                        }
                    };
                }
            }
            else
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = SModel.Sonuc,
                    KullaniciMesaji = SModel.KullaniciMesaji,
                    HataBilgi = SModel.HataBilgi
                };
            }
            VTIslem.CloseConnection();
            return SDataModel;
        }

        public virtual SurecVeriModel<IList<KatilimciTablosuModel>> KayitBilgileri()
        {
            VTIslem.SetCommandText($"SELECT {KatilimciTablosuModel.SQLSutunSorgusu} FROM KatilimciTablosu");
            VTIslem.OpenConnection();
            SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
            if (SModel.Sonuc.Equals(Sonuclar.Basarili))
            {
                VeriListe = new List<KatilimciTablosuModel>();
                while (SModel.Reader.Read())
                {
                    if (KayitBilgisiAl().Sonuc.Equals(Sonuclar.Basarili))
                    {
                        VeriListe.Add(SDataModel.Veriler);
                    }
                    else
                    {
                        SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>
                        {
                            Sonuc = SDataModel.Sonuc,
                            KullaniciMesaji = SDataModel.KullaniciMesaji,
                            HataBilgi = SDataModel.HataBilgi
                        };
                        VTIslem.CloseConnection();
                        return SDataListModel;
                    }
                }
                SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>
                {
                    Sonuc = Sonuclar.Basarili,
                    KullaniciMesaji = "Veri listesi başarıyla çekildi",
                    Veriler = VeriListe
                };
            }
            else
            {
                SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>
                {
                    Sonuc = SModel.Sonuc,
                    KullaniciMesaji = SModel.KullaniciMesaji,
                    HataBilgi = SModel.HataBilgi
                };
            }
            VTIslem.CloseConnection();
            return SDataListModel;
        }

        SurecVeriModel<KatilimciTablosuModel> KayitBilgisiAl()
        {
            try
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = Sonuclar.Basarili,
                    KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
                    Veriler = new KatilimciTablosuModel
                    {
                        KatilimciID = SModel.Reader.GetInt32(0),
                        AdSoyad = SModel.Reader.GetString(1),
                        TCNo = SModel.Reader.GetString(2),
                        ePosta = SModel.Reader.GetString(3),
                        Telefon = SModel.Reader.GetString(4),
                        SicilNo = SModel.Reader.GetString(5),
                        Branş = SModel.Reader.GetString(6),
                        Meslek = SModel.Reader.GetString(7),
                        Unvan = SModel.Reader.GetString(8),
                        Hastane = SModel.Reader.GetString(9),
                        Sehir = SModel.Reader.GetString(10),
                        Ilce = SModel.Reader.GetString(11),
                        DogumTarihi = SModel.Reader.GetString(12),
                        KvkkOnay = SModel.Reader.GetBoolean(13),

                        GuncellenmeTarihi = SModel.Reader.GetDateTime(14),
                        EklenmeTarihi = SModel.Reader.GetDateTime(15),
                    }
                };

            }
            catch (InvalidCastException ex)
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = Sonuclar.Basarisiz,
                    KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
                    HataBilgi = new HataBilgileri
                    {
                        HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
                        HataKodu = ex.HResult,
                        HataAlinanKayitID = SModel.Reader.GetValue(0)
                    }
                };
            }
            catch (Exception ex)
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = Sonuclar.Basarisiz,
                    KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
                    HataBilgi = new HataBilgileri
                    {
                        HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
                        HataKodu = ex.HResult,
                        HataAlinanKayitID = SModel.Reader.GetValue(0)
                    }
                };
            }
            return SDataModel;
        }

        public virtual SurecVeriModel<KatilimciTablosuModel> KayitBilgisiAl(int Baslangic, DbDataReader Reader)
        {
            try
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = Sonuclar.Basarili,
                    KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
                    Veriler = new KatilimciTablosuModel
                    {
                        KatilimciID = Reader.GetInt32(Baslangic + 0),
                        AdSoyad = Reader.GetString(Baslangic + 1),
                        TCNo = Reader.GetString(Baslangic + 2),
                        ePosta = Reader.GetString(Baslangic + 3),
                        Telefon = Reader.GetString(Baslangic + 4),
                        SicilNo = Reader.GetString(Baslangic + 5),
                        Branş = Reader.GetString(Baslangic + 6),
                        Meslek = Reader.GetString(Baslangic + 7),
                        Unvan = Reader.GetString(Baslangic + 8),
                        Hastane = Reader.GetString(Baslangic + 9),
                        Sehir = Reader.GetString(Baslangic + 10),
                        Ilce = Reader.GetString(Baslangic + 11),
                        DogumTarihi = Reader.GetString(Baslangic + 12),
                        KvkkOnay = Reader.GetBoolean(Baslangic + 13),

                        GuncellenmeTarihi = Reader.GetDateTime(Baslangic + 14),
                        EklenmeTarihi = Reader.GetDateTime(Baslangic + 15),

                    }
                };
            }
            catch (InvalidCastException ex)
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = Sonuclar.Basarisiz,
                    KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
                    HataBilgi = new HataBilgileri
                    {
                        HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
                        HataKodu = ex.HResult,
                        HataAlinanKayitID = Reader.GetValue(0)
                    }
                };
            }
            catch (Exception ex)
            {
                SDataModel = new SurecVeriModel<KatilimciTablosuModel>
                {
                    Sonuc = Sonuclar.Basarisiz,
                    KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
                    HataBilgi = new HataBilgileri
                    {
                        HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
                        HataKodu = ex.HResult,
                        HataAlinanKayitID = Reader.GetValue(0)
                    }
                };
            }
            return SDataModel;
        }

    }
}