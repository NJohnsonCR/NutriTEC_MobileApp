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
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_AddConsumption(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddConsumptionPage());
        }

        private void Button_AddProduct(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddProductPage());

        }
    }
}