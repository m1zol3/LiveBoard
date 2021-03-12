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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySkiaSharp : ContentPage
    {
        private List<SKPath> paths = new List<SKPath>();
        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        List<MyLocation> MyLocations = new List<MyLocation> { };
        private SKPoint[,] centerCoordinates;
        private SKPaint singlePaint;
        bool drawMyLine = false;
        
        SKBitmap originalBitmap;
        SKBitmap pixelizedBitmap;
        public MySkiaSharp()
        {
            InitializeComponent();

            
           
        }
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            
            var surface = e.Surface;
            var canvas = surface.Canvas;
           
            var stroke = new SKPaint
            {
                Color = SKColors.DarkOrange,
                StrokeWidth = 5,
                Style = SKPaintStyle.Stroke
                 
            };
           
            
            canvas.Clear();
           

            if (MyLocations.Count > 1)
            {
                var pathStroke = new SKPaint
                {
                    IsAntialias = true,
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Black,
                    StrokeWidth = 5
                };

                // create a path
                var path = new SKPath();
                path.MoveTo(MyLocations.ElementAt(MyLocations.Count - 2).AnfangX, MyLocations.ElementAt(MyLocations.Count -2).AnfangY);
                path.LineTo(MyLocations.ElementAt(MyLocations.Count - 1).AnfangX, MyLocations.ElementAt(MyLocations.Count - 1).AnfangY);


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
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    paths.Add(temporaryPaths[e.Id]);
                    MyLocations.Add(new MyLocation() { AnfangX = e.Location.X, AnfangY = e.Location.Y });
                    MeinL.Text = MyLocations.Count.ToString()+" " + temporaryPaths.Count.ToString();
                    temporaryPaths.Remove(e.Id);
                    ((SKCanvasView)sender).InvalidateSurface();
                    MyLocations.Clear();
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
             
            /*
              completedPaths.Clear();
        inProgressPaths.Clear();
        UpdateBitmap();
        canvasView.InvalidateSurface();    
         */
           //touchPath.Clear();
            paths.Clear();
           // UpdateBitmap();
            PaintSample.InvalidateSurface();
        }
    }
}