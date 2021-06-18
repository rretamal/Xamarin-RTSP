using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.Rtsp.Droid.Core
{
    public class NetUtils
    {
        public static Socket CreateSocketAndConnect(string name, int port, int timeout)
        {
            var socket = new Socket();
            socket.Connect(new InetSocketAddress(name, port));
            socket.SetSoLinger(false, 1);
            socket.SoTimeout = timeout;

            return socket;
        }
    }
}