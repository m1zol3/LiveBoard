using System;
using System.Collections.Generic;
using System.Linq;
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

        int PlayerWeite = 0;
        public ScoreSheet( )
        {
            InitializeComponent();
            // Geht.SetBinding(Label.TextProperty, "a");
           // MyThisUndo.Add(new MyUndo() { Id = 1, Zahl = PlayerOneScore });
            MyThisUndo.Add(new MyUndo() { Id = 2, Zahl = PlayerTwoScore });
            PlayerOne.Text = PlayerOneScore.ToString();
            PlayerTwo.Text = PlayerTwoScore.ToString();
           // MeineWeite.Text = MyThisUndo.Count.ToString();
            PlayerWeite = 5;

        }

        public ScoreSheet(int data, int dataB)
        {
            InitializeComponent();
            // Geht.SetBinding(Label.TextProperty, "a");
           // MeineWeite.Text = MyThisUndo.Count.ToString();
           // MyThisUndo.Add(new MyUndo() { Id = 1, Zahl = PlayerOneScore });
            MyThisUndo.Add(new MyUndo() { Id = 2, Zahl = PlayerTwoScore });
            int a = dataB;
               // Gast.Text = a.ToString();
                PlayerWeite = dataB;
                MeineWeite.Text = "Race to: " + a.ToString();

        }

        private void PlayerOne_Clicked(object sender, EventArgs e)
        {
            MyThisUndo.Add(new MyUndo() { Id = 1, Zahl = PlayerOneScore });

            PlayerOneScore++;
           // if (PlayerOneScore > 99) PlayerOne.FontSize = 200;
            PlayerOne.Text = PlayerOneScore.ToString();
           
           // MeineWeite.Text = MyThisUndo.Count.ToString();

            if (CheckWin(PlayerOneScore))
            {

                PlayerOne.IsEnabled = true;

            }
            else {
                MyThisUndo.Add(new MyUndo() { Id = 3, Zahl = satzA });
                //PlayerOne.IsEnabled = false;
                satzA++;
                Satz.Text = satzA.ToString() + ":" + satzB.ToString();
           
                PlayerOneScore = 0;
                PlayerTwoScore = 0;
                PlayerOne.Text = PlayerOneScore.ToString();
                PlayerTwo.Text = PlayerTwoScore.ToString();
                MyThisUndo.Add(new MyUndo() { Id = 2, Zahl = PlayerTwoScore });
            }

            if (MyThisUndo.Count != 0)
                Undo.IsEnabled = true;
        }

        private void PlayerTwo_Clicked(object sender, EventArgs e)
        {
            MyThisUndo.Add(new MyUndo() { Id = 2, Zahl = PlayerTwoScore });
            PlayerTwoScore++;
            //if (PlayerTwoScore > 99) PlayerTwo.FontSize = 200;
            PlayerTwo.Text = PlayerTwoScore.ToString();

            
            //MeineWeite.Text = MyThisUndo.Count.ToString();
            if (CheckWin(PlayerTwoScore))
            {
                PlayerTwo.IsEnabled = true;
            }
            else {// PlayerTwo.IsEnabled = false;
                MyThisUndo.Add(new MyUndo() { Id = 4, Zahl = satzB });
                satzB++;
                Satz.Text = satzA.ToString() + ":" + satzB.ToString();
               
                PlayerTwoScore = 0;
                PlayerOneScore = 0;
                PlayerOne.Text = PlayerOneScore.ToString();
                MyThisUndo.Add(new MyUndo() { Id = 1, Zahl = PlayerOneScore });
                PlayerTwo.Text = PlayerTwoScore.ToString();
            }
           

            if (MyThisUndo.Count != 0)
                Undo.IsEnabled = true;

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
           // MeineWeite.Text = MyThisUndo.Count.ToString();
            if (MyThisUndo.Count > 0)
            {
                switch (MyThisUndo.ElementAt(MyThisUndo.Count - 1).Id)
                {
                    case 1:
                        PlayerOneScore = MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        PlayerOne.Text = PlayerOneScore.ToString();// MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl.ToString();
                       
                        if (CheckWin(PlayerOneScore)) { PlayerOne.IsEnabled = true; }
                        break;
                    case 2:
                        PlayerTwoScore = MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        PlayerTwo.Text = PlayerTwoScore.ToString();
                        if (CheckWin(PlayerTwoScore)) { PlayerTwo.IsEnabled = true; }

                        break;
                    case 3:
                        satzA=MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        Satz.Text = satzA.ToString() + ":" + satzB.ToString();
                      //  PlayerOne.Text= MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl.ToString();
                        break;
                    case 4:
                        satzB = MyThisUndo.ElementAt(MyThisUndo.Count - 1).Zahl;
                        Satz.Text = satzA.ToString() + ":" + satzB.ToString();
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

        private void NewGame_Clicked(object sender, EventArgs e)
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            satzA = 0;
            satzB = 0;
            Satz.Text = satzA.ToString() + ":" + satzB.ToString();
            PlayerOne.Text = PlayerOneScore.ToString();
            PlayerTwo.Text = PlayerTwoScore.ToString();
            MyThisUndo.Clear();

        }

        public bool CheckWin(int a)
        {
            if (a < PlayerWeite)
                return true;
            else return false;
        }
    }
}