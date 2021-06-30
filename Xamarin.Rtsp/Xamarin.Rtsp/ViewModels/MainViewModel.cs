using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Rtsp.Services;

namespace Xamarin.Rtsp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavService navService) : base(navService)
        {
        }

        public override void Init()
        {
            base.Init();
        }
    }
}
