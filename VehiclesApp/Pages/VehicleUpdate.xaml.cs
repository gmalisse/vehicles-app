using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class VehicleUpdate : ContentPage
{
    private Vehicle _vehicle;

    public VehicleUpdate(Vehicle vehicle)
    {
        InitializeComponent();
        _vehicle = vehicle;

        etrId.Text = vehicle.Id.ToString();
        etrName.Text = vehicle.Name;
        etrFabYear.SelectedItem = vehicle.ManufacturingDate.ToString();
        etrModelYear.SelectedItem = vehicle.ModelDate.ToString();
        etrBrand.SelectedItem = vehicle.Brand.ToString();
        editorObs.Text = vehicle.Observation;
    }

    private async void BtnUpdateClicked(object sender, EventArgs e)
    {
        _vehicle.Name = etrName.Text;
        _vehicle.ManufacturingDate = int.Parse(etrFabYear.SelectedItem.ToString());
        _vehicle.ModelDate = int.Parse(etrModelYear.SelectedItem.ToString());
        _vehicle.Brand = etrBrand.SelectedItem.ToString();
        _vehicle.Observation = editorObs.Text;

        await App.VehicleDb.Update(_vehicle);
        await Navigation.PopAsync();
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