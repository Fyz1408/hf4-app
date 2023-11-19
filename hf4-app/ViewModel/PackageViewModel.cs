using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.Models;
using hf4_app.service;

namespace hf4_app.ViewModel;

// For package parameter 
[QueryProperty("PackageDetails", "PackageDetails")]
public partial class PackageViewModel : ObservableObject
{
  private readonly webHandler api = new();
  
  [ObservableProperty] 
  private ObservableCollection<PackageEvents> packageEvents = new();

  private Package packageDetails;
  public Package PackageDetails
  {
    get => packageDetails;
    set
    {
      Task.Run(async () => await loadPackageEvents(value.Id));
      SetProperty(ref packageDetails, value);
    }
  }
  
  public PackageViewModel()
  {
    Task.Run(async () => await loadPackageEvents(packageDetails.Id));
  }


  [RelayCommand]
  private static async Task GoBack()
  {
    // Return to QR scanner page
    await Shell.Current.GoToAsync("..");
  }
  
  private async Task loadPackageEvents(int packageId)
  {
    
    //var apiData = await api.getAsyncPackageEvent(packageId);
    //PackageEvents = new ObservableCollection<PackageEvents>(apiData);
    
    //PackageEvents.Add(new PackageEvents(1,packageId,DateTime.Today, 1));
  }
}