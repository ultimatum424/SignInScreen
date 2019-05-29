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
            var loginForm = new LoginForm
            {
                Login = "peter@klaven",
                Password = "cityslicka"
               // Login = main_page_login.Text,
                //Password = main_page_password.Text
            };

            SingIn(loginForm);

        }

        private async void SingIn(LoginForm loginForm)
        {
            var result = await api.TryToLogin(loginForm).Result.Content.ReadAsStringAsync();
        }
    }
}
