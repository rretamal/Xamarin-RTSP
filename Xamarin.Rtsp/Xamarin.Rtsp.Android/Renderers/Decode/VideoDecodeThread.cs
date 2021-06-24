using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.Rtsp.Droid.Renderers.Decode
{
    public class VideoDecodeThread : Java.Lang.Thread
    {
        Surface _surface;
        string _mimeType; 
        int _width; 
        int _height;
        FrameQueue _queue;

        public VideoDecodeThread(Surface surface,
            string mimeType, int width, int height, FrameQueue queue)
        {
            _surface = surface;
            _mimeType = mimeType;
            _width = width;
            _height = height;
            _queue = queue;
        }

        public override void Run()
        {
            base.Run();

            var decoder = MediaCodec.CreateDecoderByType(_mimeType);
            var format = MediaFormat.CreateVideoFormat(_mimeType, _width, _height);

            decoder.Configure(format, _surface, null, 0);
            decoder.Start();

            var bufferInfo = new MediaCodec.BufferInfo();

            while (!Interrupted()) {
                var inIndex = decoder.DequeueInputBuffer(10000L);

                if (inIndex >= 0)
                {
                    var byteBuffer = decoder.GetInputBuffer(inIndex);
                    byteBuffer.Rewind();

                    Frame frame = null;

                    try {
                        frame = _queue.Pop();

                        if (frame != null)
                        {
                            byteBuffer.Put(frame.Data, frame.Offset, frame.Lenght);
                            decoder.QueueInputBuffer(inIndex, frame.Offset, frame.Lenght, frame.Timestamp, 0);
                        }
                    }
                    catch (Exception ex)
                    { }
                }

                try
                {
                    var outIndex = decoder.DequeueOutputBuffer(bufferInfo, 10000);
                    
                    switch ((MediaCodecInfoState)outIndex)
                    {

                        case MediaCodecInfoState.OutputBuffersChanged:
                            break;
                        case MediaCodecInfoState.TryAgainLater:
                            break;
                        default:
                            if (outIndex >= 0)
                            {
                                decoder.ReleaseOutputBuffer(outIndex, bufferInfo.Size != 0);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                { 
                }
            }

            decoder.Stop();
            decoder.Release();
            _queue.Clear();
        }
    }
}