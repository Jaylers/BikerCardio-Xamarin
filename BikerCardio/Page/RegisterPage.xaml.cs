using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BikerCardio.Page
{
    public partial class RegisterPage : ContentPage
    {
        private String _messageText = "";
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegButton_OnClicked(object sender, EventArgs e)
        {
            if (Attempt())
            {
                DisplayAlert("", "Registered successfully!", "OK");
            }
        }

        private void ResetButton_OnClicked(object sender, EventArgs e)
        {
            EmailText.Text = "";
            PasswordText.Text = "";
            RePasswordText.Text = "";
        }

        public Boolean Attempt()
        {
            if (IsEmail())
            { if (IsTrustPassword()) { return true; } }
            DisplayAlert("", _messageText, "Re try");
            return false;
        }

        public Boolean IsEmail()
        {
            if (EmailText.Text.Contains("@"))
            { return true; }
            _messageText = "Invalid Email!";
            return false;
        }

        public Boolean IsTrustPassword()
        {
            if (PasswordText.Text.Length >= 6)
            {
                if (PasswordText.Text == RePasswordText.Text)
                { return true; }
                else
                { _messageText = "Passwords don't match!"; return false; }
            }
            _messageText = "Your password is too short!";
            return false;
        }
    }
}
