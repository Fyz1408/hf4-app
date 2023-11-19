using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.service;
using hf4_app.Views;

namespace hf4_app.ViewModel
{
    public partial class FrontPageViewModel : ObservableObject
    {
        private readonly webHandler api = new webHandler();

        private string logoutCheck = "";
        public string LogoutCheck
        {
            get { return logoutCheck; }
            set { SetProperty(ref logoutCheck, value); }
        }

        //Log ud
        [RelayCommand]
        private void Logout()
        {
            try
            {
                //Nulstil token
                api.logout();
                bool isLogin = api.isLogin;
                //Tjek token er nulstillet
                if (!isLogin)
                {
                    //Naviger til Loginside
                    Application.Current.MainPage = new Login();
                } else
                {
                    LogoutCheck = "Kunne ikke logge ud";
                }
            }
            catch (Exception ex)
            {
                LogoutCheck = " Error: " + ex.Message;
            }
        }

        //Button not needed
        /*[RelayCommand]
        private async Task Scan()
        {
            try
            {
                //Naviger til QR-scanner
                await Shell.Current.GoToAsync(nameof(QrScannerView));
            }
            catch (Exception ex)
            {
                Test += " Error: " + ex.Message;
            }
        }*/
    }
}
