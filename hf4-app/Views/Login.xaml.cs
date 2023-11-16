using hf4_app.ViewModel;

namespace hf4_app.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel loginVM)
	{
		InitializeComponent();
		BindingContext = loginVM;
	}
}