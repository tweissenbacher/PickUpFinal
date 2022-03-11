using Microsoft.Identity.Client;
using PickUpApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PickUpApp.Views
{
    public partial class OrdersDetailPage : ContentPage
    {
        // connects the OrderOage and OrderDetailPage through Delivery's ID and shows the Detail of a Delivery
        public OrdersDetailPage(string id)
        {
            InitializeComponent();
            BindingContext = new OrdersDetailViewModel(id);
        }

    }
}