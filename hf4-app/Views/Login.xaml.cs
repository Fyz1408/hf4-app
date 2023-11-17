using hf4_app.Utillities;
using hf4_app.ViewModel;

namespace hf4_app.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        this.BindingContext = ViewModelLocator.LoginViewModel;
    }
}