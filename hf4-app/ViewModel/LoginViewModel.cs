using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        // Properties
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
        //[RelayCommand]
        private void Login()
        {
            try
            {
                //APIkald for at få bool for "isLoggedin"
                bool isLoginSuccessful = true;//await ApiService.LoginAsync(Username, Password);
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
                //Popup med tekst: "Error: " + ex.Message;
            }
        }
    }
}
