﻿
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void POS(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("POSMainPage.xaml", UriKind.Relative));
        }
        
        private void IMS(object sender, RoutedEventArgs e)

        {
            this.NavigationService.Navigate(new Uri("IMSMainPage.xaml", UriKind.Relative));
        }
        private void Report(object sender, RoutedEventArgs e)

        {
            this.NavigationService.Navigate(new Uri("SummaryReports.xaml", UriKind.Relative));
        }
        private void Update(object sender, RoutedEventArgs e)

        {
            DatabaseUpdate db = new DatabaseUpdate();
        }
    }
}