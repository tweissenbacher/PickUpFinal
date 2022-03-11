using Microsoft.Identity.Client;
using PickUpApp.Models;
using PickUpApp.ViewModels;
using PickUpApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickUpApp.Views
{
    public partial class SendingsPage : ContentPage
    {
        SendingViewModel _viewModel;

        public SendingsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SendingViewModel();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void OnSendingDetailClicked(object sender, EventArgs args)
        {
            string button = ((Button)sender).Text; // the Text of Button is the ItemId
            await Navigation.PushAsync(new SendingsDetailPage(button)); // it is given to the DetailPage
        }


    }
}