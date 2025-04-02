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

    private async void BtnUpdateVehicle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VehicleUpdate());
    }

    private async void BtnDeleteVehicle(object sender, EventArgs e)
    {
        await DisplayAlert(
            "EXCLUIR",
            "Tem certeza que deseja excluir permanentemente o item de id {id}?", "Não", "Sim");
    }
}