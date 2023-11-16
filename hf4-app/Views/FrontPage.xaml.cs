using hf4_app.ViewModel;

namespace hf4_app.Views;

public partial class FrontPage : ContentPage
{
	public FrontPage(FrontPageViewModel frontPageVM)
	{
		InitializeComponent();
		BindingContext = frontPageVM;
	}
}