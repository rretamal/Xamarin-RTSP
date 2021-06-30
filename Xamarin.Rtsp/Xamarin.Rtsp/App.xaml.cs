using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Rtsp.Services;
using Xamarin.Rtsp.ViewModels;

namespace Xamarin.Rtsp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainPage());
            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;
            navService.XamarinFormsNav = mainPage.Navigation;

            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
