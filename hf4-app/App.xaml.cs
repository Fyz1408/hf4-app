﻿using hf4_app.Views;

namespace hf4_app;

public partial class App : Application
{
  public App()
  {
    InitializeComponent();

    MainPage = new Login();
  }
}

