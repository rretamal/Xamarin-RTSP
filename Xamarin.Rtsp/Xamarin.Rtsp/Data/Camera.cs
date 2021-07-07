using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Rtsp.Data
{
    public class Camera
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool VideoEnable { get; set; }
        public bool AudioEnable { get; set; }
    }
}
