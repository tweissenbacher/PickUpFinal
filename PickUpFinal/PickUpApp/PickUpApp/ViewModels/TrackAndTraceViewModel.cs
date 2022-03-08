using PickUpApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PickUpApp.ViewModels
{
    public class TrackAndTraceViewModel : BaseViewModel
    {
        private string text;
        private ItemsViewModel ItemsViewModel { get; set; }

        public TrackAndTraceViewModel(ItemsViewModel itemsViewModel)
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            ItemsViewModel = itemsViewModel;
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
           // await DataStore.AddItemByStringAsync(Text);

           // ItemsViewModel.Items.Add(newItem);

            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }
    }
}
