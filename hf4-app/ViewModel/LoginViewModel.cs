using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.service;
using hf4_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly webHandler api = new webHandler();

        private string test = "Postnord Login";
        public string Test
        {
            get { return test; }
            set { SetProperty(ref test, value); }
        }

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        private bool visibleTabbar = false;
        public bool VisibleTabbar
        {
            get => visibleTabbar;
            set => SetProperty(ref visibleTabbar, value);
        }

        //Tjek login
        [RelayCommand]
        private async Task Login()
        {

            try
            {
                //APIkald
                bool isLoginSuccessful = await api.login(Username, Password);
                Test += isLoginSuccessful;
                //Tjek login
                if (isLoginSuccessful)
                {
                    Test += isLoginSuccessful;
                    //await Shell.Current.DisplayAlert("Test", "test den viser alert", "OK");
                    //Naviger til FrontPage
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    Test += isLoginSuccessful;
                    //"Brugernavn eller kodeord forkert"
                    //await Shell.Current.DisplayAlert("Fejl", "Brugernavn eller adgangskode forkert", "OK");
                }
            }
            catch (Exception ex)
            {
                Test += ex.Message;
                //await Shell.Current.DisplayAlert("Fejl", ex.Message, "OK");
            }
        }
    }
}
