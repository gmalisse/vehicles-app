using VehiclesApp.Helpers;

namespace VehiclesApp
{
    public partial class App : Application
    {
        static BrandSQLiteHelper _brandDb;
        static ModelSQLiteHelper _modelDb;

        public static BrandSQLiteHelper BrandDb
        {
            get
            {
                if (_brandDb == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "vehicleapp_db.db3");

                    _brandDb = new BrandSQLiteHelper(path);
                }

                return _brandDb;
            }
        }

        public static ModelSQLiteHelper ModelDb
        {
            get
            {
                if (_modelDb == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "vehicleapp_db.db3");

                    _modelDb = new ModelSQLiteHelper(path);
                }

                return _modelDb;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
