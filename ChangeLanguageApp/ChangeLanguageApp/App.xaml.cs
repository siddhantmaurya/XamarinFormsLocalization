using ChangeLanguageApp.MyResources;
using System;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChangeLanguageApp
{
    public partial class App : Application
    {
        public App()
        {
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            InitializeComponent();

            MainPage = new MainPage();
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
