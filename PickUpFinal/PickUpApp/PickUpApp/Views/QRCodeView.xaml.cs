using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickUpApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PickUpApp.ViewModels;

namespace PickUpApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodeView : ContentPage
    {

        public QRCodeView(string id)
        {
            InitializeComponent();
            BindingContext = new QRCodeViewModel(id);

        }
        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }


    }
}