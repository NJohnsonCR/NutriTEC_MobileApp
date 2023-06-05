using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NutriTEC_MobileApp.API_Models;
using NutriTEC_MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutriTEC_MobileApp.Services
{
    class UserService
    {
        public static string url = "http://nutritec-api.azurewebsites.net/api/auth_client ";
        public static async Task<bool>  ValidateUserAsyc(UserModel user) {
            HttpClient client = new HttpClient();
            var loginData = new Dictionary<string, string>
            {
                { "email", user.email },
                { "password", user.password }
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            try
            {
               var response = await client.PostAsync(url, jsonContent);
                var json = response.Content.ReadAsStringAsync().Result;
                APIUserModel inputUser = new APIUserModel();
                inputUser = JsonConvert.DeserializeObject<APIUserModel>(json);

                if(inputUser.result.name == null){
                    await Application.Current.MainPage.DisplayAlert("NutriTEC", "The data you filled with does not match with any NutriTEC user. Please verify your info and try again!", "OK");
                    return await Task.FromResult(false);

                }
                else
                {
                    NutriTEC_MobileApp.Views.LogInPage.CURRENTUSER = inputUser.result;
                    return await Task.FromResult(true);
                }

            }
            catch (Exception e)
            {
               await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                return await Task.FromResult(false);
            }
        }
    }
}
