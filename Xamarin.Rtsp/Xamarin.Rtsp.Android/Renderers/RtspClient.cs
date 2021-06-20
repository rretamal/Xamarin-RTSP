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
    public class RtspClient : IRtspClient
    {
        Com.Alexvas.Rtsp.RtspClient localClient;

        public async Task<bool> StartStreaming()
        {
            try
            {
                var socket = await NetUtils.CreateSocketAndConnect("192.168.1.51", 554, 5000);
                string uri = "rtsp://192.168.1.51:554/11";
                int port = 554;
                Java.Util.Concurrent.Atomic.AtomicBoolean rtspStopped = new Java.Util.Concurrent.Atomic.AtomicBoolean(false);
                var listener = new RtspListener();

                localClient = new Com.Alexvas.Rtsp.RtspClient.Builder(socket, uri, rtspStopped, listener)
                    .RequestVideo(true).RequestAudio(false).WithDebug(true).WithCredentials("admin", "ksec2021").Build();
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