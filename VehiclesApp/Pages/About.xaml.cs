namespace VehiclesApp.Pages;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();

	}

    private void btnRedirecionarLinkedin(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://br.linkedin.com/in/gustavo-malisse-b60a61260");
    }

    private void btnRedirecionarGithub(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://github.com/gmalisse");
    }
}