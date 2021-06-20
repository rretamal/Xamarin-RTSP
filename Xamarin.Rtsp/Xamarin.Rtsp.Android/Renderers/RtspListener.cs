﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.Rtsp.Droid.Renderers
{
    public class RtspListener : Java.Lang.Object, Com.Alexvas.Rtsp.RtspClient.IRtspClientListener
    {
        public bool RtspStopped { get; set; }

        private FrameQueue videoFrameQueue = new FrameQueue();
        private FrameQueue audioFrameQueue = new FrameQueue();
        private string videoMimeType = "";
        private string audioMimeType = "";
        private int audioSampleRate = 0;
        private int audioChannelCount = 0;
        private byte[] audioCodecConfig = null;
        //public IntPtr Handle => throw new NotImplementedException();

        //public int JniIdentityHashCode => throw new NotImplementedException();

        //public JniObjectReference PeerReference => throw new NotImplementedException();

        //public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        //public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

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
            if (sdpInfo.VideoTrack != null)
            {
                videoFrameQueue.Clear();

                switch (sdpInfo.VideoTrack.VideoCodec)
                {
                    case Com.Alexvas.Rtsp.RtspClient.VideoCodecH264:
                        videoMimeType = "video/avc";
                        break;
                    case Com.Alexvas.Rtsp.RtspClient.VideoCodecH265:
                        videoMimeType = "video/hevc";
                        break;
                }
                
                switch (sdpInfo.AudioTrack.AudioCodec)
                {
                    case Com.Alexvas.Rtsp.RtspClient.AudioCodecAac:
                        audioMimeType = "audio/mp4a-latm";
                        break;
                }
            }

            var sps = sdpInfo.VideoTrack.Sps;
            var pps = sdpInfo.VideoTrack.Pps;

            if (sps != null && pps != null)
            {
                var data = new byte[sps.Count + pps.Count];
                sps.CopyTo(data, 0);
                pps.CopyTo(data, sps.Count + 1);

                videoFrameQueue.Push(new Frame
                {
                    Data = data,
                    Offset = 0,
                    Lenght = data.Length,
                    Timestamp = 0
                });
            }

            if (sdpInfo.AudioTrack != null)
            {
                audioFrameQueue.Clear();

                switch (sdpInfo.AudioTrack.AudioCodec)
                {
                    case Com.Alexvas.Rtsp.RtspClient.AudioCodecAac:
                        audioMimeType = "audio/mp4a-latm";
                        break;
                }

                audioSampleRate = sdpInfo.AudioTrack.SampleRateHz;
                audioChannelCount = sdpInfo.AudioTrack.Channels;
                audioCodecConfig = sdpInfo.AudioTrack.Config.ToArray();
            }

            onRtspClientConnected();
        }

        public void onRtspClientConnected()
        { }
    
        public void OnRtspConnecting()
        {
        }

        public void OnRtspDisconnected()
        {
            RtspStopped = true;
        }

        public void OnRtspFailed(string message)
        {
            RtspStopped = true;
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