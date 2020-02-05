using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using TouchTracking;

using SkiaSharp;
//using SkiaSharp.Views.Forms;
namespace LiveBoard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTab : TabbedPage
    {
        public MyTab()
        {
            InitializeComponent();
        }
    }
}