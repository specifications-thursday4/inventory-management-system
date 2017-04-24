using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Interaction logic for ViewCategoryPage.xaml
    /// </summary>
    public partial class ViewCategoryPage : Page
    {
        private static string DATABASE = "Data Source = inventory.db";
        private Button[] addCartButton;
        private int platID;
        public ViewCategoryPage()
        {
            InitializeComponent();
            POSCategotyFieldGeneration(MainWindow.tableNameFromButtonClickedInPage);
        }

        private void POSCategotyFieldGeneration(string tableName)
        {
            SQLiteConnection conn = new SQLiteConnection(DATABASE);
            conn.Open();
            var command = conn.CreateCommand();
            consoleLabel.Content = tableName;
            command.CommandText = "SELECT id FROM platforms WHERE name = '" + tableName + "'";
            platID = (int)command.ExecuteScalar();
            Random rand = new Random();

            Label gameColLabel = new Label();
            Label count = new Label();
            Label qty = new Label();
            Label priceLabel = new Label();

            BG.Background = Brushes.CornflowerBlue;
            BG2.Background = MainWindow.colourArr[rand.Next() % MainWindow.colourArr.Length];

            gameColLabel.Content = "Game Title";
            count.Content = "Count";
            qty.Content = "Qty.";
            priceLabel.Content = "Price";


            gameColLabel.FontWeight = FontWeights.ExtraBold;
            count.FontWeight = FontWeights.ExtraBold;
            qty.FontWeight = FontWeights.ExtraBold;
            priceLabel.FontWeight = FontWeights.ExtraBold;

            GameColumn.Children.Add(gameColLabel);
            Qty.Children.Add(qty);
            Price.Children.Add(priceLabel);
            //AddToCart.Children.Add(addCartButton);

            command.CommandText = "SELECT g.name, m.quantity, m.price FROM games g INNER JOIN ("
               + " SELECT game_id, quantity, price FROM multiplat_games WHERE platform_id = ("
               + " SELECT id FROM platforms WHERE name = '" + tableName + "'"
               + "))m ON g.id = m.game_id ORDER BY g.name ASC;";

           
            String tmpPrice = "0";
            SQLiteDataReader sdr = command.ExecuteReader();
            int fieldcount = 0;
            while (sdr.Read())
            {
                Label gameLabel = new Label();
                Label quantity = new Label();
                Label price = new Label();

                gameLabel.Content = sdr.GetString(0);      
                quantity.Content = sdr.GetInt32(1);
                
                
                
                GameColumn.Children.Add(gameLabel);
                Qty.Children.Add(quantity);
                
                fieldcount++;
            }


            
            conn.Close();
        }

        private void confirmEvent(object sender, RoutedEventArgs e)
        {
            // add item to cart, how to get id of item clicked?

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("POSMainPage.xaml", UriKind.Relative));
        }

        private void ViewCartClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ViewCartPage.xaml", UriKind.Relative));
        }

    }

}
