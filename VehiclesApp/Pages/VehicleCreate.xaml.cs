using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class VehicleCreate : ContentPage
{
	public VehicleCreate()
	{
		InitializeComponent();
	}

    private async void BtnInserirClicked(object sender, EventArgs e)
    {
        try
        {
            Vehicle vehicle = new Vehicle
            {
                Name = etrName.Text,
                ManufacturingDate = int.Parse(etrFabYear.SelectedItem.ToString()),
                ModelDate = int.Parse(etrModelYear.SelectedItem.ToString()),
                Brand = etrBrand.SelectedItem.ToString(),
                Observation = editorObs.Text
            };

            await App.VehicleDb.Insert(vehicle);
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
        etrFabYear.SelectedIndex = -1;
        etrModelYear.SelectedIndex = -1;
        etrBrand.SelectedIndex = -1;
    }
}