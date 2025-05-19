using System.Collections.ObjectModel;
using VehiclesApp.Models;

namespace VehiclesApp.Pages;

public partial class ModelMain : ContentPage
{
    ObservableCollection<Model> list = new ObservableCollection<Model>();

    public ModelMain()
	{
		InitializeComponent();
        listModels.ItemsSource = list;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        list.Clear();
        List<Model> tmp = await App.ModelDb.GetAll();

        foreach (Model item in tmp)
        {
            list.Add(item);
        }
    }

    private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        list.Clear();

        List<Model> tmp = await App.ModelDb.Search(q);

        foreach (Model item in tmp)
        {
            list.Add(item);
        }
    }

    private async void BtnAddModel(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ModelCreate());
    }

    private async void BtnUpdateModel(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var selectedModel = button?.BindingContext as Model;

        if (selectedModel != null)
        {
            await Navigation.PushAsync(new ModelUpdate(selectedModel));
        }
    }

    private async void BtnDeleteModel(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var selectedModel = button?.BindingContext as Model;

        if (selectedModel != null)
        {
            bool confirm = await DisplayAlert(
                "Excluir",
                $"Tem certeza que deseja excluir a marca \"{selectedModel.Name}\"?",
                "Sim", "Cancelar");

            if (confirm)
            {
                await App.ModelDb.Delete(selectedModel.Id);
                list.Remove(selectedModel);
            }
        }
    }
}