using VehiclesApp.Models;
namespace VehiclesApp.Pages;

public partial class ModelUpdate : ContentPage
{
    private Model _model;

    public ModelUpdate(Model model)
    {
        InitializeComponent();
        _model = model;

        etrId.Text = model.Id.ToString();
        etrName.Text = model.Name;
        editorObs.Text = model.Observation;
    }

    private async void BtnUpdateClicked(object sender, EventArgs e)
    {
        _model.Name = etrName.Text;
        _model.Observation = editorObs.Text;

        await App.ModelDb.Update(_model);
        await Navigation.PopAsync();
    }

    public void BtnClear(object sender, EventArgs e)
    {
        etrName.Text = "";
        editorObs.Text = "";
    }
}