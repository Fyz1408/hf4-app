using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        webHandler api = new webHandler();

        private string clicked = "";
        public string Clicked
        {
            get { return clicked; }
            set { SetProperty(ref clicked, value); }
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

        //Tjek login
        [RelayCommand]
        private async Task Login()
        {
            try
            {
                //APIkald
                bool isLoginSuccessful = await api.login(Username, Password);

                //Tjek login
                if (isLoginSuccessful)
                {
                    //Naviger til FrontPage
                }
                else
                {
                    //"Brugernavn eller kodeord forkert"
                }
            }
            catch (Exception ex)
            {
                Clicked += "Error: " + ex.Message;
            }
        }
    }
}
