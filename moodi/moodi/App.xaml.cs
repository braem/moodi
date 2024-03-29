﻿using System;
using System.IO;
using Xamarin.Forms;
using moodi.Services;

namespace moodi
{
    public partial class App : Application
    {
        private static Database _database;
        public static Database Database { get { return _database; } }

        private static MoodImageStore _moodImageStore;
        public static MoodImageStore MoodImageStore { get { return _moodImageStore; } }

        public App()
        {
            InitializeComponent();

            if (_database == null)
            {
                _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MoodEntries.db3"));
            }

            if (_moodImageStore == null)
            {
                _moodImageStore = new MoodImageStore();
                _moodImageStore.Init();
            }

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
