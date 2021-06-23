using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Rtsp.Renderers;

namespace Xamarin.Rtsp.Droid.Renderers
{
    public class CustomView : SurfaceView, ICustomView
    {
        public CustomView(Context context) : base(context)
        {
            this.SetLayerType(LayerType.Software, null);


        }
    }
}