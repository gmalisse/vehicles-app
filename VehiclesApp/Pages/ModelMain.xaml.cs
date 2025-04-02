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

    private async void BtnUpdateModel(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ModelUpdate());
    }

    private async void BtnDeleteModel(object sender, EventArgs e)
    {
        await DisplayAlert(
            "EXCLUIR",
            "Tem certeza que deseja excluir permanentemente o item de id {id}?", "Não", "Sim");
    }
}