using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _8BitIMS
{
    /// <summary>
    /// Interaction logic for POSMainPage.xaml
    /// </summary>
    public partial class POSMainPage : Page
    {

        public POSMainPage()
        {
            InitializeComponent();
        }

        private void ClickViewCart(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ViewCartPage.xaml", UriKind.Relative));
        }

        private void ClickCategory(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            MainWindow.tableNameFromButtonClickedInPage = (String)btnClicked.Content;

            this.NavigationService.Navigate(new Uri("ViewCategoryPage.xaml", UriKind.Relative));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }
    }
}
