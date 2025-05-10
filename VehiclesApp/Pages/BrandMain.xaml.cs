using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class BrandMain : ContentPage
{
    ObservableCollection<Brand> list = new ObservableCollection<Brand>();

    public BrandMain()
    {
		InitializeComponent();
        listBrands.ItemsSource = list;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        list.Clear();
        List<Brand> tmp = await App.Db.GetAll();

        foreach (Brand item in tmp)
        {
            list.Add(item);
        }
    }
    private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        list.Clear();

        List<Brand> tmp = await App.Db.Search(q);

        foreach (Brand item in tmp)
        {
            list.Add(item);
        }
    }

    private async void BtnAddBrand(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new BrandCreate());
	}

    private async void BtnUpdateBrand(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var selectedBrand = button?.BindingContext as Brand;

        if (selectedBrand != null)
        {
            await Navigation.PushAsync(new BrandUpdate(selectedBrand));
        }
    }

    private async void BtnDeleteBrand(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var selectedBrand = button?.BindingContext as Brand;

        if (selectedBrand != null)
        {
            bool confirm = await DisplayAlert(
                "Excluir",
                $"Tem certeza que deseja excluir a marca \"{selectedBrand.Name}\"?",
                "Sim", "Cancelar");

            if (confirm)
            {
                await App.Db.Delete(selectedBrand.Id); 
                list.Remove(selectedBrand); 
            }
        }
    }
}