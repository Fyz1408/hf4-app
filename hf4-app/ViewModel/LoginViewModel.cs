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

        private string test = "PostNord Login";
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
                    Test += " Sucess";
                    //Naviger til FrontPage
                    await Shell.Current.GoToAsync(nameof(FrontPage));
                }
                else
                {
                    //"Brugernavn eller kodeord forkert"
                    Test += "Failed";
                }
            }
            catch (Exception ex)
            {
                Test += " Error: " + ex.Message;
            }
        }
    }
}
