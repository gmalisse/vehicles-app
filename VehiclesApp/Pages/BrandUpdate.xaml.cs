using VehiclesApp.Models;
namespace VehiclesApp.Pages;

public partial class BrandUpdate : ContentPage
{

    private Brand _brand;

    public BrandUpdate(Brand brand)
    {

        InitializeComponent();
        _brand = brand;

        etrId.Text = brand.Id.ToString();
        etrName.Text = brand.Name;
        editorObs.Text = brand.Observation;
    }

    private async void BtnUpdateClicked(object sender, EventArgs e)
    {
        _brand.Name = etrName.Text;
        _brand.Observation = editorObs.Text;

        await App.BrandDb.Update(_brand);
        await Navigation.PopAsync(); 
    }

    private void btnClear_Clicked(object sender, EventArgs e)
    {
        etrName.Text = "";
        editorObs.Text = "";
    }
}