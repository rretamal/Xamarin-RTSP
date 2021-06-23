using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Rtsp.Renderers;
using Xamarin.Rtsp.Views;

namespace Xamarin.Rtsp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Preferences.Get("cameraUrl", "") != "")
            {
                var cameraUrl = Preferences.Get("cameraUrl", "");
                var cameraPort = Preferences.Get("cameraPort", "");
                var cameraUser = Preferences.Get("cameraUser", "");
                var cameraPwd = Preferences.Get("cameraPassword", "");
                var cameraVideo = Preferences.Get("cameraVideo", "");
                var cameraAudio = Preferences.Get("cameraAudio", "");

                
            }

            //var t = Task.Run(() => {
            //    rtspClient.StartStreaming();
            //});
            
        }

        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCameraPage());
        }

    }
}
