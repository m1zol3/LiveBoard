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
    public partial class Page1 : ContentPage
    {
        List<Distanz> MyDistanz = new List<Distanz> { };
        public Page1()
        {
         
            InitializeComponent();

        }

        async void ImageButton_Clicked(object sender, EventArgs e)
        {




        
            MyDistanz.Add(new Distanz() { WeiteA = 10, WeiteB = 9 });
            


       
           
          await Navigation.PushAsync(new ScoreSheet(MyDistanz.ElementAt(0).WeiteA, MyDistanz.ElementAt(0).WeiteB)); 

        }
    }
}