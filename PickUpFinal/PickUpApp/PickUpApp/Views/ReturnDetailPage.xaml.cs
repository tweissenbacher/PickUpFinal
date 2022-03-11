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
    public partial class ReturnDetailPage : ContentPage
    {
        public ReturnDetailPage(string id)
        {
            InitializeComponent();
            BindingContext = new OrdersDetailViewModel(id);
        }
        private async void OnReturnBoxButtonClicked(object sender, EventArgs args)
        {
            DisplayAlert("Abholung", "Anmeldung zur Abholung der Box war erfolgreich", "Okay");
            await Navigation.PushAsync(new AboutPage());
        }
    }
}