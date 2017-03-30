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

namespace _8BitIMS
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        private static string DATABASE = "Data Source = inventory.db";
        private TextBox[] countBox;
        private int platID;
        public InventoryPage()
        {
            InitializeComponent();
            InventoryFieldGeneration(MainWindow.tableNameFromButtonClickedInPage);
        }

        private void InventoryFieldGeneration(string tableName)
        {
            SQLiteConnection conn = new SQLiteConnection(DATABASE);
            conn.Open();
            var command = conn.CreateCommand();

            command.CommandText = "SELECT id FROM platforms WHERE name = '" + tableName + "'";
            platID = (int)command.ExecuteScalar();

            Label gameColLabel = new Label();
            Label count = new Label();
            Label qty = new Label();

            gameColLabel.Content = "Game Title";
            count.Content = "Count";
            qty.Content = "Qty.";

            gameColLabel.FontWeight = FontWeights.ExtraBold;
            count.FontWeight = FontWeights.ExtraBold;
            qty.FontWeight = FontWeights.ExtraBold;

            GameColumn.Children.Add(gameColLabel);
            Count.Children.Add(count);
            Qty.Children.Add(qty);

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

            countBox = new TextBox[fieldcount];

            for (int i = 0; i < countBox.Length; i++)
            {
                countBox[i] = new TextBox();
                countBox[i].Margin = new Thickness(0, 5, 0, 3);
                Count.Children.Add(countBox[i]);
            }

            
            conn.Close();
        }

        private void UpdateInventory()
        {
            SQLiteConnection conn = new SQLiteConnection(DATABASE);
            conn.Open();
            var command = conn.CreateCommand();

            IEnumerable<Label> indexedLabels = GameColumn.Children.Cast<Label>();
            Label[] labels = indexedLabels.ToArray<Label>();
            

            for (int i = 0, j = 1; i < countBox.Length; i++, j++)
            {
                if (countBox[i].Text != null)
                {
                    int result;
                    Int32.TryParse(countBox[i].Text, out result);
                    if (result != 0)
                    {
                        command.CommandText = "UPDATE multiplat_games"
                            + " SET quantity = quantity + " + result
                            + " WHERE game_id = ("
                            + " SELECT id FROM games WHERE name = '" + labels[j].Content.ToString().Replace("'","''") + "'"
                            + ") AND platform_id = " + platID + ";";
                        command.ExecuteNonQuery();
                    }
                }
                
            }
            RefreshPage();
            
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("UpdateInventory.xaml", UriKind.Relative));
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            UpdateInventory();
        }

        private void RefreshPage()
        {
            GameColumn.Children.Clear();
            Qty.Children.Clear();
            Count.Children.Clear();
            InventoryFieldGeneration(MainWindow.tableNameFromButtonClickedInPage);
        }

       

        
    }
}
