using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ShopingNightMongo.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submit(string eposta)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("gonderen@mail.com"));
            email.To.Add(MailboxAddress.Parse(eposta));
            email.Subject = "Coza Store İndirim Kodu";

            // Mail içeriği (HTML destekli)
            email.Body = new TextPart("html")
            {
                Text = "<h1>Merhaba,</h1> <p> <strong>"+ eposta +"</strong>,</p>\r\n        <p>Hesabınıza <strong>%20’lik</strong> indirim kodu tanımlanmıştır.</p>\r\n        <p><strong>İndirim kodu:</strong> <span style=\"color: #d9534f; font-weight: bold;\">M27Z05A03</span></p>"
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mehmetzahir5834@gmail.com", "smtp Key");
            smtp.Send(email);
            smtp.Disconnect(true);

            return RedirectToAction("Index");
        }
    }
}
