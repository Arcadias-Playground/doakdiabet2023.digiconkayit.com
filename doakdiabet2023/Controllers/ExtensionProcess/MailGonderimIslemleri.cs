using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using Model;
using System;
using System.Text;
using System.Web;

namespace VeritabaniIslemMerkezi
{
    public class MailGonderimIslemler
    {
        StringBuilder HtmlContent = new StringBuilder();

        public void KayitBilgilendirme(KatilimciTablosuModel OModel)
        {
            using (MimeMessage mm = new MimeMessage())
            {
                mm.From.Add(new MailboxAddress("5. DOĞU AKDENİZ DİYABET AKADEMİSİ 2023", "doakdiabet2023@digiconkayit.com"));
                mm.To.Add(new MailboxAddress($"{OModel.AdSoyad}", OModel.ePosta));
                mm.Bcc.Add(new MailboxAddress("Kadir Çağlar", "kadircaglar@consensustourism.com"));

                mm.Subject = "DOĞU AKDENİZ DİYABET AKADEMİSİ 2023 Başvuru Bilgileriniz";

                // E-posta başlığı güncellendi ve daha kısa ve anlaşılır bir hale getirildi

                HtmlContent.Append($"<p>Sayın {OModel.AdSoyad},</p>");
                HtmlContent.Append($"<p>Başvuru bilgileriniz aşağıda sunulmaktadır:</p>");
                HtmlContent.Append($"<table style='width:100%; border: 1px solid #dddddd; border-collapse: collapse;'>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>T.C. Kimlik Numarası</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.TCNo}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>E-posta Adresi</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.ePosta}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Telefon Numarası</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Telefon}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Sicil Numarası</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.SicilNo}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Branş</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Branş}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Meslek</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Meslek}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Unvan</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Unvan}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Hastane</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Hastane}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Şehir</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Sehir}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>İlçe</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.Ilce}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>Doğum Tarihi</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.DogumTarihi}</td></tr>");
                HtmlContent.Append($"<tr><td style='border: 1px solid #dddddd; padding: 8px;'>KvKK Onayınız</td><td style='border: 1px solid #dddddd; padding: 8px;'>{OModel.KvkkOnay}</td></tr>");
                HtmlContent.Append($"</table>");

                // İleti metni daha düzenli ve bilgilerin daha kolay okunabilir olduğu bir yapıya getirildi



                mm.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    ContentTransferEncoding = ContentEncoding.EightBit,
                    Text = HtmlContent.ToString()
                };

                using (ProtocolLogger logger = new ProtocolLogger(HttpContext.Current.Server.MapPath($"~/Folders/MailLog/_{OModel.ePosta}_{DateTime.Now:yyyy.MM.dd HH.mm.ss}.log")))
                {
                    using (SmtpClient client = new SmtpClient(logger))
                    {
                        try
                        {
                            client.Connect("mail.digiconkayit.com", 587, MailKit.Security.SecureSocketOptions.None);
                            client.Authenticate("doakdiabet2023@digiconkayit.com", "g9FxprA!");
                            client.Send(mm);

                        }
                        catch (Exception ex)
                        {
                            byte[] ExecptionBytes = Encoding.UTF8.GetBytes($"{ex.Message}\r\n");
                            logger.Stream.Write(ExecptionBytes, 0, ExecptionBytes.Length);
                        }
                        finally
                        {
                            client.Disconnect(true);
                        }
                    }
                }
            }
        }
    }
}