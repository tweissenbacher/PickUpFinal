using Microsoft.Identity.Client;
using PickUpApp.ViewModels;
using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickUpApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private AuthenticationResult authenticationResult;
        private ItemsViewModel _viewModel;

        //Konstruktor für die Authentifizierung
        public AboutPage(AuthenticationResult authResult)
        {
            authenticationResult = authResult;
            //var name = authenticationResult.Account.Username;
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            GetClaims();
            base.OnAppearing();
        }
        // Ist der Token gültig, können Benutzerinformationen abgerufen werden
        private void GetClaims()
        {
            var token = authenticationResult.IdToken;
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(authenticationResult.IdToken);
                var claims = data.Claims.ToList();
                if (data != null)
                {
                    // In diesem Abschnitt können noch weitere Benutzerinformationen abgebildet werden -Beispiel $Issuer, &Email uvm.
                    this.welcome.Text = $"Guten Tag {data.Claims.FirstOrDefault(X => X.Type.Equals("name")).Value} !";
                    //this.issuer.Text = $"Issuer: {data.Claims.FirstOrDefault(x => x.Type.Equals("iss")).Value}";

                }
            }
        }

        // Button_Clickevent, um sich manuell von der Applikation auszuloggen
        async void SignOutBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.AuthenticationClient.RemoveAsync(authenticationResult.Account);
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnReturnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ReturnPage());
        }

        private void OnItemsButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemsPage());
        }

        private async void OnNewItemPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage(_viewModel)); // viewModel handed over to make the access possible to the ItemList
        }
        private async void OnHelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpEmail()); // viewModel handed over to make the access possible to the ItemList
        }
        private async void OnNewDeliveryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewDeliveryPage()); // viewModel handed over to make the access possible to the ItemList
        }
        
            private async void OnSenderButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendingView()); // viewModel handed over to make the access possible to the ItemList
        }

    }
}