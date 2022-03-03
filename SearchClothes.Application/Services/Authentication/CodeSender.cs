using MailKit.Net.Smtp;
using MimeKit;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Authentication
{
    public class CodeSender : ICodeSender
    {
        public async Task<CodeSendingResult> SendCode(Verification verification)
        {
            var message = new MimeMessage();
            // TODO: move mail and pswd to json.
            message.From.Add(new MailboxAddress("Server", "searchclothesbytags@gmail.com"));

            message.To.Add(MailboxAddress.Parse(verification.Email));

            message.Subject = "SearchClothesByTags account verification";
            message.Body = new TextPart("plain")
            {
                Text = $"Hi, {verification.Username}! You registrated in SearchClothesByTags. Here is your verification code: {Environment.NewLine}{verification.Code}"
            };

            string emailAddress = "searchclothesbytags@gmail.com";
            string password = "Jw92Km%Qi65N";

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                await client.SendAsync(message);
                Console.WriteLine("Email Sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return CodeSendingResult.ServerError;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
            return CodeSendingResult.Success;
        }
    }
}
