using Camera.MAUI;
using CommunityToolkit.Maui;
using hf4_app.ViewModel;
using hf4_app.Views;
using Microsoft.Extensions.Logging;

namespace hf4_app;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UseMauiCommunityToolkit()
      .UseMauiCameraView()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });
    
    builder.Services.AddSingleton<QrScannerView>();
    builder.Services.AddSingleton<QrScannerViewModel>();
    
    builder.Services.AddTransient<PackageView>();
    builder.Services.AddTransient<PackageViewModel>();

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }
}

