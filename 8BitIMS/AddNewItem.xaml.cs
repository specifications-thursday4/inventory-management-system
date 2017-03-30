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

using System.Data.SQLite;
using System.Text;

namespace _8BitIMS
{
    /// <summary>
    /// Interaction logic for AddNewItem.xaml
    /// TODO(ANYONE): We need to figure out a way to fix the textbox location for adding games, and also minor UI Fixes. 
    /// Also, we have an issue that we can solve 1 of two ways: 1, if he adds a custom game or console, we have an issue of id numbers, 
    /// which we could generate but how can we ensure its not the same ID number that is already in the database? We could
    /// alter the database currently and just not pull the ID's for IGDB and then just set the ID numbers to autoincrement when we 
    /// add them into the database which is the easier way or we could alter and make a formula that ensures a larger number or smaller
    /// number than we currently have in the database and do it that way....
    /// 
    /// </summary>
    public partial class AddNewItem : Page
    {
        private static string DATABASE = "Data Source = inventory.db";
        private Label TypeAdded = new Label();
        private Label Name = new Label();
        private Label Quantity = new Label();
        private Label Price = new Label();
        private TextBox Info3 = new TextBox();
        private TextBox Info2 = new TextBox();
        private TextBox Info1 = new TextBox();
        private Button Confirm = new Button();
        private Button Cancel = new Button();
        private Label console = new Label();
        private TextBox consoleText = new TextBox();

        public AddNewItem()
        {
            InitializeComponent();
            DisplayAddInformation(QuickAdd.typeToAddToInventory);
        }

        private void DisplayAddInformation(string type)
        {
            

            Screen.Children.Add(console);
            Screen.Children.Add(consoleText);

            Screen.Children.Add(TypeAdded);
            Screen.Children.Add(Name);
            Screen.Children.Add(Quantity);
            Screen.Children.Add(Price);
            Screen.Children.Add(Info3);
            Screen.Children.Add(Info2);
            Screen.Children.Add(Info1);
            Screen.Children.Add(Confirm);
            Screen.Children.Add(Cancel);

            if (type.Equals("Console")) {
                Screen.Children.Remove(console);
                Screen.Children.Remove(consoleText);
                TypeAdded.Content = "Enter Console Information";
                TypeAdded.FontSize = 25;
                TypeAdded.Margin = new Thickness(165, 55, 140, 445);

                Name.Content = "Name of Console";
                Name.Margin = new Thickness(185, 130, 320, 385);

                Quantity.Content = "Amount";
                Quantity.Margin = new Thickness(230, 160, 320, 345);

                Price.Content = "Price";
                Price.Margin = new Thickness(245, 190, 350, 320);

                Info3.Height = 25;
                Info3.Width = 100;
                Info3.Margin = new Thickness(325, 190, 180, 325);

                Info2.Height = 25;
                Info2.Width = 100;
                Info2.Margin = new Thickness(325, 160, 180, 355);

                Info1.Height = 25;
                Info1.Width = 100;
                Info1.Margin = new Thickness(325, 130, 180, 385);

                Confirm.Content = "Confirm";
                Cancel.Content = "Cancel";

                Confirm.Height = 25;
                Confirm.Width = 75;
                Confirm.Margin = new Thickness(195, 280, 370, 235);

                Cancel.Height = 25;
                Cancel.Width = 75;
                Cancel.Margin = new Thickness(385, 280, 180, 235);

              

            }
            else if (type.Equals("Games"))
            {
                

                TypeAdded.Content = "Enter Game Information";
                TypeAdded.FontSize = 25;
                TypeAdded.Margin = new Thickness(185, 55, 120, 445);

                Name.Content = "Name of Game";
                Name.Margin = new Thickness(185, 127, 320, 385);

                Quantity.Content = "Amount";
                Quantity.Margin = new Thickness(230, 160, 320, 345);

                Price.Content = "Price";
                Price.Margin = new Thickness(245, 190, 350, 320);

                console.Content = "Name of Console(s)";
                console.Margin = new Thickness(170, 220, 350, 290);

                

                Info3.Height = 25;
                Info3.Width = 100;
                Info3.Margin = new Thickness(325, 190, 180, 325);

                Info2.Height = 25;
                Info2.Width = 100;
                Info2.Margin = new Thickness(325, 160, 180, 355);

                Info1.Height = 25;
                Info1.Width = 100;
                Info1.Margin = new Thickness(325, 130, 180, 385);

                consoleText.Height = 25;
                consoleText.Width = 100;
                console.Margin = new Thickness(325, 220, 180, 295);

                Confirm.Content = "Confirm";
                Cancel.Content = "Cancel";

                Confirm.Height = 25;
                Confirm.Width = 75;
                Confirm.Margin = new Thickness(195, 280, 370, 235);

                Cancel.Height = 25;
                Cancel.Width = 75;
                Cancel.Margin = new Thickness(385, 280, 180, 235);

            }
        }

        private void ParseEntry()
        {
            SQLiteConnection conn = new SQLiteConnection(DATABASE);
            conn.Open();
            string name;
            string quantity;
            string id;

            
        }
    }
}
