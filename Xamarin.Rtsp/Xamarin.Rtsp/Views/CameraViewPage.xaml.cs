using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Rtsp.Models;

namespace Xamarin.Rtsp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraViewPage : ContentPage
    {
        public CameraViewPage(CameraEntry camera)
        {
            InitializeComponent();

            cameraView.Url = camera.Url;
            cameraView.User = camera.Username;
            cameraView.Password = camera.Password;
        }
    }
}