using System;
using MobileApp.Data;
using System.IO;

namespace MobileApp
{
    public partial class App : Application
    {
        static EnrollmentDatabase database;
        public static EnrollmentDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   EnrollmentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Enrollment.db3"));
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
