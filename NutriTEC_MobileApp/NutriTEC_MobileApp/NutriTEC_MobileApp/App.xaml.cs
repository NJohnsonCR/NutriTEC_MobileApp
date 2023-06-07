using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriTEC_MobileApp
{
    public partial class App : Application
    {
        /// <summary>
        /// Sets the first page to appear on the mobile app as the log in page.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.LogInPage())
            {
                BarBackgroundColor = Color.FromHex("#645fce"),
            };
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
