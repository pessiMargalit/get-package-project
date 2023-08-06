using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using System.Text.RegularExpressions;

namespace BL.BLImplementation
{
    internal class EmailServiceBL
    {
        /// <summary>
        /// Sends an email with an offer to take the package to its destination,
        /// to all drivers whose drives were found to be suitable.
        /// </summary>
        /// <param name="drivers">
        /// The drivers who send them an email with an offer to take the package.
        /// </param>
        /// <param name="package">
        ///  The package offered to take.
        /// </param>
        /// <returns>
        /// The package they need to take.
        /// </returns>
        public static PackageDTO SendEmail(List<DriverDTO> drivers, PackageDTO package)
        {

            // create a new message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GetPackage", "getpackage.md@gmail.com"));
            message.Bcc.AddRange(drivers.Select(d => new MailboxAddress($"{d.FirstName}  {d.LastName}", d.Email))); 
            message.Subject = "This email was sent you from GetPackage";

            //איפה להפעיל את הפונקציה
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<p>Offer to take a package,That its Size is: {package.Size.Hight}X {package.Size.Width}</p>" +
                                    "<p>Click the button below to confirm the package</p>" +
                                    "<br>" +
                                    $"<a href=\"http://localhost:3000/driver/confirm-package-pickup?subject={package._Id}\"> <button type=\"button\" style=\"background-color: #008CBA; color: white; padding: 14px 20px; border: none; border-radius: 4px; cursor: pointer;\">Yes</button></a>" ;
            // add the body part to the message
            message.Body = bodyBuilder.ToMessageBody();

            SendEmailFromGetPackage(message);
            return package;
        }

      
        /// <summary>
        /// Send an email to the client whose package,
        /// to let him know that a driver will take it to its destination.
        /// </summary>
        /// <param name="c">
        /// Client whose package to send him the email
        /// </param>
        /// <param name="driver">
        /// Driver who will take the package.
        /// </param>
        public static void SendEmailToClient(ClientDTO c, DriverDTO driver, PackageDTO package)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GetPackage", "getpackage.md@gmail.com"));
            message.To.Add(new MailboxAddress($"{c.FirstName} {c.LastName}", c.Email));
            message.Subject = "This email was sent you from GetPackage";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Your package was received by driver to be connect with him:{driver.PhoneNumber}";
            message.Body = bodyBuilder.ToMessageBody();
            
            SendEmailFromGetPackage(message);
        }

        /// <summary>
        /// Sends an email to the driver that want to take the package with the client details
        /// </summary>
        /// <param name="driver">
        /// The driver that wants to take the package
        /// </param>
        /// <param name="client">
        /// The owner of the package
        /// </param>
        public static void SendEmailToDriver(DriverDTO driver,ClientDTO client,PackageDTO package)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GetPackage", "getpackage.md@gmail.com"));
            message.To.Add(new MailboxAddress($"{driver.FirstName} {driver.LastName}", driver.Email));
            message.Subject = "This email was sent you from GetPackage";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<p>The package you confirmed is waiting for you, Address to pick up the package:</p>" +"<br>"
                +$"<p>City:{package.Source.City}        <p/>"  + $"<p>Street:{package.Source.Street}        </p>" +$"<p>House number:{package.Source.HouseNumber}</p>" + "<br>"+
                 "<p>Address of destanition:</p>" + " < br > "
                + $"<p>City:{package.Destination.City}        </p>"+ $"<p>Street:{package.Destination.Street}        <p/>" + $"<p>House number:{package.Destination.HouseNumber}</p>" + "<br>"; ;
            message.Body = bodyBuilder.ToMessageBody();

            SendEmailFromGetPackage(message);

        }
        
        /// <summary>
        /// Get message and send an email with this message.
        /// </summary>
        /// <param name="message">
        /// The message that the email sends.
        /// </param>
        public static void SendEmailFromGetPackage(MimeMessage message)
        {

            using (var client = new SmtpClient())
            {
                // connect to the SMTP server
                client.Connect("smtp.gmail.com", 587, false);

                // authenticate with the server
                client.Authenticate("getpackage.md@gmail.com", "sqlecnavnwacjgsd");

                // send the message
                client.Send(message);

                // disconnect from the server
                client.Disconnect(true);
            }
        }

        /// <summary>
        /// Extracts the email address from a given string if it matches the specified pattern.
        /// </summary>
        /// <param name="emailAddress">
        /// The string to extract the email address from.
        /// </param>
        /// <returns>
        /// The extracted email address if the string matches the pattern; otherwise, the original string.
        /// </returns>
        public static string GetTheEmailAddress(string emailAddress)
        {
            string pattern = @"\<(.+?)\>";

            System.Text.RegularExpressions.Match match = Regex.Match(emailAddress, pattern);
            if (match.Success)
            {
                string email = match.Groups[1].Value;
                return email;
            }
            return emailAddress;
        }


    }
}