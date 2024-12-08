using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            
            InitializeComponent();
        }
        string password, login;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (password == null)
            {
                await Application.Current.MainPage.DisplayAlert("Внимание","вы не заригестрированы!","ок");
            }
            if (usernameEntry.Text == login && passwordEntry.Text == password)
            {
                await Navigation.PushAsync(new Tab());
                
            }
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            if (usernameEntry.Text != null && passwordEntry.Text != null)
            {
                password = passwordEntry.Text;
                login = usernameEntry.Text;

            }
        }
    }
}