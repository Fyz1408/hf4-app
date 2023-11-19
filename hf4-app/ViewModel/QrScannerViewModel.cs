#nullable enable
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Camera.MAUI;
using Camera.MAUI.ZXingHelper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.Models;
using hf4_app.service;
using hf4_app.Views;
using ZXing;

namespace hf4_app.ViewModel;

public partial class QrScannerViewModel : ObservableObject
{
    private readonly webHandler api = new();
    public Command StartCamera { get; set; }
    public Command StopCamera { get; set; }
    public BarcodeDecodeOptions BarCodeOptions { get; set; }
    public string BarcodeText { get; set; } = "Ingen QR kode scannet";

    [ObservableProperty] private string barcodeButtonColor = "#479fd1";
    public bool AutoStartPreview { get; set; }
    
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
            {
                var packageId = GetPackageId(barCodeResults[0].Text);
                if (!string.IsNullOrEmpty(packageId))
                {
                    // QR Code had a valid package ID
                    BarcodeText = packageId;
                    BarcodeButtonColor = "LightGreen";
                }
            }
            else
            {
                BarcodeText = "Ingen gyldig QR kode fundet";
                BarcodeButtonColor = "#479fd1";
            }

            OnPropertyChanged(nameof(BarcodeText));
        }
    }

    public QrScannerViewModel()
    {
        // Settings for barcode/qr scanner
        BarCodeOptions = new()
        {
            AutoRotate = true,
            PossibleFormats = { BarcodeFormat.QR_CODE },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };

        BarcodeText = "Ingen gyldig QR kode fundet";
        BarcodeButtonColor = "#479fd1";
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
    private async Task PackageDetail(string barcodeText)
    {
        try
        {
            // Get package id from the barcode text and tryParse it to get an int
            if (Int32.TryParse(GetPackageId(barcodeText), out var id))
            {
                // Get package details 
                Package packageDetails = await api.getAsyncPackage(id);
            
                var navigationParameter = new Dictionary<string, object>
                {
                    { "PackageDetails", packageDetails }
                };

                // Go to the package view page and parse the package along with it
                await Shell.Current.GoToAsync($"{nameof(PackageView)}", navigationParameter);
            }
            else
            {
                // Display error to the user 
                await Shell.Current.DisplayAlert(
                    "Ugyldig QR kode",
                    "Pakken er ugyldig, prøv venligst at scan QR koden igen",
                    "Ok"
                );
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }

    static string GetPackageId(string input)
    {
        // The package should be formatted: <package>PACKAGE_ID<package>
        // Use a regular expression to extract the content inside the <package> tags
        Match match = Regex.Match(input, @"<package>(.*?)<package>");
        
        // If we get a match return the id else we return a empty string
        return match.Success ? match.Groups[1].Value : string.Empty;
    }
}