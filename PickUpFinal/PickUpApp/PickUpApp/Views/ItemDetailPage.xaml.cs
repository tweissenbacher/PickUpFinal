using Microsoft.Identity.Client;
using PickUpApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PickUpApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(string id)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(id);
        }

    }
}