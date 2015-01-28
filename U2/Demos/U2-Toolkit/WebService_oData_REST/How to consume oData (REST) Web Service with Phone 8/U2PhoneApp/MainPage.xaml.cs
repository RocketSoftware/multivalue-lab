using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using U2PhoneApp.Resources;
using System.Windows.Data;
using System.IO;
using System.Windows.Media.Imaging;

namespace U2PhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btn_EDM_Click(object sender, RoutedEventArgs e)
        {
            Uri lSource = new Uri("/EDM_Details_Page.xaml", UriKind.Relative);
            this.NavigationService.Navigate(lSource);

        }

        private void btn_CF_Click(object sender, RoutedEventArgs e)
        {
            Uri lSource = new Uri("/EDM_Details_Page.xaml", UriKind.Relative);
            this.NavigationService.Navigate(lSource);

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }

    public class ImageConverter : IValueConverter
    {

        #region IValueConverter Members

        //Called when binding from an object property to a control property
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                MemoryStream memory = new MemoryStream(System.Convert.FromBase64String((string)value));
                BitmapImage l = new BitmapImage();
                l.SetSource(memory);
                return l;
            }
            return null;

        }

        //Called with two-way data binding as value is pulled out of control and put back into the property
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;

        }

        #endregion
    }
}