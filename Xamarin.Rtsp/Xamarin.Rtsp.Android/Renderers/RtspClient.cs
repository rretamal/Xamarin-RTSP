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
using Xamarin.Forms;
using Xamarin.Rtsp.Droid.Core;
using Xamarin.Rtsp.Renderers;

[assembly: Dependency(typeof(RtspClient))]
namespace Xamarin.Rtsp.Droid.Renderers
{
    public class RtspClient : IRtspClient
    {
        Com.Alexvas.Rtsp.RtspClient localClient;

        public bool StartStreaming()
        {
            var socket = NetUtils.CreateSocketAndConnect("rtsp://192.168.1.51", 554, 5000);
            string uri = "rtsp://192.168.1.51";
            int port = 554;
            Java.Util.Concurrent.Atomic.AtomicBoolean rtspStopped = new Java.Util.Concurrent.Atomic.AtomicBoolean(true);

            localClient = new Com.Alexvas.Rtsp.RtspClient.Builder(socket, uri, rtspStopped, null)
                .RequestVideo(true).RequestAudio(false).WithDebug(true).WithCredentials("admin", "ksec2021").Build();
            localClient.Execute();

            //NetUtils.CloseSocket(socket);

            return false;
        }
    }

    public class MyListener : Java.Lang.Object, Com.Alexvas.Rtsp.RtspClient.IRtspClientListener
    {
        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public void Disposed()
        {
        }

        public void DisposeUnlessReferenced()
        {
        }

        public void Finalized()
        {
        }

        public void OnRtspAudioSampleReceived(byte[] data, int offset, int length, long timestamp)
        {
        }

        public void OnRtspConnected(Com.Alexvas.Rtsp.RtspClient.SdpInfo sdpInfo)
        {
        }

        public void OnRtspConnecting()
        {
        }

        public void OnRtspDisconnected()
        {
        }

        public void OnRtspFailed(string message)
        {
        }

        public void OnRtspFailedUnauthorized()
        {
        }

        public void OnRtspVideoNalUnitReceived(byte[] data, int offset, int length, long timestamp)
        {
        }

        public void SetJniIdentityHashCode(int value)
        {
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
        }

        public void SetPeerReference(JniObjectReference reference)
        {
        }

        public void UnregisterFromRuntime()
        {
        }
    }
}