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
using Java.Util.Concurrent;

namespace Xamarin.Rtsp.Droid.Renderers
{
    public class FrameQueue 
    {
        string TAG = "";
        Java.Util.Concurrent.IBlockingQueue queue = new ArrayBlockingQueue(60);

        public bool Push(Frame frame)
        {
            if (queue.Offer(frame, 5, TimeUnit.Milliseconds))
            {
                return true;
            }

            return false;
        }

        public Frame Pop()
        {
            try
            {
                var frame = queue.Poll(1000, TimeUnit.Milliseconds);

                if (frame == null)
                    return null;

                return (Frame)frame;
            }
            catch (Exception ex)
            { 
            }

            return null;
        }

        public void Clear()
        {
            queue.Clear();
        }
    }

    public class Frame : Java.Lang.Object {
        public Byte[] Data { get; set; }
        public int Offset { get; set; }
        public int Lenght { get; set; }
        public long Timestamp { get; set; }
    }
}