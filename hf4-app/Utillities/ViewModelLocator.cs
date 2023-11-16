using hf4_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.Utillities
{
    internal static class ViewModelLocator
    {
        internal static FrontPageViewModel FrontPageViewModel { get; set; } = new FrontPageViewModel();
        internal static LoginViewModel LoginViewModel { get; set; } = new LoginViewModel();
    }
}
