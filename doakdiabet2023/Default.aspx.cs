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
                ddlUnvan.DataBind();
                ddlUnvan.Items.Insert(0, listItem);
            }

        }

        protected void ddlUnvan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnvan.SelectedValue.Equals("1") || ddlUnvan.SelectedValue.Equals("2"))
            {
                // '1' veya '2' değerine sahip bir seçenek seçildiğinde yapılması gereken işlemler buraya yaz

                Kontrol.Temizle(ddlUnvan);
                ddlUnvan.Visible = false;
            }
        }


        protected void lnkbtnKayitOl_Click(object sender, EventArgs e)
        {
            {
                KModel = new KatilimciTablosuModel
                {
                    KatilimciID = new KatilimciTablosuIslemler().YeniKatilimciID(),
                    AdSoyad = Kontrol.KelimeKontrol(txtAdSoyad, "Lütfen adınızı ve soyadınızı girin.", ref Uyarilar),
                    TCNo = string.IsNullOrEmpty(txtTCNo.Text) ? string.Empty : Kontrol.KimlikNoKontrol(txtTCNo, "Lütfen kimlik numaranızı girin.", "Lütfen geçerli bir kimlik numarası girin.", ref Uyarilar),
                    ePosta = Kontrol.ePostaKontrol(txtEmail, "e-Posta boş olamaz", "Lütfen e-posta adresinizi girin.", ref Uyarilar),
                    Telefon = Kontrol.KelimeKontrol(txtTelefon, "Lütfen cep telefonu numaranızı girin.", ref Uyarilar),
                    SicilNo = Kontrol.KelimeKontrol(txtSicilNo, "Lütfen sicil numaranızı girin.", ref Uyarilar),
                    Branş = Kontrol.KelimeKontrol(txtBranş, "Lütfen Branşınızı giriniz.", ref Uyarilar),
                    Meslek = Kontrol.KelimeKontrol(txtMeslek, "Lütfen Mesleğinizi giriniz.", ref Uyarilar),
                    Unvan = new BilgiKontrolMerkezi().KelimeKontrol(ddlUnvan, "Lütfen ünvanınızı seçin veya belirtin.", ref Uyarilar),
                    Hastane = Kontrol.KelimeKontrol(txtHastane, "Lütfen hangi hastane de çalıştığınızı giriniz.", ref Uyarilar),
                    Sehir = Kontrol.KelimeKontrol(txtSehir, "Lütfen hangi şehirde yaşadığınızı giriniz.", ref Uyarilar),
                    Ilce = Kontrol.KelimeKontrol(txtIlce, "Lütfen İlçe giriniz.", ref Uyarilar),
                    DogumTarihi = Kontrol.KelimeKontrol(txtDogumTarihi, "Lütfen doğum tarihinizi giriniz.", ref Uyarilar),

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
                                Response.Redirect($"~/RegistrationSuccessful.aspx?KatilimciID={KModel.KatilimciID}");
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