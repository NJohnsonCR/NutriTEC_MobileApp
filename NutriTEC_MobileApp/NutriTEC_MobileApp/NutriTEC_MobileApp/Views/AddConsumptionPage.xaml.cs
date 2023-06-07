using Newtonsoft.Json;
using NutriTEC_MobileApp.API_Models;
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
    public partial class AddConsumptionPage : ContentPage
    {
        /// <summary>
        /// Initializes the page and its components.
        /// </summary>
        public AddConsumptionPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The search bar event that searches for a product in the database, call the get method, and displays it in the list view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void searchBarEntry_SearchButtonPressed(object sender, EventArgs e)
        {

            string entry = searchBarEntry.Text;
            
            ProductList productList = new ProductList();

            string baseAddress = "http://nutritec-api.azurewebsites.net/api/search_dish_mobile/";
            string parameterEntry = entry.Replace(" ", "%20");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseAddress + parameterEntry);


            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                productList = JsonConvert.DeserializeObject<ProductList>(content);

                myListView.ItemsSource = productList.result;

            }
            else
            {
                await DisplayAlert("Error", "Failed", "OK");
            }
            
        }
        /// <summary>
        /// The button event that adds the consumption to the database using a get method with the parameters introduced, and displays a message if it was successful or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            //meal time picker cant be null
            if (myListView.SelectedItem != null || !string.IsNullOrEmpty(mealTimePicker.SelectedItem.ToString()) || !string.IsNullOrEmpty(sizeEntry.Text))
            {
                ProductSearch product = (ProductSearch)myListView.SelectedItem;
                string mealTime = mealTimePicker.SelectedItem.ToString();
                string size = sizeEntry.Text;
                string id = LogInPage.CURRENTUSER;
                string parameterMealTime = mealTime.Replace(" ", "%20");
                DateTime currentDateTime = DateTime.Now;
                string  formattedDate = currentDateTime.ToString("yyyy-MM-dd");
                string baseAddress = "http://nutritec-api.azurewebsites.net/api/add_daily_intake_mobile/";
                HttpClient client = new HttpClient();
                var result = client.GetAsync(baseAddress + id + "/" + product.product_name + "/" + formattedDate + "/" + parameterMealTime + "/" + size).Result;
                if (result.IsSuccessStatusCode)
                {
                    DisplayAlert("Success", "Consumption added", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Failed", "OK");
                }


            }
            else
            {
                DisplayAlert("Error", "No product selected", "OK");
            }
        }
    }
}