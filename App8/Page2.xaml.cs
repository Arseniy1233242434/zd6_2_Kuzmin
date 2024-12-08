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
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
           
            InitializeComponent();
        }
        async void ShowErrorMessage(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", message, "OK");
        }
        private void ButtonClicked(object sender, EventArgs e)
        {
            if (Sum.Text != null && Date.Text != null && Type.SelectedItem != null)
            {
                double A = double.Parse(Sum.Text);
                int LT = int.Parse(Date.Text);
                double Rate = Slider.Value;
                string PT = Type.SelectedItem.ToString();

                if (A >= 10000 && A <= 10000000)
                {
                    if (LT >= 1 && LT <= 360)
                    {

                        double month = 0;
                        double t = 0;
                        double over = 0;

                        if (PT == "Аннуитетный")
                        {

                            double monthRate = Rate / 100 / 12;
                            month = A * (monthRate * Math.Pow(1 + monthRate, LT)) / (Math.Pow(1 + monthRate, LT) - 1);
                            t = month * LT;
                            over = t - A;
                            MonthPay.Text = $"{month:F2} руб.";

                        }
                        else if (PT == "Дифференцированный")
                        {

                            double monthRate = Rate / 100 / 12;
                            double p = A / LT;
                            double first = p + (A * monthRate);
                            month = first;

                            t = 0;
                            for (int i = 0; i < LT; i++)
                            {
                                double ip = (A - (p * i)) * monthRate;
                                t += p + ip;
                            }
                            over = t - A;
                            MonthPay.Text = $"...";

                        }
                        Total.Text = $"{t:F2} руб.";
                        OverPay.Text = $"{over:F2} руб.";
                    }
                    else ShowErrorMessage("Срок кредита не меньше 1 и не больше 360.");
                }
                else ShowErrorMessage("Сумма не меньше 10000 и не больше 10 000 000.");
            }
            else ShowErrorMessage("Поля не заполнены");
        }
    }
}