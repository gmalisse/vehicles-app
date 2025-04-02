namespace VehiclesApp.Pages;

public partial class VehicleCreate : ContentPage
{
	public VehicleCreate()
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