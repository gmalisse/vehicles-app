using System.Collections.ObjectModel;
using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class VehicleMain : ContentPage
{
    ObservableCollection<Vehicle> list = new ObservableCollection<Vehicle>();

    public VehicleMain()
    {
        InitializeComponent();
        listVehicles.ItemsSource = list;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        list.Clear();
        List<Vehicle> tmp = await App.VehicleDb.GetAll();

        foreach (Vehicle item in tmp)
        {
            list.Add(item);
        }
    }

    private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        list.Clear();

        List<Vehicle> tmp = await App.VehicleDb.Search(q);

        foreach (Vehicle item in tmp)
        {
            list.Add(item);
        }
    }

    private async void BtnAddVehicle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VehicleCreate());
    }

    private async void BtnUpdateVehicle(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var selectedVehicle = button?.BindingContext as Vehicle;

        if (selectedVehicle != null)
        {
            await Navigation.PushAsync(new VehicleUpdate(selectedVehicle));
        }
    }

    private async void BtnDeleteVehicle(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var selectedVehicle = button?.BindingContext as Vehicle;

        if (selectedVehicle != null)
        {
            bool confirm = await DisplayAlert(
                "Excluir",
                $"Tem certeza que deseja excluir a marca \"{selectedVehicle.Name}\"?",
                "Sim", "Cancelar");

            if (confirm)
            {
                await App.VehicleDb.Delete(selectedVehicle.Id);
                list.Remove(selectedVehicle);
            }
        }
    }
}