using moodi.Services;
﻿using System;
using System.IO;
using Xamarin.Forms;

namespace moodi
{
    public partial class App : Application
    {
        private static MoodEntryDatabase _database;
        public static MoodEntryDatabase Database { get { return _database; } }

        public App()
        {
            InitializeComponent();
            if (_database == null)
            {
                _database = new MoodEntryDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MoodEntries.db3"));
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
