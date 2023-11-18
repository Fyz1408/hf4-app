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

        private string error = "";
        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
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
                    //Naviger til FrontPage
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    Error = "Brugernavn eller adgangskode forkert";
                }
            }
            catch (Exception ex)
            {
                Error = "Hov noget gik galt - Prøv igen senere "+ex.Message;
            }
        }
    }
}
