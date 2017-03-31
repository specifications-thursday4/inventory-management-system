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
using System.Security.Cryptography;

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
        private TextBox priceText = new TextBox();
        private TextBox amount = new TextBox();
        private TextBox itemName = new TextBox();
        private Button Confirm = new Button();
        private Button Cancel = new Button();
        private Label console = new Label();
        private TextBox consoleText = new TextBox();
        private CheckBox inBox = new CheckBox();
        private Label box = new Label();

        private bool resultReturn = true; // if invalid inputs return to screen
        private int screenState = -1; //0 is console add, 1 is game

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
            Screen.Children.Add(priceText);
            Screen.Children.Add(amount);
            Screen.Children.Add(itemName);
            Screen.Children.Add(Confirm);
            Screen.Children.Add(Cancel);
            Screen.Children.Add(box);
            Screen.Children.Add(inBox);
            Cancel.Click += cancelEvent;
            Confirm.Click += confirmEvent;

            if (type.Equals("Console")) {
                screenState = 0;
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

                priceText.Height = 25;
                priceText.Width = 100;
                priceText.Margin = new Thickness(325, 190, 180, 325);

                amount.Height = 25;
                amount.Width = 100;
                amount.Margin = new Thickness(325, 160, 180, 355);

                itemName.Height = 25;
                itemName.Width = 100;
                itemName.Margin = new Thickness(325, 130, 180, 385);

                Confirm.Content = "Confirm";
                Cancel.Content = "Cancel";

                Confirm.Height = 25;
                Confirm.Width = 75;
                Confirm.Margin = new Thickness(195, 280, 370, 235);

                Cancel.Height = 25;
                Cancel.Width = 75;
                Cancel.Margin = new Thickness(385, 280, 180, 235);

                box.Content = "In Box";
                box.Margin = new Thickness(240, 220, 350, 345);

                inBox.Margin = new Thickness(325, 225, 350, 345);
            }
            else if (type.Equals("Games"))
            {
                screenState = 1;

                TypeAdded.Content = "Enter Game Information";
                TypeAdded.FontSize = 25;
                TypeAdded.Margin = new Thickness(185, 55, 120, 445);

                Name.Content = "Name of Game";
                Name.Margin = new Thickness(195, 127, 320, 385);

                Quantity.Content = "Amount";
                Quantity.Margin = new Thickness(230, 160, 320, 345);

                Price.Content = "Price";
                Price.Margin = new Thickness(245, 190, 350, 320);

                console.Content = "Name of Console(s)";
                console.Margin = new Thickness(170, 220, 350, 290);


                priceText.Height = 25;
                priceText.Width = 100;
                priceText.Margin = new Thickness(325, 190, 180, 325);

                amount.Height = 25;
                amount.Width = 100;
                amount.Margin = new Thickness(325, 160, 180, 355);

                itemName.Height = 25;
                itemName.Width = 100;
                itemName.Margin = new Thickness(325, 130, 180, 385);

                consoleText.Height = 25;
                consoleText.Width = 100;
                consoleText.Margin = new Thickness(325, 220, 180, 295);

                Confirm.Content = "Confirm";
                Cancel.Content = "Cancel";

                Confirm.Height = 25;
                Confirm.Width = 75;
                Confirm.Margin = new Thickness(195, 280, 370, 235);

                Cancel.Height = 25;
                Cancel.Width = 75;
                Cancel.Margin = new Thickness(385, 280, 180, 235);

                box.Content = "In Box";
                box.Margin = new Thickness(240, 250, 350, 345);

                inBox.Margin = new Thickness(325, 255, 350, 345);
            }
            else if (type.Equals("Misc"))
            {
                screenState = 2;

                TypeAdded.Content = "Enter Item Information";
                TypeAdded.FontSize = 25;
                TypeAdded.Margin = new Thickness(185, 55, 120, 445);

                Name.Content = "Name of Item";
                Name.Margin = new Thickness(200, 127, 320, 385);

                Quantity.Content = "Amount";
                Quantity.Margin = new Thickness(230, 160, 320, 345);

                Price.Content = "Price";
                Price.Margin = new Thickness(245, 190, 350, 320);

                console.Content = "Name of Console(s)";
                console.Margin = new Thickness(170, 220, 350, 290);


                priceText.Height = 25;
                priceText.Width = 100;
                priceText.Margin = new Thickness(325, 190, 180, 325);

                amount.Height = 25;
                amount.Width = 100;
                amount.Margin = new Thickness(325, 160, 180, 355);

                itemName.Height = 25;
                itemName.Width = 100;
                itemName.Margin = new Thickness(325, 130, 180, 385);

                consoleText.Height = 25;
                consoleText.Width = 100;
                consoleText.Margin = new Thickness(325, 220, 180, 295);

                Confirm.Content = "Confirm";
                Cancel.Content = "Cancel";

                Confirm.Height = 25;
                Confirm.Width = 75;
                Confirm.Margin = new Thickness(195, 280, 370, 235);

                Cancel.Height = 25;
                Cancel.Width = 75;
                Cancel.Margin = new Thickness(385, 280, 180, 235);

                box.Content = "In Box";
                box.Margin = new Thickness(240, 250, 350, 345);

                inBox.Margin = new Thickness(325, 255, 350, 345);
            }
        }

        private void confirmEvent(object sender, RoutedEventArgs e)
        {
            int randomID = RandomGenerator.GetNext();
            SQLiteConnection conn = new SQLiteConnection(DATABASE);
            conn.Open();
            var command = conn.CreateCommand();

            // checks for values and prompts
            if (string.IsNullOrWhiteSpace(itemName.Text))
            {
                MessageBox.Show("Enter an item name please");
                resultReturn = false;
            }
            else if (string.IsNullOrWhiteSpace(amount.Text))
            {
                MessageBox.Show("Enter an amount please");
                resultReturn = false;
            }
            else if (string.IsNullOrWhiteSpace(priceText.Text))
            {
                MessageBox.Show("Enter a price please");
                resultReturn = false;
            }

            if (resultReturn == true)
            {
                if (screenState == 0) // if adding a console
                {


                    int id = randomID;
                    string name = itemName.Text;
                    string quantity = amount.Text;
                    string price = priceText.Text;


                    // need in-box column
                    command.CommandText = "INSERT into platforms (id, name, quantity, price)"
                        + "VALUES(@id,@name,@quant, @price)";

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@quant", quantity);
                    command.Parameters.AddWithValue("@price", price);
                    command.ExecuteReader();
                }
                else if (screenState == 1) // if adding a game
                {
                    int id = randomID;
                    string name = itemName.Text;
                    string quantity = amount.Text;
                    string price = priceText.Text;


                    var resultArr = consoleText.Text.Split(',');
                    long[] plats = { 0 };

                    // if multiple consoles then get their platform ids
                    // to allow for multiplate game updates
                    if (resultArr.Length < 1)
                    {
                        for (var i = 0; i < resultArr.Length; i++)
                        {
                            command.CommandText = "SELECT id from platforms"
                            + "WHERE name =" + resultArr[i];
                            plats[i] = (long)command.ExecuteScalar();
                            Console.WriteLine(command.ExecuteScalar());
                        }

                        //command.CommandText = "Update multiplate_games"
                        //          + "SET quantity = " + quantity;
                    }

                    // How to assign a platform? and need in-box column
                    else // only one result, enter the game
                    {
                        command.CommandText = "INSERT into games " +
                            "(id, name, quantity, price)" +
                            "VALUES(@id,@name,@quant, @price)";

                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@quant", quantity);
                        command.Parameters.AddWithValue("@price", price);
                        command.ExecuteReader();
                    }
                }
                this.NavigationService.Navigate(new Uri("QuickAdd.xaml", UriKind.Relative));
            }
        }

        private void cancelEvent(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("QuickAdd.xaml", UriKind.Relative));
        }
    }
}
