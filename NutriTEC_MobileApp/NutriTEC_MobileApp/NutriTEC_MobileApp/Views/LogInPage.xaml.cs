using NutriTEC_MobileApp.API_Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            string email = txtUsername.Text;

            System.Console.WriteLine("The email is: " + email);
            string password = txtPassword.Text;
            System.Console.WriteLine("The password is: " + password);

            UserModel user = new UserModel();
            user.email = email;
            user.password = password;
            System.Console.WriteLine("Email: " + user.email);
            System.Console.WriteLine("Password: " + user.password);
            bool result = Services.UserService.ValidateUserAsyc(user).Result;
            System.Console.WriteLine("CUM PASE EL SERVICE ");

            if (result)
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Error", "Username or Password is incorrect!", "OK");
            }
            /*
            if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Error", "Username or Password is incorrect!", "OK");
            }
            */
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            System.Console.WriteLine("Hit register button" );

            Navigation.PushAsync(new RegisterPage());
        }
    }
}