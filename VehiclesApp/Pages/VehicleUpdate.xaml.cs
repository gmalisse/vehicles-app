using System.Collections.ObjectModel;
using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class VehicleUpdate : ContentPage
{
    private Vehicle _vehicle;

    ObservableCollection<Brand> brandList = new ObservableCollection<Brand>();


    public VehicleUpdate(Vehicle vehicle)
    {
        InitializeComponent();
        picBrand.ItemsSource = brandList;
        picBrand.ItemDisplayBinding = new Binding("Name");
        _vehicle = vehicle;

        etrId.Text = vehicle.Id.ToString();
        etrName.Text = vehicle.Name;
        etrFabYear.SelectedItem = vehicle.ManufacturingDate.ToString();
        etrModelYear.SelectedItem = vehicle.ModelDate.ToString();
        picBrand.SelectedItem = vehicle.BrandId;
        editorObs.Text = vehicle.Observation;
    }

    protected override void OnAppearing()
    {
        loadBrands();
        var brand = this.BindingContext as Brand;
        picBrand.SelectedItem = brand;
    }
    private async void loadBrands()
    {
        List<Brand> tmp = await App.BrandDb.GetAll();
        brandList.Clear();
        foreach (Brand estado in tmp)
        {
            brandList.Add(estado);
        }
    }

    private async void BtnUpdateClicked(object sender, EventArgs e)
    {
        try
        {
            Brand brand = new Brand();
            brand = (Brand)picBrand.SelectedItem;

            Vehicle vehicle = new Vehicle
            {
                Id = _vehicle.Id,
                Name = etrName.Text,
                ManufacturingDate = int.Parse(etrFabYear.SelectedItem.ToString()),
                ModelDate = int.Parse(etrModelYear.SelectedItem.ToString()),
                BrandId = brand.Id,
                Observation = editorObs.Text
            };

            await App.VehicleDb.Update(vehicle);
            await DisplayAlert("Sucesso!", "Registro alterado", "OK");
            await Navigation.PopAsync();
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
        picBrand.SelectedIndex = -1;
    }
}