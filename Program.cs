using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace MailCHeck
{
    class Program
    {
        public  bool SendMail()
        {
            bool mailSent = false;
            try
            {
                string message = DateTime.Now + " In SendMail\n";

                using (MailMessage mm = new MailMessage())
                {
                    mm.From = new MailAddress(Convert.ToString(ConfigurationManager.AppSettings["MailFrom"]));
                    mm.To.Add("nklsanthosh143@gmail.com");
                    mm.Subject = "Indent Number - ";
                    mm.Body = " Your Indent Number";
                    mm.IsBodyHtml = false;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = false;
                    NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                        ConfigurationManager.AppSettings["Password"]);
                    //NetworkCred.Domain = "slppre-new.in";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

                    message = DateTime.Now + " Sending Mail\n";
                    smtp.Send(mm);
                    message = DateTime.Now + " Mail Sent\n";

                    System.Threading.Thread.Sleep(3000);
                    mailSent = true;
                    return mailSent;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return mailSent;
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            bool sendemail= p.SendMail();
            Console.WriteLine("Hello World!");
        }
    }
}
