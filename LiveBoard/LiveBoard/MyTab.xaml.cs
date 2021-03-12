using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using TouchTracking;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Linq;
using LiveBoard.TouchTracking;
//using SkiaSharp.Views.Forms;
namespace LiveBoard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTab : ContentPage
    {
        Random _random = new Random();
        SKBitmap monkeyBitmap;
        private List<SKPath> paths = new List<SKPath>();
        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        List<MyLocation> MyLocations = new List<MyLocation> { };   // 1 - Getting current surface 
        List<MyStoringLocation> MyStoringLocations = new List<MyStoringLocation> { };   // 1 - Getting current surface 


        public MyTab()
        {
            Title = "Practice Pool";

            monkeyBitmap = BitmapExtensions.LoadBitmapResource(GetType(),
                "LiveBoard.images.Table.jpg");

            // Create SKCanvasView to view result
           // SKCanvasView canvasView = new SKCanvasView();
           // canvasView.PaintSurface += OnPainting;
          //  Content = canvasView;

            InitializeComponent();
            AddBoxViewToLayout();
          //  PaintSample_Two = canvasView;

        }

        void AddBoxViewToLayout()
        {
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                Color = new Color(_random.NextDouble(),
                                  _random.NextDouble(),
                                  _random.NextDouble())
            };

            TouchEffect touchEffect = new TouchEffect();
            touchEffect.TouchAction +=  OnTouchEffectAction;
            boxView.Effects.Add(touchEffect);
            absoluteLayout.Children.Add(boxView);


         
        }
        Dictionary<BoxView, DragInfo> _dragDictionary = new Dictionary<BoxView, DragInfo>();
        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            BoxView boxView = sender as BoxView;

            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    // Don't allow a second touch on an already touched BoxView
                    if (!_dragDictionary.ContainsKey(boxView))
                    {
                        _dragDictionary.Add(boxView, new DragInfo(args.Id, args.Location));

                        // Set Capture property to true
                        TouchEffect touchEffect = (TouchEffect)boxView.Effects.FirstOrDefault(e => e is TouchEffect);
                        touchEffect.Capture = true;
                    }
                    break;

                case TouchActionType.Moved:
                    if (_dragDictionary.ContainsKey(boxView) && _dragDictionary[boxView].Id == args.Id)
                    {
                        Rectangle rect = AbsoluteLayout.GetLayoutBounds(boxView);
                        Point initialLocation = _dragDictionary[boxView].PressPoint;
                        rect.X += args.Location.X - initialLocation.X;
                        rect.Y += args.Location.Y - initialLocation.Y;
                        AbsoluteLayout.SetLayoutBounds(boxView, rect);
                    }
                    break;

                case TouchActionType.Released:
                    if (_dragDictionary.ContainsKey(boxView) && _dragDictionary[boxView].Id == args.Id)
                    {
                        _dragDictionary.Remove(boxView);
                    }
                    break;
            }
        }
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {

            SKImageInfo info = e.Info;
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.DrawBitmap(monkeyBitmap, info.Rect, BitmapStretch.Uniform);
            

        }
        private void OnPainting_One(object sender, SKPaintSurfaceEventArgs e)
        {

            var surface = e.Surface;
            var canvas = surface.Canvas;

            var stroke = new SKPaint
            {
                Color = SKColors.DarkOrange,
                StrokeWidth = 3,
                Style = SKPaintStyle.Stroke

            };

            canvas.Clear();


            if (MyLocations.Count >1 && MyLocations.Count % 2 == 0)
            {
                var pathStroke = new SKPaint
                {
                    IsAntialias = true,
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Black,
                    StrokeWidth = 3
                };

                // create a path
                var path = new SKPath();
                path.MoveTo(MyStoringLocations.ElementAtOrDefault(MyStoringLocations.Count - 1).AnfangX, MyStoringLocations.ElementAtOrDefault(MyStoringLocations.Count - 1).AnfangY);
                path.LineTo(MyStoringLocations.ElementAtOrDefault(MyStoringLocations.Count - 1).EndeX, MyStoringLocations.ElementAtOrDefault(MyStoringLocations.Count - 1).EndeY);

             

                // draw the path
                canvas.DrawPath(path, pathStroke);
                  
                   
            }
            



            /*    foreach (var touchPath in paths)
                {
                    canvas.DrawPath(touchPath, stroke);

                }*/
            foreach (var touchPath in temporaryPaths)
            {
                canvas.DrawPath(touchPath.Value, stroke);

            }

        }
        private void OnTouch(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    var p = new SKPath();
                    p.MoveTo(e.Location);
                    temporaryPaths[e.Id] = p;
                    MyLocations.Add(new MyLocation() { AnfangX = e.Location.X, AnfangY = e.Location.Y });
                    MyStoringLocations.Add(new MyStoringLocation() { AnfangX = e.Location.X, AnfangY = e.Location.Y });
                    MeinL.Text = "";
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    paths.Add(temporaryPaths[e.Id]);
                    MyLocations.Add(new MyLocation() { AnfangX = e.Location.X, AnfangY = e.Location.Y });
                    MyStoringLocations.ElementAtOrDefault(MyStoringLocations.Count - 1).EndeX = e.Location.X;
                    MyStoringLocations.ElementAtOrDefault(MyStoringLocations.Count - 1).EndeY = e.Location.Y;
                    int j = 0;

                    //  List<MyLocation> MyLocations = new List<MyLocation> { };   // 1 - Getting current surface 

                    foreach (MyStoringLocation aLocation in MyStoringLocations)
                    {
                        MeinL.Text += "\n"+ MyStoringLocations.ToArray().GetValue(j);
                        j++;
                    }
                    temporaryPaths.Remove(e.Id);

                    ((SKCanvasView)sender).InvalidateSurface();
                   
                    break;
            }
            if (e.InContact)
            {
                // we have handled these events
                e.Handled = true;
                ((SKCanvasView)sender).InvalidateSurface();
            }
        }

        private void MyClear_Clicked(object sender, EventArgs e)
        {
          //  MeinL.Text = " " + MyStoringLocations.Count.ToString();
         
        }

        private void AddBox_Clicked(object sender, EventArgs e)
        {
            AddBoxViewToLayout();
        }
    }
}