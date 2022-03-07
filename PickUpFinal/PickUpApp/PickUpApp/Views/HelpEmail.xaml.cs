using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickUpApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpEmail : ContentPage
    {
        public HelpEmail()
        {
            SendEmail("Anfrage 345 an Kundenservice", "Bitte schildern Sie anschließend Ihren Problemfall und wir werden und zeitnahe bei Ihnen melden.");
            InitializeComponent();
        }
        public async Task SendEmail(string subject, string body)
        {
            try
            {
                List<string> to = new List<string>();
                to.Add("help.package@package.com");
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = to,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}