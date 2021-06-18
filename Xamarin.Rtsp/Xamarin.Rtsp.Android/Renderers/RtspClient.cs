using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Alexvas.Rtsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Rtsp.Renderers;

[assembly: Dependency(typeof(RtspClient))]
namespace Xamarin.Rtsp.Droid.Renderers
{
    public class RtspClient : IRtspClient
    {
        Com.Alexvas.Rtsp.RtspClient localClient;

        public bool StartStreaming()
        {
            // Java.Net.Socket rtspSocket
            // string uriRtsp
            // Java.Util.Concurrent.Atomic.AtomicBoolean rtspStopped
            // Com.Alexvas.Rtsp.RtspClient.IRtspClientListener
            // localClient = Com.Alexvas.Rtsp.RtspClient.Builder();

            return false;
        }
    }
}