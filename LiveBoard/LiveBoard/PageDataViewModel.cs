using System;
using System.Collections.Generic;
using System.Text;

namespace LiveBoard
{
    public class PageDataViewModel
    {
        public PageDataViewModel(Type type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public Type Type { private set; get; }

        public string Title { private set; get; }

        public string Description { private set; get; }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
            {

                 new PageDataViewModel(typeof(EightNineTen), "Anstoss Spiele",
                                      "Ligaspiele 8/9/10 Ball (Testversion)"),
                 new PageDataViewModel(typeof(ScoreSheet),"Scoring Sheet","Beta Version")
                 ,
                 new PageDataViewModel(typeof(Page1),"Image Button Sheet","Beta Version"),
                  new PageDataViewModel(typeof(MyTab), "Test 1",
                                      "Kartei"),
                   new PageDataViewModel(typeof(MySkiaSharp), "Zeichnen",  "Linie"),

                new PageDataViewModel(typeof(MonkeyMoustachePage), "8/9/10 Ball",
                                      "Interact with a Slider and Button"),
               new PageDataViewModel(typeof(MySets), "Settings",
                                      "Pool Settings Global")  ,
                new PageDataViewModel(typeof(Practice), "Übungen",
                                       "Testversion")
 

            };
        }

        public static IList<PageDataViewModel> All { private set; get; }
    }
}
