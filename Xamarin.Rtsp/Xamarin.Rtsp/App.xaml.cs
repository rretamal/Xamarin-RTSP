using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Rtsp.Data;
using Xamarin.Rtsp.Renderers;
using Xamarin.Rtsp.Services;
using Xamarin.Rtsp.ViewModels;

namespace Xamarin.Rtsp
{
    public partial class App : Application
    {
        static AppDb database;

        public static AppDb Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppDb(DependencyService.Get<IFileHelper>().GetLocalFilePath("AppDb.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainPage());
            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;
            navService.XamarinFormsNav = mainPage.Navigation;

            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));

            MainPage = mainPage;
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
