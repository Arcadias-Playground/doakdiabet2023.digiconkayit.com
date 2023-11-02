using doakdiabet2023.Services;
using Model;
using System;
using System.Data.OleDb;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeritabaniIslemMerkezi;
using VeritabaniIslemMerkezi.Access;

namespace doakdiabet2023
{
    public partial class Default : Page
    {
        StringBuilder Uyarilar = new StringBuilder();
        BilgiKontrolMerkezi Kontrol = new BilgiKontrolMerkezi();
        SurecBilgiModel SModel;
        KatilimciTablosuModel KModel;
        ListItem listItem = new ListItem { Text = "Seçim Yapınız", Value = string.Empty };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

        }

        protected void lnkbtnKayitOl_Click(object sender, EventArgs e)
        {
            string tcKimlik = txtTCNo.Text; // Kullanıcının girdiği TC kimlik numarası

            KayitOlustur kayitOlustur = new KayitOlustur();
            if (kayitOlustur.TCKimlikKontrol(tcKimlik))
            {
                // Bu TC kimlik numarası ile daha önce kayıt olunmuş.
                BilgiKontrolMerkezi.UyariEkrani(this, "UyariBilgilendirme('Bilgilendirme', 'Bu TC kimlik numarası ile daha önce kayıt olunmuş.', false);", false);

            }
            else
            {
                // Yeni kayıt oluşturme işlemi
                KModel = new KatilimciTablosuModel
                {
                    AdSoyad = Kontrol.KelimeKontrol(txtAdSoyad, "Lütfen adınızı ve soyadınızı girin.", ref Uyarilar),
                    TCNo = Kontrol.KimlikNoKontrol(txtTCNo, "Lütfen kimlik numaranızı girin.", "Lütfen geçerli bir kimlik numarası girin.", ref Uyarilar),
                    ePosta = Kontrol.ePostaKontrol(txtEmail, "Lütfen e-posta adresinizi girin.", "E-posta adresi türü yanlış girildi.", ref Uyarilar),
                    Telefon = Kontrol.KelimeKontrol(txtTelefon, "Lütfen cep telefonu numaranızı girin.", ref Uyarilar),
                    SicilNo = Kontrol.KelimeKontrol(txtSicilNo, "Lütfen sicil numaranızı girin.", ref Uyarilar),
                    Branş = Kontrol.KelimeKontrol(txtBranş, "Lütfen branşınızı giriniz.", ref Uyarilar),
                    Meslek = Kontrol.KelimeKontrol(txtMeslek, "Lütfen mesleğinizi giriniz.", ref Uyarilar),
                    Unvan = Kontrol.KelimeKontrol(txtUnvan, "Lütfen ünvanınızı seçin veya belirtin.", ref Uyarilar),
                    Hastane = Kontrol.KelimeKontrol(txtHastane, "Lütfen hangi hastanede çalıştığınızı giriniz.", ref Uyarilar),
                    Sehir = Kontrol.KelimeKontrol(txtSehir, "Lütfen hangi şehirde yaşadığınızı giriniz.", ref Uyarilar),
                    Ilce = Kontrol.KelimeKontrol(txtIlce, "Lütfen İlçe giriniz.", ref Uyarilar),
                    DogumTarihi = Kontrol.TariheKontrol(txtDogumTarihi, "Lütfen doğum tarihinizi giriniz.", "Lütfen geçerli bir tarih giriniz.", ref Uyarilar),
                    KvkkOnay = chkKVKKOnay.Checked,
                    GuncellenmeTarihi = Kontrol.Simdi(),
                    EklenmeTarihi = Kontrol.Simdi(),
                };

                if (string.IsNullOrEmpty(Uyarilar.ToString()))
                {
                    using (OleDbConnection cnn = ConnectionBuilder.DefaultConnection())
                    {
                        ConnectionBuilder.OpenConnection(cnn);
                        using (OleDbTransaction trn = cnn.BeginTransaction())
                        {
                            SModel = new KatilimciTablosuIslemler(trn).YeniKayitEkle(KModel);
                            if (SModel.Sonuc.Equals(Sonuclar.Basarili))
                            {
                                trn.Commit();
                                BilgiKontrolMerkezi.UyariEkrani(this, $"BasariliBilgilendirme('{KModel.AdSoyad}');", false);
                                var mailSender = new MailGonderimIslemler();
                                mailSender.KayitBilgilendirme(KModel);
                            }
                            else
                            {
                                trn.Rollback();
                                BilgiKontrolMerkezi.UyariEkrani(this, $"UyariBilgilendirme('', '{SModel.HataBilgi.HataMesaji}', false);", false);
                            }
                        }
                        ConnectionBuilder.CloseConnection(cnn);
                    }
                }
                else
                {
                    BilgiKontrolMerkezi.UyariEkrani(this, $"UyariBilgilendirme('', '{Uyarilar}', false);", false);
                }
            }
        }
    }
}