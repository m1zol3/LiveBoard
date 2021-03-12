using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiveBoard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySets : ContentPage
    {
        public MySets()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoreSheet());
        }
    }
}