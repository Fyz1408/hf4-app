using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hf4_app.Models;

namespace hf4_app.ViewModel;

// For package parameter 
[QueryProperty("Package", "Package")]
public partial class PackageViewModel : ObservableObject
{
  [ObservableProperty] private string package;

  // Test data is temporary until api is integrated 
  [ObservableProperty] private ObservableCollection<PackageModel.PackageEvent> packageEvents = new()
  {
    new PackageModel.PackageEvent()
    {
      Id = 1,
      WarehouseId = 1,
      Timestamp = DateTime.UtcNow
    },
    new PackageModel.PackageEvent()
    {
      Id = 2,
      WarehouseId = 2,
      Timestamp = DateTime.UtcNow
    },
    new PackageModel.PackageEvent()
    {
      Id = 3,
      WarehouseId = 5,
      Timestamp = DateTime.UtcNow
    },
    new PackageModel.PackageEvent()
    {
      Id = 4,
      WarehouseId = 5,
      Timestamp = DateTime.UtcNow
    },
    new PackageModel.PackageEvent()
    {
      Id = 5,
      WarehouseId = 6,
      Timestamp = DateTime.UtcNow
    },
    new PackageModel.PackageEvent()
    {
      Id = 6,
      WarehouseId = 7,
      Timestamp = DateTime.UtcNow
    }
  };
  


  [RelayCommand]
  private static async Task GoBack()
  {
    // Return to QR scanner page
    await Shell.Current.GoToAsync("..");
  }
}