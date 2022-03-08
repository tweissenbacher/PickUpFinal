using PickUpApp.Models;
using PickUpApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickUpApp.Views
{
    public partial class TrackAndTracePage : ContentPage
    {
        TrackAndTraceViewModel _viewModel;
        public TrackAndTracePage(ItemsViewModel itemsViewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = new TrackAndTraceViewModel(itemsViewModel);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }

        private async void OnItemDetailPageClicked(object sender, EventArgs args)
        {
            //string button = ((Button)sender).Text; // the Text of Button is the ItemId
            Delivery tmp = await _viewModel.DataStore.GetItemAsync(_viewModel.Text);
            if (tmp != null)
            {
                await Navigation.PushAsync(new ItemDetailPage(_viewModel.Text)); // it is given to the DetailPage
            }
           
        }
    }
}