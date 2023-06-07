using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriTEC_MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Initializes the HomePage and its components.
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the AddConsumptionPage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddConsumption(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddConsumptionPage());
        }

        /// <summary>
        /// Navigate to the AddProductPage.
        /// </summary>
        private void Button_AddProduct(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddProductPage());

        }
    }
}