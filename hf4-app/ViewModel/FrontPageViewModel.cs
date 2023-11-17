﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.Views;

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
                await Shell.Current.GoToAsync(nameof(QrScannerView));
            }
            catch (Exception ex)
            {
                Test += " Error: " + ex.Message;
            }
        }
    }
}
