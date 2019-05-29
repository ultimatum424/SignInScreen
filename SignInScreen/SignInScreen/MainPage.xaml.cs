using Newtonsoft.Json.Linq;
using SignInScreen.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SignInScreen
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        private ILoginApi api;
        public MainPage()
        {
            InitializeComponent();

            api = new ApiFactory().Create();
        }

        public async void OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        private void FacebookButtonOnClick(object sender, EventArgs e)
        {
            OpenBrowser(new Uri("https://ru-ru.facebook.com/"));
        }

        private void LinkedinButtonOnClick(object sender, EventArgs e)
        {
            OpenBrowser(new Uri("https://ru.linkedin.com/"));
        }

        private void TwitterButtonOnClick(object sender, EventArgs e)
        {
            OpenBrowser(new Uri("https://twitter.com/?lang=ru"));
        }

        private void OnSignInButtonClick(object sender, EventArgs e)
        {
            var loginForm = new LoginEntity
            {
                Login = "peter@klaven",
                Password = "cityslicka"
               // Login = main_page_login.Text,
                //Password = main_page_password.Text
            };

            main_page_loading_bar.IsRunning = true;
            main_page_button.IsEnabled = false;
            main_page_login.IsEnabled = false;
            main_page_password.IsEnabled = false;

            SingIn(loginForm);

        }

        private async void SingIn(LoginEntity loginForm)
        {
            var result = await api.TryToLogin(loginForm);
            main_page_loading_bar.IsRunning = false;
            main_page_button.IsEnabled = true;
            main_page_login.IsEnabled = true;
            main_page_password.IsEnabled = true;
            if (result.IsSuccessStatusCode)
            {
                OnDisplayAlertSucsess();
            } else
            {
                string errorMessage = await result.Content.ReadAsStringAsync();
                var s = JObject.Parse(errorMessage);
                OnDisplayAlertError(s["error"].ToString());
            }
        }

        private async void OnDisplayAlertError(string errorMessage)
        {
            await DisplayAlert("Error Sign In", errorMessage, "OK");
        }

        private async void OnDisplayAlertSucsess()
        {
            await DisplayAlert("Sucsess", "You successfully logged in ", "OK");
        }
    }
}
