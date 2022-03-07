using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using PickUpApp.Services;
using PickUpApp.Models;


namespace PickUpApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDeliveryPage : ContentPage
    {


        private Delivery newDelivery;

        static Random rnd = new Random();

        public IDataStore<Delivery> DataStore => DependencyService.Get<IDataStore<Delivery>>();
        MockDataStore dataStore = new MockDataStore();
        public NewDeliveryPage()
        {
            InitializeComponent();
        }
        private Station FindNearestStation(String demoCoordinates, String demoSize)
        {
            List<Station> stations = dataStore.GetStations();
            int r = rnd.Next(stations.Count);

            return stations[r];
        }

        private async void OnButtonClicked(object sender, EventArgs args)
        {


            Geocoder geoCoder = new Geocoder();

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000));

            Debug.WriteLine("Position Status: {0}", position.Timestamp);
            Debug.WriteLine("Position Latitude: {0}", position.Latitude);
            Debug.WriteLine("Position Longitude: {0}", position.Longitude);

            string coordinates = position.Latitude.ToString() + ", " + position.Longitude.ToString();

            Station station = FindNearestStation(coordinates, "test");

            Debug.WriteLine("TEST " + station.getName() + " TEST");

            string route = "https://www.google.com/maps/dir/?api=1&origin=My+Location&destination=" + station.getCoordinates();



            if (Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync(route);
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                await Launcher.OpenAsync(route);
            }


            Models.Size size = Models.Size.Mittel;

            if (Choose.SelectedItem.Equals("Small"))
            {
                size = Models.Size.Klein;
            }
            if (Choose.SelectedItem.Equals("Medium"))
            {
                size = Models.Size.Mittel;
            }
            if (Choose.SelectedItem.Equals("Large"))
            {
                size = Models.Size.Groß;
            }
            Person senderr = getSender();
            string id = RandomDigits();
            string weightt = weight.ToString();
            newDelivery = new Delivery(id, senderr, receiver.Text,
                                weightt, size, Status.In_Bearbeitung, new Xamarin.Essentials.Location(), DatePicker.Date);
            if (newDelivery != null)
            {
                await DataStore.AddItemAsync(newDelivery);
            }


            await Navigation.PushAsync(new QRCodeView(id));

            // await DataStore.AddItemAsync(new Delivery("12", new Person("Zalando", "a.b@abc.com", 321, 999, new Xamarin.Essentials.Location()),
            //  "",
            //   Convert.ToDouble(weight), Models.Size.Klein, new QRCoder.QRCode(), Status.In_Bearbeitung, new Xamarin.Essentials.Location(), DatePicker.Date));



        }
        //get Person data from azure database and create new Person
        //demo method 
        private Person getSender()
        {
            Person sender = new Person("Max Mustermannn", "Max.Mustermann@gmail.com", +43664541000);
            return sender;
        }
        public string RandomDigits()
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 10; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }


    }
}