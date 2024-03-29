﻿using Newtonsoft.Json;
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
        public static string CURRENTUSER;
        /// <summary>
        /// Initializes the login page and its components.
        /// </summary>
        public LogInPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button event used for authenticating the user using a get method from the API.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string email = txtUsername.Text;
            string password = txtPassword.Text;

            UserModel user = new UserModel();
            user.email = email;
            user.password = password;

            string baseAddress = "http://nutritec-api.azurewebsites.net/api/auth_client_mobile/";

            string parameterEmail = email.Replace("@", "%40");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseAddress + parameterEmail + "/" + password);


            if (response.IsSuccessStatusCode) {
                CURRENTUSER = email;
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Username or password are incorrect!", "OK");   
            }

        }

        /// <summary>
        /// The button event used for navigating to the register page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            System.Console.WriteLine("Hit register button" );

            Navigation.PushAsync(new RegisterPage());
        }
    }
}