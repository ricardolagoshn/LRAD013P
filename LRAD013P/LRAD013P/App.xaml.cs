using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LRAD013P
{
    public partial class App : Application
    {

        static Controllers.DBEmple dBEmple;

        public static Controllers.DBEmple dbemple
        {
            get 
            {
                if (dBEmple == null)
                {
                    String DBName = "emple.db3";
                    String PathDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBName);
                    dBEmple = new Controllers.DBEmple(PathDB);
                }

                return dBEmple;
            }

        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PagePrincipal());
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
