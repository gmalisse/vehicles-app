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

    private async void BtnUpdateBrand(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BrandUpdate());
    }

    private async void BtnDeleteBrand(object sender, EventArgs e)
    {
        await DisplayAlert(
            "EXCLUIR",
            "Tem certeza que deseja excluir permanentemente o item de id {id}?", "Não", "Sim");
    }
}