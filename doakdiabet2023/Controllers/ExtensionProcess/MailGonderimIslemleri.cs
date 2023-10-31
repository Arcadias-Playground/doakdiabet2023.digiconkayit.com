//using MailKit;
//using MailKit.Net.Smtp;
//using MimeKit;
//using Model;
//using System;
//using System.Text;
//using System.Web;

//namespace VeritabaniIslemMerkezi
//{
//    public class MailGonderimIslemler
//    {
//        StringBuilder HtmlContent = new StringBuilder();

//        public void KayitBilgilendirme(KatilimciTablosuModel OModel)
//        {
//            using (MimeMessage mm = new MimeMessage())
//            {
//                mm.From.Add(new MailboxAddress("Hiv Aids 2023 Kongresi", "hiv2023burs@digiconkayit.com"));
//                mm.To.Add(new MailboxAddress($"{OModel.AdSoyad}", OModel.ePosta));
//                mm.Bcc.Add(new MailboxAddress("Cihan Çalışkan", "serhat@arkadyas.com"));

//                mm.Subject = "Hiv Aids Başvuru Onayı";

//                HtmlContent.Append($"<p>Sayın {OModel.AdSoyad},</p>");
//                HtmlContent.Append($"<p>Kayıt bilgileriniz:</p>");
//                HtmlContent.Append($"<table style='width:100%;'>");
//                HtmlContent.Append($"<tr><td style='width:250px;'>E-Posta</td><td>{OModel.ePosta}</td></tr>");
//                HtmlContent.Append($"<tr><td>Tc Kimlik No</td><td>{OModel.TCNo}</td></tr>");
//                HtmlContent.Append($"<tr><td>Unvan</td><td>{OModel.Unvan}</td></tr>");
//                HtmlContent.Append($"<tr><td>E-posta</td><td>{OModel.ePosta}</td></tr>");
//                HtmlContent.Append($"<tr><td>Telefon No</td><td>{OModel.Telefon}</td></tr>");
//                HtmlContent.Append($"<tr><td>Kurum</td><td>{OModel.Kurum}</td></tr>");
//                HtmlContent.Append($"<tr><td>Bildiriniz Var Mı ?</td><td>{OModel.Bildiri}</td></tr>");
//                HtmlContent.Append($"<tr><td>Bildiri No</td><td>{OModel.BildiriNo}</td></tr>");
//                HtmlContent.Append($"</table>");


//                mm.Body = new TextPart(MimeKit.Text.TextFormat.Html)
//                {
//                    ContentTransferEncoding = ContentEncoding.EightBit,
//                    Text = HtmlContent.ToString()
//                };

//                using (ProtocolLogger logger = new ProtocolLogger(HttpContext.Current.Server.MapPath($"~/Folders/MailLog/_{OModel.ePosta}_{DateTime.Now:yyyy.MM.dd HH.mm.ss}.log")))
//                {
//                    using (SmtpClient client = new SmtpClient(logger))
//                    {
//                        try
//                        {
//                            client.Connect("mail.digiconkayit.com", 587, MailKit.Security.SecureSocketOptions.None);
//                            client.Authenticate("hiv2023burs@digiconkayit.com", "zCmss9A!");
//                            client.Send(mm);

//                        }
//                        catch (Exception ex)
//                        {
//                            byte[] ExecptionBytes = Encoding.UTF8.GetBytes($"{ex.Message}\r\n");
//                            logger.Stream.Write(ExecptionBytes, 0, ExecptionBytes.Length);
//                        }
//                        finally
//                        {
//                            client.Disconnect(true);
//                        }
//                    }
//                }
//            }
//        }
//    }
//}