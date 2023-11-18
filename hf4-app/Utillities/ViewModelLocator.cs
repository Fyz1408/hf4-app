using hf4_app.ViewModel;

namespace hf4_app.Utillities
{
    internal static class ViewModelLocator
    {
        internal static FrontPageViewModel FrontPageViewModel { get; set; } = new();
        internal static LoginViewModel LoginViewModel { get; set; } = new();
        internal static PackageViewModel PackageViewModel { get; set; } = new();
        internal static QrScannerViewModel QrScannerViewModel { get; set; } = new();
        
    }
}
