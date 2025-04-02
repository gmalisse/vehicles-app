namespace VehiclesApp.Pages;

public partial class ModelUpdate : ContentPage
{
	public ModelUpdate()
	{
		InitializeComponent();
	}

    public void BtnClear(object sender, EventArgs e)
    {
        etrName.Text = "";
        editorObs.Text = "";
    }
}