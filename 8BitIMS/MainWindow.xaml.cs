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
    /// <summary>SS
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public static string tableNameFromButtonClickedInPage;
        public MainWindow()
        {
            InitializeComponent();
            DatabaseInit db = new DatabaseInit();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void TestQuery()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = inventory.db");
            conn.Open();
            
            conn.Close();
        }

        

       
    }
}
