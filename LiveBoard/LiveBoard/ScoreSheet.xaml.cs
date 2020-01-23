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
    public partial class ScoreSheet : ContentPage
    {
        int satzA=0, satzB=0;
        int PlayerOneScore = 0;
        int PlayerTwoScore = 0;
        List<MyUndo> MyThisUndo = new List<MyUndo> { };
        public ScoreSheet()
        {
            InitializeComponent();
            // PlayerTwo.CornerRadius = 20;

       
        }

        private void PlayerOne_Clicked(object sender, EventArgs e)
        {
            PlayerOneScore++;
            if (PlayerOneScore > 99) PlayerOne.FontSize = 200;
            PlayerOne.Text = PlayerOneScore.ToString();
            MyThisUndo.Add(new MyUndo() { Id = 1, Zahl = 1 });
             
            if (MyThisUndo.Count != 0)
                Undo.IsEnabled = true;
        }

        private void PlayerTwo_Clicked(object sender, EventArgs e)
        {
            PlayerTwoScore++;
            if (PlayerTwoScore > 99) PlayerTwo.FontSize = 200;
            PlayerTwo.Text = PlayerTwoScore.ToString();

            MyThisUndo.Add(new MyUndo() { Id = 2, Zahl = 1 });

            if (CheckWin(PlayerTwoScore))
            {
                PlayerTwo.IsEnabled = true;
            }
            else PlayerTwo.IsEnabled = false;

            if (MyThisUndo.Count != 0)
                Undo.IsEnabled = true;

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (MyThisUndo.Count > 0)
            {
                switch (MyThisUndo.ElementAt(MyThisUndo.Count - 1).Id)
                {
                    case 1:
                        PlayerOneScore = PlayerOneScore - MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        PlayerOne.Text = PlayerOneScore.ToString();

                        break;
                    case 2:
                        PlayerTwoScore = PlayerTwoScore - MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        PlayerTwo.Text = PlayerTwoScore.ToString();


                        break;
                    default:
                        Console.WriteLine("Other");
                        break;
                }
                MyThisUndo.RemoveAt(MyThisUndo.Count - 1);
                if (MyThisUndo.Count == 0)
                    Undo.IsEnabled = false;
               
                
            }

        }
        public bool CheckWin(int a)
        {
            if (a < 4)
                return true;
            else return false;
        }
    }
}