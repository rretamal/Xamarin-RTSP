using Xamarin.Forms;

namespace Xamarin.Rtsp.Renderers
{
    public class CameraView : View
    {
        public string Url { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public CameraView()
        { 
        }
    }
}
