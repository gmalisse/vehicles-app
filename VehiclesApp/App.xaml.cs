using VehiclesApp.Helpers;

namespace VehiclesApp
{
    public partial class App : Application
    {
        static BrandSQLiteHelper _db;

        public static BrandSQLiteHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "vehicleapp_db.db3");

                    _db = new BrandSQLiteHelper(path);
                }

                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
