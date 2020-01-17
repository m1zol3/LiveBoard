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
                                      "Ligaspiele 8/9/10 Ball (Testversion)")
/*
                new PageDataViewModel(typeof(MyView), "8/9/10 Ball",
                                      "Interact with a Slider and Button"),
                new PageDataViewModel(typeof(Neunball), "Neunball",
                                      "Interact with a Slider and Button"),
                new PageDataViewModel(typeof(Straightpool), "14/1 Zettel",
                                       "Bis jetzt erstmal eine Testversion")
*/

            };
        }

        public static IList<PageDataViewModel> All { private set; get; }
    }
}
