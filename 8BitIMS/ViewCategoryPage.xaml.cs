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

            command.CommandText = "SELECT id FROM platforms WHERE name = '" + tableName + "'";
            platID = (int)command.ExecuteScalar();

            Label gameColLabel = new Label();
            Label qty = new Label();
            Label price = new Label();

            gameColLabel.Content = "Game Title";
            qty.Content = "Qty.";
            price.Content = "Price";

            gameColLabel.FontWeight = FontWeights.ExtraBold;
            qty.FontWeight = FontWeights.ExtraBold;
            price.FontWeight = FontWeights.ExtraBold;

            GameColumn.Children.Add(gameColLabel);
            Qty.Children.Add(qty);
            Price.Children.Add(price);

            command.CommandText = "SELECT g.name, m.quantity FROM games g INNER JOIN ("
               + " SELECT game_id, quantity FROM multiplat_games WHERE platform_id = ("
               + " SELECT id FROM platforms WHERE name = '" + tableName + "'"
               + "))m O"
               + "N g.id = m.game_id;";




            SQLiteDataReader sdr = command.ExecuteReader();
            int fieldcount = 0;
            while (sdr.Read())
            {
                Label gameLabel = new Label();
                Label quantity = new Label();
                gameLabel.Content = sdr.GetString(0);

                quantity.Content = sdr.GetInt32(1);



                GameColumn.Children.Add(gameLabel);
                Qty.Children.Add(quantity);

                fieldcount++;
            }

            addCartButton = new Button[fieldcount];
            Button emptyButton = new Button();
            emptyButton.Visibility = Visibility.Hidden;
            AddToCart.Children.Add(emptyButton);

            for (int i = 0; i < addCartButton.Length; i++)
            {
                addCartButton[i] = new Button();
                addCartButton[i].Content = "Add To Cart";
                addCartButton[i].Margin = new Thickness(0, 5, 0, 3);
                AddToCart.Children.Add(addCartButton[i]);
            }


            conn.Close();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("POSMainPage.xaml", UriKind.Relative));
        }
    }

}
