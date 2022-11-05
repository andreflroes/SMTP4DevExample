using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

var emailMessage = new MimeMessage();
emailMessage.From.Add(new MailboxAddress("System", "system@test.com"));
emailMessage.To.Add(new MailboxAddress("André Luiz", "andre@gmail.com"));
emailMessage.Subject = "This is a test";
var bodyBuilder = new BodyBuilder();
bodyBuilder.HtmlBody = "<h1>Important message</h1><p>This is from the system</p>";
bodyBuilder.Attachments.Add("C:/Users/Pichau/Desktop/Faculdade/MapaLogicaParaComputacao.pdf");
emailMessage.Body = bodyBuilder.ToMessageBody();

using (var client = new SmtpClient())
{
    var secureSocketOptions = SecureSocketOptions.None;
    client.Connect("localhost", 25, secureSocketOptions);
    await client.SendAsync(emailMessage);
    client.Disconnect(true);
    Console.WriteLine("Sucesso ao enviar o e-mail");
}
