using System.Text.RegularExpressions;
using VehiclesApp.Models;
using VehiclesApp.Pages;

namespace VehiclesApp.Pages;

public partial class BrandCreate : ContentPage
{
    
	public BrandCreate()
	{
		InitializeComponent();
	}

    private async void BtnInserirClicked(object sender, EventArgs e)
    {
        try
        {
            Brand marca = new Brand
            {
                Name = etrName.Text,
                Observation = editorObs.Text
            };

            await App.Db.Insert(marca);
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