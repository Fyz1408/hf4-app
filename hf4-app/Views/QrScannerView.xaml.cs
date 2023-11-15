
using Camera.MAUI;
using Camera.MAUI.ZXingHelper;

namespace hf4_app.Views;

public partial class QrScannerView : ContentPage
{
  public QrScannerView()
  {
    InitializeComponent();
    CameraView.CamerasLoaded += CameraView_CamerasLoaded;
  }

  private void CameraView_CamerasLoaded(object sender, EventArgs e)
  {
    if (CameraView.Cameras.Count > 0)
    {
      CameraView.Camera = CameraView.Cameras.First();
      MainThread.BeginInvokeOnMainThread(async () =>
      {
        CameraView.MirroredImage = true;
        await CameraView.StopCameraAsync();
        await CameraView.StartCameraAsync();
      });
    }
  }

  private void CameraView_OnBarcodeDetected(object sender, BarcodeEventArgs args)
  {
    // Barcode scanning happens on a background thread therefor we need to invoke the main thread to update the UI 
    MainThread.BeginInvokeOnMainThread(() =>
    {
      BarcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
    });
  }
}