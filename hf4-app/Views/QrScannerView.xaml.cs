
using Camera.MAUI;
using Camera.MAUI.ZXingHelper;
using hf4_app.Utillities;

namespace hf4_app.Views;

public partial class QrScannerView : ContentPage
{
  public QrScannerView()
  {
    InitializeComponent();
    BindingContext = ViewModelLocator.QrScannerViewModel;
  }
}