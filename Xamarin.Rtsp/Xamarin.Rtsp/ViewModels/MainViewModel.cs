using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Rtsp.Data;
using Xamarin.Rtsp.Models;
using Xamarin.Rtsp.Services;

namespace Xamarin.Rtsp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ObservableCollection<CameraEntry> _cameraEntries;

        public ObservableCollection<CameraEntry> CameraEntries
        {
            get => _cameraEntries;
            set
            {
                _cameraEntries = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavService navService) : base(navService)
        {
            CameraEntries = new ObservableCollection<CameraEntry>();
        }

        public async override void Init()
        {
            base.Init();

            CameraEntries.Clear();

            var cameras = await App.Database.GetItemsAsync<Camera>();

            foreach (var cam in cameras)
            {
                CameraEntries.Add(new CameraEntry
                {
                    Name = cam.Name,
                    Url = cam.Url,
                    Username = cam.Username,
                    Password = cam.Password,
                    AudioEnable = cam.AudioEnable,
                    VideoEnable = cam.VideoEnable
                });
            }
        }

    }
}
