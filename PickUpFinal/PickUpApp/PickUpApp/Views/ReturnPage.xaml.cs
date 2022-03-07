using PickUpApp.Models;
using PickUpApp.Services;
using PickUpApp.ViewModels;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PickUpApp.Views
{
    public partial class ReturnPage : ContentPage
    {
        MockDataStore dataStore = new MockDataStore();
        static Random rnd = new Random();

        ReturnViewModel _viewModel;

        public ReturnPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ReturnViewModel();
        }

        //loads Google Maps with nearest Station
        private async void OnStationClicked(object sender, EventArgs e)
        {
            if (IsPickerSelected())
            {
                Geocoder geoCoder = new Geocoder();

                //Gets Coordinates of the Device
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000));
                string coordinates = position.Latitude.ToString() + ", " + position.Longitude.ToString();

                //Creates Google Maps URL to the Station
                Station station = FindNearestStation(coordinates, smallBox.ToString(), mediumBox.ToString(), largeBox.ToString());
                string route = "https://www.google.com/maps/dir/?api=1&origin=My+Location&destination=" + station.getCoordinates();

                Grid2.IsVisible = false;
                Grid1.IsVisible = true;

                if (Device.RuntimePlatform == Device.Android)
                {
                    await Launcher.OpenAsync(route);
                }
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    await Launcher.OpenAsync(route);
                }
            }
        }

        //Gets Coordinates of the Device and the amount of returned Boxes to find the nearest Station
        private Station FindNearestStation(String demoCoordinates, String smallBox, String mediumBox, String largeBox)
        {
            List<Station> stations = dataStore.GetStations();
            int r = rnd.Next(stations.Count);
            
            return stations[r];
        }

        private void OnDeliveryClicked(object sender, EventArgs e)
        {
            if (IsPickerSelected())
            {
                Grid2.IsVisible = true;
                Grid1.IsVisible = false;
            }
        }

        //Checks if User selected at least 1 box to return
        private Boolean IsPickerSelected()
        {
            if (smallBox.Text.Equals("0") && mediumBox.Text.Equals("0") && largeBox.Text.Equals("0"))
            {
                DisplayAlert("Größenauswahl", "Es muss mindestens eine Box retouniert werden", "Okay");
                return false;
            }
            return true;
        }
        private async void OnItemDetailPageClicked(object sender, EventArgs args)
        {
            string button = ((Button)sender).Text; // the Text of Button is the ItemId
            await Navigation.PushAsync(new ReturnDetailPage(button)); // it is given to the DetailPage
        }
    }
}