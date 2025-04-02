namespace VehiclesApp.Pages;

public partial class BrandCreate : ContentPage
{
	public BrandCreate()
	{
		InitializeComponent();
	}

	public void BtnClear(object sender, EventArgs e)
	{
		etrName.Text = "";
		editorObs.Text = "";
	}
}