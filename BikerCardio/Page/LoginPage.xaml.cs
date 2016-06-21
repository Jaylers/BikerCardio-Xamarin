using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BikerCardio.Class;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BikerCardio.Page
{
    public partial class LoginPage : ContentPage
    {
        public Member[] User;
        public LoginPage()
        {
            InitializeComponent();
            connectToDB();
        }
        private void LogInButton_OnClicked(object sender, EventArgs e)
        {
            string email = EmailText.Text;
            string password = PasswordText.Text;
            bool check = checkLogin(email, password);
            if (check)
                DisplayAlert("Alert", "Login Success", "OK");
            else
                DisplayAlert("Alert", "Wrong username or password", "OK");
        }

        private void RegButton_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("GOGOGOG", "Register", "Acept");
        }
        private async void connectToDB()
        {
            waitActivityIndicator.IsRunning = true;
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("http://172.20.34.139/XamarinData/Member.php");

            var result = response.Content.ReadAsStringAsync().Result;
            waitActivityIndicator.IsRunning = false;
            if (string.IsNullOrEmpty(result))
                return;
            this.User = JsonConvert.DeserializeObject<Member[]>(result);
        }
        private bool checkLogin(string username, string password)
        {
            bool check = false;
            for (int i = 0; i < User.Length; i++)
                if (username == User[i].Username && password == User[i].Password)
                    return true;
            return check;
        }
    }
}
