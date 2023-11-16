using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace hf4_app.ViewModel;

// For package parameter 
[QueryProperty("Package", "Package")]
public partial class PackageViewModel : ObservableObject
{
  [ObservableProperty] private string package;

  [RelayCommand]
  private static async Task GoBack()
  {
    await Shell.Current.GoToAsync("..");
  }
}