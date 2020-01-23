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
    public partial class EightNineTen : ContentPage
    {
        int PlayerOne = 97;
        int PlayerTwo = 0;
        List<MyUndo> MyThisUndo = new List<MyUndo> { };
        public EightNineTen()
        {
            InitializeComponent();
            PlayerO.FontSize = 240;
            PlayerT.FontSize = 240;
            PlayerO.Text = PlayerOne.ToString();
            MalSchauen.Text = MyThisUndo.Count.ToString();
            if (MyThisUndo.Count == 0)
                Undo.IsEnabled = false;
        }
        private void PlayerO_Clicked(object sender, EventArgs e)
        {
            PlayerOne++;
            PlayerO.Text = PlayerOne.ToString();
            MyThisUndo.Add(new MyUndo() { Id = 1, Zahl = 1 });
            MalSchauen.Text = MyThisUndo.Count.ToString();
            if (MyThisUndo.Count != 0)
                Undo.IsEnabled = true;

        }

        private void PlayerT_Clicked(object sender, EventArgs e)
        {
            PlayerTwo++;
            PlayerT.Text = PlayerTwo.ToString();

            MyThisUndo.Add(new MyUndo() { Id = 2, Zahl = 1 });
            MalSchauen.Text = MyThisUndo.Count.ToString();

            if (MyThisUndo.Count != 0)
                Undo.IsEnabled = true;
        }

        private void Undo_Clicked(object sender, EventArgs e)
        {

            MalSchauen.Text = MyThisUndo.Count.ToString();
            if (MyThisUndo.Count > 0)
            {
                switch (MyThisUndo.ElementAt(MyThisUndo.Count - 1).Id)
                {
                    case 1:
                        PlayerOne = PlayerOne - MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        PlayerO.Text = PlayerOne.ToString();

                        break;
                    case 2:
                        PlayerTwo = PlayerTwo - MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        PlayerT.Text = PlayerTwo.ToString();


                        break;
                    default:
                        Console.WriteLine("Other");
                        break;
                }
                MyThisUndo.RemoveAt(MyThisUndo.Count - 1);
                if (MyThisUndo.Count == 0)
                    Undo.IsEnabled = false;
                MalSchauen.Text = MyThisUndo.Count.ToString();
                //Jetzt schreibe meine Liste neu!
            }
        }
    }
}