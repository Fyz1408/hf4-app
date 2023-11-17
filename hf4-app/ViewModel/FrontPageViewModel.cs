using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.ViewModel
{
    public partial class FrontPageViewModel : ObservableObject
    {
        private string test = "Test";
        public string Test
        {
            get { return test; }
            set { SetProperty(ref test, value); }
        }

        [RelayCommand]
        private async Task Scan()
        {
            try
            {
                Test += " Should navigate";
                //Naviger til QR-scanner
                await Shell.Current.GoToAsync(nameof(qrScannerView));
            }
            catch (Exception ex)
            {
                Test += " Error: " + ex.Message;
            }
        }
    }
}
