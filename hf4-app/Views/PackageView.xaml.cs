using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hf4_app.Utillities;

namespace hf4_app.Views;

public partial class PackageView : ContentPage
{
  public PackageView()
  {
    InitializeComponent();
    BindingContext = ViewModelLocator.PackageViewModel;
  }
}