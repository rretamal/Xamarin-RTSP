using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Rtsp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCameraPage : ContentPage
    {
        public NewCameraPage()
        {
            InitializeComponent();
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("cameraUrl", cameraUrl.Text);
            Preferences.Set("cameraPort", cameraPort.Text);
            Preferences.Set("cameraUser", cameraUser.Text);
            Preferences.Set("cameraPassword", cameraPassword.Text);
            Preferences.Set("cameraVideo", cameraVideo.On);
            Preferences.Set("cameraAudio", cameraAudio.On);

            Navigation.PopAsync();
        }
    }
}