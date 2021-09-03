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
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Rtsp.Droid.Renderers;
using Xamarin.Rtsp.Renderers;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]
namespace Xamarin.Rtsp.Droid.Renderers
{
    public class CameraViewRenderer : ViewRenderer<CameraView, SurfaceView>, ISurfaceHolderCallback
    {
        SurfaceView currentView;
        Surface surface;
        int width;
        int height;
        Context _context;
        RtspClient rtspClient;

        public CameraViewRenderer(Context context) : base(context)
        {
            _context = context; 
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                currentView = new SurfaceView(_context) {
                    LayoutParameters =
                               new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
                };
                currentView.Holder.AddCallback(this);

                base.SetNativeControl(currentView);

                rtspClient = new RtspClient();//DependencyService.Get<IRtspClient>();

                if (e.NewElement != null)
                {
                    rtspClient.Url = e.NewElement.Url ?? "";
                    rtspClient.Username = e.NewElement.User ?? "";
                    rtspClient.Password = e.NewElement.Password ?? "";
                }
                //rtspClient.StartStreaming(mSurfaceView);
            }
        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
            
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            if (rtspClient != null)
            {
                Task.Run(async () =>
                {
                    rtspClient.StartStreaming(currentView);
                });
            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
        }
    }
}