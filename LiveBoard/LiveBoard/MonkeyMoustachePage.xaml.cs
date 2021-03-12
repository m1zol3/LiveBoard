using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Windows.UI.Xaml.Shapes;
using Android.Graphics;

namespace LiveBoard
{
   
    public partial class MonkeyMoustachePage : ContentPage
    {
        SKBitmap monkeyBitmap;
        private List<SKPath> paths = new List<SKPath>();
        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        List<MyLocation> MyLocations = new List<MyLocation> { };
   
        public MonkeyMoustachePage()
        {
             
            Title = "Monkey Moustache";

            monkeyBitmap = BitmapExtensions.LoadBitmapResource(GetType(),
                "LiveBoard.PracticePool.T021.jpg");
 
            // Create SKCanvasView to view result
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
          
            InitializeComponent();
            PaintSample = canvasView;
        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;
            canvas.DrawBitmap(monkeyBitmap, info.Rect, BitmapStretch.Uniform);
            SKPaint stroke = new SKPaint
            {
                Color = SKColors.DarkOrange,
                StrokeWidth = 5,
                Style = SKPaintStyle.Stroke
            };
          
         foreach (var touchPath in paths)
            {
                canvas.DrawPath(touchPath, stroke);
            }
            foreach (var touchPath in temporaryPaths)
            {
                canvas.DrawPath(touchPath.Value, stroke);

            }
            //canvas.DrawPath(touchPath, stroke);
            // canvas.Clear();
        }
        private void PaintSample_Touch(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    var p = new SKPath();
                    p.MoveTo(e.Location);
                    temporaryPaths[e.Id] = p;
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    paths.Add(temporaryPaths[e.Id]);
                    temporaryPaths.Remove(e.Id);
                   // paths.Clear();
                    ((SKCanvasView)sender).InvalidateSurface();
                    break;
            }
            if (e.InContact)
            {
                // we have handled these events
                e.Handled = true;
                // update the UI
                ((SKCanvasView)sender).InvalidateSurface();
            }
        }       
    }
}