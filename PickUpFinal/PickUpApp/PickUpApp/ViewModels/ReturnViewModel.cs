using PickUpApp.Models;
using PickUpApp.Views;
using PickUpApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace PickUpApp.ViewModels
{
    public class ReturnViewModel : BaseViewModel
    {
        public ObservableCollection<Delivery> Deliveries { get; }

        MockDataStore dataStore = new MockDataStore();
        public Command LoadDeliveriesCommand { get; }
        public Command<Delivery> DeliveryTapped { get; }

        public ReturnViewModel()
        {
            Deliveries = new ObservableCollection<Delivery>();
            LoadDeliveriesCommand = new Command(async () => await ExecuteLoadDeliveryCommand());
            DeliveryTapped = new Command<Delivery>(OnDeliverySelected);
            IsBusy = true;

        }

        //Loads Deliveries with Status "Versendet" into ReturnPage.xaml
        async Task ExecuteLoadDeliveryCommand()
        {
            IsBusy = true;
            try
            {
                Deliveries.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    if(item.Status == Status.Versendet)
                    {
                        Deliveries.Add(item);
                    }  
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        async void OnDeliverySelected(Delivery delivery)
        {
            if (delivery == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={delivery.Id}");
        }
    }
}
