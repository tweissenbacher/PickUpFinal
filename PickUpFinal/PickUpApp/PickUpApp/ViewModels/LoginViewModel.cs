using PickUpApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PickUpApp.ViewModels
{
    public class LoginViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        private string password;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public System.Windows.Input.ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (email != "admin" || password != "admin")
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
