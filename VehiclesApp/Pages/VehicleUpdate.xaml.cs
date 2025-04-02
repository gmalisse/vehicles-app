namespace VehiclesApp.Pages;

public partial class VehicleUpdate : ContentPage
{
	public VehicleUpdate()
	{
		InitializeComponent();
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