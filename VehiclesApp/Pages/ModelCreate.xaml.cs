namespace VehiclesApp.Pages;

public partial class ModelCreate : ContentPage
{
	public ModelCreate()
	{
		InitializeComponent();
	}

    public void BtnClear(object sender, EventArgs e)
    {
        etrName.Text = "";
        editorObs.Text = "";
    }
}