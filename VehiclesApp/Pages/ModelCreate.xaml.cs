using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class ModelCreate : ContentPage
{
	public ModelCreate()
	{
		InitializeComponent();
	}

    private async void BtnInserirClicked(object sender, EventArgs e)
    {
        try
        {
            Model model = new Model
            {
                Name = etrName.Text,
                Observation = editorObs.Text
            };

            await App.ModelDb.Insert(model);
            await DisplayAlert("Sucesso!", "Registro inserido", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops...", ex.Message, "OK");
        }
    }

    public void BtnClear(object sender, EventArgs e)
    {
        etrName.Text = "";
        editorObs.Text = "";
    }
}