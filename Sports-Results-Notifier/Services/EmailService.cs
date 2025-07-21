using MimeKit;
using MimeKit.Text;
using Spectre.Console;
using Sports_Results_Notifier.Models;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Sports_Results_Notifier.Services;

public class EmailService
{
    public static void SendEmail(Game game)
    {
        var email = new MimeMessage();
        var date = DateTime.Now.ToString("yyyy-MM-dd");
        var emailRecipient = "andy72391@gmail.com";

        email.From.Add(new MailboxAddress("Sender Name", "test@gmail.com"));
        email.To.Add(MailboxAddress.Parse(emailRecipient));

        var emailSubject = $"Latest Game Results for {date}";
        var emailBody =
            $"<p>{game.WinningTeam} defeats {game.LosingTeam} with the final score: {game.WinnerScore} - {game.LoserScore}</p>";

        email.Subject = emailSubject;
        email.Body = new TextPart(TextFormat.Html) { Text = emailBody };

        using (var smtp = new SmtpClient())
        {
            smtp.Connect("smtp.gmail.com", 587);

            var smtpUsername = AnsiConsole.Ask<string>("Username: ");
            var smtpPassword = AnsiConsole.Ask<string>("Password: ");
            smtp.Authenticate(smtpUsername, smtpPassword);

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
