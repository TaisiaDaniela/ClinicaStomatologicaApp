using System;
using ClinicaStomatologicaApp.DataB;
using System.IO;
namespace ClinicaStomatologicaApp
{
    public partial class App : Application
    {
        static ClinicaStomatologicaDatabase database;

        public static ClinicaStomatologicaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ClinicaStomatologicaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ClinicaStomatologicaDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}