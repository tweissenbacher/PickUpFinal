using PickUpApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Size = PickUpApp.Models.Size;

namespace PickUpApp.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class SendingDetailViewModel : BaseViewModel
    {
        public SendingDetailViewModel(string id)
        {
            LoadItemId(id);
        }

        private string itemId;
        private string receiver;
        private string status;
        private DateTime estimatedDelivery;
        private Size size;

        //public string Id { get; set; }

        public string Receiver
        {
            get => receiver;
            set => SetProperty(ref receiver, value);
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
                Receiver = item.Receiver;
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
