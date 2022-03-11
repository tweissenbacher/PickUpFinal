using PickUpApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickUpApp.Services
{
    public class MockDataStore : IDataStore<Delivery>
    {
        List<Delivery> items;
        List<Station> stations;
        List<Delivery> sendings;



        public MockDataStore()
        {
            items = new List<Delivery>()
            {

                new Delivery("10364778", new Person("test", "a.b@abc.com", 321),
                             "receiver",
                             "3.0", Size.Groß,  Status.auftretende_Probleme, new Xamarin.Essentials.Location(), DateTime.Now),
                new Delivery("24563287", new Person("Amazon", "a.b@abc.com", 123),
                             "Reiceiver1",
                             "3.0", Size.Mittel,  Status.Zugestellt, new Xamarin.Essentials.Location(), DateTime.MinValue),
                new Delivery("18344723", new Person("Muster GmbH", "a.b@abc.com", 123),
                             "Receiver2",
                             "3.0", Size.Klein,  Status.In_Bearbeitung, new Xamarin.Essentials.Location(), DateTime.MaxValue),
                new Delivery("23434578", new Person("Muster GmbH", "a.b@abc.com", 123),
                             "Receiver3",
                             "3.0", Size.Klein,  Status.Versendet, new Xamarin.Essentials.Location(), new DateTime(2022, 8, 2, 12, 0, 0, 0)),
                new Delivery("14253678", new Person("Muster GmbH", "a.b@abc.com", 123),
                             "Receiver5",
                             "3.0", Size.Klein,  Status.Versendet, new Xamarin.Essentials.Location(), new DateTime(2022, 9, 3, 12, 0, 0, 0))

            };
            sendings = new List<Delivery>()
            {

                new Delivery("103647785543", new Person("test", "a.b@abc.com", 321),
                             "receiver",
                             "3.0", Size.Groß,  Status.auftretende_Probleme, new Xamarin.Essentials.Location(), DateTime.Now) };
         

            stations = new List<Station>()
            {
                new Station(1, "Abholstation 4020", "48.303723880697106, 14.293336868540937", 48.3037238, 14.2933368),
                new Station(2, "Abholstation 4040", "48.33612015604028, 14.31245863183628", 48.3361201, 14.3124586),
                new Station(3, "Abholstation 4030", "48.258576817930646, 14.290852730776692", 48.2585768, 14.2908527)
            };
        }

        public List<Station> GetStations()
        {
            return stations;
        }

        public List<Delivery> GetDeliveries()
        {
            return items;
        }

        public async Task<bool> AddItemAsync(Delivery item)
        {
            sendings.Add(item);

            return await Task.FromResult(true);
        }

        //for returnBox
        public async Task<IEnumerable<Delivery>> GetDeliveriesAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Delivery> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<Delivery> GetSendingAsync(string id)
        {
            return await Task.FromResult(sendings.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Delivery>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<IEnumerable<Delivery>> GetSendingsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(sendings);
        }
    }
}