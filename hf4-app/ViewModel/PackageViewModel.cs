using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.Models;
using hf4_app.service;

namespace hf4_app.ViewModel;

// For package parameter 
//[QueryProperty("PackageId", "PackageId")]
[QueryProperty("PackageDetails", "PackageDetails")]
public partial class PackageViewModel : ObservableObject
{
  [ObservableProperty] private Package packageDetails;

  [ObservableProperty] private int packageId;
  [ObservableProperty] private string senderAddress = "Ingen afsender adresse";
  [ObservableProperty] private string destinationAddress = "Ingen modtager adresse";
  [ObservableProperty] private string packageStatus = "?";
  [ObservableProperty] private bool packageDelivered;
  [ObservableProperty] private bool packageFinished;

  private readonly webHandler api = new();

  // Test data is temporary until api is integrated 
  [ObservableProperty] private ObservableCollection<PackageModel.PackageEvent> packageEvents;

  public PackageViewModel()
  {
    if (packageDetails != null)
    {
      packageId = packageDetails.Id;
      senderAddress = packageDetails.SenderAddress;
      destinationAddress = packageDetails.DestinationAddress;
      packageDelivered = packageDetails.IsDelivered;
      packageFinished = packageDetails.IsFinished;
    }
  }

  // Returns to QR scanner
  [RelayCommand]
  private static async Task GoBack()
  {
    // Return to QR scanner page
    await Shell.Current.GoToAsync("..");
  }

  // Get package from the package ID 
  /*[RelayCommand]
  private async Task GetPackageDetails()
  {
    try
    {
      Int32.TryParse(PackageId, out var packageIdInt);

      // Get package details
      Package packageDetails = await api.getAsyncPackage(packageIdInt);

      packageDetails.SenderAddress = senderAddress;
      packageDetails.DestinationAddress = destinationAddress;


    }
    catch (Exception ex)
    {
      // Exception
    }
  }*/
}