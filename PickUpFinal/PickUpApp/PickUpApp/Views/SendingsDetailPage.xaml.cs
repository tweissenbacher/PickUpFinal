
using Microsoft.Identity.Client;
using PickUpApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PickUpApp.Views
{
    public partial class SendingsDetailPage : ContentPage
    {
        public SendingsDetailPage(string id)
        {
            InitializeComponent();
            BindingContext = new SendingDetailViewModel(id);
        }

    }
}