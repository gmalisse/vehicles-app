namespace VehiclesApp.Pages;

public partial class VehicleMain : ContentPage
{
	public VehicleMain()
	{
		InitializeComponent();
	}

    private async void BtnAddVehicle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VehicleCreate());
    }
}