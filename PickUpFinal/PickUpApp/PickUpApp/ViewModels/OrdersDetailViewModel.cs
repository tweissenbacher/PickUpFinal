using PickUpApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Size = PickUpApp.Models.Size;

namespace PickUpApp.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class OrdersDetailViewModel : BaseViewModel
    {
        public OrdersDetailViewModel(string id)
        {
            LoadItemId(id);
        }

        private string itemId;
        private string sender;
        private string status;
        private DateTime estimatedDelivery;
        private Size size;

        //public string Id { get; set; }

        public string Sender
        {
            get => sender;
            set => SetProperty(ref sender, value);
        }

        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                //LoadItemId(value);
            }
        }

        public DateTime EstimatedDelivery { get => estimatedDelivery; set => estimatedDelivery = value; }
        public Size Size { get => size; set => size = value; }

        //LoadItem von DataStore
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                ItemId = item.Id;
                Sender = item.Sender.Name;
                Status = item.Status.ToString();
                EstimatedDelivery = item.EstimatedDelivery;
                Size = item.Size;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
