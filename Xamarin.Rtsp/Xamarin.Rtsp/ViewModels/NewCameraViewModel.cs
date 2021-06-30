using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Rtsp.Services;

namespace Xamarin.Rtsp.ViewModels
{
    public class NewCameraViewModel : BaseValidationViewModel
    {
        string _url;

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        string _user;

        public string User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        bool _enableVideo;

        public bool EnableVideo
        {
            get => _enableVideo;
            set
            {
                _enableVideo = value;
                OnPropertyChanged();
            }
        }

        bool _enableAudio;

        public bool EnableAudio
        {
            get => _enableAudio;
            set
            {
                _enableAudio = value;
                OnPropertyChanged();
            }
        }

        Command _saveCommand;

        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(async () => await Save(), CanSave));

        async Task Save()
        {
            //var newItem = new TripLogEntry
            //{
            //    Title = Title,
            //    Latitude = Latitude,
            //    Longitude = Longitude,
            //    Date = Date,
            //    Rating = Rating,
            //    Notes = Notes
            //};

            await NavService.GoBack();
        }

        bool CanSave() => !string.IsNullOrWhiteSpace(Url) && !HasErrors;

        public NewCameraViewModel(INavService navService) : base(navService)
        {
        }

        public override void Init()
        {
            base.Init();

            
        }
    }
}
