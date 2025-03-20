namespace VehiclesApp.Pages;

public partial class BrandMain : ContentPage
{
	public BrandMain()
	{
		InitializeComponent();
	}

	private async void BtnAddBrand(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new BrandCreate());
	}
}