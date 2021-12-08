using AppMochilando.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMochilando.Api;
using System.IO;

namespace AppMochilando
{
    public partial class App : Application
    {
        static SqLiteDataBaseHelper database;
        public static SqLiteDataBaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SqLiteDataBaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamAppMochilando.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
