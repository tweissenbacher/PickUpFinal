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
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
