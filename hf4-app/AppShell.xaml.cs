﻿using hf4_app.Views;

namespace hf4_app;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();
    Routing.RegisterRoute(nameof(PackageView), typeof(PackageView));
    Routing.RegisterRoute(nameof(FrontPage), typeof(FrontPage));
    Routing.RegisterRoute(nameof(qrScannerView), typeof(qrScannerView));
  }    
}

