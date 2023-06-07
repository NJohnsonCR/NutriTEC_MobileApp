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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            string name = nameEntry.Text;
            string lastName1 = lname1Entry.Text;
            string lastName2 = lname2Entry.Text;
            string country = countryEntry.Text;
            string calorie = caloriegoalEntry.Text;
            string height = heightEntry.Text;
            string weight = weigthEntry.Text;
            string date = startDatePicker.Date.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(lastName1) || !string.IsNullOrEmpty(lastName2) || !string.IsNullOrEmpty(country) || !string.IsNullOrEmpty(calorie) || !string.IsNullOrEmpty(height) || !string.IsNullOrEmpty(weight) || !string.IsNullOrEmpty(date))
            {
                string baseAddress = "http://nutritec-api.azurewebsites.net/api/add_client_mobile/";

                string parameterEmail = email.Replace("@", "%40");

                string parameterName = name.Replace(" ", "%20");

                string parameterCountry = country.Replace(" ", "%20");

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(baseAddress + parameterName + "/" + lastName1 + "/" + lastName2 + "/" + date + "/" + weight + "/" + height + "/" + parameterEmail + "/" + password + "/" + parameterCountry + "/" + calorie);


                if (response.IsSuccessStatusCode)
                {
                    await Navigation.PushAsync(new LogInPage());
                }
                else
                {
                    await DisplayAlert("Error", "Failed to add client!", "OK");
                }

            }
            else
            {
                await DisplayAlert("Error", "All entries must be full! ", "OK");
            }

        }
    }
}