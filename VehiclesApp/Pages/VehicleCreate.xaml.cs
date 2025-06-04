using System.Collections.ObjectModel;
using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class VehicleCreate : ContentPage
{
    ObservableCollection<Brand> brandList = new ObservableCollection<Brand>();

    public VehicleCreate()
	{
		InitializeComponent();
        picBrand.ItemsSource = brandList;
        picBrand.ItemDisplayBinding = new Binding("Name");
    }

    protected override void OnAppearing()
    {
        loadBrands();
    }

    private async void loadBrands()
    {
        List<Brand> tmp = await App.BrandDb.GetAll();
        brandList.Clear();
        foreach (Brand brand in tmp)
        {
            brandList.Add(brand);
        }
    }


    private async void BtnInserirClicked(object sender, EventArgs e)
    {
        try
        {
            Brand brand = new Brand();
            brand = (Brand)picBrand.SelectedItem;

            Vehicle vehicle = new Vehicle
            {
                Name = etrName.Text,
                ManufacturingDate = int.Parse(etrFabYear.SelectedItem.ToString()),
                ModelDate = int.Parse(etrModelYear.SelectedItem.ToString()),
                BrandId = brand.Id,
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
        picBrand.SelectedIndex = -1;
    }
}