using System.Collections.ObjectModel;
using Camera.MAUI;
using Camera.MAUI.ZXingHelper;
using CommunityToolkit.Mvvm.Input;
using ZXing;
using CommunityToolkit.Maui.Views;
using Command = Microsoft.Maui.Controls.Command;


namespace hf4_app.ViewModel;

public partial class QrScannerViewModel : BaseViewModel
{
    public Command StartCamera { get; set; }
    public Command StopCamera { get; set; }
    public BarcodeDecodeOptions BarCodeOptions { get; set; }
    public string BarcodeText { get; set; } = "No barcode detected";
    public bool AutoStartPreview { get; set; } = false;
    
    
    private CameraInfo camera = null;
    public CameraInfo Camera 
    {
        get => camera;
        set
        {
            camera = value;
            OnPropertyChanged(nameof(Camera));
            AutoStartPreview = false;
            OnPropertyChanged(nameof(AutoStartPreview));
            AutoStartPreview = true;
            OnPropertyChanged(nameof(AutoStartPreview));
        }
    }
    private ObservableCollection<CameraInfo> cameras = new();
    public ObservableCollection<CameraInfo> Cameras
    {
        get => cameras;
        set
        {
            cameras = value;
            OnPropertyChanged(nameof(Cameras));
        }
    }
    public int NumCameras
    {
        set
        {
            if (value > 0)
            {
                Camera = Cameras.First();
            }
                
        }
    }
    
    private Result[] barCodeResults;
    public Result[] BarCodeResults 
    {
        get => barCodeResults;
        set
        {
            barCodeResults = value;
            if (barCodeResults != null && barCodeResults.Length > 0)
                BarcodeText = barCodeResults[0].Text;
            else
                BarcodeText = "No barcode detected";
            OnPropertyChanged(nameof(BarcodeText));
        }
    } 
    public QrScannerViewModel()
    {
        BarCodeOptions = new()
        {
            AutoRotate = true,
            PossibleFormats = { BarcodeFormat.QR_CODE },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };
        OnPropertyChanged(nameof(BarCodeOptions));
        
        StartCamera = new Command(() =>
        {
            AutoStartPreview = true;
            OnPropertyChanged(nameof(AutoStartPreview));
        });
        StopCamera = new Command(() =>
        {
            AutoStartPreview = false;
            OnPropertyChanged(nameof(AutoStartPreview));
        });

        
        OnPropertyChanged(nameof(StartCamera));
        OnPropertyChanged(nameof(StopCamera));
    }

    [RelayCommand]
    private void TryStartCamera()
    {
        StartCamera = new Command(() =>
        {
            AutoStartPreview = true;
        });
    }
    
}