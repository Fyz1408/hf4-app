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
  
  [ObservableProperty] private ObservableCollection<Warehouse> warehouses = new();
  
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
    Task.Run(async () => await loadWarehouses());
  }

  [RelayCommand]
  private static async Task GoBack()
  {
    // Return to QR scanner page
    await Shell.Current.GoToAsync("..");
  } 
  
  [RelayCommand]
  private async Task updateWarehouse()
  {
    
  }
  
  private async Task loadWarehouses()
  {
    Warehouses.Clear();
    var apiData = await api.getListAsyncWarehouse();
      
    foreach (var warehouse in apiData)
    {
      Warehouses.Add(warehouse);
    }
  }
  
  private async Task loadPackageEvents(int packageId)
  {
    PackageEvents.Clear();
    var apiData = await api.getListAsyncPackage(packageId);
      
    foreach (var packageEvent in apiData)
    {
      PackageEvents.Add(packageEvent);
    }
  }
}