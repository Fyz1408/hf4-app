using hf4_app.Utillities;
using hf4_app.ViewModel;

namespace hf4_app.Views;

public partial class PackageView : ContentPage
{
    public PackageView()
    {
        InitializeComponent();
        BindingContext = ViewModelLocator.PackageViewModel;
    }


}