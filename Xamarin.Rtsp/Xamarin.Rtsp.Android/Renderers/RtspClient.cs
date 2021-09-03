using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Alexvas.Rtsp;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Rtsp.Droid.Core;
using Xamarin.Rtsp.Renderers;

[assembly: Dependency(typeof(Xamarin.Rtsp.Droid.Renderers.RtspClient))]
namespace Xamarin.Rtsp.Droid.Renderers
{
    public class RtspClient : IRtspClient<SurfaceView>
    {
        Com.Alexvas.Rtsp.RtspClient localClient;
        SurfaceView _surfaceView;

        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public async Task<bool> StartStreaming(SurfaceView surfaceView)
        {
            try
            {
                _surfaceView = surfaceView;

                Uri uri = new Uri(this.Url);

                var socket = await NetUtils.CreateSocketAndConnect(uri.Host, 554, 5000);
                int port = uri.Port;
                Java.Util.Concurrent.Atomic.AtomicBoolean rtspStopped = new Java.Util.Concurrent.Atomic.AtomicBoolean(false);
                var listener = new RtspListener(surfaceView.Holder.Surface, surfaceView.Width, surfaceView.Height);

                localClient = new Com.Alexvas.Rtsp.RtspClient.Builder(socket, this.Url, rtspStopped, listener)
                    .RequestVideo(true).RequestAudio(false).WithDebug(true).WithCredentials(this.Username, this.Password).Build();
                localClient.Execute();

                NetUtils.CloseSocket(socket);
            }
            catch (Exception ex)
            { 
            }
            //NetUtils.CloseSocket(socket);

            return false;
        }
    }
}