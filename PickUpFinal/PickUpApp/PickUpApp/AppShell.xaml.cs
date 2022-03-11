using PickUpApp.ViewModels;
using PickUpApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PickUpApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell(LoginPage loginPage)
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OrdersPage), typeof(OrdersPage));
            Routing.RegisterRoute(nameof(OrdersDetailPage), typeof(OrdersDetailPage));
            Routing.RegisterRoute(nameof(TrackingPage), typeof(TrackingPage));
        }

    }
}
