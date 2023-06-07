using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriTEC_MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        /// <summary>
        /// Initializes the add product page and its components.
        /// </summary>
        public AddProductPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button event that adds a product to the database using a get method with the parameters of the product.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void  Button_Clicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string size = sizeEntry.Text;
            string calcium = calciumEntry.Text;
            string sodium = sodiumEntry.Text;
            string carbs = carbsEntry.Text;
            string fat = fatEntry.Text;
            string calories = caloriesEntry.Text;
            string iron = ironEntry.Text;
            string protein = proteinEntry.Text;
            if(!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(size) || !string.IsNullOrEmpty(calcium) || !string.IsNullOrEmpty(sodium) || !string.IsNullOrEmpty(carbs) || !string.IsNullOrEmpty(fat) || !string.IsNullOrEmpty(calories) || !string.IsNullOrEmpty(iron) || !string.IsNullOrEmpty(protein))
            {
                string baseAddress = "http://nutritec-api.azurewebsites.net/api/add_product_mobile/";

                string parameterName = name.Replace(" ", "%20");

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(baseAddress + parameterName + "/" + size + "/" + calcium + "/" + sodium + "/" + carbs + "/" + fat + "/" + calories + "/" + iron + "/" + protein);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Product added!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to add product!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please fill all the fields!", "OK");
            }

        }
    }
}