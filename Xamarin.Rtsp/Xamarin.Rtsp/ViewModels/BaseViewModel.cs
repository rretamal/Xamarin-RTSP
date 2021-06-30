using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Rtsp.Services;

namespace Xamarin.Rtsp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected INavService NavService { get; private set; }

        protected BaseViewModel(INavService navService)
        {
            NavService = navService;
        }

        public virtual void Init()
        { }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel(INavService navService) : base(navService)
        { }

        public override void Init()
        {
            Init(default(TParameter));
        }

        public virtual void Init(TParameter parameter)
        {
        }
    }
}
