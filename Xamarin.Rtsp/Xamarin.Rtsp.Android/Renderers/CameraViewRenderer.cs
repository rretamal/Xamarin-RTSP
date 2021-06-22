using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Rtsp.Droid.Renderers;
using Xamarin.Rtsp.Renderers;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]
namespace Xamarin.Rtsp.Droid.Renderers
{
    public class CameraViewRenderer : ViewRenderer<CameraView, CustomView>
    {
        CustomView mSurfaceView;
        Context _context;

        public CameraViewRenderer(Context context) : base(context)
        {
            _context = context; 
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                mSurfaceView = new CustomView(_context) {
                    LayoutParameters =
                               new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
                };

                base.SetNativeControl(mSurfaceView);

                var rtspClient = DependencyService.Get<IRtspClient>();
                rtspClient.StartStreaming(mSurfaceView);
            }
        }
    }
}