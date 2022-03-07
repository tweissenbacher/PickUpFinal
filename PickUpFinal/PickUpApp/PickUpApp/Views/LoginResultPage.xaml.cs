using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickUpApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginResultPage : ContentPage
    {
        private AuthenticationResult authenticationResult;
        public LoginResultPage(AuthenticationResult authResult)
        {
            authenticationResult = authResult;
            var name = authenticationResult.Account.Username;
            InitializeComponent();
        }
    }
}