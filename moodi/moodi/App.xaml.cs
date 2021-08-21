using System;
using System.IO;
using Xamarin.Forms;
using moodi.Services;

namespace moodi
{
    public partial class App : Application
    {
        private static Database _database;
        public static Database Database { get { return _database; } }

        public App()
        {
            InitializeComponent();
            if (_database == null)
            {
                _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MoodEntries.db3"));
            }
            MoodImageStore.Init();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
