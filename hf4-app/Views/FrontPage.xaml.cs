using hf4_app.Utillities;
using hf4_app.ViewModel;

namespace hf4_app.Views;

public partial class FrontPage : ContentPage
{
    public FrontPage()
    {
        InitializeComponent();
        this.BindingContext = ViewModelLocator.FrontPageViewModel;
    }
}