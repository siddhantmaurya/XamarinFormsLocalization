using ChangeLanguageApp.Models;
using ChangeLanguageApp.MyResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace ChangeLanguageApp.ViewModel
{
  public  class MainPageViewModel : BindableObject
    {


        private ObservableCollection<MyLanguage> supportedLanguages;
        public ObservableCollection<MyLanguage> SupportedLanguages
        {
            get
            {
                return supportedLanguages;
            }
            set
            {
                supportedLanguages = value;
                OnPropertyChanged();
            }
        }
        private MyLanguage selectedLanguage;
        public MyLanguage SelectedLanguage
        {
            get
            {
                return selectedLanguage;
            }
            set
            {
                selectedLanguage = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangeLanguageCommand { get; }
        public MainPageViewModel()
        {
            ChangeLanguageCommand = new Command(PerformOperation);
            SupportedLanguages = new ObservableCollection<MyLanguage>()
            {
                new MyLanguage{Name=AppResources.English,CI ="en"},
                new MyLanguage{Name=AppResources.Spanish,CI ="es"},
                new MyLanguage{Name=AppResources.French, CI ="fr"},
            };

            SelectedLanguage = SupportedLanguages.FirstOrDefault(pro => pro.CI == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
        }

        private void PerformOperation(object obj)
        {
            // Get all the cultures 
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture |
                                                          CultureTypes.SpecificCultures);

            // get the phone's culture
            var getlanguage = System.Globalization.CultureInfo.CurrentUICulture.Name;

            LocalizationResourceManager.Current.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));

        }
    }
}
