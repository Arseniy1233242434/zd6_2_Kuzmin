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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
            Data();
        }
        public void Data()
        {
            DateTime currentDate = DateTime.Now;
            DateLabel.Text = currentDate.ToString("dd MMMM yyyy");
        }
    }
}