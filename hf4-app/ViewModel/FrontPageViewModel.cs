using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.ViewModel
{
    public partial class FrontPageViewModel : ObservableObject
    {
        //[RelayCommand]
        private void Scan()
        {
            try
            {
                //Naviger til QR-scanner
            }
            catch (Exception ex)
            {
                //Popup med tekst: "Error: " + ex.Message;
            }
        }
    }
}
