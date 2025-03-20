namespace VehiclesApp.Pages;

public partial class ModelMain : ContentPage
{
	public ModelMain()
	{
		InitializeComponent();
	}

    private async void BtnAddModel(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ModelCreate());
    }
}