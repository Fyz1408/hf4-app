using hf4_app.Views;

namespace hf4_app;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();
    
    Routing.RegisterRoute(nameof(PackageView), typeof(PackageView));
  }
}

