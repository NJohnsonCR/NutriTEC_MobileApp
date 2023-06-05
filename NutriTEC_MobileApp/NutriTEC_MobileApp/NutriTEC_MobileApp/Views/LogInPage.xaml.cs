using Newtonsoft.Json;
using NutriTEC_MobileApp.API_Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriTEC_MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public static UserReturnModel CURRENTUSER;
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string email = txtUsername.Text;
            string password = txtPassword.Text;

            UserModel user = new UserModel();
            user.email = email;
            user.password = password;

            var baseAddress = new Uri("http://nutritec-api.azurewebsites.net");
            using (var httpclient = new HttpClient {BaseAddress = baseAddress })
            {
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxx");
                
                using (var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"))
                {
                    using (var response = await httpclient.PostAsync("/api/auth_client", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (user.password == "1234")
                        {
                            await Navigation.PushAsync(new HomePage());
                        }
                        else
                        {
                            await DisplayAlert("Alert", "The values provided don't match with any NutriTEC user.", "Understood");
                        }
                    }
                }   
            }

            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            System.Console.WriteLine("Hit register button" );

            Navigation.PushAsync(new RegisterPage());
        }
    }
}