using PickUpApp.Models;
using PickUpApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickUpApp.Views
{
    public partial class TrackingPage : ContentPage
    {
        TrackingViewModel _viewModel;
        public TrackingPage(OrdersViewModel itemsViewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = new TrackingViewModel(itemsViewModel);
        }

        // goes back to main menu
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        // takes the unique ID of a Delivery and shows the Detail of it
        private async void OnItemDetailPageClicked(object sender, EventArgs args)
        {
            Delivery tmp = await _viewModel.DataStore.GetItemAsync(_viewModel.Text);
            if (tmp != null)
            {
                await Navigation.PushAsync(new OrdersDetailPage(_viewModel.Text)); // it is given to the DetailPage
            }
           
        }
    }
}