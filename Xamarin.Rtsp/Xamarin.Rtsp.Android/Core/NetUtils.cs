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
using System.Threading.Tasks;

namespace Xamarin.Rtsp.Droid.Core
{
    public class NetUtils
    {
        public static async Task<Socket> CreateSocketAndConnect(string name, int port, int timeout)
        {
            var socket = new Socket();
            socket.Connect(new InetSocketAddress(name, port));
            socket.SetSoLinger(false, 1);
            socket.SoTimeout = timeout;

            return socket;
        }

        public static void CloseSocket(Socket socket)
        {
            if (socket != null)
            {
                try {
                    socket.ShutdownInput();
                }
                catch (Exception ex)
                { 
                }

                try
                {
                    socket.ShutdownOutput();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}