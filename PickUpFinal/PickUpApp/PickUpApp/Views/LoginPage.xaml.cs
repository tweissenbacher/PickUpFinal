using Microsoft.Identity.Client;
using PickUpApp.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        // Behavior "asyn"
        protected override async void OnAppearing()
        {
            await Navigation.PushAsync(new AboutPage());
            try
            {
                // Look for existing account
                IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

                if (accounts.Count() >= 1)
                {
                    AuthenticationResult result = await App.AuthenticationClient
                        .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                        .ExecuteAsync();

                    await Navigation.PushAsync(new AboutPage(result));
                }
            }
            catch
            {
                // Do nothing - the user isn't logged in
            }
            base.OnAppearing();
        }

        async void OnSignInClicked(object sender, EventArgs e)
        {

            AuthenticationResult result;

            try
            {
                result = await App.AuthenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.ForceLogin)
                    .WithParentActivityOrWindow(App.UIParent)
                    .ExecuteAsync();

                await Navigation.PushAsync(new AboutPage(result));
            }
            catch (MsalClientException ex)
            {

            }
        }
    }
}