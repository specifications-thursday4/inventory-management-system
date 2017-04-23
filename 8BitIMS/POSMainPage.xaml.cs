using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
        List<string> imageKeyList = new List<string>();
        List<string> logoKeyList = new List<string>();

        public POSMainPage()
        {
            InitializeComponent();
            imageKeyList.Add("x");    // resourcekey for the image , which are in the xaml file under windows.resource
            imageKeyList.Add("n");
            imageKeyList.Add("p");
            imageKeyList.Add("w");


            for(int i=1; i <= 12; i++) {
                logoKeyList.Add("logo" + i.ToString());
            }

           

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
        // mouse listener can be implemented in the future 
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void button2_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Canvas_MouseWheel_1(object sender, MouseWheelEventArgs e)
        {    
            if (e.Delta < 0)      // scroll toward user
            {
                logorotateCC();
                if (button3.Content.GetHashCode() == FindResource(imageKeyList[imageKeyList.Count - 1]).GetHashCode())
                {  // if the third button have the last image of the list

                    button3.Content = button2.Content;
                    button2.Content = button1.Content;
                    button1.Content = FindResource(imageKeyList[0]);
                }
                else
                {
                    int index = 0;
                    foreach (String str in imageKeyList)
                    {
                        if (FindResource(str).GetHashCode() == button3.Content.GetHashCode())
                        {
                            index = imageKeyList.IndexOf(str);
                        }
                    }

                    button3.Content = button2.Content;
                    button2.Content = button1.Content;
                    button1.Content = FindResource(imageKeyList[index + 1]);
                }

            }
            else       // scroll away user
            {
                logorotateC();
                if (button1.Content.GetHashCode() == FindResource(imageKeyList[0]).GetHashCode())
                {
                    button1.Content = button2.Content;
                    button2.Content = button3.Content;

                    button3.Content = FindResource(imageKeyList[imageKeyList.Count - 1]);

                }
                else  // button1 doesnt have  first element of the list
                {
                    int i = 0; //index
                    foreach (String str in imageKeyList)
                    {
                        if (FindResource(str).GetHashCode() == button1.Content.GetHashCode())
                        {
                            i = imageKeyList.IndexOf(str);                          // finding index of that image in the list




                        }
                    }
                    button1.Content = button2.Content;
                    button2.Content = button3.Content;
                    button3.Content = FindResource(imageKeyList[i - 1]);


                }
            }


        }

        private void logo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        private void logorotateC()                          //clockwise
        {
            int index = 0;
            foreach(string str in logoKeyList)
            {
                if(logo.Content.GetHashCode() == FindResource(str).GetHashCode())
                {
                    index = logoKeyList.IndexOf(str);
                }
                
            }
            if (index == 11)
            {
                index = 0;
                logo.Content = FindResource(logoKeyList[index ]);
            }
            else
            {
                logo.Content = FindResource(logoKeyList[index +1]);
            }


        }

        private void logorotateCC()                     //counterclockwise
        {
            int index = 0;
            foreach (string str in logoKeyList)
            {
                if (logo.Content.GetHashCode() == FindResource(str).GetHashCode())
                {   
                    index = logoKeyList.IndexOf(str);
                    
                }
                
                
            }
            if (index == 0)
            {
                index = 12;
                logo.Content = FindResource(logoKeyList[index - 1]);
            }
            else
            {
                logo.Content = FindResource(logoKeyList[index - 1]);
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }
    }
}
